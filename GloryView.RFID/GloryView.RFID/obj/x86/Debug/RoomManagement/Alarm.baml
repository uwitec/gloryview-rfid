   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5      )    #GloryView.RFID.RoomManagement.Alarm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ AlarmDetailsControl��5       � RowDefinitions 5   
   �� 5      $
��500* �6   �� 5      $	��50* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��584 �6#   �� 5      $
��168* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,8,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��实时报警��6�   �� 5      -   5        $��label2��5   l   $��起始日期��6   $��1��6#   $��29��63   $
��Left=�6?   $��5,11,0,0q�6Z   $	��Top=�6z   $��72��6�   $��14(�6�   �� 5      -   5        $��label3��5   k   $	��到��6   $��1��6    $��28��60   $
��Left=�6<   $��
215,11,0,0q�6W   $	��Top=�6y   $��27��6�   $��14(�6�   �� 5      -   5        $��button1��5   o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
387,14,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   (  "System.Windows.Controls.DatePicker  5       -   5        $��datePicker1��5    c   $��1��6   $��23��6)   $
��Left=�65   $��	76,14,0,0q�6P   $	��Top=�6v   $	��137��6�   $��11(�6�   	   DisplayDate$	 	8/19/2013��6�     5!      -   5        $��datePicker2��5!   d   $��1��6   $��25��6)   $
��Left=�65   $��
239,13,0,0q�6P   $	��Top=�6w   $	��146��6�   $��11(�6�   5"      &   System.Windows.Controls.DataGrid  5#   
   -	   5        $��	alarmGrid��5#   %   $��0,46,0,0q�6   
   AutoGenerateColumns
 .     CanUserAddRows .     
IsReadOnly . $��0q�6{   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��11(�6�   $��Center=�6�   ��5$      �� 5%      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 5'      �� 5(       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5)      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5*      P� 5+       P� Property �@J�IsMouseOver P� Value . . �5-      ��  � ��
 ��·�6;   �� 5.       � ��
 �����6;   5/      51         Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 6/      
Visibility$ Hidden=�6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ID+6P     55      $ 编 号��6%   $	 50* 62    6>   �� *NUMBER+  56      $ 名 称��6%   $
 100* 62    6?   �� *NAME+  57      $ 类 别��6%   $
 100* 62    6?   �� *	TYPE_NAME+  58      $ 机 房��6%   $
 100* 62    6?   �� *	ROOM_NAME+  59      $ 报警类别��6%   $
 100* 63    6@   �� *ALARM_TYPE_NAME+  5:      $ 报警时间��6%   $
 100* 63    6@   �� *
ALARM_TIME+ �� 	Converter# [  4	  .System.Windows.Controls.DataGridTemplateColumn	  5;      $ 操 作��6)   $	 80* 66    	  CellTemplate 5<      �� 5=      .R�5>      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��1��6S   $��11(�6`   $
��Wrap=�6n   
��� ����� 5?   "    �Name$ 	Treatment��6,   -
   5        .�5?   U   	处 理6Z   5@      5B      5D      5F      &
    GloryView.RFID.PageControl.Pager
  5G   
   -   5         
 Name$
 page��5G      ���	#04000000$��0,1,0,0q�6;   $��1��6L   6[   5H      5I      