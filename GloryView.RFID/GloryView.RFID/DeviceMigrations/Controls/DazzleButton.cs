using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace GloryView.RFID.Controls
{
	public class DazzleButton : Button
	{
		public static readonly DependencyProperty MyMoverBrushProperty;
		public static readonly DependencyProperty MyEnterBrushProperty;
		public Brush MyMoverBrush
		{
			get
			{
				return base.GetValue(DazzleButton.MyMoverBrushProperty) as Brush;
			}
			set
			{
				base.SetValue(DazzleButton.MyMoverBrushProperty, value);
			}
		}
		public Brush MyEnterBrush
		{
			get
			{
				return base.GetValue(DazzleButton.MyEnterBrushProperty) as Brush;
			}
			set
			{
				base.SetValue(DazzleButton.MyEnterBrushProperty, value);
			}
		}
		static DazzleButton()
		{
			DazzleButton.MyMoverBrushProperty = DependencyProperty.Register("MyMoverBrush", typeof(Brush), typeof(DazzleButton), new PropertyMetadata(null));
			DazzleButton.MyEnterBrushProperty = DependencyProperty.Register("MyEnterBrush", typeof(Brush), typeof(DazzleButton), new PropertyMetadata(null));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DazzleButton), new FrameworkPropertyMetadata(typeof(DazzleButton)));
		}
        public DazzleButton()
		{
			base.Content = "";
			base.Background = Brushes.Orange;
		}
	}
}
