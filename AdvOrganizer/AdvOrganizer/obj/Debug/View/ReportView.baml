   M S B A M L   `   `   `  ����G  CAdvOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AdvOrganizer.ViewAdvOrganizer.View  5      I)clr-namespace:AdvOrganizer.InfrustructureAdvOrganizer.Infrustructure  5      "    AdvOrganizer.View.ReportView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:AdvOrganizer.View     5      :infr)clr-namespace:AdvOrganizer.Infrustructure     5      $
��auto��5      $
��auto��6,     � 	Resources  5	      9   3AdvOrganizer.Infrustructure.DateTimeToDateConverter   dateTimeToDateConverter>  8AdvOrganizer.Infrustructure.TimeSpanToShortTimeConverter   timeSpanToShortTimeConverter��%:   &	        &	        5
   
   6'     5   
   6,   5      .��5      � .+�5   
   �� $
��Auto=�6   .��5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     RowHeaderWidth$ 0Q�6P   $	��250��6c   ��6   �� *
AdvInfos+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Date+ �� 	Converter# [    5      $	 Who��6%    62   �� *
Advertiser+   	CellStyle 5      �� 5      .�5      ��  �� Property � ��	 �� Value$	 Center=�6U   5      5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $
 Paid��6)    67   �� *IsPaid+  5      $
 Time��6%    63   �� *Time+# [ 5      5      5      5      