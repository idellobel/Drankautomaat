   M S B A M L   `   `   `  ����K  GWpfDrankAutomaat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfDrankAutomaatWpfDrankAutomaat  5   	   !    WpfDrankAutomaat.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfDrankAutomaat     5   	   -   5          �Name$  DrankAutomaat��5   	    � Title$ DrankAutomaat��5   	   $	��700��6   $	��550��6,    � 
ResizeMode$ NoResize=�68   .��5	      � -   5         �Name$ gdDrankautomaat��5	      $��0,-48,0,0.4q�6$   .+�5
   
   �� -   5         ��Name$ spMaakEenKeuze��5
      $��25,70,34,508q�6-    �� Orientation$ 
Horizontal=�6C   6^   �� 5   
   -   5         ��Name$ gbMaakEenKeuze��5      $��Maak een keuze��6+   $��Right=�6C   $	��140��6_   $��	0,70,34,0q�6l   $	��Top=�6   $	��485��6�   $��1,1,1,1q�6�   �� 5   
   -   5         ��Name$ lbHuidigeKeuze��5      $��Huidige keuze:��6(   $	��120��6A   $��30��6M   $��0,140,399,500.4q�6Y   $��Right=�6r   $��30,5,5,5q�6�   ��. 6�   �� 5   
   -   5        $ spInworpEuro��5      $
��Left=�6+   $��80��6F   $��
25,245,0,0q�6R   $	��Top=�6f   $	��485��6~   $ 
Horizontal=�6�   �� 5   
   -   5        $ gbInworp��5      $��Inworp��6%   $��Right=�65   $	��Top=�6Q   $	��140��6i   $��
0,245,34,0q�6v   $	��485��6�   �� 5   
   -   5        $ lbHuidigeInworp��5      $��Huidige Inworp:��6)   $��Right=�6C   $��0,355,399,0q�6_   $	��Top=�6t   $	��120��6�   $��30��6�   $��30,5,5,5q�6�   ��. 6�   �� 5   
   -	   5        $ spInworpEuroCent��5      $
��Left=�6/   $��85��6J   $��
25,300,0,0q�6V   $	��Top=�6j   $	��485��6�   $ 
Horizontal=�6�   �� 5   
   -
   5        $ Melding��5      $��Melding:��6!   $
��Left=�64   $��
20,455,0,0q�6O   $	��Top=�6c   $	��125��6{   $��30��6�   $��0,5,5,5q�6�   ��. $
��Bold"�6�    J� RenderTransformOrigin$ 
0.458,1.16&�6�   �� 5   
   -   5        $ lbIngeworpenBedrag��5      $��€ 0.00��6,   $
��Left=�6=   $��430,355,0,0q�6X   $	��Top=�6m   $��30��6�   $��60��6�   �� 5   
   -   5        	 ��Name$	 btAnnuleren��5      $��	Annuleren��6&   $
��Left=�6:   $��
20,410,0,0q�6U   $	��Top=�6i   $	��230��6�   $��30��6�   6�   �� 5   
   -   5        $	 btnKopen��5      $��Kopen!��6#   $��255,410,20,0q�64   $	��Top=�6J   $��30��6b   $	��230��6n   {�.  6�   �� 5   
   -   5        $ lbStatus��5      $
��Kies��6"   $��Right=�61   $��430,455,0,0q�6M   $	��Top=�6b   $��30��6z   $��74��6�   ���	#00000000���	#FF60EB206�   �� 5   
   -   5        $	 btNeemDrankje��5      $��Neem drankje��6(   $��Center=�6?   $��150,640,150,0q�6\   $	��Top=�6s   $	��230��6�   $��30��6�   $y�Hidden=�6�   6�   �� 5   
   -   5        $ lbDrankkeuze��5      $�� ��6&   $��Right=�61   $��
0,164,54,0q�6M   $	��Top=�6a   $��30��6y   $	��160��6�   
���   �6�   �� 5   
   -   5        $ lbMdedelingInhoud��5      $�� ��6+   $
��Left=�66   $��
25,490,0,0q�6Q   $	��Top=�6e   $	��145��6}   $	��120��6�   ���	#FFF413136�   �� 5   
   -   5        
 ��Name$
 img01��5      $
��Left=�6   $	��100��6:   $��157,490,0,0q�6G   $	��Top=�6\   $��93��6t   $
��Fill=�6�   5      5      