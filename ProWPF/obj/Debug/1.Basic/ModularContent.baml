   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProWPF.ConvertersProWPF.Converters  5   	   !    ProWPF.Basic.ModularContent   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6
convertersclr-namespace:ProWPF.Converters     5   	     ? Title$  组合式用户界面??5   	   $	??450??6   $	??800??6&    ? 	Resources 5	      4  .ProWPF.Converters.BooleanToVisibilityConverter   	converter   	TrueValue   
FalseValue??%@   &	          5
   
   $ Visible=?6D   $ 	Collapsed=?6X   5      .??5      ]? ??. .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $	??Top=?6.    5       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5      " ??6   .?5      ??  ?@d?	IsChecked$
 TrueY?62   ?? 5       ? ??$
 12,6q?6/   5      5      .+?5      ?? -   5         ??Name$ 	checkbox1??5      $??Page1??6*   ?? 5      -   5        $ 	checkbox2??5      $??Page2??6*   ?? 5      -   5        $ 	checkbox3??5      $??Page3??6*   ?? 5      -   5        $ 	checkbox4??5      $??Page4??6*   5      ? 5   
   $??12q?6   .+?5      A? -   5        	 A?Name$	 page1??5      
 A? Rows$
 2??6)    A? Columns$ 2??62   y?5      ??  ?? ElementName$ 	checkbox1?? ?? Path$ 	IsChecked? ?? 	Converter# [   5      ??%?   '??       ?? 5      " ??6   .?5       ??  ? ??$	 100??62   ?? 5!       ? ??$	 100??63   ?? 5"       ? ??$ 10q?63   5#      5$      .+?5%      ?? $??1??6   ?? 5&      $??2??6   ?? 5'      $??3??6   ?? 5(      $??4??6   5)      ? 5+      -   5         ?Name$ page2??5+      y?5,      ?? $ 	checkbox2??$ 	IsChecked?# [  .+?5-      ?? $	??400??6   .@?5.      ?? $
??Tab1??6   .??5/      ?? $
??tabs??6    
???????6/   50      ?? 51      $
??Tab2??6   .??52      ?? $
??tabs??6    
??? ???6/   53      54      55      ]? 57      -   5         ]?Name$ page3??57      ??. y?58      ?? $ 	checkbox3??$ 	IsChecked?# [  .+?59      ?? $ 
Horizontal=?6   $??Bottom=?66   .+?5:      ?? $??OK??6   ?? 5;      $??Cancel??6   5<      ?? 5>      .??6   :8This is a test of a text box that contains wrapped text.5@      5A      A? 5C      -   5        $	 page4??5C      $
 2??6)   $ 2??62   y?5D      ?? $ 	checkbox4??$ 	IsChecked?# [   5E      ??%?   '??       ?? 5F      " ??6   .?5G      ??  ? ??$ 50??62   ?? 5H       ? ??$ 50??63   ?? 5I       ? ??$ 5q?63   5J      5K      .+?5L      ?? $??5??6   ?? 5M      $??6??6   ?? 5N      $??7??6   ?? 5O      $??8??6   5P      5Q      5R      5S      