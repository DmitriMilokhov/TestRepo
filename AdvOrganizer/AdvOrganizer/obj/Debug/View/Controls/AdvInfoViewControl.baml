   M S B A M L   `   `   `  ����G  CAdvOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AdvOrganizer.View.ControlsAdvOrganizer.View.Controls  5      I)clr-namespace:AdvOrganizer.InfrustructureAdvOrganizer.Infrustructure  5      3    -AdvOrganizer.View.Controls.AdvInfoViewControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AdvOrganizer.View.Controls     5      :infr)clr-namespace:AdvOrganizer.Infrustructure     5      $
��auto��5      $
��auto��6,     � 	Resources  5	      9   3AdvOrganizer.Infrustructure.DateTimeToDateConverter   DateConverter>  8AdvOrganizer.Infrustructure.TimeSpanToShortTimeConverter   timeSpanToShortTimeConverter �� 
TargetType �� BasedOn �� Property �� Value��%�  &	        &	      '�� &     7��'�� w     7��'��     7��  5
   
   6'     5   
   6,   �� 5   
   " ��6   8   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6   8   .�5      ��  � ��$ Center=�62   �� 5       � ��$	 180��6&   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   8   .�5      ��  � ��$ Center=�62   �� 5       � ��$	 180��6&   �� 5       � ��$ 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#       � ColumnDefinitions 5%   
   �� 5&      �� 5'      .+�5*   
   �� $��Date: ��6   �� 5+   
   $��1��6   ��6$   �� *AdvInfo.Date+ �� RelativeSource ��  �� AncestorType$ UserControlL�	 �� 	Converter#	 [  �� 5.   
   $��2��6   $��Time: ��6!   �� 5/   
   $��2��6   $��1��6   ��6/   �� *AdvInfo.Time+ �� $ UserControlL�#	 [ �� 52   
   $��3��6   $��Who: ��6!   �� 53   
   $��3��6   $��1��6   ��6/   �� *AdvInfo.Advertiser+ �� $ UserControlL��� 55   
   $��4��6   $��Type: ��6!   �� 56   
   $��4��6   $��1��6    
 �� DisplayMemberPath$
 DisplayMember��57       �� SelectedValuePath$
 Type��65   ��56   0   �� *
AdvTypes+ �� $ UserControlL� �� SelectedValue 57   N   �� *AdvInfo.Type+ �� Mode$ TwoWay=� �� $ UserControlL��� 59   
   $��5��6   $��Paid: ��6!   �� 5:   
   $��5��6   $��1��6    $��Center=�60   $��5q�6M    d� 	IsChecked 6X   �� *AdvInfo.IsPaid+ �� $ UserControlL�5<      5=      