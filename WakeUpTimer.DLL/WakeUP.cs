﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WakeUpTimer
{
    class WakeUP
    {
        [DllImport("kernel32.dll")]
        public static extern SafeWaitHandle CreateWaitableTimer(IntPtr lpTimerAttributes,
                                                                  bool bManualReset,
                                                                string lpTimerName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWaitableTimer(SafeWaitHandle hTimer,
                                                    [In] ref long pDueTime,
                                                              int lPeriod,
                                                           IntPtr pfnCompletionRoutine,
                                                           IntPtr lpArgToCompletionRoutine,
                                                             bool fResume);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelWaitableTimer([In] SafeWaitHandle hTimer);

        public event EventHandler Woken;

        private BackgroundWorker bgWorker;

        SafeWaitHandle handle;
        EventWaitHandle wh;

        public WakeUP()
        {

        }

        public void SetWakeUpTime(DateTime WakeUp)
        {
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.WorkerSupportsCancellation = true;

            bgWorker.RunWorkerAsync(WakeUp.ToFileTime());
        }

        public void StopWorkerAsync()
        {
            CancelWaitableTimer(handle);
            bgWorker.CancelAsync();
            bgWorker.Dispose();
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Woken != null)
            {
                Woken(this, new EventArgs());
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            long waketime = (long)e.Argument;

            handle = CreateWaitableTimer(IntPtr.Zero, true, this.GetType().Assembly.GetName().Name.ToString() + "Timer");

            if (SetWaitableTimer(handle, ref waketime, 0, IntPtr.Zero, IntPtr.Zero, true))
            {
                wh = new EventWaitHandle(false, EventResetMode.AutoReset);
                wh.SafeWaitHandle = handle;
                wh.WaitOne();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}
