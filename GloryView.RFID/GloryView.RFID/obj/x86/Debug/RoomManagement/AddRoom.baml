   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      +    %GloryView.RFID.RoomManagement.AddRoom   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5        � 	Resources  5
      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ add_room��5       � RowDefinitions 5   
   �� 5      $
��503* �6   �� 5      $	��47* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��421 �6#   �� 5      $
��331* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��机房列表��6�   �� 5      -   5        $��image1��5   _   $��1��6   $��25��6$   $
��Left=�60   $��
367,10,0,0q�6K   $
��Fill=�6m   $	��Top=�6|   $��41��6�   $.��(/GloryView.RFID;component/Skin/house.png��6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��roomDate��5   %   $��0,49,0,0q�6   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  $��12(�6i      
IsReadOnly . $��0q�6�   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�      AlternatingRowBackground 6�   Z� ��5      �� 5       $4 ./GloryView.RFID;component/Images/blueprint.png��6   $
 None=�6Z   $
 Tile=�6i   $ 	0,0,48,48�6y   $ Absolute=�6�      RowStyle 5"      �� 5#       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5$      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5%      P� 5&       P� Property �@J�IsMouseOver P� Value . . �5(      ��  � ��
 ��·�6;   �� 5)       � ��
 �����6;   5*      5,         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5 61      
Visibility$ Hidden=�6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ID+6R     51      $ 	机房名��6%   $
 100* 62    6?   �� *	ROOM_NAME+  52      $ 用 途��6%   $
 100* 62    6?   �� *	PURPOSE+  53      $ 所属单位��6%   $
 100* 63    6@   �� *	BELONGS+  54      $ 所在楼层��6%   $
 100* 63    6@   �� *FLOOR+  55      $ 创建用户��6%   $
 100* 63    6@   �� *	USER_NAME+  56      $ 创建时间��6%   $
 100* 63    6@   �� *CREATION_DATE+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  57      $ 操 作��6)   $
 100* 66      CellTemplate 58      �� 59      .R�5:      �� $��button2��6]   -   5        $��编 辑��5:   %   $��22��63   $��Center=�6@   $	��Top=�6l   $��69��6�   $��0q�6�   $��11(�6�   ��6�   Z� 6�   5;      5=      5?      &	    GloryView.RFID.PageControl.Pager	  5@   
   -   5         	 Name$
 page��5@      $��1��6$   ���	#040000006J   5A      5B      