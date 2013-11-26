using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.DeviceMigrations
{
    class DeviceMigrationsFactory
    {
        private DeviceMigrationsFactory() { }
        private static Equipments equipments = new Equipments();

        public static Equipments Equipments
        {
            get { return DeviceMigrationsFactory.equipments; }
            set { DeviceMigrationsFactory.equipments = value; }
        }
        private static NewEquipment newEquipment = new NewEquipment();

        public static NewEquipment NewEquipment
        {
            get { return DeviceMigrationsFactory.newEquipment; }
            set { DeviceMigrationsFactory.newEquipment = value; }
        }
        private static OldEquipment oldEquipment = new OldEquipment();

        public static OldEquipment OldEquipment
        {
            get { return DeviceMigrationsFactory.oldEquipment; }
            set { DeviceMigrationsFactory.oldEquipment = value; }
        }
        private static EquipmentDelivery equipmentDelivery = new EquipmentDelivery();

        public static EquipmentDelivery EquipmentDelivery
        {
            get { return DeviceMigrationsFactory.equipmentDelivery; }
            set { DeviceMigrationsFactory.equipmentDelivery = value; }
        }
        private static EquipmentScrapping equipmentScrapping = new EquipmentScrapping();

        public static EquipmentScrapping EquipmentScrapping
        {
            get { return DeviceMigrationsFactory.equipmentScrapping; }
            set { DeviceMigrationsFactory.equipmentScrapping = value; }
        }
        private static DeviceMigration deviceMigrations = new DeviceMigration();

        public static DeviceMigration DeviceMigrations
        {
            get { return DeviceMigrationsFactory.deviceMigrations; }
            set { DeviceMigrationsFactory.deviceMigrations = value; }
        }
        private static DevicePower devicePower = new DevicePower();

        public static DevicePower DevicePower
        {
            get { return DeviceMigrationsFactory.devicePower; }
            set { DeviceMigrationsFactory.devicePower = value; }
        }
        private static DeviceMove deviceMove = new DeviceMove();

        public static DeviceMove DeviceMove
        {
            get { return DeviceMigrationsFactory.deviceMove; }
            set { DeviceMigrationsFactory.deviceMove = value; }
        }
        private static RequestDiscarding requestDiscarding = new RequestDiscarding();

        public static RequestDiscarding RequestDiscarding
        {
            get { return DeviceMigrationsFactory.requestDiscarding; }
            set { DeviceMigrationsFactory.requestDiscarding = value; }
        }
        private static ApplyDevice applyDevice = new ApplyDevice();

        public static ApplyDevice ApplyDevice
        {
            get { return DeviceMigrationsFactory.applyDevice; }
            set { DeviceMigrationsFactory.applyDevice = value; }
        }
        private static Review review = new Review();

        public static Review Review
        {
            get { return DeviceMigrationsFactory.review; }
            set { DeviceMigrationsFactory.review = value; }
        }
        private static EquipmentReview equipmentReview = new EquipmentReview();

        public static EquipmentReview EquipmentReview
        {
            get { return DeviceMigrationsFactory.equipmentReview; }
            set { DeviceMigrationsFactory.equipmentReview = value; }
        }
        private static EquipmentInformation equipmentInformation = new EquipmentInformation();

        public static EquipmentInformation EquipmentInformation
        {
            get { return DeviceMigrationsFactory.equipmentInformation; }
            set { DeviceMigrationsFactory.equipmentInformation = value; }
        }
        private static MigrationDetails migrationDetails = new MigrationDetails();

        public static MigrationDetails MigrationDetails
        {
            get { return DeviceMigrationsFactory.migrationDetails; }
            set { DeviceMigrationsFactory.migrationDetails = value; }
        }

        private static Addserver _Addserver = new Addserver();

        public static Addserver Addserver
        {
            get { return DeviceMigrationsFactory._Addserver; }
            set { DeviceMigrationsFactory._Addserver = value; }
        }

        private static Deleteserver _Deleteserver = new Deleteserver();

        public static Deleteserver Deleteserver
        {
            get { return DeviceMigrationsFactory._Deleteserver; }
            set { DeviceMigrationsFactory._Deleteserver = value; }
        }

        private static Alterserver _Alterserver = new Alterserver();

        public static Alterserver Alterserver
        {
            get { return DeviceMigrationsFactory._Alterserver; }
            set { DeviceMigrationsFactory._Alterserver = value; }
        }

        private static motor _motor = new motor();

        public static motor motor
        {
            get { return DeviceMigrationsFactory._motor; }
            set { DeviceMigrationsFactory._motor = value; }
        }


        private static AddEquipment _AddEquipment=new AddEquipment();

        public static AddEquipment AddEquipment
        {
            get { return DeviceMigrationsFactory._AddEquipment; }
            set { DeviceMigrationsFactory._AddEquipment = value; }
        }
      
        private static RepairEquipment _RepairEquipment = new RepairEquipment();

        public static RepairEquipment RepairEquipment
        {
            get { return DeviceMigrationsFactory._RepairEquipment; }
            set { DeviceMigrationsFactory._RepairEquipment = value; }
        }
      

    }
}
