using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace GloryView.RFID
{
   public class ModelObject:ModelVisual3D
    {
        public string[] usize = new string[42];
        public int type;//服务器是1，机柜是2，ups是3，空调是4
        public int selected;
        public string parentrfid;//服务器所在机柜的RFID标签号
        public string RFID;//所有设备的RFID标签号
        public double ag;//角度
        public TranslateTransform3D translate = new TranslateTransform3D(0, 0, 0);
        public DiffuseMaterial[] material = new DiffuseMaterial[12];
        public DiffuseMaterial[] materiala = new DiffuseMaterial[12];
        public DiffuseMaterial[] materialb = new DiffuseMaterial[12];
        public DiffuseMaterial[] materialc = new DiffuseMaterial[12];
        public DiffuseMaterial[] materiald = new DiffuseMaterial[12];
        public DiffuseMaterial[] materialf = new DiffuseMaterial[12];
        public ModelObject()
        {
            type = 0;
            selected = 0;
        }

        public void Move(double offsetX, double offsetY, double offsetZ, double angle)
        {
            Transform3DGroup transform = new Transform3DGroup();
            RotateTransform3D rotateTrans = new RotateTransform3D();
            rotateTrans.Rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), angle);
            TranslateTransform3D translateTrans = new TranslateTransform3D(offsetX, offsetY, offsetZ);
            transform.Children.Add(rotateTrans);
            transform.Children.Add(translateTrans);
            this.Transform = transform;
            translate = translateTrans;
            ag = angle;
        }

        public void aricondition(double x, double y, double z)
        {
            type = 4;
            DiffuseMaterial material1 = new DiffuseMaterial();
            material1.Brush = Brushes.LightGray;
            DiffuseMaterial material2 = new DiffuseMaterial();
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"air.jpg", UriKind.Relative));
            material2.Brush = brush;

            Model3DGroup cube = new Model3DGroup();
            material[0] = material1;
            material[1] = material1;
            material[2] = material1;
            material[3] = material1;
            material[4] = material1;
            material[5] = material1;
            material[6] = material1;
            material[7] = material1;
            material[8] = material2;
            material[9] = material2;
            material[10] = material1;
            material[11] = material1;
            cubegroup( x, y, z,ref cube, material);
            this.Content = cube;           
        }

        public void servercabinet(double x, double y, double z)
        {
            type = 2;
            Model3DGroup total = new Model3DGroup();
            Model3DGroup side1 = new Model3DGroup();//底
            DiffuseMaterial material11 = new DiffuseMaterial();
            material11.Brush = Brushes.Gray;
            DiffuseMaterial material12 = new DiffuseMaterial();
            material12.Brush = Brushes.Black;
            materiala[0] = material11;
            materiala[1] = material11;
            materiala[2] = material11;
            materiala[3] = material11;
            materiala[4] = material12;
            materiala[5] = material12;
            materiala[6] = material12;
            materiala[7] = material12;
            materiala[8] = material12;
            materiala[9] = material12;
            materiala[10] = material12;
            materiala[11] = material12;
            cubegroup(x, 0.2, z + 0.2, ref side1, materiala);

            Model3DGroup side2 = new Model3DGroup();//顶
            DiffuseMaterial material2 = new DiffuseMaterial();
            material2.Brush = Brushes.Black;
            materialb[0] = material2;
            materialb[1] = material2;
            materialb[2] = material2;
            materialb[3] = material2;
            materialb[4] = material2;
            materialb[5] = material2;
            materialb[6] = material2;
            materialb[7] = material2;
            materialb[8] = material2;
            materialb[9] = material2;
            materialb[10] = material2;
            materialb[11] = material2;
            cubegroup(x, 0.2, z + 0.2, ref side2, materialb);
            Transform3DGroup transform2 = new Transform3DGroup();
            TranslateTransform3D translateTrans2 = new TranslateTransform3D(0, y + 0.2, 0);
            transform2.Children.Add(translateTrans2);
            side2.Transform = transform2;

            Model3DGroup side3 = new Model3DGroup();//左
            DiffuseMaterial material31 = new DiffuseMaterial();
            material31.Brush = Brushes.Black;
            DiffuseMaterial material32 = new DiffuseMaterial();
            material32.Brush = Brushes.Gray;
            materialc[0] = material31;
            materialc[1] = material31;
            materialc[2] = material31;
            materialc[3] = material31;
            materialc[4] = material31;
            materialc[5] = material31;
            materialc[6] = material32;
            materialc[7] = material32;
            materialc[8] = material31;
            materialc[9] = material31;
            materialc[10] = material31;
            materialc[11] = material31;
            cubegroup(0.1, y, z + 0.2, ref side3, materialc);
            Transform3DGroup transform3 = new Transform3DGroup();
            TranslateTransform3D translateTrans3 = new TranslateTransform3D(-x + 0.1, 0.2, 0);
            transform3.Children.Add(translateTrans3);
            side3.Transform = transform3;

            Model3DGroup side4 = new Model3DGroup();//右
            DiffuseMaterial material41 = new DiffuseMaterial();
            material41.Brush = Brushes.Black;
            DiffuseMaterial material42 = new DiffuseMaterial();
            material42.Brush = Brushes.Gray;
            materiald[0] = material41;
            materiald[1] = material41;
            materiald[2] = material41;
            materiald[3] = material41;
            materiald[4] = material42;
            materiald[5] = material42;
            materiald[6] = material41;
            materiald[7] = material41;
            materiald[8] = material41;
            materiald[9] = material41;
            materiald[10] = material41;
            materiald[11] = material41;
            cubegroup(0.1, y, z + 0.2, ref side4, materiald);
            Transform3DGroup transform4 = new Transform3DGroup();
            TranslateTransform3D translateTrans4 = new TranslateTransform3D(x - 0.1, 0.2, 0);
            transform4.Children.Add(translateTrans4);
            side4.Transform = transform4;
                                            
                                                    //前
                                                
            Model3DGroup side6 = new Model3DGroup();//后
            DiffuseMaterial material61 = new DiffuseMaterial();
            material61.Brush = Brushes.Black;
            DiffuseMaterial material62 = new DiffuseMaterial();
            material62.Brush = Brushes.Gray;
            materialf[0] = material61;
            materialf[1] = material61;
            materialf[2] = material61;
            materialf[3] = material61;
            materialf[4] = material61;
            materialf[5] = material61;
            materialf[6] = material61;
            materialf[7] = material61;
            materialf[8] = material62;
            materialf[9] = material62;
            materialf[10] = material61;
            materialf[11] = material61;
            cubegroup(x - 0.2, y, 0.4, ref side6, materialf);
            Transform3DGroup transform6 = new Transform3DGroup();
            TranslateTransform3D translateTrans6 = new TranslateTransform3D(0, 0.2, -z + 0.2);
            transform6.Children.Add(translateTrans6);
            side6.Transform = transform6;

            total.Children.Add(side1);
            total.Children.Add(side2);
            total.Children.Add(side3);
            total.Children.Add(side4);
            total.Children.Add(side6);
            this.Content = total;
        }
    
        public void server(double x, double y, double z)
        {
            type = 1;
            DiffuseMaterial material1 = new DiffuseMaterial();
            material1.Brush = Brushes.Gray;

            DiffuseMaterial material2 = new DiffuseMaterial();
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"server.jpg", UriKind.Relative));
            brush.Viewport = new Rect(0, 0, 1, 0.25);
            brush.TileMode = TileMode.Tile;
            material2.Brush = brush;

            Model3DGroup cube = new Model3DGroup();
            material[0] = material1;
            material[1] = material1;
            material[2] = material1;
            material[3] = material1;
            material[4] = material1;
            material[5] = material1;
            material[6] = material1;
            material[7] = material1;
            material[8] = material2;
            material[9] = material2;
            material[10] = material1;
            material[11] = material1;
            cubegroup( x, y, z,ref cube, material);
            this.Content = cube; 
        }

        public void ups(double x, double y, double z)
        {
            type = 3;
            DiffuseMaterial material1 = new DiffuseMaterial();
            material1.Brush = Brushes.LightGray;

            DiffuseMaterial material2 = new DiffuseMaterial();
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"ups.jpg", UriKind.Relative));
            material2.Brush = brush;

            Model3DGroup cube = new Model3DGroup();
            material[0] = material1;
            material[1] = material1;
            material[2] = material1;
            material[3] = material1;
            material[4] = material1;
            material[5] = material1;
            material[6] = material1;
            material[7] = material1;
            material[8] = material2;
            material[9] = material2;
            material[10] = material1;
            material[11] = material1;
            cubegroup( x, y, z,ref cube, material);
            this.Content = cube;          
        }

        public void cubegroup(double x, double y, double z, ref Model3DGroup cube, DiffuseMaterial[] material)
        {
            GeometryModel3D F1 = new GeometryModel3D();
            topside(x, y, z, ref F1, material[0], material[1]);
            GeometryModel3D F2 = new GeometryModel3D();
            bottomside(x, y, z, ref F2, material[2], material[3]);
            GeometryModel3D F3 = new GeometryModel3D();
            leftside(x, y, z, ref F3, material[4], material[5]);
            GeometryModel3D F4 = new GeometryModel3D();
            rightside(x, y, z, ref F4, material[6], material[7]);
            GeometryModel3D F5 = new GeometryModel3D();
            fontside(x, y, z, ref F5, material[8], material[9]);
            GeometryModel3D F6 = new GeometryModel3D();
            backside(x, y, z, ref F6, material[10], material[11]);
            cube.Children.Add(F1);
            cube.Children.Add(F2);
            cube.Children.Add(F3);
            cube.Children.Add(F4);
            cube.Children.Add(F5);
            cube.Children.Add(F6);
        }

        public void topside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1, DiffuseMaterial material2)
        {
            MeshGeometry3D mymeshgeometry3D3 = new MeshGeometry3D();
            Point3DCollection myPositionCollection3 = new Point3DCollection();
            PointCollection myTextureCoordinatesCollection3 = new PointCollection();
            Int32Collection myTriangleIndicesCollection3 = new Int32Collection();

            myPositionCollection3.Add(new Point3D(x, y, -z));
            myPositionCollection3.Add(new Point3D(-x, y, -z));
            myPositionCollection3.Add(new Point3D(-x, y, z));
            myPositionCollection3.Add(new Point3D(x, y, z));

            myTriangleIndicesCollection3.Add(0);
            myTriangleIndicesCollection3.Add(1);
            myTriangleIndicesCollection3.Add(2);
            myTriangleIndicesCollection3.Add(0);
            myTriangleIndicesCollection3.Add(2);
            myTriangleIndicesCollection3.Add(3);

            myTextureCoordinatesCollection3.Add(new Point(0, 1));
            myTextureCoordinatesCollection3.Add(new Point(0, 0));
            myTextureCoordinatesCollection3.Add(new Point(1, 0));
            myTextureCoordinatesCollection3.Add(new Point(1, 1));
            mymeshgeometry3D3.Positions = myPositionCollection3;
            mymeshgeometry3D3.TextureCoordinates = myTextureCoordinatesCollection3;
            mymeshgeometry3D3.TriangleIndices = myTriangleIndicesCollection3;

            side.Geometry = mymeshgeometry3D3;
            side.Material = material1;
            side.BackMaterial = material2;
        }

        public void bottomside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1, DiffuseMaterial material2)
        {
            MeshGeometry3D mymeshgeometry3D1 = new MeshGeometry3D();
            Point3DCollection myPositionCollection1 = new Point3DCollection();
            PointCollection myTextureCoordinatesCollection1 = new PointCollection();
            Int32Collection myTriangleIndicesCollection1 = new Int32Collection();

            myPositionCollection1.Add(new Point3D(x, 0, -z));
            myPositionCollection1.Add(new Point3D(-x, 0, -z));
            myPositionCollection1.Add(new Point3D(-x, 0, z));
            myPositionCollection1.Add(new Point3D(x, 0, z));
            myTriangleIndicesCollection1.Add(0);
            myTriangleIndicesCollection1.Add(1);
            myTriangleIndicesCollection1.Add(2);
            myTriangleIndicesCollection1.Add(0);
            myTriangleIndicesCollection1.Add(2);
            myTriangleIndicesCollection1.Add(3);

            myTextureCoordinatesCollection1.Add(new Point(0, 1));
            myTextureCoordinatesCollection1.Add(new Point(0, 0));
            myTextureCoordinatesCollection1.Add(new Point(1, 0));
            myTextureCoordinatesCollection1.Add(new Point(1, 1));

            mymeshgeometry3D1.Positions = myPositionCollection1;
            mymeshgeometry3D1.TextureCoordinates = myTextureCoordinatesCollection1;
            mymeshgeometry3D1.TriangleIndices = myTriangleIndicesCollection1;

            side.Geometry = mymeshgeometry3D1;
            side.Material = material1;
            side.BackMaterial = material2;
        }

        public void leftside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1, DiffuseMaterial material2)
        {
            MeshGeometry3D mymeshgeometry3D2 = new MeshGeometry3D();
            Point3DCollection myPositionCollection2 = new Point3DCollection();
            PointCollection myTextureCoordinatesCollection2 = new PointCollection();
            Int32Collection myTriangleIndicesCollection2 = new Int32Collection();

            myPositionCollection2.Add(new Point3D(-x, 0, z));
            myPositionCollection2.Add(new Point3D(-x, 0, -z));
            myPositionCollection2.Add(new Point3D(-x, y, -z));
            myPositionCollection2.Add(new Point3D(-x, y, z));

            myTriangleIndicesCollection2.Add(0);
            myTriangleIndicesCollection2.Add(1);
            myTriangleIndicesCollection2.Add(2);
            myTriangleIndicesCollection2.Add(0);
            myTriangleIndicesCollection2.Add(2);
            myTriangleIndicesCollection2.Add(3);

            myTextureCoordinatesCollection2.Add(new Point(0, 1));
            myTextureCoordinatesCollection2.Add(new Point(0, 0));
            myTextureCoordinatesCollection2.Add(new Point(1, 0));
            myTextureCoordinatesCollection2.Add(new Point(1, 1));
            mymeshgeometry3D2.Positions = myPositionCollection2;
            mymeshgeometry3D2.TextureCoordinates = myTextureCoordinatesCollection2;
            mymeshgeometry3D2.TriangleIndices = myTriangleIndicesCollection2;

            side.Geometry = mymeshgeometry3D2;
            side.Material = material1;
            side.BackMaterial = material2;
        }

        public void rightside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1, DiffuseMaterial material2)
        {
            MeshGeometry3D mymeshgeometry3D4 = new MeshGeometry3D();
            Point3DCollection myPositionCollection4 = new Point3DCollection();
            PointCollection myTextureCoordinatesCollection4 = new PointCollection();
            Int32Collection myTriangleIndicesCollection4 = new Int32Collection();

            myPositionCollection4.Add(new Point3D(x, 0, z));
            myPositionCollection4.Add(new Point3D(x, 0, -z));
            myPositionCollection4.Add(new Point3D(x, y, -z));
            myPositionCollection4.Add(new Point3D(x, y, z));

            myTriangleIndicesCollection4.Add(0);
            myTriangleIndicesCollection4.Add(1);
            myTriangleIndicesCollection4.Add(2);
            myTriangleIndicesCollection4.Add(0);
            myTriangleIndicesCollection4.Add(2);
            myTriangleIndicesCollection4.Add(3);

            myTextureCoordinatesCollection4.Add(new Point(0, 1));
            myTextureCoordinatesCollection4.Add(new Point(0, 0));
            myTextureCoordinatesCollection4.Add(new Point(1, 0));
            myTextureCoordinatesCollection4.Add(new Point(1, 1));
            mymeshgeometry3D4.Positions = myPositionCollection4;
            mymeshgeometry3D4.TextureCoordinates = myTextureCoordinatesCollection4;
            mymeshgeometry3D4.TriangleIndices = myTriangleIndicesCollection4;

            side.Geometry = mymeshgeometry3D4;
            side.Material = material1;
            side.BackMaterial = material2;
        }


        public void fontside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1, DiffuseMaterial material2)
        {
            MeshGeometry3D mymeshgeometry3D5 = new MeshGeometry3D();
            Point3DCollection myPositionCollection5 = new Point3DCollection();
            PointCollection myTextureCoordinatesCollection5 = new PointCollection();
            Int32Collection myTriangleIndicesCollection5 = new Int32Collection();

            myPositionCollection5.Add(new Point3D(-x, 0, z));
            myPositionCollection5.Add(new Point3D(-x, y, z));
            myPositionCollection5.Add(new Point3D(x, y, z));
            myPositionCollection5.Add(new Point3D(x, 0, z));

            myTriangleIndicesCollection5.Add(0);
            myTriangleIndicesCollection5.Add(1);
            myTriangleIndicesCollection5.Add(2);
            myTriangleIndicesCollection5.Add(0);
            myTriangleIndicesCollection5.Add(2);
            myTriangleIndicesCollection5.Add(3);

            myTextureCoordinatesCollection5.Add(new Point(0, 1));
            myTextureCoordinatesCollection5.Add(new Point(0, 0));
            myTextureCoordinatesCollection5.Add(new Point(1, 0));
            myTextureCoordinatesCollection5.Add(new Point(1, 1));
            mymeshgeometry3D5.Positions = myPositionCollection5;
            mymeshgeometry3D5.TextureCoordinates = myTextureCoordinatesCollection5;
            mymeshgeometry3D5.TriangleIndices = myTriangleIndicesCollection5;

            side.Geometry = mymeshgeometry3D5;
            side.Material = material1;
            side.BackMaterial = material2;
        }

        public void backside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1,DiffuseMaterial material2)
        {
            MeshGeometry3D mymeshgeometry3D6 = new MeshGeometry3D();
            Point3DCollection myPositionCollection6 = new Point3DCollection();
            PointCollection myTextureCoordinatesCollection6 = new PointCollection();
            Int32Collection myTriangleIndicesCollection6 = new Int32Collection();

            myPositionCollection6.Add(new Point3D(-x, 0, -z));
            myPositionCollection6.Add(new Point3D(-x, y, -z));
            myPositionCollection6.Add(new Point3D(x, y, -z));
            myPositionCollection6.Add(new Point3D(x, 0, -z));

            myTriangleIndicesCollection6.Add(0);
            myTriangleIndicesCollection6.Add(1);
            myTriangleIndicesCollection6.Add(2);
            myTriangleIndicesCollection6.Add(0);
            myTriangleIndicesCollection6.Add(2);
            myTriangleIndicesCollection6.Add(3);

            myTextureCoordinatesCollection6.Add(new Point(0, 1));
            myTextureCoordinatesCollection6.Add(new Point(0, 0));
            myTextureCoordinatesCollection6.Add(new Point(1, 0));
            myTextureCoordinatesCollection6.Add(new Point(1, 1));
            mymeshgeometry3D6.Positions = myPositionCollection6;
            mymeshgeometry3D6.TextureCoordinates = myTextureCoordinatesCollection6;
            mymeshgeometry3D6.TriangleIndices = myTriangleIndicesCollection6;

            side.Geometry = mymeshgeometry3D6;
            side.Material = material1;
            side.BackMaterial = material2;
        }
    }
}
