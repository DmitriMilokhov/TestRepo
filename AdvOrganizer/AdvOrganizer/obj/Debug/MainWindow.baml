   M S B A M L   `   `   `  ����G  CAdvOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AdvOrganizerAdvOrganizer  5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   G(clr-namespace:AdvOrganizer.View.ControlsAdvOrganizer.View.Controls  5   	   I)clr-namespace:AdvOrganizer.InfrustructureAdvOrganizer.Infrustructure  5	   	   5clr-namespace:AdvOrganizer.ViewAdvOrganizer.View  5
   	       AdvOrganizer.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AdvOrganizer     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   <MyCtrls(clr-namespace:AdvOrganizer.View.Controls     5   	   :Infr)clr-namespace:AdvOrganizer.Infrustructure     5	   	   1Viewsclr-namespace:AdvOrganizer.View     5
   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   $��16(�5        � 
ResizeMode$  NoResize=�6(    � Title$ Adv Organizer��5   	    � SizeToContent$ WidthAndHeight=�6    � 	Resources 5      .  (AdvOrganizer.Infrustructure.BindingProxy   ReportDataContext   Data   booleanToVisibilityConverter �� 
TargetType �� BasedOn �� Property �� Value��%�   &	        &	 )     '�� <     7��  5   
    66   �� *
IsReport+�� 5   
   6'   �� 5   
   " ��6   8   .�5      ��  � ��$	 125��6&   �� 5       � ��$ 5q�6'   5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   
 � ColumnDefinitions
 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5"   
   &   System.Windows.Controls.Calendar  -   5          Name$ calendar��5"         IsTodayHighlighted .    FirstDayOfWeek$ Monday=�6?   $	��Top=�6W   $��5q�6o   $	��200��6z   .  (System.Windows.Interactivity.Interaction   Triggers 5#      /  )System.Windows.Interactivity.EventTrigger  5$         	EventName$ SelectedDatesChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5%      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *DateChangedCommand+   CommandParameter 5&   ,   �� *SelectedDates+ �� ElementName$ calendar��5'      5)      �� 5+   
   $��1��6   .@�5,      �� $��Morning��6   $
��auto��6'   .��5-      3   -AdvOrganizer.View.Controls.AdvInfoViewControl     AdvInfo 6-   �� *MorningAdvInfo+5.      �� 5/      $��Evening��6   $
��auto��6'   .��50         6-   �� *EveningAdvInfo+51      52      �� 54   
   $��1��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�55      �� $
��Save��6   ��6$   �� *SaveCommand+�� 56      $��	Clean Old��6   ��6)   �� *CleanOldCommand+�� 57      $��Show Report��6   ��6+   �� *ShowReportCommand+58      "   AdvOrganizer.View.ReportView  5:   
   $��3��6   $��2��6,   $	��Top=�6<    � DataContext 6T   �� *ReportViewModel+y�5;      ��  �� Path$
 Data� �� 	Converter# [  �� Source# [  5=      5>      