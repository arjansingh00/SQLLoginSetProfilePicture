   M S B A M L   `   `   `  ����T  PSQLLoginSetProfilePicture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SQLLoginSetProfilePictureSQLLoginSetProfilePicture  5   	   *    $SQLLoginSetProfilePicture.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SQLLoginSetProfilePicture     5   	   -   5          � Title$  Set a Profile Picture��5   	   $	��800��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�6e   .��5
      � ���#10454F J� RenderTransformOrigin$ 0.511,0.414&�6     � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��320* �6   �� 5      $
��260* �6   �� 5      $
��193* �6   .+�5   
   A� $	��260��6   $	��260��6   $��1��6+   ��5      �� 5      .��5      �  � Color$ #BDE038��6#    � Offset$ 0Q�63   � 5      $ #45C4B0��6#   $ 1Q�63   5      5      A� 5   
   -   5         A�Name$ ImageCircle��5      $	��250��6'   $	��250��63   $��1��6@   �� 5   
   -   5        	 ��Name$	 UserName��5      $��1��6"   $��1��62   $��	User Name��6?   $��Center=�6S   $��0,0,0,0q�6w   $��48(�6�   
�������6�   �� 5   
   -   5        
 ��Name$
 ImageSelector��5      $	��300��6*   $��30��66   $��1��6B   $��1��6R   $��Center=�6_   $��0,0,0,20q�6|   $��16(�6�    �� SelectedIndex$ 1��6�   .@�5       �� 6   5!      �� 5"   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6;   $��Center=�6K   $��40��6h   $��	0,130,0,0q�6t   .+�5#      �� -   5         ��Name$ Upload��5#      $��Center=�6%   $	��100��6G   $��0,0,25,0q�6S      RoundedButtonStyle#���   6e   .��6�   Upload6�   �� 5$      -   5        $ Delete��5$      $��Center=�6%   $	��100��6G   $��25,0,0,0q�6S   #���   6e   .��6�   Delete6�   5%      5&      5'      