using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.RoomManagement.Rooms
{
    class RoomBean
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _RoomName;

        public string RoomName
        {
            get { return _RoomName; }
            set { _RoomName = value; }
        }
        private string _Belongs;

        public string Belongs
        {
            get { return _Belongs; }
            set { _Belongs = value; }
        }
        private string _Purpose;

        public string Purpose
        {
            get { return _Purpose; }
            set { _Purpose = value; }
        }
        private string _Floor;

        public string Floor
        {
            get { return _Floor; }
            set { _Floor = value; }
        }
        private int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private DateTime _CreateTime;

        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
    }
}
