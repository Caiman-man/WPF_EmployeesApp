   M S B A M L   `   `   `  ����R  NIvanov_WPF_EF_Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ivanov_WPF_EF_EmployeesIvanov_WPF_EF_Employees  5   	   (    "Ivanov_WPF_EF_Employees.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Ivanov_WPF_EF_Employees     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   $��Regular"�5
   	   $��15(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Ivanov_WPF_EF_Employees��5   	   $	��630��6)   $
��1080��66   $
��1080��6C   $	��630��6S    � WindowStartupLocation$ CenterScreen=�6c    � Icon$ Icons/icon_1.ico��6�    � 	Resources 5        GroupHeaderStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 9�Name 9� 
IsExpanded��%  &	       �� 5   
   " ��6)   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      9� $	
 exp��6#    . 
�������
���   ���5      �� 5   "   ��6,   �� *Name+.��5      �� 5      5       5"      5#      5$      .��5'      � -   5         �Name$ 	main_grid��5'      ���#211F2E.+�5*   
   � -   5        $ 
menu_panel��5*      $
��Left=�5+      $	��180��5,      ���#211F2E J� RenderTransformOrigin$ 0.5, 0.5&�5.      .+�50      �� -   5         ��Name$ 	showAll_B��50      $��Show All��51      $��25��52      $	��150��53      ���	#FF673AB7$	��Top=�55      $
��Left=�56      $��	15,15,0,0q�57      $��15(�58      ���	#FF673AB7$��Normal"�5:       � Cursor$
 Hand��5;   1   5<      �� 5>      -   5         ��Name$ departmentFilter_CB��5>      $
��Left=�5?      $��25��5@      $	��150��5A      $	��Top=�5B      $��	15,60,0,0q�5C      
���   ����	#DDFFFFFF5F      �� 5H      -   5        $ departmentFilter_B��5H      $��Department filter��5I      $��25��5J      $	��150��5K      $	��Top=�5L      $
��Left=�5M      $��	15,90,0,0q�5N      $��15(�5O      $��Normal"�5P      5Q      �� 5S      -   5        $ employeeFilter_CB��5S      $��25��5T      $	��150��5U      $	��Top=�5V      $
��Left=�5W      $��
15,135,0,0q�5X      
���   ����	#DDFFFFFF5[      �� 5]      -   5        $ employeeFilter_B��5]      $��Employee filter��5^      $��25��5_      $	��150��5`      $	��Top=�5a      $
��Left=�5b      $��
15,165,0,0q�5c      $��15(�5d      $��Normal"�5e      $
 Hand��6G   5f      �� 5h      -   5         ��Name$ find_TB��5h      $��25��5i      $	��150��5j      $	��Top=�5k      $
��Left=�5l      $��
15,210,0,0q�5m       �� TextWrapping$
 Wrap=�5n      $�� ��5o      ���	#DDFFFFFF$��15(�5q      
���   �.��67   5r      �� 5t      -	   5        $ find_B��5t      $��Find singer by ID��5u      $��25��5v      $	��150��5w      $	��Top=�5x      $
��Left=�5y      $��
15,240,0,0q�5z      $��15(�5{      $��Normal"�5|      $
 Hand��6)   5}      d� 5      -
   5         d�Name$ editMode_ToggleB��5       $  MaterialDesignSwitchToggleButton#��[ 5�       � ToolTip$&  MaterialDesignSwitchToggleButton��5�      $��
15,281,0,0q�5�      $��45��5�      $��20��5�      ���#7ED048$	��Top=�5�      $
��Left=�5�      6Y   �� 5�      $��	Edit mode��6   $
��Left=�5�      $��
60,277,0,0q�5�      $	��Top=�5�      ���	#DDFFFFFF$��15(�5�      5�      �� 5�      -   5        $ editMode_CB��5�      $��25��5�      $	��150��5�      $	��Top=�5�      $
��Left=�5�      $��
15,311,0,0q�5�      ���	#DD000000���	#DDFFFFFF$��15(�5�       �� IsTextSearchEnabled .  .@�5�      �� $��Departments��5�      
����������	#DD0000005�      �� 5�      
�������$��	Employees��5�      ���	#DD0000005�      5�      �� 5�      -   5        $ insert_B��5�      $��Insert��5�      $��25��5�      $	��150��5�      $	��Top=�5�      $
��Left=�5�      ���#7ED048$��
15,356,0,0q�5�      $��15(�5�      $��Normal"�5�      $
 Hand��6)   ���	#FF7ED0485�      �� 5�      -   5        $ edit_B��5�      $
��Edit��5�      $��25��5�      $	��150��5�      $	��Top=�5�      $
��Left=�5�      ���#7ED048$��
15,386,0,0q�5�      $��15(�5�      $��Normal"�5�      $
 Hand��6)   ���	#FF7ED0485�      �� 5�      -   5        $ show_B��5�      $
��Show��5�      $��25��5�      $	��150��5�      $	��Top=�5�      $
��Left=�5�      ���#7ED048$��
15,416,0,0q�5�      $��15(�5�      $��Normal"�5�      $
 Hand��6)   ���	#FF7ED0485�      �� 5�      -   5        $ delete_B��5�      $��Delete��5�      $��25��5�      $	��150��5�      $	��Top=�5�      $
��Left=�5�      ���#7ED048$��
15,446,0,0q�5�      $��15(�5�      $��Normal"�5�      $
 Hand��6)   ���	#FF7ED0485�      �� 5�      -   5        $ GitHub��5�       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5�      $0 *MaterialDesignFloatingActionMiniDarkButton��5�      $��15,0,125,10q�5�   Y   $��40��6�   $��Bottom=�6�   {�5�      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL���5�   n   Z� ��6�   Z� .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Github=�5�      
�������$��27��5�      $��27��5�      5�      5�      �� 5�      -   5        $ Twitter��5�      #��[ 5�      $0 *MaterialDesignFloatingActionMiniDarkButton��5�      $��
70,0,70,10q�5�   �   $��40��6�   $��Bottom=�6�   {�6   �� *DataContext.ControlsEnabled+ �� *FindAncestor+" ���6�   Z� ��6�   Z� .��5�        $ Twitter=�5�      
�������$��27��5�      $��27��5�      5�      5�      �� 5�      -   5        $ Email��5�      #��[ 5�      $0 *MaterialDesignFloatingActionMiniDarkButton��5�      $��125,0,15,10q�5�   �   $��40��6�   $��Bottom=�6�   {�6   �� *DataContext.ControlsEnabled+ �� *FindAncestor+" ���6�   Z� ��6�   Z� .��5�      �� -   5        $��http://www.msn.com?�5�      .�6=   .�5�        $ EmailOutline=�5�      
�������$��27��5�      $��27��5�      5�      5�      5�      5�      &   System.Windows.Controls.DataGrid  5  
   -   5          Name$ 	dataGrid1��5     $��180,10,10,10q�5        VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush
 �����
���   �
�������$��15(�5	        AutoGenerateColumns .     CanUserAddRows .     MinRowHeight$ 90Q�5     !   EnableColumnVirtualization .     HeadersVisibility$  Column=�5  _   ��5     Z� ! �� 
GroupStyle! 5     (  "System.Windows.Controls.GroupStyle  5     "   ContainerStyle#" [ 6   5     #   Columns# 5     4  .System.Windows.Controls.DataGridTemplateColumn  5     ,  &System.Windows.Controls.DataGridColumn$   Header$$ Photo��6)   %   Width5  /System.Windows.Controls.DataGridLengthConverter$
% Auto 68   &   CellTemplate& 5     �� 5     .R�5     �� $��70��6=   $
��auto��6I   ��6$   �� *Photo+6I   5     5     0  *System.Windows.Controls.DataGridTextColumn  5     $$ 
EmployeeID��6%   '   
IsReadOnly' . $
% Auto 6�   1	  +System.Windows.Controls.DataGridBoundColumn( 	  Binding( 6:   �� ) �� Path$) 
EmployeeID�* �� UpdateSourceTrigger$* PropertyChanged=�6�     5     $$ 	FirstName��6%   $
% Auto 6�   ( 69   �� $) 	FirstName�$* PropertyChanged=�6�     5     $$ LastName��6%   $
% Auto 6   ( 68   �� $) LastName�$* PropertyChanged=�6     5      $	$ Age��6%   $
% Auto 6u   ( 63   �� $	) Age�$* PropertyChanged=�6u     5!     $$ EmployeeAdress��6%   $
% Auto 6�   ( 6>   �� $) EmployeeAddress�$* PropertyChanged=�6�     5#     $$ DepartmentID��6%   $	% 140 6a   ( 6;   �� $) DepartmentID�6a     5$     $$ Title��6%   $
% Auto 6x   ( 64   �� $) Title�$* PropertyChanged=�6x     5%     $$ HeadID��6%   $
% Auto 6z   ( 65   �� $) HeadID�$* PropertyChanged=�6z     5&     $$ DepartmentAdress��6%   $
% Auto 6�   ( 6?   �� $) DepartmentAdress�$* PropertyChanged=�6�     5'     $$ Phone��6%   $
% Auto 6y   ( 65   �� $) Phone�$* PropertyChanged=�6y   5+     5-     5/     