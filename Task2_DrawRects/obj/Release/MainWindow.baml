   M S B A M L   `   `   `  ���� M  IEmvuCV_VideoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EmvuCV_VideoPlayerEmvuCV_VideoPlayer  I)clr-namespace:EmvuCV_VideoPlayer.ControlsEmvuCV_VideoPlayer.Controls  #    EmvuCV_VideoPlayer.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:EmvuCV_VideoPlayer     ;ctrls)clr-namespace:EmvuCV_VideoPlayer.Controls       � Title$  
MainWindow��$	��413��$	��667�� � 	Resources  �� 
TargetType �� Property �� Value   RadioButtonList �� Orientation �� 
TargetType J� IsHitTestVisible �� 
IsSelected	 d� 	IsChecked
 �� Padding J� SnapsToDevicePixels��%  '��       '�� 8     '�� p     &	  �     �� " ��.���  � ��$ 12(���  � ��$ 5q��� " ��.���  � ��$ 12(���  � ��$ 5q��� " ��.���  � ��$ 50����  � ��$ 5q��� " ��.���  � �� �� .R��� $ 
Horizontal=�$��Center=���  � �� �� " ��.���  � ��$ 5q���  � �� �� " ��.R��� $��0q�
������ ._�	� |�.   .  #	 z .���� ��  � �� �� " ��.R��� $��0q�$
 0q�
������ 
������  . ._��� # z .���  � RowDefinitions �� $��30 ��� �� $��30 ��� $��50 �.+��� $��0��$ 
Horizontal=�.+��� ����  �� Path$
 Name�]� $��1��
���   �.+��� $
��Fill=����� *Frame+-   'EmvuCV_VideoPlayer.Controls.VideoSlider  $��2�� �� IsMoveToPointEnabled .  � Value �� $ 	Timestamp� � Maximum �� $ Duration��� $��3��$ 
Horizontal=�.+��� $
��Play������ *PlayVideoCommand+���� *	Capture+�� $��Pause������ *PauseVideoCommand+���� *	Capture+�� $��Settings������ *OpenSettingWindowCommand+�� $��Source��.���� #��[   �� SelectedValuePath$	 Tag�� �� SelectedValue �� $ SelectedSerializator�.@��� 
 � Tag$ XmlSerializator��.��
From XML�� $ YamlSerializator��.��	From YAML�� $��	Show mode��.���� $ 
Horizontal=�$��Center=�.+��� $
��Name��	 �� $ IsNameShowModeSelected��� $��Coordinates��	 �� $" IsCoordinateShowModeSelected��� $��3��$��Right=�$��Center=����� $ 	Timestamp�