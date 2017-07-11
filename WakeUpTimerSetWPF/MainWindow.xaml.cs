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
                cboSleepHour.Items.Add(i);
                cboWakeUpHour.Items.Add(i);
            }

            cboSleepHour.SelectedIndex = now.Hour;
            cboWakeUpHour.SelectedIndex = now.Hour;

            for (int i = 0; i < 60; i++)
            {
                cboSleepMin.Items.Add(i);
                cboWakeUpMin.Items.Add(i);
            }

            cboSleepMin.SelectedIndex = now.AddMinutes(1).Minute;
            cboWakeUpMin.SelectedIndex = now.AddMinutes(3).Minute;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dtSleep = new DateTime(now.Year, now.Month, now.Day, int.Parse(cboSleepHour.SelectedValue.ToString()), int.Parse(cboSleepMin.SelectedValue.ToString()), 0);
                DateTime dtWakeUp = new DateTime(now.Year, now.Month, now.Day, int.Parse(cboWakeUpHour.SelectedValue.ToString()), int.Parse(cboWakeUpMin.SelectedValue.ToString()), 0);

                btnStart.Content = "STARTED!!!!";

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
