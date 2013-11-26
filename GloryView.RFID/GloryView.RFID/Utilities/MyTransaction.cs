    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    using GloryView.RFID.DeviceMigrations.DeviceClass;
    using System.Data;
    using GloryView.RFID.ReaderAndWriterClass;
    using System.Windows;

    namespace GloryView.RFID.Utilities
    {
    class MyTransaction
    {
        
    /************************************************************************/
    /* 设备信息录入，录入属原子性，要么写如标签和插入数据同时通过，要么就同时失败 .                                                                    */
    /************************************************************************/
    public static int addEquipmentService(DeviceBean bean,Window win)
    {
        ReaderAndWriterConnection _Connection = new ReaderAndWriterConnection();
        MySqlConnection conn = new MySqlConnection(MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
        try
        {
            //读写器连接
            int state = _Connection.Connection();
            //返回写入标签状态（成功/失败）
            int _WState = _Connection.WritertEPC(bean.EPCCode, win);
            
            //如果连接和写入标签成功，则操作数据库存储
            if (state == BaseRequest.SUCCESS&&_WState==BaseRequest.SUCCESS) { 
            string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
            string sql = "INSERT INTO equipment(ID,NUMBER,NAME,DEVICE_CLASS_ID,ROOMS_ID,USER_ID,STORAGE_TIME)" +
                        " VALUES(" + @bean.Id + ",'" + @bean.EPCCode + "','" + @bean.Name + "'," + @bean.Type + "," + 
                        @bean.RoomId + "," + @Session.UserId + ",'" + @date + "')";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@bean.Id",bean.Id),
                new MySqlParameter("@bean.EPCCode",bean.EPCCode),
                new MySqlParameter("@bean.Name",bean.Name),
                new MySqlParameter("@bean.Type",bean.Type),
                new MySqlParameter("@bean.RoomId",bean.RoomId),
                new MySqlParameter("@Session.UserId",Session.UserId),
                new MySqlParameter("@date",date),
                };
            cmd.CommandText = sql;
            if (parameters != null)
            {
                foreach (MySqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            string orderSql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) " +
                                    "VALUES(" + @bean.Id + "," + @BaseRequest.INPUT_STATUS + "," + @Session.UserId + ",'" + @date + "')";
            MySqlParameter[] parametersTow =
            {
                new MySqlParameter("@bean.Id",bean.Id),
                new MySqlParameter("@BaseRequest.REPAIR_STATUS",BaseRequest.INPUT_STATUS),
                new MySqlParameter("@Session.UserId",Session.UserId),
                new MySqlParameter("@date",date),
            };
            cmd.CommandText = orderSql;
            if (parametersTow != null)
            {
                foreach (MySqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            tx.Commit();
            conn.Close();
            return BaseRequest.SUCCESS;
            }
            else
            {
                return BaseRequest.SYSTEM_EXCEPTION;
            }
            }
        catch (Exception e)
        {
            tx.Rollback();
            e.GetBaseException();
            return BaseRequest.SYSTEM_EXCEPTION;
        }
    }
    //申请报修
    public static int addRepair(int id)
    {
        MySqlConnection conn = new MySqlConnection(MySqlHelper.Conn);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        MySqlTransaction tx = conn.BeginTransaction();
        cmd.Transaction = tx;
        try
        {
            string _Date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
            string _UpSql = "UPDATE equipment AS e SET e.WORK_STATUS="+@BaseRequest.REPAIR_STATUS+" WHERE e.ID="+@id;
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@BaseRequest.REPAIR_STATUS",BaseRequest.REMOVE_STATUS),
                new MySqlParameter("@id",id),
                };
            cmd.CommandText = _UpSql;
            if (parameters != null)
            {
                foreach (MySqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            string _InSql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) VALUES(" + @id + "," + @BaseRequest.REPAIR_STATUS + "," + @Session.UserId + ",'" + @_Date + "')";
            MySqlParameter[] _Parameters =
            {
                new MySqlParameter("@id",id),
                new MySqlParameter("@BaseRequest.OUT",BaseRequest.OUT),
                new MySqlParameter("@Session.UserId",Session.UserId),
                new MySqlParameter("@date",_Date),
            };
            cmd.CommandText = _InSql;
            if (_Parameters != null)
            {
                foreach (MySqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            tx.Commit();
            conn.Close();
            return BaseRequest.SUCCESS;

        }
        catch (Exception e)
        {
            tx.Rollback();
            e.GetBaseException();
            return BaseRequest.SYSTEM_EXCEPTION;
        }

    }
    //报警扫描
    public static void insertAlarm()
    {
        MySqlConnection conn = new MySqlConnection(MySqlHelper.Conn);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        MySqlTransaction tx = conn.BeginTransaction();
        cmd.Transaction = tx;
        try
        {
            string inlineTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss");
            string sql = "SELECT a.EQUIPMENT_NUMBER,a.ALARM_TYPE_ID,a.ALARM_TIME,COUNT(*) AS NUM FROM alarm_original AS a " +
                            "GROUP BY a.EQUIPMENT_NUMBER , a.ALARM_TYPE_ID ORDER BY a.ALARM_TIME";
            cmd.CommandText = sql;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            //清除参数
            cmd.Parameters.Clear();
            int count = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            //获取group by后的历史警报信息
                int _Eid = int.Parse(dr["EQUIPMENT_NUMBER"].ToString());
                int _Atype = int.Parse(dr["ALARM_TYPE_ID"].ToString());
                string date = dr["ALARM_TIME"].ToString();
                count += int.Parse(dr["NUM"].ToString());
                    
            //查询警报表是否存在同一条报警信息
                string _SSql = "SELECT a.ALARM_ID FROM alarm AS a WHERE a.EQUIPMENT_ID=" + @_Eid + 
                                " AND a.ALARM_TYPE_ID=" + @_Atype + " AND a.STATUS="+@BaseRequest.ALARM_STATUS;
                MySqlParameter[] parameters=
                {
                    new MySqlParameter("@_Eid",_Eid),
                    new MySqlParameter("@_Atype",_Atype),
                    new MySqlParameter("@BaseRequest.ALARM_STATUS",BaseRequest.ALARM_STATUS),
                };
                cmd.CommandText = _SSql;
                if (parameters != null)
                {
                    foreach (MySqlParameter parm in parameters)
                        cmd.Parameters.Add(parm);
                }

                MySqlDataReader _Reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                    
        //如果有存在同一条报警信息，则更新时间
                if (_Reader.Read())
                {
                    int _AId = int.Parse(_Reader["ALARM_ID"].ToString());
                    string updateSql = "UPDATE alarm AS a SET a.ALARM_TIME='" + @date + "' WHERE a.ALARM_ID=" + @_AId;
                    MySqlParameter[] Uparameters =
                    {
                        new MySqlParameter("@date",date),
                        new MySqlParameter("@_AId",_AId),
                    };
                    cmd.CommandText = updateSql;
                    if (Uparameters != null)
                    {
                        foreach (MySqlParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                    }
                    _Reader.Close();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                        
                }
        //如果没有同一条报警信息，则插入该条报警信息
                else
                {
                    string _InsertSql = "INSERT INTO alarm(EQUIPMENT_ID,ALARM_TYPE_ID,ALARM_TIME) VALUES("+
                            @_Eid + "," + @_Atype + ",'" + @date + "')";
                    MySqlParameter[] Uparameters =
                    {
                        new MySqlParameter("@_Eid",_Eid),
                        new MySqlParameter("@_Atype",_Atype),
                        new MySqlParameter("@date",date),
                    };
                    cmd.CommandText = _InsertSql;
                    if (Uparameters != null)
                    {
                        foreach (MySqlParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                    }
                    _Reader.Close();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                        
                }
                    
            }
            //   System.Windows.MessageBox.Show(count.ToString());
            //一下进行删除
            string _DelectSql = "DELETE FROM alarm_original  LIMIT "+count;
            cmd.CommandText = _DelectSql;
            cmd.ExecuteNonQuery();
            tx.Commit();
            conn.Close();
        }
        catch (Exception e)
        {
            tx.Rollback();
            conn.Close();
            e.GetBaseException();
        }
    }
    //报修设备入库
    public static int repairEquipmentCome(int id)
    {
        MySqlConnection conn = new MySqlConnection(MySqlHelper.Conn);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        MySqlTransaction tx = conn.BeginTransaction();
        cmd.Transaction = tx;
        try
        {
            string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
            string sql = "UPDATE equipment AS e SET e.WORK_STATUS=" + @BaseRequest.INPUT_STATUS + " WHERE e.ID="+@id;
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@BaseRequest.INPUT_STATUS",BaseRequest.INPUT_STATUS),
                    new MySqlParameter("@id",id),
                };
            cmd.CommandText = sql;
            if (parameters != null)
            {
                foreach (MySqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            string InSql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) VALUES("+@id+","+@BaseRequest.INPUT_STATUS+","+
            +@Session.UserId+",'"+@date+"')";
            MySqlParameter[] _Parameters =
                {
                    new MySqlParameter("@id",id),
                    new MySqlParameter("@BaseRequest.INPUT_STATUS",BaseRequest.INPUT_STATUS),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                };
            cmd.CommandText = sql;
            if (_Parameters != null)
            {
                foreach (MySqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            tx.Commit();
            conn.Close();
            return BaseRequest.SUCCESS;
        }
        catch (Exception e)
        {
            tx.Rollback();
            conn.Close();
            e.GetBaseException();
            return BaseRequest.SYSTEM_EXCEPTION;
        }
    }
    //读写器天线录入
    public static int WriterReader(WriterReaderBean bean,Window win)
    {
       ReaderAndWriterConnection _Connection = new ReaderAndWriterConnection();
        MySqlConnection conn = new MySqlConnection(MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
        try
        {
            //读写器连接
            int state = _Connection.Connection();
            int _WState = _Connection.WritertEPC(bean.EpcCode, win);
            if (state == BaseRequest.SUCCESS && _WState == BaseRequest.SUCCESS)
            {
                //把16进制字符串转换成ushout数组
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "INSERT INTO reader_writer(READER_WRITER_ID,NUMBER,NAME,IP,PORT,ANTENNA_SUM,TYPE,SWEEP_TIME,CREATE_USER_ID,CREATE_TIME,ROOM_ID)" +
                            "VALUES(" + @bean.Id + ",'" + @bean.EpcCode + "','" + @bean.Name + "','" + @bean.Ip + "'," + @bean.Port + "," + @bean.AntennaSum + "," + @bean.Type + "," +
                            +@bean.SweepTime + "," + @Session.UserId + ",'" + @date + "'," + @bean.RoomId + ")";
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@bean.Id",bean.Id),
                    new MySqlParameter("@bean.EpcCode",bean.EpcCode),
                    new MySqlParameter("@bean.Name",bean.Name),
                    new MySqlParameter("@bean.Ip",bean.Ip),
                    new MySqlParameter("@bean.Port",bean.Port),
                    new MySqlParameter("@bean.AntennaSum",bean.AntennaSum),
                    new MySqlParameter("@bean.Type",bean.Type),
                    new MySqlParameter("@bean.SweepTime",bean.SweepTime),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                    new MySqlParameter("@bean.RoomId",bean.RoomId),
                };
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (MySqlParameter parm in parameters)
                        cmd.Parameters.Add(parm);
                }

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //string InSql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) VALUES(" + @bean.Id + "," + @BaseRequest.INPUT_STATUS + "," +
                //+@Session.UserId + ",'" + @date + "')";
                //MySqlParameter[] parametersIt =
                //    {
                //        new MySqlParameter("@bean.Id",bean.Id),
                //        new MySqlParameter("@BaseRequest.INPUT_STATUS",BaseRequest.INPUT_STATUS),
                //        new MySqlParameter("@Session.UserId",Session.UserId),
                //        new MySqlParameter("@date",date),
                //    };
                //cmd.CommandText = InSql;
                //if (parametersIt != null)
                //{
                //    foreach (MySqlParameter parm in parameters)
                //        cmd.Parameters.Add(parm);
                //}
                //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();

                for (int i = 1; i < (bean.AntennaSum + 1); i++)
                {
                    string _sql = "INSERT INTO antenna (ID_CODE,READER_WRITER_ID) VALUES(" + @i + "," + @bean.Id + ") ";
                    MySqlParameter[] _Parameters =
                    {
                            new MySqlParameter("@i",i),
                        new MySqlParameter("@bean.Id",bean.Id),
                    };
                    cmd.CommandText = _sql;
                    if (_Parameters != null)
                    {
                        foreach (MySqlParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                tx.Commit();
                return BaseRequest.SUCCESS;
            }
            else
            {
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        catch (Exception e)
        {
            tx.Rollback();
            conn.Close();
            e.GetBaseException();
            return BaseRequest.SYSTEM_EXCEPTION;
        }
    }
    }
    }
