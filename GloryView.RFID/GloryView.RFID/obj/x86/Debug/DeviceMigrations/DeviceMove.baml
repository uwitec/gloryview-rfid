   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5      0    *GloryView.RFID.DeviceMigrations.DeviceMove   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5        � 	Resources  5      $  GloryView.RFID.User.DateString   dateStrA  ;GloryView.RFID.DeviceMigrations.DeviceClass.StatusConverter  	statusStr��%:   &	        &	        5   
   6     5   
   6   5      .��5      � -   5         �Name$ 
moveDevice��5       � RowDefinitions 5   
   �� 5      $
��503* �6   �� 5      $	��47* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��502 �6#   �� 5      $
��250* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��设备迁移��6�   �� 5      -   5        $��label3��5   l   $��
编 号：��6   $��1��6#   $��28��63   $
��Left=�6?   $��0,10,0,0q�6Z   $	��Top=�6z   $��55��6�   $��12(�6�   �� 5      -   5        $��textBox2��5   `   $��1��6   $��25��6&   $
��Left=�62   $��	52,12,0,0q�6M   $	��Top=�6p   $	��119��6�   �� 5       -   5        $��button1��5    o   $��搜  索��6   $��1��6$   $��25��64   $
��Left=�6@   $��
194,13,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   �� 5!      -   5        $��
textBlock1��5!   c   $��1��6   $��27��6(   $
��Left=�64   $��
384,15,0,0q�6O   $	��Top=�6u   $��92��6�   $��12(�6�   �� 5"      -   5        ���	#FFA70000	 �� TextDecorations	 5"   I   Z� .�6d   申请迁移6j   5#      5$      &   System.Windows.Controls.DataGrid  5%   
   -	   5        $��
removeGrid��5%   %   $��0,46,0,0q�6   
   AutoGenerateColumns
 .     CanUserAddRows .     
IsReadOnly . $��0q�6}   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��11(�6�   $��Center=�6�   ��5&      �� 5'      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 5)      �� 5*       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5+      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5,      P� 5-       P� Property �@J�IsMouseOver P� Value . . �5/      ��  � ��
 ��·�6;   �� 50       � ��
 �����6;   51      53         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 6/      
Visibility$ Hidden=�6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ID+6P     57      $ 编 号��6%   $
 100* 62    6?   �� *NUMBER+  58      $ 名 称��6%   $
 100* 62    6?   �� *NAME+  59      $ 类 别��6%   $
 100* 62    6?   �� *	TYPE_NAME+  5:      $ 机 房��6%   $
 100* 62    6?   �� *	ROOM_NAME+4	  .System.Windows.Controls.DataGridTemplateColumn	  5;      $ 操 作��6)   $	 80* 66    	  CellTemplate 5<      �� 5=      .R�5>      �� $��navigateTextBlock��6(   $��14,0,0,5q�6A   $��迁移中...��6S   $��1��6a   $��11(�6n   $
��Wrap=�6|   
���  ��5@      5A      5C        5D      $ 操作用户��6%   $
 100* 63    6@   �� *	USER_NAME+  5E      $ 入库时间��6%   $
 100* 63    6@   �� *	DATE_TIME+ �� 	Converter# [  5R      &
    GloryView.RFID.PageControl.Pager
  5S   
   -
   5         
 Name$
 page��5S      ���	#04000000$��1��6;   6J   5T      5U      