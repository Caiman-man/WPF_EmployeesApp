   M S B A M L   `   `   `  ����R  NIvanov_WPF_EF_Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ivanov_WPF_EF_EmployeesIvanov_WPF_EF_Employees  5   	   ,    &Ivanov_WPF_EF_Employees.InsertEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Ivanov_WPF_EF_Employees     5   	   -   5          �Name$  AddActorWindow��5   	    � Title$ Insert employee��5   	   $	��265��6!   $	��385��6.    � WindowStartupLocation$ CenterOwner=�6:    � 
ResizeMode$ NoResize=�6^   .��5      � -   5        ���#161523.+�5   
   �� -   5         ��Name$ fnameTB��5      $��
142,20,0,0q�5       �� TextWrapping$
 Wrap=�5      $�� First name��5      
����������#211F2E���	#FF434343 � UseLayoutRounding . $��Center=�5      $��30��6t   $	��Top=�6�   $
��Left=�6�   $	��214��6�   6�   �� 5   
   -   5        $ lnameTB��5      $	��Top=�5      $��
142,58,0,0q�5      $
 Wrap=�5      $��
 Last name��5      
����������#211F2E���	#FF434343 . $��Center=�5       $��30��64   $
��Left=�6�   $	��214��6�   6�   �� 5!   
   -   5        $ ageTB��5!      $	��Top=�5"      $��
142,95,0,0q�5#      $
 Wrap=�5$      $
�� Age��5%      
����������#211F2E���	#FF434343 . $��Center=�5*      $��30��64   $
��Left=�6~   $	��214��6�   6�   �� 5+   
   -   5        $ 	addressTB��5+      $	��Top=�5,      $��142,132,0,0q�5-      $
 Wrap=�5.      $�� Address��5/      
����������#211F2E���	#FF434343 . $��Center=�54      $��30��64   $
��Left=�6�   $	��214��6�   �� 56   
   -   5         ��Name$ insertB��56      $	��Top=�57      $��Insert��58      $��
20,183,0,0q�59      ���	#FF673AB7$��30��5;      $
��Left=�63   $	��100��6N   $��15(�6Z   �� 5<   
   -   5        $ clearB��5<      $	��Top=�5=      $��Clear��5>      $��138,183,0,0q�5?      ���	#FF673AB7$��30��5A      $
��Left=�62   $	��100��6M   $��15(�6Y   �� 5B   
   -	   5        $ cancelB��5B      $	��Top=�5C      $��Cancel��5D      $��256,183,0,0q�5E      ���	#FF673AB7$��30��5G      $
��Left=�63   $	��100��6N   $��15(�6Z   �� 5I   
   -
   5         ��Name$ employeeImage��5I      $
��Left=�5J      $��	15,20,0,0q�5K      $��Icons/picture.png��5L      	 � IsSharedSizeScope	 . $
��Fill=�5N       . $	��112��5P      
 � Cursor$

 Hand��6   $	��142��6p   $	��Top=�6}   5Q      5R      