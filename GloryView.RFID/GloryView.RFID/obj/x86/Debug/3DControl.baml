   M S B A M L   `   `   `  ����I  E3DTools, Version=1.0.2614.20437, Culture=neutral, PublicKeyToken=null4'clr-namespace:_3DTools;assembly=3DTools_3DTools  5       GloryView.RFID   GloryView.RFID._3DControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <_3DTools'clr-namespace:_3DTools;assembly=3DTools     5      .��5	      � 
��� � �  � RowDefinitions  5
   
   �� 5      $��47 �6   �� 5      $
��495* �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��900* �6   .+�5   
   �� -   5        $��listBox��5      $��2��6!   $��0��62   
����� �5      � 5   
   $��0��6   $��1��6   $��
0,0,-340,0q�6,    5      �� 5      $	��510 �6#   ��5      �� 5       �� ImageSource$0 */GloryView.RFID;component/Skin/listBox.jpg��6   .+�5      �� -   5        $��button5��5   ^   $��查询 ��6   $��25��6#   $
��Left=�6/   $��
254,11,0,0q�6J   $	��Top=�6m   $��70��6�   $��12(�6�   �� 5      -   5        $��label1��5   ]   $
��RFID��6   $��29��6#   $
��Left=�6/   $��	44,10,0,0q�6J   $	��Top=�6k   $��74��6�   $��Right=�6�   $��12(�6�   �� 5      -   5        $��textBox1��5   Q   $��25��6   $
��Left=�6"   $��
119,12,0,0q�6=   $	��Top=�6a   $	��129��6y   5      � 5   
   -   5         �Name$ 	SenceGrid��5   @   $��1��6   $��1��6   
��� � �$��
0,0,-340,0q�6S   .+�5       !   _3DTools.TrackballDecorator  "   _3DTools.Viewport3DDecorator   Content. 5!      '� -   5         '�Name$ viewport��5!       �� CachingHint$ Cache=�6/   }�.  '� Camera 5"      =� 5#      -   5        myPerspectiveCamera�� � FarPlaneDistance$	 300Q�5#   I   	 � Position$	 -0.175,18.285,10.2971�6`   
 � LookDirection$
 0.175 -18.285 -10.2975�6�    � UpDirection$ -0.002 0.490 -0.8715�6�    � NearPlaneDistance$ 1Q�6�    =� FieldOfView$ 90Q�6�    �� 	Transform 5$      t� 5%   "   5&   #   5(      .x�5+      7  1System.Windows.Media.Media3D.ContainerUIElement3D  -   5        FurnitureContainer��5+   +   g� 5-      -	   5        viewportLightsModelVisual3D�� g� Content 5.      h� 5/      .��50   "   �� -
   5        ambientLight�� �� Color$ #666666��50   E   t� 51   "   -   5        directionalLight��$ #444444��51   M    t� 	Direction$ 0 -1 -15�6]   52   #   �� 53   "   -   5        	spotLight��$ #666666��53   ?    �� 	Direction$ 0 0 -15�6O    �� InnerConeAngle$ 30Q�6b    �� OuterConeAngle$ 60Q�6v    !� Position$ 0 1 301�6�   54   #   55      57      58      59      5:      5;      5<      