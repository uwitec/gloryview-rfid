   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GloryView.RFID.PageControlGloryView.RFID.PageControl  5      9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5      Y1clr-namespace:GloryView.RFID.ReaderAndWriterClass#GloryView.RFID.ReaderAndWriterClass  5      i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5	      /clr-namespace:GloryView.RFIDGloryView.RFID  5   7   0    *GloryView.RFID.SystemManagement.AllUserLog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GloryView.RFID.PageControl     5      0ut!clr-namespace:GloryView.RFID.User     5      @nf1clr-namespace:GloryView.RFID.ReaderAndWriterClass     5      Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5	      +myclr-namespace:GloryView.RFID     5   7     � 	Resources  5      $  GloryView.RFID.User.DateString   dateStrA  ;GloryView.RFID.DeviceMigrations.DeviceClass.StatusConverter  	statusStr)  #GloryView.RFID.User.StringConverter  userType��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��48 �6   �� 5      $
��456* �6   �� 5      $	��46* �6   .+�5   
   � -   5        $��grid1��5      $��47��6   $	��Top=�6(   $��0,1,0,0q�6@    � ColumnDefinitions 5      �� 5      $	��133 �6#   �� 5      $
��222* �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6    j� Stretch$
 Fill=�6V    j� TileMode$ FlipXY=�6e    j� Viewport$ 0,0,247,438�6w    j� ViewportUnits$ Absolute=�6�   .+�5      �� -   5        $��roomName��5   L   $��36��6   $
��Left=�6    $��6,6,0,0q�6;   $	��Top=�6\   $	��118��6t   $��16(�6�   
���   �$��用户日记��6�   �� 5       -   5        $��label1��5    l   $��用户名：��6   $��1��6#   $��23��63   $
��Left=�6?   $��0,10,0,0q�6Z   $	��Top=�6z   $��59��6�   $��11(�6�   �� 5!      -   5        $��textBox1��5!   `   $��1��6   $��24��6&   $
��Left=�62   $��	54,10,0,0q�6M   $	��Top=�6p   $	��116��6�   �� 5"      -   5        $��label2��5"   k   $	��起��6   $��1��6    $��23��60   $
��Left=�6<   $��
176,11,0,0q�6W   $	��Top=�6y   $��25��6�   $��11(�6�   (  "System.Windows.Controls.DatePicker  5#      -   5        $��datePicker1��5#   d   $��1��6   $��24��6)   $
��Left=�65   $��
207,10,0,0q�6P   $	��Top=�6w   $	��118��6�   $��11(�6�   �� 5$      -   5        $��label3��5$   k   $	��到��6   $��1��6    $��23��60   $
��Left=�6<   $��
329,11,0,0q�6W   $	��Top=�6y   $��25��6�   $��11(�6�     5%      -   5        $��datePicker2��5%   d   $��1��6   $��23��6)   $
��Left=�65   $��
360,11,0,0q�6P   $	��Top=�6w   $	��119��6�   $��11(�6�   �� 5&      -	   5        $��button1��5&   n   $��搜 索��6   $��1��6#   $��24��63   $
��Left=�6?   $��
486,11,0,0q�6Z   $	��Top=�6}   $��44��6�   $��11(�6�   5'      &   System.Windows.Controls.DataGrid  5(   
   -
   5        $��logGrid��5(         AutoGenerateColumns .  	   CanUserAddRows	 .  
   
IsReadOnly
 . $��0q�6g   $   HorizontalScrollBarVisibility$
 Auto=�6{    J� Opacity$ 1Q�6�   $��Center=�6�   $��12(�6�   $��1��6�   ��5)      �� 5*      $2 ,/GloryView.RFID;component/Skin/blueprint.png��6   $
 None=�6X   $
 Tile=�6g   $ 	0,0,48,48�6w   $ Absolute=�6�      RowStyle 5,      �� 5-       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5.      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5/      P� 50       P� Property �@J�IsMouseOver P� Value . . �52      ��  � ��
 ��·�6;   �� 53       � ��
 �����6;   54      56         Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
Visibility$ Hidden=�6H   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 61   �� *ID+6H     5:      $ 帐 号��6%      Width5
  /System.Windows.Controls.DataGridLengthConverter$	 80*
 62    6>   �� *	ACCOUNT+  5;      $ 	用户名��6%   $	 80*
 62    6>   �� *	USER_NAME+  5<      $ 权 限��6%   $	 80*
 62    6>   �� *TYPE+ �� 	Converter# [   5=      $ 登录时间��6%   $	 80*
 63    6?   �� *
LOGIN_TIME+# [    5>      $ 退出时间��6%   $	 80*
 63    6?   �� *	EXIT_TIME+# [    5?      $ 创建时间��6%   $	 80*
 63    6?   �� *CREATE_TIME+# [  5A      &    GloryView.RFID.PageControl.Pager  5B   
   -   5          Name$
 page��5B      ���	#04000000$��2��6;   6J   5C   
   5D      