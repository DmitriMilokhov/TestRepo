   M S B A M L   `   `   `  ���� M  IEmvuCV_VideoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EmvuCV_VideoPlayer.ViewEmvuCV_VideoPlayer.View  )    #EmvuCV_VideoPlayer.View.SettingView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:EmvuCV_VideoPlayer.View       � Title$  Settings��$	��182��$	��750�� � 	Resources  �� 
TargetType �� Property �� Value��%B   '��       �� " ��.���  � ��$ 12(���  � ��$ 5q�.���  � RowDefinitions �� $��25 ��� .+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $!��Deserializations files path���� ��  �� Command �� *OpenDialogCommand+.�Change�� $��1��.+��� $	��120��$��Stretch=����� *SerializatorsSettings+ �� View �� .P��� $
��Type��	 �� Width$
	 Auto��
 �� DisplayMemberBinding
 �� *SeriaizatorTypeText+�� $
��Path��$
	 Auto��
 �� *
FilePath+