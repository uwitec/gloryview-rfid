   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      Y1clr-namespace:GloryView.RFID.RoomManagement.Rooms#GloryView.RFID.RoomManagement.Rooms  5      Y1clr-namespace:GloryView.RFID.ReaderAndWriterClass#GloryView.RFID.ReaderAndWriterClass  5	      1    +GloryView.RFID.RoomManagement.EquipmentList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      @rm1clr-namespace:GloryView.RFID.RoomManagement.Rooms     5      @nf1clr-namespace:GloryView.RFID.ReaderAndWriterClass     5	        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr<  6GloryView.RFID.RoomManagement.Rooms.EquipmentConverter  	statusStr8  2GloryView.RFID.RoomManagement.Rooms.MainsConverter  mainsStr6  0GloryView.RFID.ReaderAndWriterClass.NumberFormat 
 format��%t   &	        &	      &	 &     &	 9       5   
   6     5   
   6      5   
   6     5   
   6   5      .��5      � -   5         �Name$ cateGrid��5       � RowDefinitions 5   
   �� 5      $
��503* �6   �� 5      $	��47* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��506 �6#   �� 5      $
��246* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5       �� -   5        $��roomName��5    L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��设备列表��6�   �� 5!      -   5        $��label2��5!   l   $��
类 别：��6   $��1��6#   $��29��63   $
��Left=�6?   $��5,11,0,0q�6Z   $	��Top=�6z   $��52��6�   $��12(�6�   �� 5"      -   5        $��label3��5"   _   $��1��6   $��25��6$   $
��Left=�60   $��
184,0,0,11q�6K   $��Bottom=�6m   $��44��6�   $��12(�6�   $��
编 号：��6�   �� 5#      -   5        $��button1��5#   o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
362,11,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   6�   �� 5$      -   5        $
��type��5$   a   $��1��6   $��24��6'   $
��Left=�63   $��	54,12,0,0q�6N   $	��Top=�6m   $	��129��6�   $��11(�6�   5&      �� 5'      -   5        $��number��5'   a   $��1��6   $��25��6&   $
��Left=�62   $��
234,11,0,0q�6M   $	��Top=�6o   $	��122��6�   5(      &   System.Windows.Controls.DataGrid  5)   
   -	   5        $��	equipment��5)   %   $��0,48,0,0q�6   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     
IsReadOnly . $��0q�6{   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��12(�6�      RowStyle 5*      �� 5+       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5,      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5-      P� 5.       P� Property �@J�IsMouseOver P� Value . . �50      ��  � ��
 ��·�6;   �� 51       � ��
 �����6;   52      54      ��56      �� 57      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
Visibility$ Hidden=�6H   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 61   �� *ID+6H     5;      $ 设备编号��6%      Width5
  /System.Windows.Controls.DataGridLengthConverter$
 150*
 63    6@   �� *NUMBER+  5<      $ 设备名称��6%   $
 100*
 63    6@   �� *NAME+  5=      $ 类 别��6%   $
 100*
 62    6?   �� *	TYPE_NAME+  5>      $ 所在机房��6%   $
 100*
 63    6@   �� *	ROOM_NAME+  5?      $ 创建时间��6%   $
 100*
 63    6@   �� *STORAGE_TIME+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5@      $ 操 作��6)   $
 100*
 66      CellTemplate 5A      �� 5B      .R�5C      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��1��6S   $��11(�6`   $
��Wrap=�6n   
��� ����� 5E   #    �Name$ Details��6-   -
   5         �� TextDecorations 5E   =   Z� .�6r   .�5F   %   �� $:��4/GloryView.RFID;component/Images/UIImage/publish.png��6+   $��25��6i   $��18��6t    � ToolTip$ 查看详细信息��6�   5G   "   5H      5J      5L      5N      &    GloryView.RFID.PageControl.Pager  5O   
   -   5          Name$
 page��5O      ���	#04000000$��1��6;   6J   5P      5Q      