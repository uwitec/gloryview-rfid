   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      /    )GloryView.RFID.RoomManagement.DeviceClass   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5        � 	Resources  5
      $  GloryView.RFID.User.DateString   dateStr��%   &	          5   
   6   5      .��5      � -   5         �Name$ device_class��5       � RowDefinitions 5   
   �� 5      $
��501* �6   �� 5      $	��49* �6   .+�5   
   � $��47��6   $	��Top=�6   $��0,1,0,0q�63    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $	��359 �6#   �� 5      $
��393* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��设备类别��6�   �� 5      -   5        $��
textBlock1��5   W   $��1��6   $
��Left=�6(   $��
172,10,0,0q�6C   $	��Top=�6i   �� 5      -   5        	 �Name$	 Details��5      
 �� TextDecorations
 6,   Z� .�6\   .�5      �� $3��-/GloryView.RFID;component/Images/user/add.png��6   $��30��6R   $��30��6]    � ToolTip$ 添加设备类别��6i   5      5       5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��
deviceData��5"   /      AutoGenerateColumns .     CanUserAddRows .  $��0,49,0,0q�6X   $��12(�6j      
IsReadOnly . $��0q�6�   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�      RowStyle 5#      �� 5$       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5%      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5&      P� 5'       P� Property �@J�IsMouseOver P� Value . . �5)      ��  � ��
 ��·�6;   �� 5*       � ��
 �����6;   5+      5-      ��5/      �� 50      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 30* 61      
Visibility$ Hidden=�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *ID+6T     54      $ 设备类别��6%   $
 100* 63    6@   �� *	TYPE_NAME+  55      $ 创建用户��6%   $
 100* 63    6@   �� *CREATE_USER+  56      $ 编辑用户��6%   $
 100* 63    6@   �� *
EDITE_USER+  57      $ 编辑时间��6%   $
 100* 63    6@   �� *	EDIT_TIME+ �� 	Converter# [    58      $ 创建时间��6%   $
 100* 63    6@   �� *CREATE_TIME+# [  4  .System.Windows.Controls.DataGridTemplateColumn  59      $ 操 作��6)   $
 100* 66      CellTemplate 5:      �� 5;      .R�5<      �� $��navigateTextBlock��6(   $��1��6A   $��11(�6N   $
��Wrap=�6\   
��� ��� �� Padding$ 2,2,0,0q�6�   �� 5=   !   $	 Details��6+   -   5        
 5=   ;   Z� .�6o   .�5>   %   �� $7��1/GloryView.RFID;component/Images/UIImage/edit.png��6+   $��25��6f   $��18��6q   $ 编辑信息��6}   5?   "   5@      5A      5C      5E      &	    GloryView.RFID.PageControl.Pager	  5G   
   -   5          	 Name$
  page��5G      ���	#04000000$��1��6;   6J   5H      5I      