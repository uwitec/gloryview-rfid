   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5      8    2GloryView.RFID.DeviceMigrations.EquipmentScrapping   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ 	scrapping��5       � RowDefinitions 5   
   �� 5      $
��497* �6   �� 5      $	��53* �6   .+�5   
   � -   5        $��grid1��5      $��0,1,0,0q�6   $��47��6-   $	��Top=�69    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��561 �6#   �� 5      $
��191* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��报废设备��6�   �� 5      -   5        $��label2��5   l   $��
类 别：��6   $��1��6#   $��29��63   $
��Left=�6?   $��5,11,0,0q�6Z   $	��Top=�6z   $��49��6�   $��12(�6�   �� 5      -   5        $��button1��5   o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
353,16,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   �� 5      -   5        $��	comboBox1��5   a   $��1��6   $��24��6'   $
��Left=�63   $��	52,14,0,0q�6N   $	��Top=�6r   $	��130��6�   $��11(�6�   .@�5       �� $��所有设备��6   	 �� 
IsSelected	 . 6.   �� 5!      $��	服务器��6   �� 5"      $��机柜��6   �� 5#      $��电脑��6   �� 5$      $��空调��6   5%      �� 5&      -   5        $��label1��5&   n   $��
编 号：��6   $��1��6#   $��26��63   $
��Left=�6?   $��
188,16,0,0q�6Z   $	��Top=�6|   $��48��6�   $��11(�6�   �� 5'      -   5        $��textBox1��5'   a   $��1��6   $��25��6&   $
��Left=�62   $��
233,15,0,0q�6M   $	��Top=�6q   $	��114��6�   �� 5(      -	   5        $��
textBlock1��5(   c   $��1��6   $��26��6(   $
��Left=�64   $��
486,18,0,0q�6O   $	��Top=�6u   $��75��6�   �� 5)      -
   5        ���	#FFA70000$��12(�5)   c   
 �� TextDecorations
 61   Z� .�6q   申请报废6w   5*      5+      &   System.Windows.Controls.DataGrid  5,   
   -   5        $��	scrapGrid��5,   %   $��0,46,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6{   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��11(�6�   $��Center=�6�   ��5-      �� 5.      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 50      �� 51       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�52      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 53      P� 54       P� Property �@J�IsMouseOver P� Value . . �56      ��  � ��
 ��·�6;   �� 57       � ��
 �����6;   58      5:         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 6/      
Visibility$ Hidden=�6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ID+6P     5>      $ 编 号��6%   $
 100* 62    6?   �� *NUMBER+  5?      $ 名 称��6%   $
 100* 62    6?   �� *NAME+  5@      $ 类 别��6%   $
 100* 62    6?   �� *	TYPE_NAME+  5A      $ 机 房��6%   $
 100* 62    6?   �� *	ROOM_NAME+4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ 操 作��6)   $	 80* 66      CellTemplate 5C      �� 5D      .R�5E      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��1��6S   $��报废中...��6`   $��11(�6n   $
��Wrap=�6|   
���  ��5G      5H      5J        5K      $ 操作用户��6%   $
 100* 63    6@   �� *	USER_NAME+  5L      $ 入库时间��6%   $
 100* 63    6@   �� *	DATE_TIME+ �� 	Converter# [  5Y      &	    GloryView.RFID.PageControl.Pager	  5Z   
   -   5         	 Name$
 page��5Z      ���	#04000000$��0,1,0,0q�6;   $��1��6L   6[   5[      5\      