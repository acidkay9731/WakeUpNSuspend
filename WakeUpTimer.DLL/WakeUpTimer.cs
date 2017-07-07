using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakeUpTimer
{
    public class WakeUpTimer
    {
        private Timer timerMain;
        WakeUP wup = new WakeUP();
        DateTime dtWakeUp;
        DateTime dtSleep;

        public WakeUpTimer()
        {
            try
            {
                timerMain = new Timer();
#if DEBUG
                timerMain.Interval = 1000; // 1분
#else
                timerMain.Interval = 1000 * 60; // 1분
#endif
                timerMain.Tick += TimerMain_Tick;
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;

                if (dtSleep.Hour == dt.Hour
                    && dtSleep.Minute == dt.Minute)
                {
                    Suspend();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }

        private void Suspend()
        {
            try
            {
#if DEBUG
                dtWakeUp = dtWakeUp.AddMinutes(3);
                dtSleep = dtSleep.AddMinutes(3);
#else
                dtWakeUp = dtWakeUp.AddDays(1);
                dtSleep = dtSleep.AddDays(1);
#endif

                wup = new WakeUP();
                wup.SetWakeUpTime(dtWakeUp);

                

                Application.SetSuspendState(PowerState.Suspend, false, false);
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }

        public void SetTimer(DateTime _dtWakeUp, DateTime _dtSleep)
        {
            try
            {
                //timerMain.Stop();

                //wup.StopWorkerAsync();

                dtWakeUp = _dtWakeUp;
                dtSleep = _dtSleep;
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }

        public void Start()
        {
            try
            {
                timerMain.Start();
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }

        public void Stop()
        {
            try
            {
                timerMain.Stop();
                wup = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }
    }
}
