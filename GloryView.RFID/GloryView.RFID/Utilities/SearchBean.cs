using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.Utilities
{
    class SearchBean
    {
        private int _Number;

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private int _RoomId;

        public int RoomId
        {
            get { return _RoomId; }
            set { _RoomId = value; }
        }
        private int _WorkStatus;

        public int WorkStatus
        {
            get { return _WorkStatus; }
            set { _WorkStatus = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private int _EditId;

        public int EditId
        {
            get { return _EditId; }
            set { _EditId = value; }
        }
        private string _CreateTime;

        public string CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        private string _EditTime;

        public string EditTime
        {
            get { return _EditTime; }
            set { _EditTime = value; }
        }
        //时间范围的截止日期
        private string _OnTime;

        public string OnTime
        {
            get { return _OnTime; }
            set { _OnTime = value; }
        }
    }
}
