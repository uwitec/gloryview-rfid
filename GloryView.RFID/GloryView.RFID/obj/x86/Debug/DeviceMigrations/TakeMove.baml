   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5   	   9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5   	   i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5   	   .    (GloryView.RFID.DeviceMigrations.TakeMove   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:GloryView.RFID.PageControl     5   	   0ut!clr-namespace:GloryView.RFID.User     5   	   Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5   	     � Title$  申请设备迁移��5
   	    � WindowStyle$ 
ToolWindow=�6    � WindowStartupLocation$ CenterOwner=�61    � WindowState$ Normal=�5   	    � 
ResizeMode$ NoResize=�6    � AllowsTransparency .  $	��550��5   $   $	��885��61    � ShowInTaskbar .  ���	#02000000���	#FFAC0000 � 	Resources 5      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ 
take_repar��5      ��5   
   �� 5      	 �� ImageSource$1	 +/GloryView.RFID;component/Images/listBg.jpg��6   
 � RowDefinitions
 5   
   �� 5      $
��497* �6   �� 5      $	��53* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $��64 �6#   �� 5      $	��711 �6#   �� 5      $
��110* �6#   ��5      �� 5      $0	 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5!      �� -   5        $��label3��5!   n   $��
编 号：��6   $��1��6#   $��28��63   $
��Left=�6?   $��
137,10,0,0q�6Z   $	��Top=�6|   $��47��6�   $��12(�6�   �� 5"      -   5        $��textBox2��5"   a   $��1��6   $��25��6&   $
��Left=�62   $��
179,13,0,0q�6M   $	��Top=�6q   $	��119��6�   �� 5#      -   5        $��button1��5#   o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
483,14,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   �� 5$      -   5        $��label2��5$   ^   $��
类 别：��6   $��29��6#   $
��Left=�6/   $��
304,11,0,0q�6J   $	��Top=�6l   $��50��6�   $��12(�6�   $��1��6�   �� 5%      -   5        $��	comboBox1��5%   R   $��24��6   $
��Left=�6#   $��
347,14,0,0q�6>   $	��Top=�6c   $	��130��6{   $��11(�6�   $��1��6�   .@�5&      �� $��所有设备��6    �� 
IsSelected . 6.   �� 5'      $��	服务器��6   �� 5(      $��机柜��6   �� 5)      $��电脑��6   �� 5*      $��空调��6   5+      �� 5,      -   5        $��label10��5,   \   $��选择机房��6   $��24��6#   $
��Left=�6/   $��0,11,0,0q�6J   $	��Top=�6k   $��55��6�   $��11(�6�   $��1��6�   �� 5-      -	   5        $��roomBox��5-   Q   $��24��6   $
��Left=�6#   $��	52,12,0,0q�6>   $	��Top=�6`   $��87��6x   $��11(�6�   $��1��6�   5/      50      &   System.Windows.Controls.DataGrid  51   
   -
   5        $��MoveGrid��51   %   $��0,46,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6z   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��11(�6�   $��Center=�6�   ��52      �� 53      $2	 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 55      �� 56       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�57      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 58      P� 59       P� Property �@J�IsMouseOver P� Value . . �5;      ��  � ��
 ��·�6;   �� 5<       � ��
 �����6;   5=      5?         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 6/       
Visibility$  Hidden=�6P   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 69   �� *ID+6P     5C      $ 编 号��6%   $
 100* 62   ! 6?   �� *NUMBER+  5D      $ 名 称��6%   $
 100* 62   ! 6?   �� *NAME+  5E      $ 类 别��6%   $
 100* 62   ! 6?   �� *	TYPE_NAME+  5F      $ 机 房��6%   $
 100* 62   ! 6?   �� *	ROOM_NAME+  5G      $ 操作用户��6%   $
 100* 63   ! 6@   �� *	USER_NAME+  5H      $ 入库时间��6%   $
 100* 63   ! 6@   �� *STORAGE_TIME+" �� 	Converter#" [  4  .System.Windows.Controls.DataGridTemplateColumn  5I      $ 操 作��6)   $	 80* 66   #   CellTemplate# 5J      �� 5K      .R�5L      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��1��6S   $��11(�6`   $
��Wrap=�6n   
��� ����� 5M   !   $ �Name$
$ edit��6+   -   5        .�5M   K   申请迁移6Q   5N      5O      5Q      5S      &	    GloryView.RFID.PageControl.Pager	  5T   
   -   5        % 	 Name$
% page��5T      ���	#04000000$��0,1,0,0q�6;   $��1��6L   6[   5U      5V      