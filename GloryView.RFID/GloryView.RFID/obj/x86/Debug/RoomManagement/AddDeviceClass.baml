   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5   	   i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5   	   2    ,GloryView.RFID.RoomManagement.AddDeviceClass   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ut!clr-namespace:GloryView.RFID.User     5   	   Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5   	     � Title$  添加用户��5	   	    � WindowStartupLocation$ CenterOwner=�6    � AllowsTransparency .   � WindowStyle$ 
ToolWindow=�5
   $    � ShowInTaskbar .  ���	#02000000���	#FFAC0000$	��250��5   	   $	��450��6   $��12(�6"    � WindowState$ Normal=�60    � 
ResizeMode$ NoResize=�6E   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��102* �6   �� 5      $
��112* �6   �� 5      $	��90* �6   �� 5      $
��124* �6    � RowDefinitions 5   
   �� 5      $��58 �6   �� 5      $��42 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $	��21* �6   ��5   
   �� 5      	 �� ImageSource$W	 Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6   .+�5   
   �� 
�������$��1q�6&   $��2��6:   ._�5      �� $��类别名称：��6   $��Right=�6$   ��5       �� 5!      $W	 Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6!   5#      5$      �� 5%   
   
�������$��1q�6&   $��2��6:   $��3��6G   $��0,0,1,0q�6[   $��1��6l   ._�5&      �� -   5        $��typeName��5&   5   
�������$��5q�6)   65   5'      �� 5(   
   -   5        $��border1��5(   �   ���	#FFB4ADAD$��1q�6)   $��4��6=   $��0��6Q   $
��Left=�6\   $��12,6,0,0q�6w   $	��Top=�6�   $	��404��6�   $��1��6�   �� 5)   
   -   5        $��title��5)   !   $��1,0,0,0q�6   $��4��6/   ���	#FFC20000$��20(�6Z   ��5*      �� 5+      $0	 */GloryView.RFID;component/Skin/listBox.jpg��6   5-      �� 5.   
   -   5        $��button2��5.   g   $��提  交��6   $��4��6    $��25��6.   $
��Left=�6L   $	��Top=�6v   $��75��6�   $��11(�6�   $��1��6�   �� 5/   
   -   5        $��button1��5/   �   $��取  消��6   $��2��6    $��4��60   $��24��6=   $
��Left=�6^   $��15,0,0,0q�6y   $	��Top=�6�   $��75��6�   $��11(�6�   �� 50   
   -   5        $��image1��50   J   $��41��6   $
��Left=�6   $��	21,13,0,0q�67   $
��Fill=�6X   $	��Top=�6g   $��51��6   $3��-/GloryView.RFID;component/Images/user/add.png��6�   �� 51   
   -   5        $��label1��51   o   $��添加设备类别��6   $��3��6!   $��30��65   $
��Left=�6A   $��	67,21,0,0q�6\   $	��Top=�6}   $	��158��6�   $��16(�6�   ���	#FF840000��6�   Z� 6�   52      53      