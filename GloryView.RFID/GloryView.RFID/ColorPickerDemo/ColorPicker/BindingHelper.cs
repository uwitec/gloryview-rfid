using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;

namespace GloryView.RFID.ColorPickerDemo.ColorPicker
{
   public static class BindingHelper
{
    public static readonly DependencyProperty BindOnEnterProperty =
      DependencyProperty.RegisterAttached("BindOnEnter",
      typeof(DependencyProperty), typeof(BindingHelper),
      new UIPropertyMetadata(null, new PropertyChangedCallback(OnBindOnEnterChanged)));
    private static void OnBindOnEnterChanged(DependencyObject d,
                        DependencyPropertyChangedEventArgs e)
    {
      UIElement element = d as UIElement;
      element.KeyDown += new KeyEventHandler(OnKeyDown);
    }
 
    private static void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        UIElement element = e.Source as UIElement;
        DependencyProperty property =
          (DependencyProperty)element.GetValue(BindOnEnterProperty);
 
        BindingExpression binding =
          BindingOperations.GetBindingExpression(element, property);
        if (binding != null)
          binding.UpdateSource();
      }
    }
}
}
