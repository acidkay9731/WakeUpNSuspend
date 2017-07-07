using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WakeUpTimerSetWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime now = DateTime.Now;
        WakeUpTimer.WakeUpTimer wpTimer = new WakeUpTimer.WakeUpTimer();

        public MainWindow()
        {
            InitializeComponent();

            InitControl();
        }

        private void InitControl()
        {
            btnStart.Click += BtnStart_Click;

            for (int i = 0; i < 24; i++)
            {
                cboWakeUpHour.Items.Add(i);
                cboSleepHour.Items.Add(i);
            }

            cboWakeUpHour.SelectedIndex = now.Hour;
            cboSleepHour.SelectedIndex = now.Hour;

            for (int i = 0; i < 60; i++)
            {
                cboWakeUpMin.Items.Add(i);
                cboSleepMin.Items.Add(i);
            }

            cboWakeUpMin.SelectedIndex = now.Minute;
            cboSleepMin.SelectedIndex = now.Minute;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                DateTime dtWakeUp = new DateTime(now.Year, now.Month, now.Day, int.Parse(cboWakeUpHour.SelectedValue.ToString()), int.Parse(cboWakeUpMin.SelectedValue.ToString()), 0);
                DateTime dtSleep = new DateTime(now.Year, now.Month, now.Day, int.Parse(cboSleepHour.SelectedValue.ToString()), int.Parse(cboSleepMin.SelectedValue.ToString()), 0);

                wpTimer.SetTimer(dtSleep, dtWakeUp);

                wpTimer.Start();
            }
            catch(Exception ex)
            {
                string err = ex.Message + "\n\n" + ex.StackTrace;
                MessageBox.Show(err);
            }
        }
    }
}
