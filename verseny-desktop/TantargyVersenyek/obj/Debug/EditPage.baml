   M S B A M L   `   `   `  ����L  HTantargyVersenyek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TantargyVersenyekTantargyVersenyek  5           TantargyVersenyek.EditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TantargyVersenyek     5        N� Title$  EditPage��5      $	��610��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5         ��Name$ 	EditLabel��5      $��Szerkesztés��6'   $��Center=�6=   $��Center=�6Z   $��24(�6u   $��42��6�   5      �� 5   
   $��1��6   $��
Alapadatok��6    .��5      �� .+�5      �� .��6   Competition:6&   �� 5      -   5        $��CompetitionNameTextBox��5      6:   �� 5      .��6   Description:6&   �� 5      -   5        $��DescriptionTextBox��5      66   5      5      �� 5   
   $��2��6   $��
Kérdések��6    .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5       $
��auto �6'   66   .+�5"      &   System.Windows.Controls.DataGrid  -   5        $��KerdesekDataGrid��5"   +   $��0��6      AutoGenerateColumns .     CanUserAddRows .  $��Stretch=�5#      $��Stretch=�61      RowBackground �#fff$
��Bold"�5$      ���#525252��. $	��390��5%   &   $	��390��63      AlternatingRowBackground �#f2f2f2���#000$��1q�5&   7   $��Visible=�5'      $
��Auto=�5(      	   Columns	 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6-      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ Id�6W     5+      $
 Question��6-    .   6?   �� $ Question�6c     5,      $
 Answer1��6-    .   6>   �� $ Answer1�6a     5-      $
 Answer2��6-    .   6>   �� $ Answer2�6a     5.      $
 Answer3��6-    .   6>   �� $ Answer3�6a     5/      $
 Answer4��6-    .   6>   �� $ Answer4�6a     50      $
 CorrectAnswer��6-    .   6D   �� $ CorrectAnswer�6m   4  .System.Windows.Controls.DataGridTemplateColumn  51      $
 Delete��61      CellTemplate 52      �� 53   "   .R�54   &   �� $��	DeleteBtn��6-   -   5        $��Delete��54   >   6O   55   #   57      59      5:      5;      � 5<   
   $��3��6    5=      �� 5>      $��* �6#   6/   �� 5?      $��* �6#   6/   .+�5A      �� $��0��6   $ 
Horizontal=�6)   $��Center=�6B   .+�5B      �� -   5        $��BackBtn��5B      $��Vissza��6(   $��80��69   6\   5D      �� 5E      $��1��6   $ 
Horizontal=�6)   $��Right=�6B   .+�5F      �� -   5        $��NewBtn��5F      $��80��6'   $��Új kérdés��62   6]   �� 5G      -   5        $��SaveBtn��5G      $��80��6)   $��Mentés��64   6]   5H      5I      5K      5L      