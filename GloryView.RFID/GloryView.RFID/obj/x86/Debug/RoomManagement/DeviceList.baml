   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      .    (GloryView.RFID.RoomManagement.DeviceList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5        � 	Resources  5
      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��503* �6   �� 5      $	��47* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��580 �6#   �� 5      $
��172* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,8,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��设备盘点��6�   �� 5      -   5        $��label2��5   l   $��起始日期��6   $��1��6#   $��26��63   $
��Left=�6?   $��5,14,0,0q�6Z   $	��Top=�6z   $��65��6�   $��12(�6�   �� 5      -   5        $��button1��5   o   $��搜  索��6   $��1��6$   $��26��64   $
��Left=�6@   $��
214,15,0,0q�6[   $	��Top=�6~   $��56��6�   $��11(�6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��datePicker1��5   c   $��1��6   $��23��6)   $
��Left=�65   $��	71,15,0,0q�6P   $	��Top=�6v   $	��137��6�   $��11(�6�      DisplayDate$ 	8/19/2013��6�   �� 5      -   5        $��button2��5   o   $��打  印��6   $��1��6$   $��26��64   $
��Left=�6@   $��
302,14,0,0q�6[   $	��Top=�6~   $��60��6�   $��11(�6�   �� 5       -   5        $��button3��5    o   $��导出数据��6   $��1��6$   $��27��64   $
��Left=�6@   $��
378,13,0,0q�6[   $	��Top=�6~   $��62��6�   $��11(�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��stock��5"   %   $��0,48,0,0q�6   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     
IsReadOnly . $��0q�6w   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�   $��11(�6�      RowStyle 5#      �� 5$       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5%      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5&      P� 5'       P� Property �@J�IsMouseOver P� Value . . �5)      ��  � ��
 ��·�6;   �� 5*       � ��
 �����6;   5+      5-      ��5/      �� 50      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 30* 61      
Visibility$ Hidden=�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *ID+6T     54      $ 盘点日期��6%   $
 100* 63    6@   �� *	EDIT_TIME+ �� 	Converter# [    55      $ 盘点人员��6%   $
 100* 63    6@   �� *	TYPE_NAME+  56      $ 盘点统计��6%   $
 100* 63    6@   �� *	TYPE_NAME+  57      $ 盘点开始时间��6%   $
 100* 65    6B   �� *	EDIT_TIME+# [    58      $ 盘点结束时间��6%   $
 100* 65    6B   �� *CREATE_TIME+# [  4	  .System.Windows.Controls.DataGridTemplateColumn	  59      $ 操 作��6)   $
 100* 66    	  CellTemplate 5:      �� 5;      .R�5<      �� $��button2��6[   $��详  情��6%   $��22��64   $
��Left=�6@   $	��Top=�6j   $��74��6�   $��11(�6�   $��0q�6�   ���	#FF008300��6�   Z� ��6�   Z� 6�   5=      5@      5B      &
    GloryView.RFID.PageControl.Pager
  5C   
   -	   5         
 Name$
 page��5C      ���	#04000000$��1��6;   6J   5D      5E      