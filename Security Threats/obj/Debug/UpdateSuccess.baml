   M S B A M L   `   `   `  ����K  GSecurity Threats, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Security_ThreatsSecurity_Threats  5   	   $    Security_Threats.UpdateSuccess   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Security_Threats     5   	     � Title$  Обновление��5   	   $	��400��6   $	��500��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   ���	#FFC6E6E3.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5
      $
��Left=�6=      
IsReadOnly . $	��263��6j   $	��Top=�6x   $	��463��6�      AutoGenerateColumns .  $��	10,86,0,0q�6�   ��6%   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$' !Идентификатор УБИ��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Id+  5      $ Было��6%    63   �� *Before+  5      $ 
Стало��6%    64   �� *After+5      �� 5   
   $��Center=�6   $
��Wrap=�61   $	��Top=�6E   $��31��6]   $	��353��6i   $��22(�6u   $��
73,10,68,0q�6�   �� 6�   $� ��6�   �� 6�   $=�7Обновление завершено успешно!��6�   6�   �� 5   
   -   5        	 ��Name$
	 text��5      $��Center=�6"   $
��Wrap=�6?   $�� ��6S   $	��Top=�6[   $��20��6s   $	��200��6   $��14(�6�   $��10,46,284,0q�6�   5      5      