   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      Y1clr-namespace:GloryView.RFID.ReaderAndWriterClass#GloryView.RFID.ReaderAndWriterClass  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5	      i9clr-namespace:GloryView.RFID.SystemManagement.SystemClass+GloryView.RFID.SystemManagement.SystemClass  5
      /clr-namespace:GloryView.RFIDGloryView.RFID  5   7   5    /GloryView.RFID.SystemManagement.MovedDevicesLog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      @nf1clr-namespace:GloryView.RFID.ReaderAndWriterClass     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5	      Isys9clr-namespace:GloryView.RFID.SystemManagement.SystemClass     5
      +myclr-namespace:GloryView.RFID     5   7     � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr)  #GloryView.RFID.User.StringConverter  userType@  :GloryView.RFID.SystemManagement.SystemClass.OperateTypeStr  opertypeStr��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��48* �6   �� 5      $
��452* �6   �� 5      $	��50* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $
��222* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5       �� -   5        $��roomName��5    L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��迁移设备日记��6�   �� 5!      -   5        $��label2��5!   i   $	��起��6   $��1��6    $��23��60   $
��Left=�6<   $��9,11,0,0q�6W   $	��Top=�6w   $��25��6�   $��11(�6�   (  "System.Windows.Controls.DatePicker  5"      -   5        $��datePicker1��5"   c   $��1��6   $��24��6)   $
��Left=�65   $��	32,11,0,0q�6P   $	��Top=�6v   $	��118��6�   $��11(�6�   �� 5#      -   5        $��label3��5#   k   $	��到��6   $��1��6    $��23��60   $
��Left=�6<   $��
151,11,0,0q�6W   $	��Top=�6y   $��25��6�   $��11(�6�     5$      -   5        $��datePicker2��5$   d   $��1��6   $��23��6)   $
��Left=�65   $��
174,11,0,0q�6P   $	��Top=�6w   $	��119��6�   $��11(�6�   ��6�   Z� 6�   �� 5%      -   5        $��button1��5%   n   $��搜 索��6   $��1��6#   $��24��63   $
��Left=�6?   $��
299,11,0,0q�6Z   $	��Top=�6}   $��44��6�   $��11(�6�   5&      &   System.Windows.Controls.DataGrid  5'   
   -   5        $��EquiplogGrid��5'         AutoGenerateColumns .  	   CanUserAddRows	 .  
   
IsReadOnly
 . $��0q�6l   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��Center=�6�   $��12(�6�   $��1��6�   ��5(      �� 5)      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 5+      �� 5,       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5-      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5.      P� 5/       P� Property �@J�IsMouseOver P� Value . . �51      ��  � ��
 ��·�6;   �� 52       � ��
 �����6;   53      55         Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
Visibility$ Hidden=�6H   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 61   �� *ID+6H     59      $	 EID��6%   $ Hidden=�6S    62   �� *EQUIPMENT_ID+6S     5:      $ 设备编号��6%      Width5
  /System.Windows.Controls.DataGridLengthConverter$
 150*
 63    6@   �� *NUMBER+  5;      $ 设备类别��6%   $	 80*
 63    6?   �� *	TYPE_NAME+  5<      $ 历史机房��6%   $	 80*
 63    6?   �� *	ROOM_NAME+  5=      $ 操作类型��6%   $	 80*
 63    6?   �� *TYPE+ �� 	Converter# [   5>      $ 操作用户��6%   $	 80*
 63    6?   �� *	ACCOUNT+  5?      $ 操作时间��6%   $	 80*
 63    6?   �� *	DATE_TIME+# [  4  .System.Windows.Controls.DataGridTemplateColumn  5@      $ 操 作��6)   $	 80*
 66      CellTemplate 5A      �� 5B      .R�5C      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��1��6S   $��11(�6`   $
��Wrap=�6n   
��� ����� 5D   "    �Name$ HistoryOrder��6,   -	   5        ���	#FFA80000 �� TextDecorations 5D   @   Z� .�6�   .�5E   &   �� $:��4/GloryView.RFID;component/Images/UIImage/publish.png��6,   $��25��6j   $��16��6u    � ToolTip$ 详细信息��6�   5F   #   5G      5I      5K      5M      &    GloryView.RFID.PageControl.Pager  5N   
   -
   5          Name$
 page��5N      ���	#04000000$��2��6;   6J   5O      5P      