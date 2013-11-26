using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloryView.RFID.Util;
using System.Windows;
using System.Windows.Threading;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.Controls
{
    public class DazzleWindow : Window
    {
        private DispatcherTimer dTimer;
        public DazzleWindow()
        {
            this.DefaultStyleKey = typeof(DazzleWindow);

            //缩放，最大化修复
            WindowBehaviorHelper wh = new WindowBehaviorHelper(this);
            wh.RepairBehavior();
            ExitSystemOntime();
            this.MouseMove += new System.Windows.Input.MouseEventHandler(DazzleWindow_MouseMove);
           
        }

        
        void DazzleWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            dTimer.Stop();
            ExitSystemOntime();
           // MessageBox.Show("........");
        }
        private void ExitSystemOntime()
        {
            
            dTimer = new System.Windows.Threading.DispatcherTimer();
            //设置事件处理函数
            dTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dTimer.Interval = new TimeSpan(0, 0, BaseRequest._ExitSystemTime, 0, 0);
           
            dTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            
        }
        //void DazzleWindow_MouserClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    }
}
