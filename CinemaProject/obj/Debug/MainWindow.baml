   M S B A M L   `   `   `  ����  CinemaProject    CinemaProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Cinema Project by yurKO��5   	   $	��400��6)   $��585.5��66    � SizeToContent$ WidthAndHeight=�6]   .��5      � -   5         �Name$ mwGrid��5      .+�5   
   �� -   5         ��Name$ 
cbSessions��5      $
��Left=�6'   $��	87,40,0,0q�6B   $	��Top=�6U   $	��120��6m   6y   �� 5   
   -   5        $ cbHalls��5      $
��Left=�6$   $��
307,10,0,0q�6?   $	��Top=�6S   $	��120��6k   6w   �� 5   
   -   5        $ cbFilms��5      $
��Left=�6$   $��
307,40,0,0q�6?   $	��Top=�6S   $	��120��6k   �� 5	   
   -   5         ��Name$ tblSessions��5	      $
��Left=�6)   $��	10,40,0,0q�6D   $
��Wrap=�6W   $��20��6k   $��62��6w    �� TextAlignment$ Center=�6�   $	��Top=�6�   �� 6�    � Language$ ru-ru�6�   $�
Сеанс��6�   6�   �� 5
   
   -   5        $ tblHalls��5
      $
��Left=�6&   $��
240,10,0,0q�6A   $
��Wrap=�6U   $��20��6i   $��62��6u   $ Center=�6�   $	��Top=�6�   $��Зал��6�   �� 5   
   -   5        $ tblFilms��5      $
��Left=�6&   $��
226,40,0,0q�6A   $
��Wrap=�6U   $��20��6i   $��76��6u   $ Center=�6�   $	��Top=�6�   $��
Фильм��6�   � 5   
   -	   5        $
 grid��5      $��
10,60,0,10q�6   $
��Left=�61   $	��Top=�6L    � ShowGridLines . 6d   �� 5   
   -
   5         ��Name$ btZvit��5      $#��Отчет о
продаже��6!   $
��Left=�6D   $��
482,10,0,0q�6_   $	��Top=�6s   $��70��6�   $��52��6�   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 � MappingMode$
 RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FFF3F3F3��6#   � 5      $ 	#FFEBEBEB��6#    � Offset$ 1Q�65   � 5      $ 	#FFDDDDDD��6#   $ 0.954Q�65   � 5      $ 	#FF16C8E4��6#   $ 0.167Q�65   � 5      $ 	#FE45E277��6#   $ 0.862Q�65   5      5      �� 5   
   -   5        $ tbDate��5      $
��Left=�6$   $��0,10,0,0q�6?   $
��Wrap=�6Q   $��20��6e   $	��100��6q   $ Center=�6}   $	��Top=�6�   $��Дата сеанса��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDate��5      $
��Left=�6%   $��
105,10,0,0q�6@   $	��Top=�6T   6l   5      5      