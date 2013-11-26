using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GloryView.RFID.Utilities
{
    class TimeOutExitSystem : RoutedEventArgs
    {
       public delegate void MyRoutedEventHandler(object sender ,TimeOutExitSystem e);
       public static readonly RoutedEvent MyRoutedEvent = EventManager.RegisterRoutedEvent(
   "MyRouted", RoutingStrategy.Bubble, typeof(MyRoutedEventHandler), typeof(MainForm));

       //public event MyRoutedEventHandler MyRouted
       //{
       //    //add { AddHandler(RoutedEvent, value); }
       //    //remove { RemoveHandler(RoutedEvent, value); }
       //}
    }
}
