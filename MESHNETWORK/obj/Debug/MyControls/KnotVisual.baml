   M S B A M L   `   `   `  ����F  BMESHNETWORK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MESHNETWORK.MyControlsMESHNETWORK.MyControls  5      9!clr-namespace:MESHNETWORK.ClassesMESHNETWORK.Classes  5      '    !MESHNETWORK.MyControls.KnotVisual   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MESHNETWORK.MyControls     5      5Classes!clr-namespace:MESHNETWORK.Classes     5      -   5          >�Name$  userControl��5   @    J� RenderTransformOrigin$ 25,25&�5   L   $��Center=�6j   $��Center=�6�   $��-100000q�6�    � 	Resources 5       �� 
TargetType   
RadiusBase �� Property �� Value  	RadiusOff �� BasedOn  RadiusON  Base 
 Common � Color � Offset	 �� Triggers
 P� Property P� Value 
 Source 
 Target��%2  &	        &	 �     7   &	 9    7   &	 �    &	 G    7  &	     7  &	 �    7  �� 5   
   " A�6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � �� 6%   Z� �� 5       � ��
 �   �6'   �� 5       �@K�ZIndex$ 2��6-   5      �� 5   
   " A�6   8   .�5      ��  � y�$ Hidden=�6+   5      �� 5   
   " A�6   8   .�5      ��  � y�$ Visible=�6+   5      �� 5   
   " A�6   .�5       ��  � ��$ Center=�64   �� 5!       � ��$ Center=�62   �� 5"       � ��$ 50��6&   �� 5#       � ��$ 50��6'   5$      �� 5%   
   " A�6   8   .�5&      ��  � �� 5'      
� 5(      .��5)      � $ 	#FFF9F9F9��6'   � 5*      $ 1Q�6J    6'   �� *Config.ColorKnot+6J   5+      5-      	 5.      P� 5/      
 �@J�IsMouseOver . . �50      ��  � �� 51      
� 52      .��53   "   � $ 	#FFF9F9F9��6/   � 54   "   $ 1Q�6T    6/   �� *Config.ColorSelect+6T   55      57      58      5:      �� 5;   
   " A�6   8   .�5<      ��  � �� 5=      
� 5>      .��5?      � $ 	#FFF9F9F9��6'   � 5@      
ColorPoint��$ 1Q�6`    6;   �� *Config.ColorSource+6`   5A      5C      5D      �� 5E   
   " A�6   8   .�5F      ��  � �� 5G      
� 5H      .��5I      � $ 	#FFF9F9F9��6'   � 5J      
ColorPoint��$ 1Q�6`    6;   �� *Config.ColorTarget+6`   5K      5M      5N      5O      .��5P      � .+�5Q   
   A� -   5         A�Name$ Radius��5Q      #���  6"   ��6E   �� *	Ks.Radius+ �� Mode$ TwoWay=���6n   �� *	Ks.Radius+$ TwoWay=�A� 5R   
   -   5        $ Point��5R   3   #���  6    � ToolTip 5S      �� 5T       �� Orientation$ Vertical=�6   .+�5U      �� ��6    �� *Ks.id+ �� StringFormat$ Код: {0}���� 5V      ��6    �� *	Ks.Name+$ Название: {0}���� 5W      ��6    �� *
Ks.CordX+$! Координата X: {0}���� 5X      ��6    �� *
Ks.CordY+$! Координата Y: {0}���� 5Y      ��6    �� *	Ks.Radius+$ Радиус: {0}��5Z      5\      5]      5^      