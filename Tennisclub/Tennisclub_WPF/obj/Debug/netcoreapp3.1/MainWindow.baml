   M S B A M L   `   `   `  ����I  ETennisclub_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Tennisclub_WPFTennisclub_WPF  5   	       Tennisclub_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Tennisclub_WPF     5   	     � Title$  
Tennisclub��5   	   $	��900��6   $
��1600��6)    � WindowStartupLocation$ CenterScreen=�5	   	   ���#36393f � 	Resources 5         menuBtnStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName  menuTextBlockStyle��%�  &	        &	 �    �� 5   
   " ��6%   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$	 100��6'   �� 5       � ��$ 0,10,0,0q�6'   �� 5       � �� 6(   �� *UpdateViewCommand+�� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5      �� $	 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5      
 5      P� 5       �@J�IsMouseOver$
 true��6=   . �5   "   �� $ border��6?    � �� �#34373c6S   �� 5   "   $ border��6@    � �� �#34373c6T   5      P� 5       � ��$
 true��6;   . �5   "   �� $ border��6?    � �� �#34373c6S   �� 5    "   $ border��6@    � �� �#34373c6T   5!      5#      5%      5&      �� 5'   
   " ��6,   .�5(      ��  � �� �#6f78916+   �� 5)       � ��$ 15(�6)   �� 5*       � ��$ 20,0,0,0q�6'   �� 5+       � ��$	 100��6&   �� 5,       � ��$ Center=�62   5-      5.      .��50      �  � RowDefinitions 51   
   �� 52      $	��100 �6   �� 53      $��* �6   �� 54      $	��100 �6    � ColumnDefinitions 56   
   �� 57      $	��200 �6   �� 58      $��* �6   .+�5;   
   �� $��0��6   $��1��6&   $��3��66   ��6G   �� *SelectedViewModel+� 5=   
   $��0��6   $��3��6   ���#2f31366D   � 5?   
   $��0��6   $��0��6   .+�5@      �� ���#6f7891$��
Tennisclub��6-   $��30(�6?   $��Center=�6M   $��Center=�6h   $
��Bold"�6�   5A      � 5C   
   $��1��6   $��0��6   .+�5D      �� $
��Left=�6   ���#2f3136$	��200��6I   .+�5E      �� -   5         ��Name$ membersButton��5E   ?   #��[  6   $��Members��6V   .��5F      ��  �� Orientation$ 
Horizontal=�6!   .+�5G      �� $!��/Assets/membersGreyIcon.png��6    $
��None=�6E   �� 5H      #��[ 6$   $��Members��6P   5I      5J      �� 5K      -   5        $ rolesButton��5K   ?   #��[  6   $��Roles��6T   .��5L      �� $ 
Horizontal=�6!   .+�5M      �� $��/Assets/roleGreyIcon.png��6    $
��None=�6B   �� 5N      #��[ 6$   $��Roles��6P   5O      5P      �� 5Q      -   5        $ memberRolesButton��5Q   ?   #��[  6   $��MemberRoles��6Z   .��5R      �� $ 
Horizontal=�6!   .+�5S      �� $%��/Assets/memberrolesGreyIcon.png��6    $
��None=�6I   �� 5T      #��[ 6$   $��Member Roles��6P   5U      5V      �� 5W      -   5        $ memberFinesButton��5W   ?   #��[  6   $��MemberFines��6Z   .��5X      �� $ 
Horizontal=�6!   .+�5Y      �� $%��/Assets/memberFinesGreyIcon.png��6    $
��None=�6I   �� 5Z      #��[ 6$   $��Fines��6P   5[      5\      �� 5]      -   5        $ gamesButton��5]   ?   #��[  6   $��Games��6T   .��5^      �� $ 
Horizontal=�6!   .+�5_      �� $��/Assets/gamesGreyIcon.png��6    $
��None=�6C   �� 5`      #��[ 6$   $��Games��6P   5a      5b      �� 5c      -   5        $ gameResultsButton��5c   ?   #��[  6   $��GameResults��6Z   .��5d      �� $ 
Horizontal=�6!   .+�5e      �� $%��/Assets/gameResultsGreyIcon.png��6    $
��None=�6I   �� 5f      #��[ 6$   $��Game Results��6P   5g      5h      5i      5j      5l      5m      