   M S B A M L   `   `   `  ����I  ETennisclub_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Tennisclub_WPF.ViewsTennisclub_WPF.Views  5      G(clr-namespace:Tennisclub_WPF.ValidationsTennisclub_WPF.Validations  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      %    Tennisclub_WPF.Views.MemberView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Tennisclub_WPF.Views     5      :utils(clr-namespace:Tennisclub_WPF.Validations     5      6sys&clr-namespace:System;assembly=mscorlib     5      ���#36393f
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
   � $��1��6   $��1��6    5B      �� 5C      $
��auto �6    �� 5D      $��* �6    .+�5G      � $��0��6   	 5H      �� 5I      $��* �6'   �� 5J      $��* �6'   �� 5K      $��* �6'   �� 5L      $��* �6'   �� 5M      $��* �6'   .+�5P      �� $��0��6   $��0,0,10,0q�6-   .+�5Q      �� $��FederationNr��6    �� 5R      -   5        
 ��Name$
 FilterFederationNrTextBox��5R      6A   5S      �� 5U      $��1��6   $��0,0,10,0q�6-   .+�5V      �� $��
First name��6    �� 5W      -   5        $
 FilterFirstnameTextBox��5W      6>   5X      �� 5Z      $��2��6   $��0,0,10,0q�6-   .+�5[      �� $��	Last name��6    �� 5\      -   5        $
 FilterLastnameTextBox��5\      6=   5]      �� 5_      $��3��6   $��0,0,10,0q�6-   .+�5`      �� $��ZIP code��6    �� 5a      -   5        $
 FilterZipcodeTextBox��5a      6<   5b      �� 5d      $��4��6   $��0,0,10,0q�6-   .+�5e      �� $
��City��6    �� 5f      -   5        $
 FilterCityTextBox��5f      69   5g      5h      &   System.Windows.Controls.DataGrid  5j      -   5          Name$ MembersDataGrid��5j         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 60   $��1��5k      $��
0,15,10,10q�6      GridLinesVisibility$
 None=�62      CanUserAddRows$ False��6M      AutoGenerateColumns$ False��5l      $��0q�6-      SelectionMode$ Single=�6A      HeadersVisibility$ Column=�6X      CanUserResizeRows$ False��5m         
IsReadOnly$
 True��6+   
������� �� SelectedItem 6P   �� *Member+  5n      *  $System.Windows.Controls.DataGridCell �� Triggers��%�   '        �� 5o      "  6    5p      P� 5q       �@ 
IsSelected$
 True��6<   . �5r   "   ��  � �� �#5c6fb16?   �� 5s   "    � ��
 �����6?   �� 5t   "    � ��$ 0q�6D   5u      5w      5x         Columns 5y      0  *System.Windows.Controls.DataGridTextColumn  5z      ,  &System.Windows.Controls.DataGridColumn   Header$ FederationNr��6)      Width$
 auto 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *FederationNr+6`     5{      $ 
First name��6)    6=   �� *	FirstName+  5|      $ 	Last name��6)    6<   �� *
LastName+  5}      $ 
Birth date��6)    6=   �� *	BirthDate+ �� StringFormat$ 
dd/MM/yyyy��  5~      $ Gender��6)   $
 auto 6Y    69   �� *Gender.Name+6Y     5      $ Address��6)   $
 auto 6V    6:   �� *	Address+6V     5�      $ Number��6)    69   �� *Number+  5�      $ Addition��6)    6;   �� *
Addition+  5�      $ Zip code��6)    6;   �� *	Zipcode+  5�      $
 City��6)    67   �� *City+  5�      $ PhoneNr��6)    6:   �� *	PhoneNr+5�      5�      � 5�   
   -   5         �Name$ ManagementGrid��5�      $��1��6'   $��2��64   ���#2f3136$��	0,15,0,10q�6Y    5�      �� 5�      $��10 �6    �� 5�      $��* �6    �� 5�      $��10 �6    	 5�      �� 5�      $��35 �6#   �� 5�      $��* �6#   �� 5�      $��35 �6#   .+�5�      � -   5        $ AddMemberGrid��5�   0   $��1��6   $��1��6     5�      �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   .+�5�      �� $��0��6   $��Member management��6)   $��Center=�6B   $��28(�6_   $
��Bold"�6m   �� 5�      $��1��6   #��[  6*   .+�5�      �� $��FederationNr��6    �� 5�      -	   5        $#
 ManagementFederationNrTextBox��5�        errorTemplate =� ErrorTemplate# [ 6E   .��6   ��5�      �� 5�       �� Path$ FederationNr�6&    �� ValidatesOnDataErrors$
 True��6:    �� UpdateSourceTrigger$ PropertyChanged=�6W     �� ValidationRules  5�   "   B   <Tennisclub_WPF.Validations.RequiredStringFieldValidationRule  5�   &   !   Length$! 10��6N   "   Pattern#" [ 6Z   ,  &System.Windows.Controls.ValidationRule#   ValidatesOnTargetUpdated$
# True��6�   5�      .��5�   (   5�      5�      �� 5�      $��2��6   #��[  6*   .+�5�      �� $��
First name��6    �� 5�      -
   5        $ 
 ManagementFirstNameTextBox��5�      # [ 6B   .��6|   ��5�      �� 5�      $ 	FirstName�6&   $
 True��67   $ PropertyChanged=�6T     5�   "     5�   &   $! 25��6N   #" [ 6Z   $
# True��6�   5�      .��5�   (   5�      5�      �� 5�      $��3��6   #��[  6*   .+�5�      �� $��	Last name��6    �� 5�      -   5        $
 ManagementLastNameTextBox��5�      # [ 6A   .��6{   ��5�      �� 5�      $ LastName�6&   $
 True��66   $ PropertyChanged=�6S     5�   "     5�   &   $! 35��6N   #" [ 6Z   $
# True��6�   5�      .��5�   (   5�      5�      �� 5�      $��4��6   #��[  6*   .+�5�      �� $��
Birth date��6    (	  "System.Windows.Controls.DatePicker	  5�      -   5        $ 	 Name$#$ ManagementBirthDateDatePicker��5�   !   # [ 6H   % 	  SelectedDate% 5�      �� 5�      $ 	BirthDate�6&   $
 True��67   $ PropertyChanged=�6T     5�   "   7
   1Tennisclub_WPF.Validations.DateTimeValidationRule
  5�   &   $
# True��6C   5�      5�      5�      �� 5�      $��5��6   #��[  6*   .+�5�      �� $��Gender��6    �� 5�      -   5        & ��Name$& ManagementGenderComboBox��5�      ' �� DisplayMemberPath$
' Name��6A   ( �� SelectedValuePath$
( Name��6Z   ) �� SelectedValue) 6s   �� *SelectedItem.Gender.Name+* �� ElementName$* MembersDataGrid��+ �� Mode$+ OneWay=�5�      �� 5�      $��6��6   #��[  6*   .+�5�      �� $��Address��6    �� 5�      -   5        $
 ManagementAddressTextBox��5�      # [ 6@   .��6z   ��5�      �� 5�      $ Address�6&   $
 True��65   $ PropertyChanged=�6R     5�   "     5�   &   $! 70��6N   #" [ 6Z   $
# True��6�   5�      .��5�   (   5�      5�      �� 5�      $��7��6   #��[  6*   .+�5�      �� $��Number��6    �� 5�      -   5        $
 ManagementNumberTextBox��5�      # [ 6?   .��6y   ��5�      �� 5�      $ Number�6&   $
 True��64   $ PropertyChanged=�6Q     5�   "     5�   &   $! 6��6N   #" [ 6Y   $
# True��6�   5�      .��5�   (   5�      5�      �� 5�      $��8��6   #��[  6*   .+�5�      �� $��Addition��6    �� 5      -   5        $
 ManagementAdditionTextBox��5      # [ 6A   .��6{   ��5     �� 5     $ Addition�6&   $
 True��66   $ PropertyChanged=�6S     5  "   B   <Tennisclub_WPF.Validations.NullableStringFieldValidationRule  5  &   ,   Length$, 2��6N   $
# True��6Y   5     .��5  (   5     5	     �� 5     $��9��6   #��[  6*   .+�5     �� $��ZIP code��6    �� 5     -   5        $
 ManagementZipCodeTextBox��5     # [ 6@   .��6z   ��5     �� 5     $ Zipcode�6&   $
 True��65   $ PropertyChanged=�6R     5  "     5  &   $! 6��6N   #" [ 6Y   $
# True��6�   5     .��5  (   5     5     �� 5     $��10��6   #��[  6+   .+�5     �� $
��City��6    �� 5     -   5        $
 ManagementCityTextBox��5     # [ 6=   .��6w   ��5     �� 5     $
 City�6&   $
 True��62   $ PropertyChanged=�6O     5  "     5  &   $! 30��6N   #" [ 6Z   $
# True��6�   5      .��5!  (   5"     5#     �� 5%     $��11��6   #��[  6+   .+�5&     �� $��PhoneNr��6    �� 5'     -   5        $
 ManagementPhoneNrTextBox��5'     # [ 6@   .��6z   ��5(     �� 5)     $ PhoneNr�6&   $
 True��65   $ PropertyChanged=�6R     5*  "     5+  &   $, 15��6N   $
# True��6Z   5-     .��5.  (   5/     50     �� 52     -   5        - ��Name$- AddMemberBtn��52     $��
Add member��6/   $��12��6D   ��53     �� 54     " ��6    . �� BasedOn#. [ 64   .�55     ��  � {�$ False��6:    56     �� 57  "   / �� Binding/ 6.   �� *SelectedItems.Count+$* MembersDataGrid��0 �� Value0 16s   .a�58  &   ��  � {�$ False��6B   �� 59  &    � y�$ 	Collapsed=�6C   5:  #   ^� 5;  "   1 ^� 
Conditions1 5<  &   �� 5=  *   2 �� Binding2 64   �� $ (Validation.HasError)�$#* ManagementFederationNrTextBox��3 �� Value	3 False6�   �� 5>  *   2 64   �� $ (Validation.HasError)�$ * ManagementFirstNameTextBox��	3 False6�   �� 5?  *   2 64   �� $ (Validation.HasError)�$* ManagementLastNameTextBox��	3 False6�   �� 5@  *   2 64   �� $ (Validation.HasError)�$#* ManagementBirthDateDatePicker��	3 False6�   �� 5A  *   2 64   �� $ (Validation.HasError)�$* ManagementAddressTextBox��	3 False6�   �� 5B  *   2 64   �� $ (Validation.HasError)�$* ManagementNumberTextBox��	3 False6�   �� 5C  *   2 64   �� $ (Validation.HasError)�$* ManagementAdditionTextBox��	3 False6�   �� 5D  *   2 64   �� $ (Validation.HasError)�$* ManagementZipCodeTextBox��	3 False6�   �� 5E  *   2 64   �� $ (Validation.HasError)�$* ManagementCityTextBox��	3 False6�   �� 5F  *   2 64   �� $ (Validation.HasError)�$* ManagementPhoneNrTextBox��	3 False6�   .0�5H  &   ��  � {�$
 True��6B   5I  #   5K     5M     �� 5N     -   5        $- UpdateMemberBtn��5N     $��Update member��62   $��12��6J   ��5O     �� 5P     " ��6    #. [ 64   .�5Q     ��  � {�$ False��6:    5R     �� 5S  "   / 6.   �� *SelectedItems.Count+$* MembersDataGrid��0 06s   .a�5T  &   ��  � {�$ False��6B   �� 5U  &    � y�$ 	Collapsed=�6C   5V  #   ^� 5W  "   1 5X  &   �� 5Y  *   2 64   �� $ (Validation.HasError)�$#* ManagementFederationNrTextBox��	3 False6�   �� 5Z  *   2 64   �� $ (Validation.HasError)�$ * ManagementFirstNameTextBox��	3 False6�   �� 5[  *   2 64   �� $ (Validation.HasError)�$* ManagementLastNameTextBox��	3 False6�   �� 5\  *   2 64   �� $ (Validation.HasError)�$#* ManagementBirthDateDatePicker��	3 False6�   �� 5]  *   2 64   �� $ (Validation.HasError)�$* ManagementAddressTextBox��	3 False6�   �� 5^  *   2 64   �� $ (Validation.HasError)�$* ManagementNumberTextBox��	3 False6�   �� 5_  *   2 64   �� $ (Validation.HasError)�$* ManagementAdditionTextBox��	3 False6�   �� 5`  *   2 64   �� $ (Validation.HasError)�$* ManagementZipCodeTextBox��	3 False6�   �� 5a  *   2 64   �� $ (Validation.HasError)�$* ManagementCityTextBox��	3 False6�   �� 5b  *   2 64   �� $ (Validation.HasError)�$* ManagementPhoneNrTextBox��	3 False6�   .0�5d  &   ��  � {�$
 True��6B   5e  #   5g     5i     �� 5j     -   5        $- DeleteMemberBtn��5j     $��Delete member��62   $��13��6J   ��5k     �� 5l     " ��6    #. [ 64    5m     �� 5n  "   / 6.   �� *SelectedItems.Count+$* MembersDataGrid��0 06s   .a�5o  &   ��  � {�$ False��6B   �� 5p  &    � y�$ 	Collapsed=�6C   5q  #   5s     5u     �� 5v     -   5        $- NewMemberBtn��5v     $��
New member��6/   $��14��6D   ��5w     �� 5x     " ��6    #. [ 64    5y     �� 5z  "   / 6.   �� *SelectedItems.Count+$* MembersDataGrid��0 06s   .a�5{  &   ��  � {�$ False��6B   �� 5|  &    � y�$ 	Collapsed=�6C   5}  #   5     5�     5�     5�     5�     5�     