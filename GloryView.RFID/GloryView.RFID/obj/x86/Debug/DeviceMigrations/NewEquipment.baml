   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      Y1clr-namespace:GloryView.RFID.ReaderAndWriterClass#GloryView.RFID.ReaderAndWriterClass  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5	      /clr-namespace:GloryView.RFIDGloryView.RFID  5   7   2    ,GloryView.RFID.DeviceMigrations.NewEquipment   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      @nf1clr-namespace:GloryView.RFID.ReaderAndWriterClass     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5	      +myclr-namespace:GloryView.RFID     5   7     � 	Resources  5      $  GloryView.RFID.User.DateString   dateStrA  ;GloryView.RFID.DeviceMigrations.DeviceClass.StatusConverter  	statusStr6  0GloryView.RFID.ReaderAndWriterClass.NumberFormat 
 format��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5      .��5      � -   5         �Name$ addequipment��5       � RowDefinitions 5   
   �� 5      $
��506* �6   �� 5      $��44 �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��106 �6#   �� 5      $	��768 �6#   �� 5      $	��11* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5!      �� -   5        $��roomName��5!   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $��83��6t   $��16(�6   
���   �$��设备入库��6�   �� 5"      -   5        $��label2��5"   m   $��
类 别：��6   $��1��6#   $��29��63   $
��Left=�6?   $��	220,6,0,0q�6Z   $	��Top=�6{   $��49��6�   $��12(�6�   �� 5#      -   5        $��label3��5#   m   $��
编 号：��6   $��1��6#   $��28��63   $
��Left=�6?   $��	348,9,0,0q�6Z   $	��Top=�6{   $��48��6�   $��12(�6�   �� 5$      -   5        $
��name��5$   a   $��1��6   $��25��6&   $
��Left=�62   $��
410,13,0,0q�6M   $	��Top=�6m   $	��119��6�   �� 5%      -   5        $��button1��5%   o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
546,12,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   �� 5&      -   5        $��	comboBox1��5&   a   $��1��6   $��24��6'   $
��Left=�63   $��	267,9,0,0q�6N   $	��Top=�6r   $��75��6�   $��11(�6�   .@�5'      �� $��所有设备��6   	 �� 
IsSelected	 . 6.   �� 5(      $��	服务器��6   �� 5)      $��机柜��6   �� 5*      $��电脑��6   �� 5+      $��空调��6   5,      o� 5-      -	   5        $��menu1��5-   ^   $��1��6   $��21��6#   $
��Left=�6/   $��
622,17,0,0q�6J   $	��Top=�6k   $	��100��6�   ��6�   Z� .@�5.      m� $��设备操作功能��6   $��0,2,2,2q�6+   
 m� Icon
 5/      �� 50      $8��2/GloryView.RFID;component/Images/user/21294124.gif��6    $��12��6\   .@�52      m� -
   5        $��新设备信息录入��52      
 53      �� 54      $8��2/GloryView.RFID;component/Images/user/21294124.gif��6$   $��12��6`   56      m� 57      -   5        $��读写器录入��57      
 58      �� 59      $8��2/GloryView.RFID;component/Images/user/21294124.gif��6$   $��12��6`   5;      m� 5<      -   5        $��保修设备入库申请��5<      
 5=      �� 5>      $8��2/GloryView.RFID;component/Images/user/21294124.gif��6$   $��12��6`   5@      5A      5B      5D      &   System.Windows.Controls.DataGrid  5E   
   -   5        $��comingGrild��5E   %   $��0,46,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6}   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��Center=�6�   $��12(�6�   ��5F      �� 5G      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 5I      �� 5J       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5K      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5L      P� 5M       P� Property �@J�IsMouseOver P� Value . . �5O      ��  � ��
 ��·�6;   �� 5P       � ��
 �����6;   5Q      5S         Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
Visibility$ Hidden=�6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+6H     5W      $ 编 号��6%      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 150*	 62    6?   �� *NUMBER+  5X      $ 名 称��6%   $	 80*	 62    6>   �� *NAME+  5Y      $ 设备类别��6%   $	 80*	 63    6?   �� *	TYPE_NAME+  5Z      $ 机 房��6%   $	 80*	 62    6>   �� *	ROOM_NAME+  5[      $ 创建用户��6%   $	 80*	 63    6?   �� *	USER_NAME+  5\      $ 创建时间��6%   $
 100*	 63    6@   �� *STORAGE_TIME+ �� 	Converter# [  4
  .System.Windows.Controls.DataGridTemplateColumn
  5]      $ 操 作��6)   $	 80*	 66    
  CellTemplate 5^      �� 5_      .R�5`      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��1��6S   $��11(�6`   $
��Wrap=�6n   
��� ����� 5a   "    �Name$
 edit��6,   -   5        ���	#FFA80000 �� TextDecorations 5a   8   Z� .�6}   .�5b   &   �� $7��1/GloryView.RFID;component/Images/UIImage/edit.png��6,   $��25��6g   $��16��6r     � ToolTip$  编辑设备信息��6~   5c   #    | �� 5d   "   $ enter��6,   -   5         5d   9   Z� .�6j   .�5e   &   �� $7��1/GloryView.RFID;component/Images/UIImage/zone.png��6,   $��25��6g   $��16��6r   $  确认位置��6~   5f   #   5g      5i      5k      5m      &    GloryView.RFID.PageControl.Pager  5n   
   -   5        !  Name$
! page��5n      ���	#04000000$��1��6;   6J   5o      5p      