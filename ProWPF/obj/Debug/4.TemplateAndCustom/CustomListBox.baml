   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProWPF.TemplateAndCustomProWPF.TemplateAndCustom  5   	   ,    &ProWPF.TemplateAndCustom.CustomListBox   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProWPF.TemplateAndCustom     5   	     ? Title$  自定义ListBox样式??5   	   $	??450??6   $	??800??6+    ? 	Resources 5
         ListBoxBackgroundBrush ? Color ? Offset  StandardBroderBrush  StandardBrush ?? Color  PressedBrush 
? GradientOrigin  
GlyphBrush ?? 
TargetType ?? Property ?? Value	 ?? 
TargetType
 ??Name ?? CornerRadius J? SnapsToDevicePixels ?? Triggers :? RoutedEvent	 W? To g? Duration ?? TargetProperty g? 	BeginTime P? Property P? Value ?? 
TargetName  ScrollBarPageButtonStyle  ScrollBarLineButtonStyle A?Name  ScrollBarThumbStyle  VerticalScrollBar ? RowDefinitions ]?Name ]? DecreaseRepeatButton ]? IncreaseRepeatButton ]? Thumb ?? Triggers??%?  &	        &	 |     &	 ?     &	     &	 ?    '?? ?    7   7  '?? ?    &	      &	 ?    7  7  7  &	 ?    7  7  7  7  &	 ?	    7  7  7  7  7  7  7  '?? ?    7  ?? 5   
   .??5      ? $ LightYellow??6   $ 0Q?6/   ? 5      $ 	AliceBlue??6   $ 1Q?6-   5      ?? 5   
   .??5      ? $ Orange??6   $ 0Q?6*   ? 5      $ Green??6   $ 1Q?6)   5      ?? 5   
   $ Green??60   
? 5   
   $ 0.5 0.5&?63   .??5      ? $ LightYellow??6   $ 0Q?6/   ? 5      $ 	LightBlue??6   $ 1Q?6-   5      ?? 5   
   $ Coral??6-   ?? 5   
   " ??6   .?5      ??  ? ?? 5       ?? 5!      "	 ??6&   .R?5"      ?? $
 border??6!   8??  8?? $??1q?5#   T   $ 4??6h    . ._?5$      ?? |?.  .??5&   "   ?? $??4q?61   5'      5(      5)      5+      5,      ?? 5.   
   " ??6   .?5/      ??  ? ?? 50      ?? 51      "	 ??6&   .R?52      ?? $
 border??6!   $??1q?61   $ 4??6E   $??0q?6V   ._?54      ?? $	??4,6q?6/   55       57      :? 58      $ 
MouseEnter??6+   .[?59   "   ?? .??5:   &   ?? .??5;   *   W? $ 20X?6:   $ 0:0:1D?6B   $ FontSize?6S   5<   '   5=   #   5>      :? 5?      $ 
MouseLeave??6+   .[?5@   "   ?? .??5A   &   ?? .??5B   *   W? $ FontSize?6:   $ 0:0:0.2D?6_   $ 0:0:0.5X?6r   5C   '   5D   #   5E      P? 5F       ?@J?IsMouseOver . . ?5G   "   ?? $ border??6)    ? ?? ?	#7F0000006T   5H      P? 5I       ?@??
IsSelected . . ?5J   "   ?? $ border??6)    ? ??
 ?????6S   ?? 5K   "   $ border??6)    ? ??
 ?????6]   5L      5N      5P      5Q      ?? 5T   
   " ??61   .?5U      ??  ? ?? .  6*   ?? 5V       ? |? .  6*   ?? 5W       ? ?? 5X      ?? 5Y      "	 ??6&   .R?5Z      ?? 
?????? 6!   5[      5]      5^      ?? 5a   
   " ??61   .?5b      ??  ? |? .  6*   ?? 5c       ? ?? 5d      ?? 5e      "	 ??6&   .R?5f      ? $??1q?6   .+?5g      A? $ border??6&   $??1??66   8??  8?? 6x   ?? 5h      $??Center=?6/   $??Center=?6L   5i       5j      P? 5k       ? ?? . . ?5l   "   ?? $ border??6)   8   ? ??6M   5m      5o      5q      5s      ?? 5v   
   " n?6,   .?5w      ??  ? ?? .  6*   ?? 5x       ? |? .  6*   ?? 5y       ? ??$ 1 0 1 0q?6'   ?? 5z       ? ??8   6+   ?? 5{       ? ??8  6,   ?? 5|       ? ?? 5}      ?? 5~      "	 n?6&   .R?5      A? 8?? 8?? 6P   5?      5?      5?      ?? 5?   
   "	 ??64   .R?5?      ?  5?      ?? 5?      $??18??6$   ?? 5?      $??* ?6$   ?? 5?      $??18??6$   .+?5?      ?? $??0??6   $??18??6,   8??  $??ScrollBar.LineUpCommand??6j   .??5?      F? 8?? "????     	= ? z  	= ? 	=     	6>   5?      ]? 5?      $ 
PART_Track??6   $??1??6,   ??. $??0Q?6T    5?      ?? 5?      8?? $??ScrollBar.PageUpCommand??6Y    5?      ?? 5?      8?? $??ScrollBar.PageDownCommand??6Y    5?      n? 5?      8?? 6    5?      ?? 5?      $??2??6   $??18??6,   8?? $??ScrollBar.LineDownCommand??6j   .??5?      F? 8?? "????        ? 	=  	= ? z     	6>   5?      5?      5?      ?? 5?   
   " ??6   .?5?      ??  ?@J?SnapsToDevicePixels . 64   ?? 5?       ?@?OverridesDefaultStyle . 66    5?      P? 5?       ?@??Orientation$ Vertical=?61   . ?5?      ??  ? ??$ 18??6.   ?? 5?       ? ??$
 Auto??6/   ?? 5?       ? ??8   61   5?      5?      5?      .??5?      ? .+?5?   
   ?? $	??150??6   $	??400??6   $??Visible=?6+   .@?5?      ?? .??6   One6   ?? 5?      .??6   Two6   ?? 5?      .??6   Three6!   ?? 5?      .??6   Four6    ?? 5?      .??6   Five6    ?? 5?      .??6   Six6   ?? 5?      .??6   Seven6!   ?? 5?      .??6   Eight6!   ?? 5?      .??6   Nine6    ?? 5?      .??6   Ten6   ?? 5?      .??6   	Hundred6#   ?? 5?      .??6   
Thousand6$   ?? 5?      .??6   	Million6#   5?      5?      5?      