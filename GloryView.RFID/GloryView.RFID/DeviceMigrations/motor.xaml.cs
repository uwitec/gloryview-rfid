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
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// motor.xaml 的交互逻辑
    /// </summary> 
    public partial class motor : UserControl
    {
        public List<NewRoom> rooms = new List<NewRoom>();
        public motor()
        {
            InitializeComponent();
            Getxmal xmal = new Getxmal("2.xml");
            xmal.scenelayout(ref rooms);
            foreach (NewRoom roomm in rooms)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = roomm.roomname;
                listBox.Items.Add(item);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FurnitureContainer.Children.Clear();
            if (listBox.SelectedItem == null)
            {
                return;
            }
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            string Engineroomname = "";
            Engineroomname = lbi.Content.ToString();
            NewRoom room=new NewRoom();
            foreach (NewRoom roomtemp in rooms)
            {
                if (roomtemp.roomname == Engineroomname)
                {
                    room = roomtemp;
                }
            }

            foreach (ModelWall wall in room.walls)
            {
                this.FurnitureContainer.Children.Add(wall);
            }
            for (int i = 0; i < room.myStore.Count; i++)
            {
                ModelObject ex = (ModelObject)room.myStore.GetByIndex(i);
                string RFID = room.myStore.GetKey(i).ToString();

                this.FurnitureContainer.Children.Add(ex);
            }
            this.canvas1.Visibility = Visibility.Visible;
        }

        private void VerticalTransform(bool upDown, double angleDeltaFactor)
        {
            Vector3D postion = new Vector3D(myPerspectiveCamera.Position.X, myPerspectiveCamera.Position.Y, myPerspectiveCamera.Position.Z);
            Vector3D rotateAxis = Vector3D.CrossProduct(postion, myPerspectiveCamera.UpDirection);
            RotateTransform3D rt3d = new RotateTransform3D();
            AxisAngleRotation3D rotate = new AxisAngleRotation3D(rotateAxis, angleDeltaFactor * (upDown ? -1 : 1));
            rt3d.Rotation = rotate;
            Matrix3D matrix = rt3d.Value;
            Point3D newPostition = matrix.Transform(myPerspectiveCamera.Position);
            myPerspectiveCamera.Position = newPostition;
            myPerspectiveCamera.LookDirection = new Vector3D(-newPostition.X, -newPostition.Y, -newPostition.Z);
            Vector3D newUpDirection = Vector3D.CrossProduct(myPerspectiveCamera.LookDirection, rotateAxis);
            newUpDirection.Normalize();
            myPerspectiveCamera.UpDirection = newUpDirection;
        }

        private void HorizontalTransform(bool leftRight, double angleDeltaFactor)
        {
            Vector3D postion = new Vector3D(myPerspectiveCamera.Position.X, myPerspectiveCamera.Position.Y, myPerspectiveCamera.Position.Z);
            Vector3D rotateAxis = myPerspectiveCamera.UpDirection;
            RotateTransform3D rt3d = new RotateTransform3D();
            AxisAngleRotation3D rotate = new AxisAngleRotation3D(rotateAxis, angleDeltaFactor * (leftRight ? -1 : 1));
            rt3d.Rotation = rotate;
            Matrix3D matrix = rt3d.Value;
            Point3D newPostition = matrix.Transform(myPerspectiveCamera.Position);
            myPerspectiveCamera.Position = newPostition;
            myPerspectiveCamera.LookDirection = new Vector3D(-newPostition.X, -newPostition.Y, -newPostition.Z);
        }

        double keyDeltaFactor = 4;// determine the angle delta when the ddirection key pressed
        private void arrowupclick(object sender, RoutedEventArgs e)
        {
            //上移   ---------------------------
                VerticalTransform(true, keyDeltaFactor);
        }

        private void arrowdownclick(object sender, RoutedEventArgs e)
        {
            //下移
                VerticalTransform(false, keyDeltaFactor); 
        }

        private void arrowleftclick(object sender, RoutedEventArgs e)
        {
            //左移
            HorizontalTransform(false, keyDeltaFactor);
        }

        private void arrowrightclick(object sender, RoutedEventArgs e)
        {
            //右移
            HorizontalTransform(true, keyDeltaFactor);
        }

        void positionAnimation_Completed(object sender, EventArgs e)
        {
            Point3D position = myPerspectiveCamera.Position;
            myPerspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, null);
            myPerspectiveCamera.Position = position;
        }

        private void arrowaddclick(object sender, RoutedEventArgs e)
        {
            //拉近
            double scaleFactor = 3;
            Point3D currentPosition = myPerspectiveCamera.Position;
            Vector3D lookDirection = myPerspectiveCamera.LookDirection;//new Vector3D(camera.LookDirection.X, camera.LookDirection.Y, camera.LookDirection.Z);
            lookDirection.Normalize();
            lookDirection *= scaleFactor;
            if ((currentPosition.X + lookDirection.X) * currentPosition.X > 0)
            {
                currentPosition += lookDirection;
            }
            Point3DAnimation positionAnimation = new Point3DAnimation();
            positionAnimation.BeginTime = new TimeSpan(0, 0, 0);
            positionAnimation.Duration = TimeSpan.FromMilliseconds(100);
            positionAnimation.To = currentPosition;
            positionAnimation.From = myPerspectiveCamera.Position;
            positionAnimation.Completed += new EventHandler(positionAnimation_Completed);
            myPerspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, positionAnimation, HandoffBehavior.Compose);         
        }

        private void arrowdelclick(object sender, RoutedEventArgs e)
        {
            //拉远
            double scaleFactor = 3;
            Point3D currentPosition = myPerspectiveCamera.Position;
            Vector3D lookDirection = myPerspectiveCamera.LookDirection;//new Vector3D(camera.LookDirection.X, camera.LookDirection.Y, camera.LookDirection.Z);
            lookDirection.Normalize();
            lookDirection *= scaleFactor;
            currentPosition -= lookDirection;
            Point3DAnimation positionAnimation = new Point3DAnimation();
            positionAnimation.BeginTime = new TimeSpan(0, 0, 0);
            positionAnimation.Duration = TimeSpan.FromMilliseconds(100);
            positionAnimation.To = currentPosition;
            positionAnimation.From = myPerspectiveCamera.Position;
            positionAnimation.Completed += new EventHandler(positionAnimation_Completed);
            myPerspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, positionAnimation, HandoffBehavior.Compose);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            string rfid = textBox1.Text;
            NewRoom room = rooms[0];
            for (int i = 0; i < room.myStore.Count; i++)
            {
                ModelObject ex = (ModelObject)room.myStore.GetByIndex(i);
                string RFID = room.myStore.GetKey(i).ToString();
                if (RFID == rfid)
                {
                    switch(ex.type)
                    {
                        case 1:
                            {
                                MessageBox.Show("查询设备是服务器");
                                break;
                            }                          
                        case 2:
                            {
                                ex.materiala[4].Brush = Brushes.Red;
                                ex.materiala[5].Brush = Brushes.Red;
                                ex.materiala[6].Brush = Brushes.Red;
                                ex.materiala[7].Brush = Brushes.Red;
                                ex.materiala[8].Brush = Brushes.Red;
                                ex.materiala[9].Brush = Brushes.Red;
                                ex.materiala[10].Brush = Brushes.Red;
                                ex.materiala[11].Brush = Brushes.Red;

                                ex.materialb[1].Brush = Brushes.Red;
                                ex.materialb[2].Brush = Brushes.Red;
                                ex.materialb[3].Brush = Brushes.Red;
                                ex.materialb[4].Brush = Brushes.Red;
                                ex.materialb[5].Brush = Brushes.Red;
                                ex.materialb[6].Brush = Brushes.Red;
                                ex.materialb[7].Brush = Brushes.Red;
                                ex.materialb[8].Brush = Brushes.Red;
                                ex.materialb[9].Brush = Brushes.Red;
                                ex.materialb[10].Brush = Brushes.Red;
                                ex.materialb[11].Brush = Brushes.Red;

                                ex.materialc[1].Brush = Brushes.Red;
                                ex.materialc[2].Brush = Brushes.Red;
                                ex.materialc[3].Brush = Brushes.Red;
                                ex.materialc[4].Brush = Brushes.Red;
                                ex.materialc[5].Brush = Brushes.Red;
                                ex.materialc[8].Brush = Brushes.Red;
                                ex.materialc[9].Brush = Brushes.Red;
                                ex.materialc[10].Brush = Brushes.Red;
                                ex.materialc[11].Brush = Brushes.Red;

                                ex.materiald[1].Brush = Brushes.Red;
                                ex.materiald[2].Brush = Brushes.Red;
                                ex.materiald[3].Brush = Brushes.Red;
                                ex.materiald[6].Brush = Brushes.Red;
                                ex.materiald[7].Brush = Brushes.Red;
                                ex.materiald[8].Brush = Brushes.Red;
                                ex.materiald[9].Brush = Brushes.Red;
                                ex.materiald[10].Brush = Brushes.Red;
                                ex.materiald[11].Brush = Brushes.Red;

                                ex.materialf[1].Brush = Brushes.Red;
                                ex.materialf[2].Brush = Brushes.Red;
                                ex.materialf[3].Brush = Brushes.Red;
                                ex.materialf[4].Brush = Brushes.Red;
                                ex.materialf[5].Brush = Brushes.Red;
                                ex.materialf[6].Brush = Brushes.Red;
                                ex.materialf[7].Brush = Brushes.Red;
                                ex.materialf[10].Brush = Brushes.Red;
                                ex.materialf[11].Brush = Brushes.Red;
                                MessageBox.Show("查询设备是机柜");
                                break;
                            }
                        case 3:
                            {
                                MessageBox.Show("查询设备是UPS设备");
                                break;
                            }
                        case 4:
                            {
                                MessageBox.Show("查询设备是空调");
                                break;
                            }
                    }
                }
            }
        }   

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(myPerspectiveCamera.Position.X.ToString() + " " + myPerspectiveCamera.Position.Y.ToString() + " " + myPerspectiveCamera.Position.Z.ToString());
        }

        private void rebackclick(object sender, RoutedEventArgs e)
        {
            Point3D position = new Point3D(-1.075, 87.285, 48.297);
            Vector3D lookdirection = new Vector3D(1.075, -87.285, -48.297);
            Vector3D updirection = new Vector3D(-0.002, 0.490, -0.871);
            this.myPerspectiveCamera.Position = position;
            this.myPerspectiveCamera.LookDirection = lookdirection;
            this.myPerspectiveCamera.UpDirection = updirection;            
        }
    }
}
