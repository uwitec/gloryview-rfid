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
    public  class ModelWall : ModelVisual3D
    {
        DiffuseMaterial[] material = new DiffuseMaterial[12];
        public void Move(double offsetX, double offsetY, double offsetZ, double angle)
        {
            Transform3DGroup transform = new Transform3DGroup();
            RotateTransform3D rotateTrans = new RotateTransform3D();
            rotateTrans.Rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), angle);
            TranslateTransform3D translateTrans = new TranslateTransform3D(offsetX, offsetY, offsetZ);
            transform.Children.Add(rotateTrans);
            transform.Children.Add(translateTrans);
            this.Transform = transform;
        }

        public DiffuseMaterial setmaterial1()
        {

            DiffuseMaterial material = new DiffuseMaterial();
            DrawingBrush brush = new DrawingBrush();
            brush.Viewport = new Rect(0, 0, 0.36, 0.2);
            brush.TileMode = TileMode.Tile;
            DrawingGroup Dgroup = new DrawingGroup();
            GeometryDrawing draw1 = new GeometryDrawing();
            draw1.Brush = Brushes.Silver;
            RectangleGeometry RectGeometry1 = new RectangleGeometry();
            RectGeometry1.Rect = new Rect(0, 0, 100, 100);
            draw1.Geometry = RectGeometry1;
            GeometryDrawing draw2 = new GeometryDrawing();
            GeometryGroup Ggroup = new GeometryGroup();
            RectangleGeometry RectGeometry2 = new RectangleGeometry();
            RectGeometry2.Rect = new Rect(0, 0, 50, 50);
            RectangleGeometry RectGeometry3 = new RectangleGeometry();
            RectGeometry3.Rect = new Rect(50, 50, 50, 50);
            Ggroup.Children.Add(RectGeometry2);
            Ggroup.Children.Add(RectGeometry3);
            draw2.Geometry = Ggroup;
            draw2.Brush = Brushes.White;
            LinearGradientBrush linebrush = new LinearGradientBrush();
            GradientStop dient1 = new GradientStop();
            dient1.Offset = 0.0;
            dient1.Color = Colors.White;
            GradientStop dient2 = new GradientStop();
            dient2.Offset = 1.0;
            dient2.Color = Colors.LightCyan;
            linebrush.GradientStops.Add(dient1);
            linebrush.GradientStops.Add(dient2);
            draw2.Brush = linebrush;
            Dgroup.Children.Add(draw1);
            Dgroup.Children.Add(draw2);
            brush.Drawing = Dgroup;
            material.Brush = brush;
            return material;
        }

        public void floor(double l, double h, double w)
        {
            DiffuseMaterial material1 = new DiffuseMaterial();
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"floor15.jpg", UriKind.Relative));
            brush.Viewport = new Rect(0, 0, 0.1, 0.1);
            brush.TileMode = TileMode.Tile;
            material1.Brush = brush;

            Model3DGroup cube = new Model3DGroup();
            material[0] = material1;
            material[1] = material1;
            material[2] = material1;
            material[3] = material1;
            material[4] = material1;
            material[5] = material1;
            material[6] = material1;
            material[7] = material1;
            material[8] = material1;
            material[9] = material1;
            material[10] = material1;
            material[11] = material1;
            cubegroup(l, h, w,ref cube,  material);
            this.Content = cube;  
        }

        public void outwall(double l, double h, double w)
        {
            //DiffuseMaterial material1 = new DiffuseMaterial();
            //material1.Brush = Brushes.LightGoldenrodYellow;

            DiffuseMaterial material1 = new DiffuseMaterial();
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"wall4.jpg", UriKind.Relative));
            brush.Viewport = new Rect(0, 0, 1, 1);
            brush.TileMode = TileMode.Tile;
            material1.Brush = brush;

            Model3DGroup cube = new Model3DGroup();
            DiffuseMaterial[] material = new DiffuseMaterial[12];
            material[0] = material1;
            material[1] = material1;
            material[2] = material1;
            material[3] = material1;
            material[4] = material1;
            material[5] = material1;
            material[6] = material1;
            material[7] = material1;
            material[8] = material1;
            material[9] = material1;
            material[10] = material1;
            material[11] = material1;
            cubegroup(l, h, w,ref cube, material);
            this.Content = cube;
        }

        public DiffuseMaterial setmaterial()
        {

            DiffuseMaterial material = new DiffuseMaterial();
            DrawingBrush brush = new DrawingBrush();
            brush.Viewport = new Rect(0, 0, 0.1, 0.1);
            brush.TileMode = TileMode.Tile;
            DrawingGroup Dgroup = new DrawingGroup();
            GeometryDrawing draw1 = new GeometryDrawing();
            draw1.Brush = Brushes.PapayaWhip;
            RectangleGeometry RectGeometry1 = new RectangleGeometry();
            RectGeometry1.Rect = new Rect(0, 0, 20, 20);
            draw1.Geometry = RectGeometry1;
            GeometryDrawing draw2 = new GeometryDrawing();
            GeometryGroup Ggroup = new GeometryGroup();
            RectangleGeometry RectGeometry2 = new RectangleGeometry();
            RectGeometry2.Rect = new Rect(0, 1, 9, 8);
            RectangleGeometry RectGeometry3 = new RectangleGeometry();
            RectGeometry3.Rect = new Rect(11, 1, 9, 8);

            RectangleGeometry RectGeometry4 = new RectangleGeometry();
            RectGeometry4.Rect = new Rect(1, 11, 18, 8);

            Ggroup.Children.Add(RectGeometry2);
            Ggroup.Children.Add(RectGeometry3);
            Ggroup.Children.Add(RectGeometry4);
            draw2.Geometry = Ggroup;
            draw2.Brush = Brushes.GhostWhite;

            Dgroup.Children.Add(draw1);
            Dgroup.Children.Add(draw2);
            brush.Drawing = Dgroup;
            material.Brush = brush;

            return material;
        }

        public void inwall(double l, double h, double w)
        {

            DiffuseMaterial material1 = new DiffuseMaterial();
            material1 = setmaterial();

            Model3DGroup cube = new Model3DGroup();

            material[0] = material1;
            material[1] = material1;
            material[2] = material1;
            material[3] = material1;
            material[4] = material1;
            material[5] = material1;
            material[6] = material1;
            material[7] = material1;
            material[8] = material1;
            material[9] = material1;
            material[10] = material1;
            material[11] = material1;
            cubegroup(l, h, w,ref cube, material);
            this.Content = cube;
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

        public void backside(double x, double y, double z, ref GeometryModel3D side, DiffuseMaterial material1, DiffuseMaterial material2)
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

        public void cubegroup(double x, double y, double z, ref Model3DGroup cube,  DiffuseMaterial[] material)
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
    }
}
