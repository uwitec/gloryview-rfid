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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace GloryView.RFID.PageControl
{
    /// <summary>
    /// T4PopupControl.xaml 的交互逻辑
    /// </summary>
    [ContentProperty("PopupContent")]
    public partial class T4PopupControl : UserControl
    {
       
            public FrameworkElement PopupContent
            {
                get { return (FrameworkElement)GetValue(PopupContentProperty); }
                set { SetValue(PopupContentProperty, value); }
            }
            /// <summary>
            /// PopupContent，弹出内容。
            /// </summary>
            public static readonly DependencyProperty PopupContentProperty =
                DependencyProperty.Register("PopupContent",
                typeof(FrameworkElement), typeof(T4PopupControl), new UIPropertyMetadata(null));
            /// <summary>
            /// IsOpen，是否显示弹出内容。
            /// </summary>
            public bool IsOpen
            {
                get { return (bool)GetValue(IsOpenProperty); }
                set { SetValue(IsOpenProperty, value); }
            }
            /// <summary>
            /// IsOpen，是否显示弹出内容，依赖属性。
            /// </summary>
            public static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register("IsOpen",
                typeof(bool), typeof(T4PopupControl),
                new UIPropertyMetadata(false, IsOpen_Changed));
            private static void IsOpen_Changed(DependencyObject s, DependencyPropertyChangedEventArgs e)
            {
                var Owner = s as T4PopupControl; Owner.SetAdonersVisibility();
            }
            // Pri
            private CPri Pri = new CPri();
            private class CPri
            {
                public bool ThisLoadedIf = false;
                public AdornerLayer ThisAdornerLayer = null;
                public T4PopupControlOverlayAdorner OverlayAdorner = null;
                public T4PopupControlContentAdorner ContentAdorner = null;
            }

            /// <summary>
            /// T4PopupControl，构造函数。
            /// </summary>
            public T4PopupControl()
            {
                InitializeComponent();
                this.DefaultStyleKey = typeof(T4PopupControl);
                this.Loaded -= T4PopupControl_Loaded;
                this.Loaded += T4PopupControl_Loaded;
            }
            private void T4PopupControl_Loaded(object sender, RoutedEventArgs e)
            {
                Pri.ThisAdornerLayer = AdornerLayer.GetAdornerLayer(this);
                MessageBox.Show("========" + Pri.ThisAdornerLayer);
                Pri.OverlayAdorner = new T4PopupControlOverlayAdorner(this);
                Pri.ContentAdorner = new T4PopupControlContentAdorner(this, this.PopupContent);
                MessageBox.Show(Pri.ThisAdornerLayer.ToString());
                MessageBox.Show(Pri.ContentAdorner.ToString());
                Pri.ThisAdornerLayer.Add(Pri.OverlayAdorner);
                Pri.ThisAdornerLayer.Add(Pri.ContentAdorner);
                Pri.OverlayAdorner.MouseDown -= OverlayAdorner_MouseDown;
                Pri.OverlayAdorner.MouseDown += OverlayAdorner_MouseDown;
                Pri.ThisLoadedIf = true; SetAdonersVisibility();
            }
            private void OverlayAdorner_MouseDown(object sender, MouseButtonEventArgs e) { this.IsOpen = false; }
            private void SetAdonersVisibility()
            {
                if (Pri.ThisLoadedIf)
                {
                    if (this.IsOpen) { ShowAdorners(); }
                    else { HideAdorners(); }
                }
            }
            private void ShowAdorners()
            {
                Pri.OverlayAdorner.Visibility = Visibility.Visible;
                Pri.ContentAdorner.Visibility = Visibility.Visible;
            }
            private void HideAdorners()
            {
                Pri.OverlayAdorner.Visibility = Visibility.Collapsed;
                Pri.ContentAdorner.Visibility = Visibility.Collapsed;
            }
        }
        internal class T4PopupControlOverlayAdorner : Adorner
        {
            private CPri Pri = new CPri();
            private class CPri
            {
                public Grid OverlayGrid = null;
            }
            internal T4PopupControlOverlayAdorner(UIElement AdornedElement)
                : base(AdornedElement)
            {
                Pri.OverlayGrid = new Grid() { Background = new SolidColorBrush(Colors.Transparent), };
                this.IsHitTestVisible = true; this.AddVisualChild(Pri.OverlayGrid);
            }
            protected override int VisualChildrenCount { get { return 1; } }
            protected override Visual GetVisualChild(int index) { return this.Pri.OverlayGrid; }
            protected override Size MeasureOverride(Size constraint)
            {
                return constraint;
            }
            protected override Size ArrangeOverride(Size finalSize)
            {
                var Host = FindParent<Window>(this.AdornedElement);
                var Pos = this.AdornedElement.TranslatePoint(default(Point), Host);
                this.Pri.OverlayGrid.Arrange(new Rect()
                {
                    X = -Pos.X,
                    Y = -Pos.Y,
                    Width = finalSize.Width,
                    Height = finalSize.Height
                });
                return base.ArrangeOverride(finalSize);
            }
            private T FindParent<T>(DependencyObject Child) where T : DependencyObject
            {
                var Rlt = null as T;
                var Tmp = VisualTreeHelper.GetParent(Child);
                if (Tmp != null)
                {
                    if ((Tmp as T) != null) { Rlt = Tmp as T; }
                    else { Rlt = FindParent<T>(Tmp); }
                }
                return Rlt;
            }
        }
        internal class T4PopupControlContentAdorner : Adorner
        {
            private CPri Pri = new CPri();
            private class CPri
            {
                public FrameworkElement ContentVisual = null;
            }
            internal T4PopupControlContentAdorner(UIElement AdornedElement, FrameworkElement ContentVisual)
                : base(AdornedElement)
            {
                Pri.ContentVisual = ContentVisual;
                this.IsHitTestVisible = true;
                this.AddVisualChild(Pri.ContentVisual);
            }
            protected override int VisualChildrenCount { get { return 1; } }
            protected override Visual GetVisualChild(int index) { return this.Pri.ContentVisual; }
            protected override Size MeasureOverride(Size constraint)
            {
                Pri.ContentVisual.Measure(constraint);
                var NewSize = Pri.ContentVisual.DesiredSize;
                return NewSize;
            }
            protected override Size ArrangeOverride(Size finalSize)
            {
                this.Pri.ContentVisual.Arrange(new Rect()
                {
                    X = 0,
                    Y = 0,
                    Width = finalSize.Width,
                    Height = finalSize.Height
                });
                return base.ArrangeOverride(finalSize);
            }
        }
}
