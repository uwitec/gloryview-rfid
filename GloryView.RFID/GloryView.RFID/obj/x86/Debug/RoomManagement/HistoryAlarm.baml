   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5      0    *GloryView.RFID.RoomManagement.HistoryAlarm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ history_alarm��5       � RowDefinitions 5   
   �� 5      $
��499* �6   �� 5      $	��51* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��623 �6#   �� 5      $
��129* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,8,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��历史报警��6�   �� 5      -   5        $��label2��5   l   $��起始日期��6   $��1��6#   $��29��63   $
��Left=�6?   $��5,11,0,0q�6Z   $	��Top=�6z   $��72��6�   $��14(�6�   �� 5      -   5        $��label3��5   k   $	��到��6   $��1��6    $��28��60   $
��Left=�6<   $��
215,11,0,0q�6W   $	��Top=�6y   $��27��6�   $��14(�6�   �� 5      -   5        $��button1��5   o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
387,14,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   (  "System.Windows.Controls.DatePicker  5       -   5        $��datePicker1��5    c   $��1��6   $��23��6)   $
��Left=�65   $��	76,14,0,0q�6P   $	��Top=�6v   $	��137��6�   $��11(�6�   	   DisplayDate$	 	8/19/2013��6�     5!      -   5        $��datePicker2��5!   d   $��1��6   $��25��6)   $
��Left=�65   $��
239,13,0,0q�6P   $	��Top=�6w   $	��146��6�   $��11(�6�   �� 5"      $8��2/GloryView.RFID;component/Images/user/21294124.gif��6   $��12��6P   $��1��6[   $��465,8,146,2q�6k   �� 5#      $��1��6   $��478,18,73,6q�6*   $��12(�6?   �� 5$      -	   5        ���	#FFA70000
 �� TextDecorations
 5$   3   Z� .�6^   导出报表6d   5%      �� 5&      -
   5        $��button2��5&   o   $��打印报表��6   $��1��6$   $��26��64   $
��Left=�6@   $��
564,11,0,0q�6[   $	��Top=�6~   $��59��6�   $��11(�6�   5'      &   System.Windows.Controls.DataGrid  5(   
   -   5        $��	alarmGrid��5(   %   $��0,46,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6{   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��12(�6�   $��Center=�6�   ��5)      �� 5*      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 5,      �� 5-       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5.      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 50      P� 51       P� Property �@J�IsMouseOver P� Value . . �53      ��  � ��
 ��·�6;   �� 54       � ��
 �����6;   55      57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 6/      
Visibility$ Hidden=�6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
ALARM_ID+6W     5;      $ 编 号��6%   $	 50* 62    6>   �� *NUMBER+  5<      $ 设备类别��6%   $	 80* 63    6?   �� *	TYPE_NAME+  5=      $ 报警类别��6%   $	 80* 63    6?   �� *ALARM_TYPE_NAME+  5>      $ 机 房��6%   $	 80* 62    6>   �� *	ROOM_NAME+  5?      $ 	处理人��6%   $	 70* 62    6>   �� *	USER_NAME+  5@      $ 报警时间��6%   $
 100* 63    6@   �� *
ALARM_TIME+ �� 	Converter# [    5A      $ 处理时间��6%   $
 100* 63    6@   �� *PROCESSING_TIME+# [  4	  .System.Windows.Controls.DataGridTemplateColumn	  5B      $ 操 作��6)   $	 80* 66    	  CellTemplate 5C      �� 5D      .R�5E      �� $��navigateTextBlock��6(   $��1��6A   $��11(�6N   $
��Wrap=�6\   
��� ����� 5F   "    �Name$ Details��6,   -   5        
 5F   ;   Z� .�6m   �� $:��4/GloryView.RFID;component/Images/UIImage/publish.png��6s   $��25��6�   $��23��6�    � ToolTip$ 查看详细信息��6�   6�   5H      5J      5L      5N      &
    GloryView.RFID.PageControl.Pager
  5O   
   -   5          
 Name$
  page��5O      ���	#04000000$��1��6;   6J   5P      5Q      