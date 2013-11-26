using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.RoomManagement
{
    class RoomManagerBean
    {
        private RoomManagerBean() { }
        private static RoomManagerBean roomManager = new RoomManagerBean();

        internal static RoomManagerBean RoomManager
        {
            get { return RoomManagerBean.roomManager; }
            set { RoomManagerBean.roomManager = value; }
        }
        private static Room room = new Room();

        public static Room Room
        {
            get { return room; }
            set { room = value; }
        }
        private static DeviceClass deviceClass = new DeviceClass();

        public static DeviceClass DeviceClass
        {
            get { return deviceClass; }
            set { deviceClass = value; }
        }
        private static Statement statement = new Statement();

        public static Statement Statement
        {
            get { return statement; }
            set { statement = value; }
        }
        private static DeviceList deviceList = new DeviceList();

        public static DeviceList DeviceList
        {
            get { return RoomManagerBean.deviceList; }
            set { RoomManagerBean.deviceList = value; }
        }
        private static EquipmentList equipmentList = new EquipmentList();

        public static EquipmentList EquipmentList
        {
            get { return RoomManagerBean.equipmentList; }
            set { RoomManagerBean.equipmentList = value; }
        }
        private static Alarm alarm = new Alarm();

        public static Alarm Alarm
        {
            get { return RoomManagerBean.alarm; }
            set { RoomManagerBean.alarm = value; }
        }
        private static HistoryAlarm historyAlarm = new HistoryAlarm();

        public static HistoryAlarm HistoryAlarm
        {
            get { return RoomManagerBean.historyAlarm; }
            set { RoomManagerBean.historyAlarm = value; }
        }
        private static AddRoom addRoom = new AddRoom();

        public static AddRoom AddRoom
        {
            get { return RoomManagerBean.addRoom; }
            set { RoomManagerBean.addRoom = value; }
        }
        private static RecycleLabels recycleLabels = new RecycleLabels();

        public static RecycleLabels RecycleLabels
        {
            get { return RoomManagerBean.recycleLabels; }
            set { RoomManagerBean.recycleLabels = value; }
        }
        private static AddRecycleLabels addRecycleLabels = new AddRecycleLabels();

        public static AddRecycleLabels AddRecycleLabels
        {
            get { return RoomManagerBean.addRecycleLabels; }
            set { RoomManagerBean.addRecycleLabels = value; }
        }
        private static AddRooms addRooms = new AddRooms();

        public static AddRooms AddRooms
        {
            get { return RoomManagerBean.addRooms; }
            set { RoomManagerBean.addRooms = value; }
        }
        private static AddEquipment addEquipment = new AddEquipment();

        public static AddEquipment AddEquipment
        {
            get { return RoomManagerBean.addEquipment; }
            set { RoomManagerBean.addEquipment = value; }
        }
        private static EditRoom editRoom = new EditRoom();

        public static EditRoom EditRoom
        {
            get { return RoomManagerBean.editRoom; }
            set { RoomManagerBean.editRoom = value; }
        }
        private static RoomDetails roomDetails = new RoomDetails();

        public static RoomDetails RoomDetails
        {
            get { return RoomManagerBean.roomDetails; }
            set { RoomManagerBean.roomDetails = value; }
        }
        private static EditDeviceClass editDeviceClass = new EditDeviceClass();

        public static EditDeviceClass EditDeviceClass
        {
            get { return RoomManagerBean.editDeviceClass; }
            set { RoomManagerBean.editDeviceClass = value; }
        }
        private static HistoryEquipment _HistoryEquipment = new HistoryEquipment();

        public static HistoryEquipment HistoryEquipment
        {
            get { return RoomManagerBean._HistoryEquipment; }
            set { RoomManagerBean._HistoryEquipment = value; }
        }
        private static HistoryEquipmentDetails _HistoryEquipmentDetails=new HistoryEquipmentDetails();

        public static HistoryEquipmentDetails HistoryEquipmentDetails
        {
          get { return RoomManagerBean._HistoryEquipmentDetails; }
          set { RoomManagerBean._HistoryEquipmentDetails = value; }
        }
        
    }
}
