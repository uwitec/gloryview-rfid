   M S B A M L   `   `   `  ����I  EGloryView.RFID, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GloryView.RFID.UserGloryView.RFID.User  5   	   i9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass+GloryView.RFID.DeviceMigrations.DeviceClass  5   	   6    0GloryView.RFID.RoomManagement.EditWriteAndReader   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ut!clr-namespace:GloryView.RFID.User     5   	   Hst9clr-namespace:GloryView.RFID.DeviceMigrations.DeviceClass     5   	     � Title$  编辑设备信息��5	   	    � WindowStartupLocation$ CenterOwner=�6    � AllowsTransparency .   � WindowStyle$ 
ToolWindow=�5
   $    � ShowInTaskbar .  $	��350��5   	   $	��550��6   $��12(�6"    � WindowState$ Normal=�60    � 
ResizeMode$ NoResize=�6E   ��5      �� 5   
    �� ImageSource$W Q/GloryView.RFID;component/Images/user/%255II5C%7d%7e%7eZ%7bQ%29PZA1NTC%7b%60B.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��60* �6   �� 5      $
��137* �6   �� 5      $	��60* �6   �� 5      $
��137* �6   	 � RowDefinitions	 5   
   �� 5      $��70 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $	��48* �6   .+�5"   
   �� 
�������$��1,1,0,0q�6&   $��1��6@   $��1��6P   ._�5#      �� -   5        $��	numberStr��5#   :   
 �� Padding$
 5q�6.   ��6   Z� 6:   5$      �� 5%   
   -   5        $��number��5%      $y�Hidden=�6   $�� ��62   �� 5&   
   
�������$��1,1,0,0q�6&   $��1��6@   ._�5'      �� $��设备编号：��6   $��Right=�6$   5(      �� 5)   
   
�������$��1,1,0,0q�6&   $��2��6@   $��1��6P   ._�5*      �� $��设备名称：��6   $��Right=�6$   5+      �� 5,   
   
�������$��1,1,1,0q�6&   $��3��6@   $��1��6P   ._�5-      �� -   5        $��Ename��5-   5   
�������$��5q�6)   65   5.      �� 5/   
   
�������$��1,1,0,0q�6&   $��2��6@   ._�50      �� $��设备类别：��6   $��Right=�6$   51      �� 52   
   
�������$��1,1,0,0q�6&   $��1��6@   $��2��6P   ._�53      �� -   5        $��Etype��53   :   $
 5q�6.   ��6   Z� 6:   54      �� 55   
   
�������$��1,1,0,0q�6&   $��2��6@   $��2��6P   ._�56      �� $��所在机房：��6   $��Right=�6$   57      �� 58   
   
�������$��1,1,1,0q�6&   $��3��6@   $��2��6P   ._�59      �� -   5        $
��room��59   :   $
 5q�6.   ��6   Z� 6:   5:      �� 5;   
   
�������$��1,1,0,0q�6&   $��3��6@   ._�5<      �� $��IP：��6   $��Right=�6"   5=      �� 5>   
   
�������$��1,1,0,0q�6&   $��1��6@   $��3��6P   ._�5?      �� -   5        $��ip��5?   5   
�������$��5q�6)   65   5@      �� 5A   
   
�������$��1,1,0,0q�6&   $��2��6@   $��3��6P   ._�5B      �� $��	端口：��6   $��Right=�6"   5C      �� 5D   
   
�������$��1,1,1,0q�6&   $��3��6@   $��3��6P   ._�5E      �� -   5        $
��port��5E   5   
�������$��5q�6)   6A   5F      �� 5G   
   
�������$��1,1,0,0q�6&   $��4��6@   ._�5H      �� $��天线个数：��6   $��Right=�6$   5I      �� 5J   
   
�������$��1,1,0,0q�6&   $��1��6@   $��4��6P   ._�5K      �� -   5        $��
antenenSum��5K   :   $
 5q�6.   ��6   Z� 6:   5L      �� 5M   
   
�������$��1,1,0,0q�6&   $��2��6@   $��4��6P   ._�5N      �� $��	类别：��6   $��Right=�6"   5O      �� 5P   
   
�������$��1,1,1,0q�6&   $��3��6@   $��4��6P   ._�5Q      �� 
�������6   5R      �� 5S   
   
�������$��1,1,0,0q�6&   $��5��6@   ._�5T      �� $��扫描时间：��6   $��Right=�6$   5U      �� 5V   
   
�������$��1,1,0,0q�6&   $��1��6@   $��5��6P   ._�5W      �� -	   5        $��	sweepTime��5W   5   
�������$��5q�6)   6F   5X      �� 5Y   
   -
   5        $��border1��5Y   s   $��1q�6   $��4��6&   $��1��6:   $
��Left=�6E   $��	12,64,0,0q�6`   $	��Top=�6�   $	��504��6�   �� 5Z   
   -   5        $��ID��5Z   U   $�� ��6   $��65��6   $
��Left=�6'   $��	140,0,0,0q�6B   $	��Top=�6_   $��12��6w   $��20(�6�   $��3��6�   $y�Hidden=�6�   �� 5[   
   
�������$��1,1,0,0q�6&   $��2��6@   $��5��6P   ._�5\      �� $��录入用户：��6   $��Right=�6$   5]      �� 5^   
   
�������$��1,1,0,0q�6&   $��3��6@   $��5��6P   ._�5_      �� -   5        $��userName��5_   .   $
 5q�6>   ��6   Z� 6L   5`      �� 5a   
   
�������$��1,1,0,1q�6&   $��6��6@   ._�5b      �� $��录入时间：��6   $��Right=�6$   5c      �� 5d   
   
�������$��1q�6&   $��1��6:   $��6��6J   $��3��6W   ._�5e      �� -   5        $��
createTime��5e   .   $
 5q�6@   ��6   Z� 6@   5f      �� 5g   
   -   5        $��Close��5g   !   $��	关   闭��6   $��80��6B   $��25��6M   $��2��6Z   $��71,18,113,18q�6j   $��7��6�   $��2��6�   $��2��6�   $��11(�6�   �� 5h   
   -   5        $��SaveEdit��5h   �   $��	保   存��6   $��1��6!   $��7��61   $��25��6>   $
��Left=�6a   $��	25,18,0,0q�6|   $	��Top=�6�   $��80��6�   $��11(�6�   �� 5i   
   $��1��6   $��5��6$   $��22��61   $
��Left=�6=   $��94,6,0,0q�6X   $��(秒)��6j   $	��Top=�6u   $��34��6�   ���	#FFC800006�   �� 5j   
   $��4��6   ��5k      �� 5l      $0 */GloryView.RFID;component/Skin/listBox.jpg��6   5n      �� 5o   
   -   5        $��image1��5o   J   $��53��6   $
��Left=�6   $��	12,12,0,0q�67   $
��Fill=�6X   $	��Top=�6g   $��67��6   $7��1/GloryView.RFID;component/Images/UIImage/edit.png��6�   �� 5p   
   -   5        $��label1��5p   o   $��编辑设备信息��6   $��2��6!   $��41��65   $
��Left=�6A   $��	75,24,0,0q�6\   $	��Top=�6}   $	��140��6�   $��18(�6�   ���	#FF8200006�   �� 5q   
   -   5        $
��type��5q   %   $��3,4,58,2q�6   $��24��61   $	��123��6>   $��3��6J   $��4��6Z   $��11(�6g   .@�5r      �� $��出入口读写器��6   
 � Tag$ 0��6,   �� 5s      $��室内读写器��6   $ 1��6+   5t      5u      5v      