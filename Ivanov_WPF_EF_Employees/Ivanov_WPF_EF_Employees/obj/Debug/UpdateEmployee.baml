   M S B A M L   `   `   `  ����R  NIvanov_WPF_EF_Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ivanov_WPF_EF_EmployeesIvanov_WPF_EF_Employees  5   	   ,    &Ivanov_WPF_EF_Employees.UpdateEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Ivanov_WPF_EF_Employees     5   	   -   5          �Name$  UpdateEmployeeWindow��5   	    � Title$ Update employee��5   	   $	��265��6!   $	��385��6.    � WindowStartupLocation$ CenterOwner=�6:    � 
ResizeMode$ NoResize=�6^   .��5      � ���#161523.+�5   
   �� -   5         ��Name$ fnameTB��5      $	��Top=�5      $��
140,20,0,0q�5       �� TextWrapping$
 Wrap=�5      
����������#211F2E���	#FF434343 � UseLayoutRounding . $��Center=�5      $��30��64   $
��Left=�6@   $	��215��6[   6g   �� 5   
   -   5        $ lnameTB��5      $��
140,58,0,0q�5      $
 Wrap=�5      
����������#211F2E���	#FF434343 . $��Center=�5      $
��Left=�64   $	��215��6O   $��30��6[   $	��Top=�6g   6   �� 5   
   -   5        $ ageTB��5      $��
140,95,0,0q�5      $
 Wrap=�5       
����������#211F2E���	#FF434343 . $��Center=�5%      $
��Left=�64   $	��215��6O   $��30��6[   $	��Top=�6g   6   �� 5&   
   -   5        $ 	addressTB��5&      $��140,132,0,0q�5'      $
 Wrap=�5(      
����������#211F2E���	#FF434343 . $��Center=�5-      $
��Left=�64   $	��215��6O   $��30��6[   $	��Top=�6g   �� 5/   
   -   5         ��Name$ updateB��5/      $��Update��50      $��
15,180,0,0q�51      ���	#FF673AB7$��30��53      $	��100��63   $	��Top=�6?   $
��Left=�6W   $��15(�6r   �� 54   
   -   5        $ defaultB��54      $��Default��55      $��136,180,0,0q�56      ���	#FF673AB7$��30��58      $	��Top=�64   $
��Left=�6L   $	��100��6g   $��15(�6s   �� 59   
   -   5        $ cancelB��59      $��Cancel��5:      $��255,180,0,0q�5;      ���	#FF673AB7$��30��5=      $	��100��63   $	��Top=�6?   $
��Left=�6W   $��15(�6r   �� 5?   
   -	   5         ��Name$ employeeImage��5?      $
��Left=�5@      $��	15,20,0,0q�5A      $��Icons/picture.png��5B      	 � IsSharedSizeScope	 . $
��Fill=�5D       . $	��112��5F      
 � Cursor$

 Hand��6   $	��142��6m   $	��Top=�6z   5G      5H      