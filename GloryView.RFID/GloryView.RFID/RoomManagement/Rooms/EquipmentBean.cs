using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.RoomManagement.Rooms
{
    class EquipmentBean
    {
        private string _Number;

        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        private int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

    }
}
