   M S B A M L   `   `   `  ����L  HTantargyVersenyek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TantargyVersenyekTantargyVersenyek  5      '    !TantargyVersenyek.CompetitionList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TantargyVersenyek     5        N� Title$  CompetitionListPage��5      $	��480��6#   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6   $��0��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5      �� -   5         ��Name$ CompetitionLabel��5      $��	Versenyek��6.   $��Center=�6B   $	��Top=�6_   $��24(�6w   $��42��6�   5      �� 5   
   -   5        $��	LogoutBtn��5      $��2��6   $��Kijelentkezés��6/   $
��Left=�6G   $	��Top=�6b   $	��100��6z   $��42��6�   6�   �� 5   
   -   5        $��NewBtn��5      $��Új verseny��6   $��Right=�64   $	��Top=�6P   $	��100��6h   $��42��6u   6�   �� 5   
   -   5        $ MessageLabel��5      $��2��6   $�� ��63   $��Right=�6>   $��
90,365,0,0q�6Z   $	��Top=�6n   $	��616��6�   $��42��6�   
���   �$��14(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��VersenyekDataGrid��5       $��1��6      AutoGenerateColumns .     CanUserAddRows .  $��Stretch=�5      $��Stretch=�61      RowBackground �#fff$
��Bold"�5      ���#525252��. $	��390��5   &   $	��390��63      AlternatingRowBackground �#f2f2f2���#000$��1q�5   7   $��Visible=�5       $
��Auto=�5!      	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ Id�6O     5$      $
 Competition��6%    .  6:   �� $ Competition�6a     5%      $
 Description��6%    .  6:   �� $ Description�6a   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $

 Edit��6)      CellTemplate 5'      �� 5(      .R�5)      �� $��EditBtn��6%   -   5        $
��Edit��5)   4   6C   5*      5,        5-      $
 Delete��6)    5.      �� 5/      .R�50      �� $��	DeleteBtn��6%   -   5        $��Delete��50   6   6G   51      53      55      56      57      