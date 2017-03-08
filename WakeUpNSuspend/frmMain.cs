using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakeUpANDSuspend
{
    public partial class frmMain : Form
    {
        string strStartupPath;
        string strIniFileName;
        bool IsClose = false;
        DateTime dtEnd = DateTime.Now;
        WakeUP wup = new WakeUP();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            HideWindow();

            strStartupPath = Application.StartupPath;

            strIniFileName = strStartupPath + "\\WakeUpNSuspend.ini";

            SetIniFile();
        }

        //private void WakeUP_Woken(object sender, EventArgs e)
        //{
        //    Console.WriteLine(string.Format("Woken: {0}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));
        //}

        private void SetIniFile()
        {
            if (!File.Exists(strIniFileName))
            {
                using (FileStream fs = File.Create(strIniFileName))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("WAKEUP:06:00");
                        sw.WriteLine("SUSPEND:23:59");
                    }
                }
            }

            using (FileStream fs = File.OpenRead(strIniFileName))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    DateTime dtNow = DateTime.Now;
                    DateTime dtStart = dtNow;
                    dtEnd = dtNow;

                    string[] strStartSplit = sr.ReadLine().Split(':');

                    dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day,
                        int.Parse(strStartSplit[1]),
                        int.Parse(strStartSplit[2]),
                        00);

                    nudWakeUpTime.Value = dtStart.Hour;
                    nudWakeUpMin.Value = dtStart.Minute;

                    if (dtStart <= dtNow)
                    {
                        dtStart = dtStart.AddDays(1);
                    }

                    //wup.Woken += WakeUP_Woken;
                    wup.SetWakeUpTime(dtStart);

                    string[] strEndSplit = sr.ReadLine().Split(':');

                    dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day,
                        int.Parse(strEndSplit[1]),
                        int.Parse(strEndSplit[2]),
                        00);

                    nudSuspendTime.Value = dtEnd.Hour;
                    nudSuspendMin.Value = dtEnd.Minute;

                    if (dtEnd <= dtNow)
                    {
                        dtEnd = dtEnd.AddDays(1);
                    }
                }
            }

            timerMain.Start();
        }

        private void btnSetTimer_Click(object sender, EventArgs e)
        {
            try
            {
                timerMain.Stop();

                wup.StopWorkerAsync();

                DateTime dtNow = DateTime.Now;
                DateTime dtStart = dtNow;
                dtEnd = dtNow;

                dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day,
                        (int)nudWakeUpTime.Value,
                        (int)nudWakeUpMin.Value,
                        00);

                if (dtStart <= dtNow)
                {
                    dtStart = dtStart.AddDays(1);
                }

                wup = new WakeUP();
                wup.SetWakeUpTime(dtStart);

                dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day,
                        (int)nudSuspendTime.Value,
                        (int)nudSuspendMin.Value,
                        00);

                if (dtEnd <= dtNow)
                {
                    dtEnd = dtEnd.AddDays(1);
                }

                using (FileStream fs = File.Create(strIniFileName))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("WAKEUP:" + dtStart.Hour + ":" + dtStart.Minute + "");
                        sw.WriteLine("SUSPEND:" + dtEnd.Hour + ":" + dtEnd.Minute + "");
                    }
                }

                timerMain.Start();
            }
            catch(Exception ex)
            {
                string err = ex.Message + "\r\n" + ex.StackTrace;
                MessageBox.Show(err);
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            if(dtEnd.Hour == dt.Hour 
                && dtEnd.Minute == dt.Minute)
            {
                Suspend();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsClose)
            {
                e.Cancel = true;
                HideWindow();
            }
        }

        private void HideWindow()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            this.notifyIconMain.Visible = true;
            notifyIconMain.ContextMenuStrip = contextMenuStripNotify;
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void ShowWindow()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            IsClose = true;
            this.Close();
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            Suspend();
        }

        private void Suspend()
        {
            Application.SetSuspendState(PowerState.Suspend, false, false);
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }
    }
}
