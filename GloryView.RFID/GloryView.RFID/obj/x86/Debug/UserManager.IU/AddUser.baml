   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5          GloryView.RFID.AddUser   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      :local(clr-namespace:GloryView.RFID.PageControl     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0ut!clr-namespace:GloryView.RFID.User     5        � 	Resources  5      )  #GloryView.RFID.User.StringConverter   userType)  #GloryView.RFID.User.StatusConverter  
userStatus$  GloryView.RFID.User.DateString  dateStr��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5      .��5      � -   5         �Name$ add_user��5       � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��467* �6   �� 5      $��38 �6    � ColumnDefinitions 5   
   �� 5      $
��190* �6   .+�5   
   � -   5        $��grid1��5      $��45��6   $	��Top=�6(   $��0,1,0,0q�6@    5      �� 5      $	��230 �6#   �� 5      $	��519 �6#   �� 5      $
��136* �6#   .+�5       �� -   5        $��label1��5    ]   $��用户管理��6   $��36��6#   $
��Left=�6/   $��	77,10,0,0q�6J   $	��Top=�6k   $	��146��6�   $��20(�6�   
�������6�   �� 5!      -   5        $��label2��5!   n   $��	帐  号:��6   $��1��6$   $��24��64   $
��Left=�6@   $��	10,15,0,0q�6[   $	��Top=�6|   $��52��6�   $��12(�6�   $��Right=�6�   
�������6�   �� 5"      -   5        $��queryAccount��5"   `   $��1��6   $��25��6&   $
��Left=�62   $��	63,16,0,0q�6M   $	��Top=�6t   $	��124��6�   �� 5#      -   5        $��label3��5#   o   $��	姓  名:��6   $��1��6$   $��24��64   $
��Left=�6@   $��
189,15,0,0q�6[   $	��Top=�6}   $��46��6�   $��12(�6�   $��Right=�6�   ���	#FFFFFCFC6�   �� 5$      -   5        $��	queryName��5$   b   $��1��6   $��25��6&   $��Right=�62   $��
0,16,165,0q�6N   $	��Top=�6s   $	��119��6�   �� 5%      $��1��6   $��452,17,24,3q�6(   $
��Wrap=�6=   �� 5&      -   5         �Name$ Details��5&       �� TextDecorations 6,   Z� .�6^   .�5'      �� $7��1/GloryView.RFID;component/Images/user/AddUser.png��6    � ToolTip$ 新增用户��6Y   5(      5)      �� 5*      -	   5        $��image1��5*   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $
��Fill=�6Z   $	��Top=�6i   $��72��6�   $<��6/GloryView.RFID;component/Images/user/managerUsers.png��6�   �� 5+      $��1��6   $��25��6(   $��
361,17,0,0q�64   $	��Top=�6H   $
��Left=�6`   $��25��6{   �� 5,      -
   5         5,      Z� .�6J   .�5-      �� $6��0/GloryView.RFID;component/Images/user/search.png��6   $ 搜索��6X   5.      5/      ��50      �� 51       �� ImageSource$8 2/GloryView.RFID;component/Images/UIImage/logBG.jpg��6    j� Stretch$
 Fill=�6^   	 j� TileMode$	 FlipXY=�6m   
 j� Viewport$
 0,0,2,32�6    j� ViewportUnits$ Absolute=�6�   53      &    GloryView.RFID.PageControl.Pager  54   
   -   5          Name$
 page��54   #   $��2��6   ��61   Z� 6I   � 55   
   $��1��6   ��56      �� 57      $0 */GloryView.RFID;component/Images/groud.jpg��6   .+�59      &   System.Windows.Controls.DataGrid  -   5        $��userData��59   3      AutoGenerateColumns .     CanUserAddRows .  $��12(�6Z      
IsReadOnly . $��0q�6z   $   HorizontalScrollBarVisibility$
 Auto=�6�    J� Opacity$ 1Q�6�      HorizontalGridLinesBrush �	#71000000��6�   Z�    RowStyle 5:      �� 5;       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5<      ��  �� Property � �� �� Value
 ��ح�67    �� Triggers 5=      P� 5>       P� Property �@J�IsMouseOver P� Value . . �5@   "   ��  � ��
 ��·�6?   �� 5A   "    � ��
 �����6?   5B      5D         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5	  /System.Windows.Controls.DataGridLengthConverter$	 30*	 65      
Visibility$ Hidden=�6X   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6A   �� *ID+6X     5H      $ 帐 号��6)   $
 100*	 66    6C   �� *	ACCOUNT+  5I      $ 姓 名��6)   $
 100*	 66    6C   �� *	USER_NAME+  5J      $ 联系电话��6)   $
 100*	 67    6D   �� *PHONE+  5K      $ 权 限��6)   $
 100*	 66    6C   �� *TYPE+ �� 	Converter# [    5L      $ 状 态��6)   $
 100*	 66    6C   �� *STATUS+# [   5M      $ 	创建者��6)   $
 100*	 66    6C   �� *NAME+  5N      $ 最近登陆时间��6)   $
 100*	 69    6F   �� *
LOGIN_TIME+# [ 4  .System.Windows.Controls.DataGridTemplateColumn  5O      $ 操 作��6-   $
 100*	 6:       CellTemplate  5P      �� 5Q      .R�5R   "   �� $��navigateTextBlock��6,   $��14,0,0,5q�6E   $��1��6W   $��11(�6d   $
��Wrap=�6r   
��� ����� 5T   #   $ Details��6-   -   5         5T   <   Z� .�6i   .�5U   %   �� $8��2/GloryView.RFID;component/Images/user/editUser.png��6+   $��25��6g   $��18��6r   $ 编辑用户信息��6~   5V   "   6.   5W      5Y      !   AlternatingRowBackground! 5[      �� 5\      $0 */GloryView.RFID;component/Images/groud.jpg��6!   5^      5_      5`      5a      