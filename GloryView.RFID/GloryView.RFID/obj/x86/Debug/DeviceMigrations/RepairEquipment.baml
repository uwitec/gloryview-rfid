   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5      5    /GloryView.RFID.DeviceMigrations.RepairEquipment   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ apply_repair��5      .+�5   
   �  � RowDefinitions 5      �� 5      $
��497* �6    �� 5      $	��53* �6    .+�5      � -   5        $��grid1��5      $��47��6   $	��Top=�6,   $��0,1,0,0q�6D    � ColumnDefinitions 5      �� 5      $	��124 �6'   �� 5      $	��651 �6'   �� 5      $
��110* �6'   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6!    j� Stretch$
 Fill=�6Z    j� TileMode$ FlipXY=�6i    j� Viewport$ 0,0,247,438�6{    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   P   $��36��6   $
��Left=�6$   $��6,7,0,0q�6?   $	��Top=�6`   $	��118��6x   $��16(�6�   
���   �$��报修列表��6�   �� 5      -   5        $��label3��5   r   $��
编 号：��6   $��1��6'   $��28��67   $
��Left=�6C   $��
147,11,0,0q�6^   $	��Top=�6�   $��47��6�   $��12(�6�   �� 5      -   5        $��textBox2��5   e   $��1��6   $��25��6*   $
��Left=�66   $��
192,14,0,0q�6Q   $	��Top=�6u   $	��119��6�   �� 5       -   5        $��button1��5    s   $��搜  索��6   $��1��6(   $��25��68   $
��Left=�6D   $��
501,14,0,0q�6_   $	��Top=�6�   $��56��6�   $��11(�6�   �� 5!      -   5        $��label2��5!   b   $��
类 别：��6   $��29��6'   $
��Left=�63   $��
317,12,0,0q�6N   $	��Top=�6p   $��50��6�   $��12(�6�   $��1��6�   �� 5"      -   5        $��	comboBox1��5"   V   $��24��6   $
��Left=�6'   $��
365,15,0,0q�6B   $	��Top=�6g   $	��130��6   $��11(�6�   $��1��6�   .@�5#      �� $��所有设备��6#   	 �� 
IsSelected	 . 62   �� 5$      $��	服务器��6#   �� 5%      $��机柜��6#   �� 5&      $��电脑��6#   �� 5'      $��空调��6#   5(      �� 5)      -	   5        $��label10��5)   `   $��选择机房��6   $��24��6'   $
��Left=�63   $��0,11,0,0q�6N   $	��Top=�6o   $��55��6�   $��11(�6�   $��1��6�   �� 5*      -
   5        $��roomBox��5*   U   $��24��6   $
��Left=�6'   $��	54,13,0,0q�6B   $	��Top=�6d   $��87��6|   $��11(�6�   $��1��6�   5,      �� 5-      -   5        $��
textBlock1��5-   g   $��1��6   $��25��6,   $
��Left=�68   $��
582,18,0,0q�6S   $	��Top=�6y   $��69��6�   $��12(�6�   �� 5.      -   5        
 �Name$
 Repair��5.      ���	#FFA70000 �� TextDecorations 6)   Z� .�6p   申请报修6v   5/      50      &   System.Windows.Controls.DataGrid  51      -   5        $��repair_Grid��51   )   $��0,46,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6�   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��11(�6�   $��Center=�6�   ��52      �� 53      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6!   $
 None=�6\   $
 Tile=�6k   $ 	0,0,48,48�6{   $ Absolute=�6�      RowStyle 55      �� 56       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�57      ��  �� Property � �� �� Value
 ��ح�67    �� Triggers 58      P� 59       P� Property �@J�IsMouseOver P� Value . . �5;   "   ��  � ��
 ��·�6?   �� 5<   "    � ��
 �����6?   5=      5?         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 63      
Visibility$ Hidden=�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *ID+6T     5C      $ 编 号��6)   $
 100* 66    6C   �� *ID+  5D      $ 名 称��6)   $
 100* 66    6C   �� *NAME+  5E      $ 类 别��6)   $
 100* 66    6C   �� *	TYPE_NAME+  5F      $ 机 房��6)   $
 100* 66    6C   �� *	ROOM_NAME+4  .System.Windows.Controls.DataGridTemplateColumn  5G      $ 报修状态��6-   $	 80* 6;      CellTemplate 5H      �� 5I      .R�5J   "   �� $��navigateTextBlock��6,   $��14,0,0,5q�6E   $��1��6W   $��11(�6d   $
��Wrap=�6r   
���  ��报修中...5L   #   5N      5P        5Q      $ 操作用户��6)   $
 100* 67    6D   �� *	USER_NAME+  5S      $ 申请时间��6)   $
 100* 67    6D   �� *	DATE_TIME+ �� 	Converter# [  5a      &	    GloryView.RFID.PageControl.Pager	  5b      -   5         	 Name$
 page��5b      ���	#04000000$��0,1,0,0q�6?   $��1��6P   6_   5c      5d      5e      