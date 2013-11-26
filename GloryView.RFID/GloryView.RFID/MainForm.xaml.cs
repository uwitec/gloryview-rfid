using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GloryView.RFID.Controls;
using WpfApplication2;
using MySql.Data.MySqlClient;
using System.Windows.Media.Media3D;
using System.Collections;
using GloryView.RFID.UserManager.IU;
using GloryView.RFID.RoomManagement;
using GloryView.RFID.DeviceMigrations;
using GloryView.RFID.SystemManagement;
using GloryView.RFID.Utilities;
using GloryView.RFID.User;
using System.Data;
using GloryView.RFID.RoomManagement.Rooms;
using GloryView.RFID.DeviceMigrations.DeviceClass;
using GloryView.RFID.PageControl;
using GloryView.RFID.SystemManagement.SystemClass;
namespace GloryView.RFID
{
    /// <summary>
    /// MainForm.xaml 的交互逻辑
    /// </summary>
    /// 

    public delegate void ClickEventHandler();//
    public partial class MainForm : DazzleWindow
    {
        public motor s1 = DeviceMigrationsFactory.motor;
        public MainForm()
        {
            InitializeComponent();
            roomsTreeView();
            //3D场景机房初始化
           // InitListItem();
            roomgrid.Children.Add(s1);
            this.move.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(ButtonDownMove);
        }
        void ButtonDownMove(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void roomsTreeView()
        {
            RoomClass rc=new RoomClass();
            MySqlDataReader reader=rc.queryRoomsName();
            while(reader.Read())
            {
                TreeViewItem item = new TreeViewItem();
                //item.HeaderTemplate;
                item.Header=reader["ROOM_NAME"];
                item.Uid = reader["ID"].ToString();
                item.FontSize = 12;
                //item.Foreground = ;
                this.rooms.Items.Add(item);
            }
        }

        //系统最小化
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        //系统最大化
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }
        //系统退出
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //添加Gild
        private void AddGrid(Object ob)
        {
            if (gridList.Children!=null) gridList.Children.Clear();
            //AddUser au = new AddUser();
            //grid.Add("grid", au);
            if (ob.GetType() == UserManagerBean.AddUser.GetType())
            {
                gridList.Children.Add(UserManagerBean.AddUser);
                UserManagerBean.AddUser.SetValue(Grid.RowProperty, 0);
                UserManagerBean.AddUser.SetValue(Grid.ColumnProperty, 0);
                UserManagerBean.AddUser.Background = null; 
            }
            else if (ob.GetType() == UserManagerBean.EditPower.GetType())
            {
                gridList.Children.Add(UserManagerBean.EditPower);
                UserManagerBean.EditPower.SetValue(Grid.RowProperty, 0);
                UserManagerBean.EditPower.SetValue(Grid.ColumnProperty, 0);
                UserManagerBean.EditPower.Background = null; 
            }
            else if (ob.GetType() == UserManagerBean.ChangePassword.GetType())
            {
                gridList.Children.Add(UserManagerBean.ChangePassword);
                UserManagerBean.ChangePassword.SetValue(Grid.RowProperty, 0);
                UserManagerBean.ChangePassword.SetValue(Grid.ColumnProperty, 0);
                UserManagerBean.ChangePassword.Background = null; 
            }
            else if (ob.GetType() == UserManagerBean.LoginLog.GetType())
            {
                gridList.Children.Add(UserManagerBean.LoginLog);
                UserManagerBean.LoginLog.SetValue(Grid.RowProperty, 0);
                UserManagerBean.LoginLog.SetValue(Grid.ColumnProperty, 0);
                UserManagerBean.LoginLog.Background = null; 
            }
            else if (ob.GetType() == UserManagerBean.ActionLog.GetType())
            {
                gridList.Children.Add(UserManagerBean.ActionLog);
                UserManagerBean.ActionLog.SetValue(Grid.RowProperty, 0);
                UserManagerBean.ActionLog.SetValue(Grid.ColumnProperty, 0);
                UserManagerBean.ActionLog.Background = null; 
            }
            

        }
        //操作安全判断
        private void Safety(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = ((sender as TreeView).SelectedItem as TreeViewItem);
            string save = tvi.Uid.ToString();
            if (save == null || "".Equals(save)) return;
            if (save.Equals("loginDiary"))
            {
                Grid saveGrid = new Grid();
                showGrid.Children.Add(saveGrid);
                saveGrid.SetValue(Grid.RowProperty, 0);
                saveGrid.SetValue(Grid.ColumnProperty, 1);
                saveGrid.Background = Brushes.DarkCyan;
            }
            else
            {
                Grid saveGrid = new Grid();
                showGrid.Children.Add(saveGrid);
                saveGrid.SetValue(Grid.RowProperty, 0);
                saveGrid.SetValue(Grid.ColumnProperty, 1);
                saveGrid.Background = Brushes.DarkOrchid;
            }
        }
        //机房选择
        private void SelectRoom(object sender, RoutedEventArgs e)
        {
            TreeViewItem roomId = ((sender as TreeView).SelectedItem as TreeViewItem);

            string  id = roomId.Uid.ToString();
            
            if (roomGrid.Children != null) roomGrid.Children.Clear();
            if ("roomName".Equals(id))
            {
                AddRoom addRoom = RoomManagerBean.AddRoom;
                RoomClass room = new RoomClass();
                QueryUser query = new QueryUser();
                //query.Account = UserManagerBean.AddUser.queryAccount.Text;
                //query.UserName = UserManagerBean.AddUser.queryName.Text;
                DataSet set = room.queryRoomsList();
                RoomManagerBean.AddRoom.page.ShowPages(RoomManagerBean.AddRoom.roomDate, set, BaseRequest.PAGE_SIZE);
                roomGrid.Children.Add(addRoom);
                addRoom.SetValue(Grid.RowProperty, 0);
                addRoom.SetValue(Grid.ColumnProperty, 0);
            }
            else if (id.Equals("EquipmentInfo")) { }

            else if (id.Equals("Elist"))
            {
                EquipmentList equipment = RoomManagerBean.EquipmentList;
                RoomClass rc = new RoomClass();
                EquipmentBean bean = new EquipmentBean();

                DataSet equipmentSet = rc.queryEquipmentList(bean);
                DataSet typeSet = rc.queryType();
                ComboBox box = RoomManagerBean.EquipmentList.type;
                if (box.HasItems) box.Items.Clear();
                ComboBoxItem boxItem = new ComboBoxItem();
                boxItem.Content = "请选择...";
                boxItem.Tag = "";
                boxItem.IsSelected = true;
                box.Items.Add(boxItem);
                //RoomManagerBean.DeviceClass.selectType.SelectedValuePath = "";
                if (typeSet.Tables.Count > 0)
                {
                    DataRowCollection drc = typeSet.Tables[0].Rows;

                    for (int i = 0; i < drc.Count; i++)
                    {
                        DataRow dr = drc[i];
                        int typeId = (int)dr["ID"];
                        string typeName = dr["TYPE_NAME"].ToString();

                        ComboBoxItem boxItems = new ComboBoxItem();
                        boxItems.Content = typeName;
                        boxItems.Tag = typeId;
                        box.Items.Add(boxItems);
                        //MessageBox.Show("typeId=" + typeId + " typeName=" + boxItems.Tag);
                    }
                    //MessageBox.Show("===" + equipmentSet.Tables.Count);
                    RoomManagerBean.EquipmentList.page.ShowPages(RoomManagerBean.EquipmentList.equipment, equipmentSet, BaseRequest.PAGE_SIZE);
                    roomGrid.Children.Add(equipment);
                    equipment.SetValue(Grid.RowProperty, 0);
                    equipment.SetValue(Grid.ColumnProperty, 0);
                }
            }
            else if (id.Equals("Report"))
            {
                Statement statement = RoomManagerBean.Statement;
                roomGrid.Children.Add(statement);
                statement.SetValue(Grid.RowProperty, 0);
                statement.SetValue(Grid.ColumnProperty, 0);
            }
            else if (id.Equals("Inventory"))
            {
                RoomClass rc = new RoomClass();
                DataSet stockSet = rc.queryInventory();
                RoomManagerBean.DeviceList.page.ShowPages(RoomManagerBean.DeviceList.stock, stockSet, BaseRequest.PAGE_SIZE);
                DeviceList deviceList = RoomManagerBean.DeviceList;
                roomGrid.Children.Add(deviceList);
                deviceList.SetValue(Grid.RowProperty, 0);
                deviceList.SetValue(Grid.ColumnProperty, 0);
            }
            else if (id.Equals("Category"))
            {
                DeviceClass deviceClass = RoomManagerBean.DeviceClass;
                RoomClass room = new RoomClass();
                QueryUser query = new QueryUser();

                //query.Account = UserManagerBean.AddUser.queryAccount.Text;
                //query.UserName = UserManagerBean.AddUser.queryName.Text;
                DataSet set = room.queryType();

                RoomManagerBean.DeviceClass.page.ShowPages(RoomManagerBean.DeviceClass.deviceData, set, BaseRequest.PAGE_SIZE);

                roomGrid.Children.Add(deviceClass);
                deviceClass.SetValue(Grid.RowProperty, 0);
                deviceClass.SetValue(Grid.ColumnProperty, 0);
            }
            else if (id.Equals("HistoryEquipment"))
            {
                HistoryEquipment he = RoomManagerBean.HistoryEquipment;
                RoomClass rc = new RoomClass();
                DataSet set = rc.queryHistoryEquipment();
                he.page.ShowPages(he.historyEquipment, set, BaseRequest.PAGE_SIZE);
                roomGrid.Children.Add(he);
                he.SetValue(Grid.RowProperty, 0);
                he.SetValue(Grid.ColumnProperty, 0);
            }
            else
            {
                Room roomBean = RoomManagerBean.Room;
                EquipmentClass ec = new EquipmentClass();
                roomBean.roomId.Text = id;
                DataSet set = ec.getEquipmentInformationByRoom(int.Parse(id));
                roomBean.page.ShowPages(roomBean.roomEquipment, set, BaseRequest.PAGE_SIZE);
                roomBean.roomName.Content = roomId.Header.ToString();
                roomGrid.Children.Add(roomBean);
                roomBean.SetValue(Grid.RowProperty, 0);
                roomBean.SetValue(Grid.ColumnProperty, 0);
            }
            
        }

        private void CheckCategory(object sender, RoutedEventArgs e)
        {
            TreeViewItem roodId = ((sender as TreeView).SelectedItem as TreeViewItem);
            //MessageBox.Show(lbi.Content.ToString());
            string deviceName = roodId.Header.ToString();
            if (deviceName == null || "".Equals(deviceName)) return;
            if (roomGrid.Children != null) roomGrid.Children.Clear();
            DeviceClass roomBean = RoomManagerBean.DeviceClass;
            roomBean.roomName.Content = deviceName;
            roomGrid.Children.Add(roomBean);
            roomBean.SetValue(Grid.RowProperty, 0);
            roomBean.SetValue(Grid.ColumnProperty, 0);
        }
        //设备管理功能选择
        private void Choice(object sender, RoutedEventArgs e)
        {
            TreeViewItem assets = ((sender as TreeView).SelectedItem as TreeViewItem);
            //MessageBox.Show(assets.Uid.ToString());
            string assetsName = assets.Uid.ToString();
            if (assetsName == null || "".Equals(assetsName))
            {
                roomGrid.Children.Clear();
            }
            if (roomGrid.Children != null) roomGrid.Children.Clear();

            // ==================================================================================

            if (assetsName.Equals("Elist"))
            {
                EquipmentList equipment = RoomManagerBean.EquipmentList;
                RoomClass rc = new RoomClass();
                EquipmentBean bean = new EquipmentBean();
                
                DataSet equipmentSet = rc.queryEquipmentList(bean);
                DataSet typeSet = rc.queryType();
                ComboBox box = RoomManagerBean.EquipmentList.type;
                if (box.HasItems) box.Items.Clear();
                ComboBoxItem boxItem = new ComboBoxItem();
                boxItem.Content = "请选择...";
                boxItem.Tag = "";
                boxItem.IsSelected = true;
                box.Items.Add(boxItem);
                //RoomManagerBean.DeviceClass.selectType.SelectedValuePath = "";
                if (typeSet.Tables.Count > 0)
                {
                    DataRowCollection drc = typeSet.Tables[0].Rows;

                    for (int i = 0; i < drc.Count; i++)
                    {
                        DataRow dr = drc[i];
                        int typeId = (int)dr["ID"];
                        string typeName = dr["TYPE_NAME"].ToString();

                        ComboBoxItem boxItems = new ComboBoxItem();
                        boxItems.Content = typeName;
                        boxItems.Tag = typeId;
                        box.Items.Add(boxItems);
                        //MessageBox.Show("typeId=" + typeId + " typeName=" + boxItems.Tag);
                    }
                    //MessageBox.Show("===" + equipmentSet.Tables.Count);
                    RoomManagerBean.EquipmentList.page.ShowPages(RoomManagerBean.EquipmentList.equipment, equipmentSet, BaseRequest.PAGE_SIZE);
                    roomGrid.Children.Add(equipment);
                    equipment.SetValue(Grid.RowProperty, 0);
                    equipment.SetValue(Grid.ColumnProperty, 0);
                }
            }
                else if (assetsName.Equals("Report"))
                {
                    Statement statement = RoomManagerBean.Statement;
                    roomGrid.Children.Add(statement);
                    statement.SetValue(Grid.RowProperty, 0);
                    statement.SetValue(Grid.ColumnProperty, 0);
                }
                else if (assetsName.Equals("Inventory"))
                {
                    RoomClass rc = new RoomClass();
                    DataSet stockSet = rc.queryInventory();
                    RoomManagerBean.DeviceList.page.ShowPages(RoomManagerBean.DeviceList.stock, stockSet, BaseRequest.PAGE_SIZE);
                    DeviceList deviceList = RoomManagerBean.DeviceList;
                    roomGrid.Children.Add(deviceList);
                    deviceList.SetValue(Grid.RowProperty, 0);
                    deviceList.SetValue(Grid.ColumnProperty, 0);
                }
                else if (assetsName.Equals("Category"))
                {
                    DeviceClass deviceClass = RoomManagerBean.DeviceClass;
                    RoomClass room = new RoomClass();
                    QueryUser query = new QueryUser();

                    //query.Account = UserManagerBean.AddUser.queryAccount.Text;
                    //query.UserName = UserManagerBean.AddUser.queryName.Text;
                     DataSet set = room.queryType();
                    
                     RoomManagerBean.DeviceClass.page.ShowPages(RoomManagerBean.DeviceClass.deviceData, set, BaseRequest.PAGE_SIZE);
                   
                    roomGrid.Children.Add(deviceClass);
                    deviceClass.SetValue(Grid.RowProperty, 0);
                    deviceClass.SetValue(Grid.ColumnProperty, 0);
                }
            else if (assetsName.Equals("HistoryEquipment"))
            {
                HistoryEquipment he = RoomManagerBean.HistoryEquipment;
                RoomClass rc = new RoomClass();
                DataSet set = rc.queryHistoryEquipment();
                he.page.ShowPages(he.historyEquipment, set, BaseRequest.PAGE_SIZE);
                roomGrid.Children.Add(he);
                he.SetValue(Grid.RowProperty, 0);
                he.SetValue(Grid.ColumnProperty, 0);
            }
            
            }


        //报修设备
        private void Device_Migrations(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem assets = ((sender as TreeView).SelectedItem as TreeViewItem);
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            string migrations = assets.Uid.ToString();
            if (migrations == null || "".Equals(migrations)) return;
            if (migrations.Equals("repair"))
            {
                if (moveGrid.Children != null) moveGrid.Children.Clear();
                Equipments equipments = DeviceMigrationsFactory.Equipments;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
            else if (migrations.Equals("incoming"))
            {

                if (moveGrid.Children != null) moveGrid.Children.Clear();
                NewEquipment equipments = DeviceMigrationsFactory.NewEquipment;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
            else if (migrations.Equals("delivery"))
            {
                if (moveGrid.Children != null) moveGrid.Children.Clear();
                EquipmentDelivery equipments = DeviceMigrationsFactory.EquipmentDelivery;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
            else if (migrations.Equals("incoming"))
            {
                if (moveGrid.Children != null) moveGrid.Children.Clear();
                EquipmentDelivery equipments = DeviceMigrationsFactory.EquipmentDelivery;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
            else if (migrations.Equals("migrate"))
            {
                if (moveGrid.Children != null) moveGrid.Children.Clear();
                DeviceMove equipments = DeviceMigrationsFactory.DeviceMove;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
            else if (migrations.Equals("scrap"))
            {
                if (moveGrid.Children != null) moveGrid.Children.Clear();
                EquipmentScrapping equipments = DeviceMigrationsFactory.EquipmentScrapping;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
            else if (migrations.Equals("mains"))
            {
                if (moveGrid.Children != null) moveGrid.Children.Clear();
                DevicePower equipments = DeviceMigrationsFactory.DevicePower;
                moveGrid.Children.Add(equipments);
                equipments.SetValue(Grid.RowProperty, 0);
                equipments.SetValue(Grid.ColumnProperty, 0);
            }
        }
       
        private void Delivery(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            EquipmentDelivery delivery = DeviceMigrationsFactory.EquipmentDelivery;
            moveGrid.Children.Add(delivery);
            delivery.SetValue(Grid.RowProperty, 0);
            delivery.SetValue(Grid.ColumnProperty, 0);
        }
        //报废设备
        private void Scrapping(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            EquipmentScrapping scrapping = DeviceMigrationsFactory.EquipmentScrapping;
            moveGrid.Children.Add(scrapping);
            scrapping.SetValue(Grid.RowProperty, 0);
            scrapping.SetValue(Grid.ColumnProperty, 0);
        }

        private void Migrations(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            DeviceMigration migrations = DeviceMigrationsFactory.DeviceMigrations;
            moveGrid.Children.Add(migrations);
            migrations.SetValue(Grid.RowProperty, 0);
            migrations.SetValue(Grid.ColumnProperty, 0);
        }
       

        private void System_set(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem power = ((sender as TreeView).SelectedItem as TreeViewItem);
            string systemTypeName = power.Uid.ToString();
            if (systemTypeName == null || "".Equals(systemTypeName)) return;
            if (systemGrid.Children != null) systemGrid.Children.Clear();
            if (systemTypeName.Equals("sys"))
            {
                SystemSetting devicePower = SystemManagerFactory.SystemSetting;
                systemGrid.Children.Add(devicePower);
                devicePower.SetValue(Grid.RowProperty, 0);
                devicePower.SetValue(Grid.ColumnProperty, 0);
            }
            else if (systemTypeName.Equals("setting"))
            {
                AlarmSetting alarmSetting = SystemManagerFactory.AlarmSetting;
                systemGrid.Children.Add(alarmSetting);
                alarmSetting.SetValue(Grid.RowProperty, 0);
                alarmSetting.SetValue(Grid.ColumnProperty, 0);
            }
            else if (systemTypeName.Equals("userLog"))
            {
                AllUserLog userLog = SystemManagerFactory.UserLog;
                Users user = new Users();
                DataSet set = user.getUserLoginLog();
                userLog.page.ShowPages(userLog.logGrid, set, BaseRequest.PAGE_SIZE);
                systemGrid.Children.Add(userLog);
                userLog.SetValue(Grid.RowProperty, 0);
                userLog.SetValue(Grid.ColumnProperty, 0);
            }
            else if (systemTypeName.Equals("movedLog"))
            {
                MovedDevicesLog movedDevicesLog = SystemManagerFactory.MovedDevicesLog;
                SystemManager sm = new SystemManager();
                DataSet set=sm.getEquipmentOperation();
                movedDevicesLog.page.ShowPages(movedDevicesLog.EquiplogGrid, set, BaseRequest.PAGE_SIZE);
                systemGrid.Children.Add(movedDevicesLog);
                movedDevicesLog.SetValue(Grid.RowProperty, 0);
                movedDevicesLog.SetValue(Grid.ColumnProperty, 0);
            }
            else if (systemTypeName.Equals("cycleSetting"))
            {
                BackupCycleSetting backupCycleSetting = new BackupCycleSetting();
                systemGrid.Children.Add(backupCycleSetting);
                backupCycleSetting.SetValue(Grid.RowProperty, 0);
                backupCycleSetting.SetValue(Grid.ColumnProperty, 0);
            }
        }
        //设备迁移
        private void Device_Move(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            DeviceMove deviceMove = DeviceMigrationsFactory.DeviceMove;
            EquipmentClass _Eclass = new EquipmentClass();
            //DataSet _RemoveSet = _Eclass.getWorkEquipment();
            DataSet _RemoveSet = _Eclass.getMoveEquipment();
            deviceMove.page.ShowPages(deviceMove.removeGrid, _RemoveSet, BaseRequest.PAGE_SIZE);
            moveGrid.Children.Add(deviceMove);
            deviceMove.SetValue(Grid.RowProperty, 0);
            deviceMove.SetValue(Grid.ColumnProperty, 0);
        }
       
        //用户列表
        private void userManager(object sender, RoutedEventArgs e)
        {

           
            //UserManagerBean.AddUser
            Users u = new Users();
            QueryUser query = new QueryUser();
            query.Account = UserManagerBean.AddUser.queryAccount.Text;
            query.UserName = UserManagerBean.AddUser.queryName.Text;
            
            DataSet set = u.getUsersList(query);
            UserManagerBean.AddUser.page.ShowPages(UserManagerBean.AddUser.userData, set, BaseRequest.PAGE_SIZE);
            AddGrid(UserManagerBean.AddUser);

              
        }
        
        
        //机房列表
        private void AddRooms(object sender, RoutedEventArgs e)
        {
            if (roomGrid.Children != null) roomGrid.Children.Clear();
            AddRoom addRoom = RoomManagerBean.AddRoom;
            roomGrid.Children.Add(addRoom);
            addRoom.SetValue(Grid.RowProperty, 0);
            addRoom.SetValue(Grid.ColumnProperty, 0);
        }

        private void Recycle(object sender, RoutedEventArgs e)
        {
            if (roomGrid.Children != null) roomGrid.Children.Clear();
            RecycleLabels recycle = RoomManagerBean.RecycleLabels;
            roomGrid.Children.Add(recycle);
            recycle.SetValue(Grid.RowProperty, 0);
            recycle.SetValue(Grid.ColumnProperty, 0);
        }
        //新设备录入
        private void Device_Incoming(object sender, RoutedEventArgs e)
        {
            EquipmentClass equitment= new EquipmentClass();
            DataSet set = equitment.comingEquipment();
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            NewEquipment equipments = DeviceMigrationsFactory.NewEquipment;

            equipments.MyEvent += new ClickEventHandler(form2_MyEvent);   
            DeviceMigrationsFactory.NewEquipment.page.ShowPages(DeviceMigrationsFactory.NewEquipment.comingGrild, set, BaseRequest.PAGE_SIZE);
           
            moveGrid.Children.Add(equipments);
            equipments.SetValue(Grid.RowProperty, 0);
            equipments.SetValue(Grid.ColumnProperty, 0);
            
        }

        private void form2_MyEvent()
        {
            //MessageBox.Show("YYYYYYYYYYYYYYYYYYYY");
            s1.FurnitureContainer.Children.Clear();
            s1.rooms.Clear();
            s1.listBox.Items.Clear();
            Getxmal xmal = new Getxmal("2.xml");
            xmal.scenelayout(ref s1.rooms);
            foreach (NewRoom roomm in s1.rooms)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = roomm.roomname;

                s1.listBox.Items.Add(item);
            }
        }

        //出库
        private void Device_Out(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            EquipmentDelivery _Delivery = DeviceMigrationsFactory.EquipmentDelivery;
            EquipmentClass _Eclass = new EquipmentClass();
            //DataSet _OutSet=_Eclass.getWorkEquipment();
            DataSet _OutSet = _Eclass.getDeliverEquipment();
            _Delivery.page.ShowPages(_Delivery.outGird, _OutSet, BaseRequest.PAGE_SIZE);
            moveGrid.Children.Add(_Delivery);
            _Delivery.SetValue(Grid.RowProperty, 0);
            _Delivery.SetValue(Grid.ColumnProperty, 0);
        }
      

        //报修设备申请
        private void Device_Repair(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            RepairEquipment _RepairEquipment = DeviceMigrationsFactory.RepairEquipment;
            EquipmentClass _Eclass = new EquipmentClass();

            //Equipments _Repair = DeviceMigrationsFactory.Equipments;
            //EquipmentClass _Eclass = new EquipmentClass();
           // DataSet _OutSet = _Eclass.getWorkEquipment();
            DataSet _OutSet = _Eclass.getRepairEquipment();
            _RepairEquipment.page.ShowPages(_RepairEquipment.repair_Grid, _OutSet, BaseRequest.PAGE_SIZE);
            moveGrid.Children.Add(_RepairEquipment);
            _RepairEquipment.SetValue(Grid.RowProperty, 0);
            _RepairEquipment.SetValue(Grid.ColumnProperty, 0);
        }

        //报废申请
        private void Device_Mains(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            EquipmentScrapping _Scrap = DeviceMigrationsFactory.EquipmentScrapping;
            EquipmentClass _Eclass = new EquipmentClass();
            //DataSet _Scrap_Set = _Eclass.getWorkEquipment();
            DataSet _Scrap_Set = _Eclass.getScrappingEquipment();
            _Scrap.page.ShowPages(_Scrap.scrapGrid, _Scrap_Set, BaseRequest.PAGE_SIZE);
            moveGrid.Children.Add(_Scrap);
            _Scrap.SetValue(Grid.RowProperty, 0);
            _Scrap.SetValue(Grid.ColumnProperty, 0);
        }

        private void Device_Prower(object sender, RoutedEventArgs e)
        {
            if (roomGrid.Children != null) roomGrid.Children.Clear();
            DevicePower equipments = DeviceMigrationsFactory.DevicePower;
            roomGrid.Children.Add(equipments);
            equipments.SetValue(Grid.RowProperty, 0);
            equipments.SetValue(Grid.ColumnProperty, 0);
        }

        private void Apply_For(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            RequestDiscarding request = DeviceMigrationsFactory.RequestDiscarding;
            moveGrid.Children.Add(request);
            request.SetValue(Grid.RowProperty, 0);
            request.SetValue(Grid.ColumnProperty, 0);
        }

        private void Equipment_Review(object sender, RoutedEventArgs e)
        {
            if (moveGrid.Children != null) moveGrid.Children.Clear();
            EquipmentReview equipmentReview = DeviceMigrationsFactory.EquipmentReview;
            moveGrid.Children.Add(equipmentReview);
            equipmentReview.SetValue(Grid.RowProperty, 0);
            equipmentReview.SetValue(Grid.ColumnProperty, 0);
        }

        private void Save_Device(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem save = ((sender as TreeView).SelectedItem as TreeViewItem);
            //MessageBox.Show(lbi.Content.ToString());
            string saveName = save.Uid.ToString();
            if (saveName == null || "".Equals(saveName)) return;
            if (saveDevice.Children != null) saveDevice.Children.Clear();
            if (saveName.Equals("Alarm"))
            {
                Alarm alarm = RoomManagerBean.Alarm;
                saveDevice.Children.Add(alarm);
                alarm.SetValue(Grid.RowProperty, 0);
                alarm.SetValue(Grid.ColumnProperty, 0);
            }
            else if (saveName.Equals("History"))
            {
                HistoryAlarm alarm = RoomManagerBean.HistoryAlarm;
                saveDevice.Children.Add(alarm);
                alarm.SetValue(Grid.RowProperty, 0);
                alarm.SetValue(Grid.ColumnProperty, 0);
            }
        }
        //报警
        private void Arning(object sender, RoutedEventArgs e)
        {
            if (saveDevice.Children != null) saveDevice.Children.Clear();
            Alarm alarm = RoomManagerBean.Alarm;
            RoomClass _Rclass = new RoomClass();
            DataSet _Alarm_Set = _Rclass.queryAlarmList();
            alarm.page.ShowPages(alarm.alarmGrid, _Alarm_Set, BaseRequest.PAGE_SIZE);
            saveDevice.Children.Add(alarm);
            alarm.SetValue(Grid.RowProperty, 0);
            alarm.SetValue(Grid.ColumnProperty, 0);
        }

        private void Alarm_History(object sender, RoutedEventArgs e)
        {
            if (saveDevice.Children != null) saveDevice.Children.Clear();
            HistoryAlarm alarm = RoomManagerBean.HistoryAlarm;
            RoomClass _Rclass = new RoomClass();
            DataSet _HistoryAlarmSet = _Rclass.queryHistoryAlarmList();
            alarm.page.ShowPages(alarm.alarmGrid, _HistoryAlarmSet, BaseRequest.PAGE_SIZE);
            saveDevice.Children.Add(alarm);
            alarm.SetValue(Grid.RowProperty, 0);
            alarm.SetValue(Grid.ColumnProperty, 0);
        }

        private void Change_Password(object sender, RoutedEventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.account.Content = Session.UserAccount;
            if (login.Children.Contains(change))
            {
                change.Visibility = Visibility.Visible;
            }
            else
            {
                login.Children.Add(change);
                change.Name = "change";
            }
        }
        //退出系统
        private void exitSystem(object sender, RoutedEventArgs e)
        {
       
            MsgResult r =JXMessageBox.Show(this, "您是否要退出系统?", "提示", MsgButton.Yes_No_Cancel, MsgImage.Exclamation);
            if (r == MsgResult.OK)
            {
                Session.UserId = 0;
                Session.UserAccount = null;
                Session.LogId = 0;
                Session.LoginTime = null;
                roomgrid.Children.Clear();
                this.Close();
            }
        }



        //private void _UserManager(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    //UserManagerBean.AddUser
        //    Users u = new Users();
        //    QueryUser query = new QueryUser();
        //    query.Account = UserManagerBean.AddUser.queryAccount.Text;
        //    query.UserName = UserManagerBean.AddUser.queryName.Text;

        //    DataSet set = u.getUsersList(query);
        //    UserManagerBean.AddUser.page.ShowPages(UserManagerBean.AddUser.userData, set, BaseRequest.PAGE_SIZE);
        //    AddGrid(UserManagerBean.AddUser);
        //}

        private void User_Manager_KeyDown(object sender, KeyEventArgs e)
        {
            //UserManagerBean.AddUser
            Users u = new Users();
            QueryUser query = new QueryUser();
            query.Account = UserManagerBean.AddUser.queryAccount.Text;
            query.UserName = UserManagerBean.AddUser.queryName.Text;

            DataSet set = u.getUsersList(query);
            UserManagerBean.AddUser.page.ShowPages(UserManagerBean.AddUser.userData, set, BaseRequest.PAGE_SIZE);
            AddGrid(UserManagerBean.AddUser);
        }

        private void DazzleTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DazzleTabItem item = ((sender as DazzleTabControl).SelectedItem as DazzleTabItem);
            if (item != null)
            {
                //MessageBox.Show(item.ToString());
                if (item.Name.Equals("User_Manager"))
                {
                    Users u = new Users();
                    QueryUser query = new QueryUser();
                    query.Account = UserManagerBean.AddUser.queryAccount.Text;
                    query.UserName = UserManagerBean.AddUser.queryName.Text;

                    DataSet set = u.getUsersList(query);
                    UserManagerBean.AddUser.page.ShowPages(UserManagerBean.AddUser.userData, set, BaseRequest.PAGE_SIZE);
                    AddGrid(UserManagerBean.AddUser);
                }
            }
        }

    }
}
