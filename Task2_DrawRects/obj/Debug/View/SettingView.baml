   M S B A M L   `   `   `  ����M  IEmvuCV_VideoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EmvuCV_VideoPlayer.ViewEmvuCV_VideoPlayer.View  5   	   )    #EmvuCV_VideoPlayer.View.SettingView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:EmvuCV_VideoPlayer.View     5   	     � Title$  Settings��5   	   $	��182��6   $	��750��6'    � 	Resources 5	       �� 
TargetType �� Property �� Value��%u   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $!��Deserializations files path��6   �� 5      �� 5       �� Command 6   �� *OpenDialogCommand+.�6B   Change6J   5      5      �� 5   
   $��1��6   .+�5      �� $	��120��6   $��Stretch=�6R   ��6$   �� *SerializatorsSettings+ �� View 5      �� 5      .P�5       �� $
��Type��6)   	 �� Width$
	 Auto��67   
 �� DisplayMemberBinding
 6D   �� *SeriaizatorTypeText+�� 5!      $
��Path��6)   $
	 Auto��67   
 6D   �� *
FilePath+5"      5$      5%      5'      5(      