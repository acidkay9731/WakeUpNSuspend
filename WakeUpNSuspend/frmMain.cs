using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakeUpANDSuspend
{
    public partial class frmMain : Form
    {
        string strStartupPath;
        string strIniFileName;
        bool IsClose = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            strStartupPath = Application.StartupPath;

            strIniFileName = strStartupPath + "\\WakeUpNSuspend.ini";

            SetIniFile();
        }

        private void SetIniFile()
        {
            if (!File.Exists(strIniFileName))
            {
                using (FileStream fs = File.Create(strIniFileName))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("WAKEUP:06:00");
                        sw.WriteLine("SUSPEND:00:00");
                        sw.Dispose();
                        sw.Close();
                    }
                    fs.Dispose();
                    fs.Close();
                }
            }
            else
            {
                using (FileStream fs = File.OpenRead(strIniFileName))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        DateTime dtStart = DateTime.Now;
                        DateTime dtEnd = DateTime.Now;

                        string [] strSplit = sr.ReadLine().Split(':');

                    }
                }
            }
        }

        private void btnSetTimer_Click(object sender, EventArgs e)
        {

        }

        private void timerMain_Tick(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsClose)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;

                this.notifyIconMain.Visible = true;
                notifyIconMain.ContextMenuStrip = contextMenuStripNotify;
            }
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
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
    }
}
