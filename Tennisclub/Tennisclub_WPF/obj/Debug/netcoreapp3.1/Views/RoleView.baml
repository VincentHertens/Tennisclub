   M S B A M L   `   `   `  ����I  ETennisclub_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Tennisclub_WPF.ViewsTennisclub_WPF.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      G(clr-namespace:Tennisclub_WPF.ValidationsTennisclub_WPF.Validations  5      #    Tennisclub_WPF.Views.RoleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Tennisclub_WPF.Views     5      6sys&clr-namespace:System;assembly=mscorlib     5      :utils(clr-namespace:Tennisclub_WPF.Validations     5      ���#36393f
�������  � 	Resources  5         managementStackPanelStyle �� 
TargetType �� Property �� Value  btnStyle �� 
TargetType �� Triggers P� Property P� Value  requiredRegex��%&  &	        &	 N     &	 �    �� 5   
   " ��62   .�5      ��  � ��$ 0,15,0,0q�6'   5      �� 5   
   " ��6!   .�5      ��  � ��$
 auto��6&   �� 5       � ��$ 40��6'   �� 5       � ��$ 0,15,0,0q�6'   �� 5       � �� �#292b2f6+   �� 5       � ��
 �����6+   �� 5       � ��$ 13(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 0q�60   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5        �@J�IsMouseOver$
 True��6=   . �5!   "   ��  � �� �#40444b6@   �� 5"   "    � ��
 �����6?   5#      P� 5$       � ��$
 true��6;   . �5%   "   ��  � �� �#5c6fb16@   �� 5&   "    � ��
 �����6@   5'      P� 5(       � {�$ False��6;   . �5)   "   ��  � �� �#40444b6?   �� 5*   "    � ��
 �����6?   5+      5-      5/      50      ��51   
   	^\s*$��62   52      .��54      �  � RowDefinitions 55   
   �� 56      $��10 �6   �� 57      $��* �6   �� 58      $��10 �6   	 � ColumnDefinitions	 5:   
   �� 5;      $��10 �6   �� 5<      $
��0.7* �6   �� 5=      $
��0.3* �6   �� 5>      $��10 �6   .+�5A   
   &   System.Windows.Controls.DataGrid  -   5        
  Name$
 RolesDataGrid��5A         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*   $��1��5B      $��1��6   $��
0,15,10,10q�6*      GridLinesVisibility$
 None=�6>      CanUserAddRows$ False��6Y      AutoGenerateColumns$ False��5C      $��0q�6)      SelectionMode$ Single=�6=      HeadersVisibility$ Column=�6T      CanUserResizeRows$ False��5D         
IsReadOnly$
 True��6'   
������� �� SelectedItem 6L   �� *Role+ �� Mode$ OneWayToSource=�  5E      *  $System.Windows.Controls.DataGridCell �� Triggers��%�   '        �� 5F      "  6    5G      P� 5H       �@ 
IsSelected$
 True��68   . �5I      ��  � �� �#5c6fb16;   �� 5J       � ��
 �����6;   �� 5K       � ��$ 0q�6@   5L      5N      5O         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+5S      � 5U   
   -   5         �Name$ ManagementGrid��5U      $��1��6'   $��2��64   ���#2f3136$��	0,15,0,10q�6Y    5V      �� 5W      $��10 �6    �� 5X      $��* �6    �� 5Y      $��10 �6    	 5[      �� 5\      $��35 �6#   �� 5]      $��* �6#   �� 5^      $��35 �6#   .+�5`      � $��1��6   $��1��6     5a      �� 5b      $
��auto �6$   �� 5c      $
��auto �6$   �� 5d      $
��auto �6$   �� 5e      $
��auto �6$   .+�5h      �� $��0��6   $��Role management��6)   $��Center=�6@   $��28(�6]   $
��Bold"�6k   �� 5j      $��1��6   #��[  6*   .+�5k      �� $
��Name��6    �� 5l      -   5         ��Name$ ManagementNameTextBox��5l        errorTemplate =� ErrorTemplate# [ 6=   .��6w   ��5m      �� 5n       �� Path$
 Name�6&    �� ValidatesOnDataErrors$
 True��62    �� UpdateSourceTrigger$ PropertyChanged=�6O    �� ValidationRules 5o   "   B   <Tennisclub_WPF.Validations.RequiredStringFieldValidationRule  5p   &       Length$  20��6N   !   Pattern#! [ 6Z   ,  &System.Windows.Controls.ValidationRule"   ValidatesOnTargetUpdated$
" True��6�   5r      .��5s   (   5t      5u      �� 5w      -   5        # ��Name$# 
AddRoleBtn��5w      $��Add role��6-   $��2��6@   $��0,20,0,0q�6f   ��5x      �� 5y      " ��6    $ �� BasedOn#$ [ 64   .�5z      ��  � {�$ False��6:   �� 5{       � y�$ Visible=�6;    5|      �� 5}   "   % �� Binding% 6.   �� *SelectedItems.Count+& �� ElementName$& RolesDataGrid��' �� Value' 16q   .a�5~   &   ��  � {�$ False��6B   �� 5   &    � y�$ Hidden=�6C   5�   #   ^� 5�   "   ( ^� 
Conditions( 5�   &   �� 5�   *   ) �� Binding) 64   �� $ (Validation.HasError)�$& ManagementNameTextBox��* �� Value	* False6�   .0�5�   &   ��  � {�$
 True��6B   5�   #   5�      5�      �� 5�      -   5        $# UpdateRoleBtn��5�      $��Update role��60   $��2��6F   ��5�      �� 5�      " ��6    #$ [ 64   .�5�      ��  � {�$ False��6:    5�      �� 5�   "   % 6.   �� *SelectedItems.Count+$& RolesDataGrid��' 06q   .a�5�   &   ��  � {�$ False��6B   �� 5�   &    � y�$ 	Collapsed=�6C   5�   #   ^� 5�   "   ( 5�   &   �� 5�   *   ) 64   �� $ (Validation.HasError)�$& ManagementNameTextBox��	* False6�   .0�5�   &   ��  � {�$
 True��6B   5�   #   5�      5�      �� 5�      -   5        $# 
NewRoleBtn��5�      $��New role��6-   $��3��6@   ��5�      �� 5�      " ��6    #$ [ 64    5�      �� 5�   "   % 6.   �� *SelectedItems.Count+$& RolesDataGrid��' 06q   .a�5�   &   ��  � {�$ False��6B   �� 5�   &    � y�$ Hidden=�6C   5�   #   5�      5�      5�      5�      5�      5�      