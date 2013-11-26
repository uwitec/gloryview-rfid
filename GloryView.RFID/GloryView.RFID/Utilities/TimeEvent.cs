using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using WpfApplication2;
using System.Data;
using MySql.Data.MySqlClient;

namespace GloryView.RFID.Utilities
{
    class TimeEvent
    {
        private  int logId;
       // private MysqlDataDao dao = new MysqlDataDaoImpl();
        public TimeEvent(int logId)
        {
            this.logId = logId;
            
        }
        public  void TimerRun()
        {
            DispatcherTimer dTimer;
            dTimer = new System.Windows.Threading.DispatcherTimer();
            //设置事件处理函数
            dTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, BaseRequest.TIME);
           
            dTimer.Start();
        }
        private  void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           
            string inlineTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss");
            string sql = "update users_log as ul set ul.EXIT_TIME='" + @inlineTime + "' where ul.ID=" + @logId;
            MySqlParameter[] parameters=
            {
                new MySqlParameter("@inlineTime",inlineTime),
                new MySqlParameter("@logId",logId),
             };
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
        }
    }

}
