   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      Y1clr-namespace:GloryView.RFID.RoomManagement.Rooms#GloryView.RFID.RoomManagement.Rooms  5      Y1clr-namespace:GloryView.RFID.ReaderAndWriterClass#GloryView.RFID.ReaderAndWriterClass  5	      (    "GloryView.RFID.RoomManagement.Room   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      @rm1clr-namespace:GloryView.RFID.RoomManagement.Rooms     5      @nf1clr-namespace:GloryView.RFID.ReaderAndWriterClass     5	        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr<  6GloryView.RFID.RoomManagement.Rooms.EquipmentConverter  	statusStr8  2GloryView.RFID.RoomManagement.Rooms.MainsConverter  mainsStr6  0GloryView.RFID.ReaderAndWriterClass.NumberFormat 
 format��%t   &	        &	      &	 &     &	 9       5   
   6     5   
   6      5   
   6     5   
   6   5      .��5      � -   5         �Name$ add_Equ��5       � RowDefinitions 5   
   �� 5      $
��498* �6   �� 5      $	��52* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��181 �6#   �� 5      $
��704* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��175��6t   $��16(�6�   
���   �6�   �� 5       -   5        $��roomId��5    b   $��1��6   $��43��6(   $
��Left=�64   $��	689,2,0,0q�6O   $�� ��6p   $	��Top=�6x   $��13��6�   $y�Hidden=�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��roomEquipment��5"   %   $��0,48,0,0q�6   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     
IsReadOnly . $��0q�6   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��12(�6�      RowStyle 5#      �� 5$       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5%      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5&      P� 5'       P� Property �@J�IsMouseOver P� Value . . �5)      ��  � ��
 ��·�6;   �� 5*       � ��
 �����6;   5+      5-      ��5/      �� 50      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
Visibility$ Hidden=�6H   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 61   �� *ID+6H     54      $ TYPE_ID��6%   $ Hidden=�6Z    66   �� *DEVICE_CLASS_ID+6Z     55      $ 设备编号��6%      Width5
  /System.Windows.Controls.DataGridLengthConverter$
 150*
 63    6@   �� *NUMBER+  56      $ 设备名称��6%   $
 100*
 63    6@   �� *NAME+  57      $ 设备类别��6%   $
 100*
 63    6@   �� *	TYPE_NAME+  58      $ 所在机房��6%   $	 80*
 63    6?   �� *	ROOM_NAME+  59      $ 录入用户��6%   $
 100*
 63    6@   �� *	USER_NAME+  5:      $ 录入时间��6%   $
 100*
 63    6@   �� *STORAGE_TIME+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5;      $ 操 作��6)   $	 80*
 66      CellTemplate 5<      �� 5=      .R�5>      �� $��navigateTextBlock��6(   $��1��6A   $��11(�6N   $
��Wrap=�6\   
��� ��� �� Padding$ 2,2,0,0q�6�   �� 5?   !    �Name$ Details��6+   -   5         �� TextDecorations 5?   ;   Z� .�6l   .�5@   %   �� $:��4/GloryView.RFID;component/Images/UIImage/publish.png��6+   $��25��6i   $��18��6t    � ToolTip$ 查看详细信息��6�   5A   "    �� 5B   "   $
 Edit��6,   -   5         5B   9   Z� .�6g   .�5C   &   �� $7��1/GloryView.RFID;component/Images/UIImage/edit.png��6,   $��25��6g   $��18��6r   $ 编辑设备信息��6~   5D   #   5E      5G      5I      5K      &    GloryView.RFID.PageControl.Pager  5L   
   -   5           Name$
  page��5L      ���	#04000000$��1��6;   6J   5M      5N      