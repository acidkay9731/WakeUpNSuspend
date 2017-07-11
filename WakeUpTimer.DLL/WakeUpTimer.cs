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
                timerMain.Interval = 1000; // 1초
#else
                timerMain.Interval = 1000 * 30; // 30초
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


                wup = new WakeUP();
                bool result = wup.SetWakeUpTime(dtWakeUp);

                System.Threading.Thread.Sleep(1000);

                if (result == false)
                {
                    MessageBox.Show("Error: SetWakeUpTime");
                    return;
                }

                Application.SetSuspendState(PowerState.Suspend, false, false);

#if DEBUG
                dtSleep = dtSleep.AddMinutes(3);
                dtWakeUp = dtWakeUp.AddMinutes(3);
#else
                dtSleep = dtSleep.AddDays(1);
                dtWakeUp = dtWakeUp.AddDays(1);
#endif
            }
            catch (Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(err);
            }
        }

        public void SetTimer(DateTime _dtSleep, DateTime _dtWakeUp)
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
