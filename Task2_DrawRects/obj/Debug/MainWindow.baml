   M S B A M L   `   `   `  ����M  IEmvuCV_VideoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EmvuCV_VideoPlayerEmvuCV_VideoPlayer  5   	   I)clr-namespace:EmvuCV_VideoPlayer.ControlsEmvuCV_VideoPlayer.Controls  5   	   #    EmvuCV_VideoPlayer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:EmvuCV_VideoPlayer     5   	   ;ctrls)clr-namespace:EmvuCV_VideoPlayer.Controls     5   	     � Title$  
MainWindow��5	   	   $	��413��6   $	��667��6)    � 	Resources 5
       �� 
TargetType �� Property �� Value   RadioButtonList �� Orientation �� 
TargetType J� IsHitTestVisible �� 
IsSelected	 d� 	IsChecked
 �� Padding J� SnapsToDevicePixels��%�  '��       '�� k     '�� �     &	  A    �� 5   
   " ��6   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 50��6&   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6(   .�5      ��  � �� 5      �� 5      .R�5      �� $ 
Horizontal=�6%   $��Center=�6>   5      5      �� 5       � �� 5       �� 5!      " ��6   .�5"      ��  � ��$ 5q�63   �� 5#       � �� 5$      �� 5%   "   " ��62   .R�5&   &   �� $��0q�6-   
������ ._�5'   *   	� |�.   .  #	 z 5(   -   .��5)   .   �� 5*   +   5+   '   5,   #   5.      5/      51      �� 52       � �� 53      �� 54      " ��6&   .R�55      �� $��0q�6!   $
 0q�65   
������ 
������  . ._�56      �� # z 6-   57      58      5:      5;      5<      .��5=      �  � RowDefinitions 5>   
   �� 5?      $��30 �6   �� 5@      �� 5A      $��30 �6   �� 5B      $��50 �6   .+�5D   
   �� $��0��6   $ 
Horizontal=�6"   .+�5E      �� ��6   ��  �� Path$
 Name�5F      ]� 5H   
   $��1��6   
���   �.+�5I      �� $
��Fill=�6-   ��6   �� *Frame+6-   5J      -   'EmvuCV_VideoPlayer.Controls.VideoSlider  5L   
   $��2��6=    �� IsMoveToPointEnabled .  � Value 6   �� $ 	Timestamp� � Maximum 6J   �� $ Duration�6l   �� 5N   
   $��3��6   $ 
Horizontal=�6"   .+�5O      �� $
��Play��6_   ��6   �� *PlayVideoCommand+��6:   �� *	Capture+6_   �� 5P      $��Pause��6`   ��6   �� *PauseVideoCommand+��6;   �� *	Capture+6`   �� 5Q      $��Settings��6B   ��6   �� *OpenSettingWindowCommand+6B   �� 5R      $��Source��6   .��5S      �� #��[  6    �� SelectedValuePath$	 Tag��6C    �� SelectedValue 6[   �� $ SelectedSerializator�.@�5T      �� 
 � Tag$ XmlSerializator��6"   .��68   
From XML6B   �� 5U      $ YamlSerializator��6"   .��69   	From YAML6D   5V      5W      �� 5X      $��	Show mode��6   .��5Y      �� $ 
Horizontal=�6   $��Center=�66   .+�5Z      �� $
��Name��6   	 6.   �� $ IsNameShowModeSelected��� 5[      $��Coordinates��6   	 65   �� $" IsCoordinateShowModeSelected�5\      5]      5^      �� 5_   
   $��3��6   $��Right=�6B   $��Center=�6^   ��6!   �� $ 	Timestamp�6^   5`      5a      