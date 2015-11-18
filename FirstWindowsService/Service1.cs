using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FirstWindowsService
{
    public partial class Service1 : ServiceBase
    {
        // tạo 1 biến Timer private
        private Timer timer = null;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            // Tạo 1 timer từ libary System.Timers
            timer = new Timer();
            // Execute mỗi 60s
            timer.Interval = 60000;
            // Những gì xảy ra khi timer đó dc tick
            timer.Elapsed += timer_Tick;
            // Enable timer
            timer.Enabled = true;
            // Ghi vào log file khi services dc start lần đầu tiên
            Utilities.WriteLogError("Test for 1st run WindowsService");
        }

        private void timer_Tick(object sender, ElapsedEventArgs args)
        {
            // Xử lý một vài logic ở đây
            Utilities.WriteLogError("Timer has ticked for doing something!!!");
        }


        protected override void OnStop()
        {
            // Ghi log lại khi Services đã được stop
            timer.Enabled = true;
            Utilities.WriteLogError("1st WindowsService has been stop");
        }
    }
}
