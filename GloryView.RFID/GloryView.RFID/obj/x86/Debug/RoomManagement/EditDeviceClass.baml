   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5   	   i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5   	   3    -GloryView.RFID.RoomManagement.EditDeviceClass   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ut!clr-namespace:GloryView.RFID.User     5   	   Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5   	     � Title$  编辑设备类别信息��5	   	    � WindowStartupLocation$ CenterOwner=�6    � AllowsTransparency .   � WindowStyle$ 
ToolWindow=�5
   $    � ShowInTaskbar .  ���	#02000000���	#FFAC0000$	��300��5   	   $	��500��6   $��12(�6"    � WindowState$ Normal=�60    � 
ResizeMode$ NoResize=�6E   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��137* �6   �� 5      $
��100* �6   �� 5      $
��137* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $	��43* �6   ��5   
   �� 5      	 �� ImageSource$W	 Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6   .+�5   
   �� 
�������$��1,1,1,0q�6&   $��1��6@   $��2��6P   $��3��6]   ._�5       �� -   5        $��typeName��5    "   $��5q�6   
�������62   5!      �� 5"   
   -   5        $��id��5"      $y�Hidden=�6   �� 5#   
   
�������$��1,1,0,0q�6&   $��2��6@   $��0,0,1,0q�6M   ._�5$      �� $��类别名称：��6   $��Right=�6$   ��5%      �� 5&      $W	 Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6!   5(      5)      �� 5*   
   -   5        $��border1��5*   �   ���	#FFB4ADAD$��1q�6)   $��4��6=   $��1��6Q   $
��Left=�6\   $��	12,64,0,0q�6w   $	��Top=�6�   $	��504��6�   �� 5+   
   -   5        $��title��5+   !   $��1,0,0,0q�6   $��4��6/   ���	#FFC20000$��20(�6Z   ��5,      �� 5-      $0	 */GloryView.RFID;component/Skin/listBox.jpg��6   5/      �� 50   
   -   5        $��button2��50   �   $��提  交��6   $��1��6    $��5��60   $��25��6>   $
��Left=�6d   $��0,29,0,0q�6   $	��Top=�6�   $��85��6�   $��11(�6�   �� 51   
   -   5        $��button1��51   �   $��取  消��6   $��2��6    $��5��60   $��25��6=   $
��Left=�6h   $��	58,29,0,0q�6�   $	��Top=�6�   $��85��6�   $��11(�6�   $��2��6�   �� 52   
   -   5        $��image1��52   I   $��38��6   $
��Left=�6   $��20,7,0,0q�67   $
��Fill=�6W   $	��Top=�6f   $��52��6~   $7��1/GloryView.RFID;component/Images/UIImage/edit.png��6�   �� 53   
   $��编辑类别名称��6   $
��Left=�6!   $��	63,15,0,2q�6<   $��2��6O   $��16(�6c   $	��129��6q   ���	#FF9400006}   �� 54   
   
�������$��1,1,0,1q�6&   $��4��6@   ._�55      �� $��创建日期：��6   $��Right=�6$   ��56      �� 57      $W	 Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6!   59      5:      �� 5;   
   
�������$��1,1,0,0q�6&   $��3��6@   ._�5<      �� $��创建用户：��6   $��Right=�6$   ��5=      �� 5>      $W	 Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6!   5@      5A      �� 5B   
   
�������$��1,1,1,1q�6&   $��4��6@   $��1��6M   $��3��6]   ._�5C      �� -   5        $��
createTime��5C      5D      �� 5E   
   
�������$��1,1,1,0q�6&   $��1��6@   $��3��6P   $��3��6]   ._�5F      �� -	   5        $��
createUser��5F      5G      5H      5I      