   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media 5   	        ProWPF.Advanced.ListColors   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	   Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore     5   	     ? Title$  颜色列表??5	   	   $	??450??6   $	??800??6#   .??5      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $??2* ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? -   5         ??Name$ 
listColors??5      $??4q?6&       ProWPF.Advanced.ListColors   ListFullColors#??Z 61    ?? SelectionMode$ Multiple=?5       ? 	Resources 5       ?? 
TargetType ?? Property ?? Value	 ?? 
TargetType
 ??Name ?? Padding ?? Triggers P? Property P? Value ?? 
TargetName??%?  '??       ?? 5      " ??6   .?5      ??  ? ?? 5      ?? 5      "	 ??6.   .R?5   "   ?? $
 PART_border??6)   $	??8,4q?6>   $	 8,4q?6K   
?????? ._?5   &   ?? $??Center=?67   $??Center=?6T   5   #    5   "   P? 5   &    ?@J?IsMouseOver . . ?5   *   ?? $ PART_border??6Y    ? ?? ?	#FF69C3315    '   P? 5"   &    ?@??
IsSelected . . ?5#   *   ?? $ PART_border??6Y    ? ?? ?	#FF49E8845$   '   5&      5(      5)      5*      ??5,      ?? 5-      .R?5.      A? $??4q?6"    A? Columns$ 4??6-   5/      ??52      ?? 53       ?? DataType   ProWPF.Advanced.FullColor"  6   .R?54      ]? ??. $	??150??65    ? ToolTip 6D   ?? *
ColorValue+.+?55      ?? $??20??6!   $??20??6,   $??Right=?68   ??56      ?? 57   "    ?? Color 62   ?? *
ColorValue+59      ?? 5;      $??Center=?6?   ??6$   ?? *	ColorName+6?   5<      5=      5?      ]? 5A   
   $??1??6   $??4q?6!   ??. .+?5B      ?? -   5        $
 borderColorsView??5B      $	??100??6/   $	??100??6;   
?????? $??Right=?6a   $??	50,0,50,0q?6x   ?? 5D      $??WrapWithOverflow=?6   当前选中的颜色：?? 5F      ?? 5G      -   5         ??Name$ runSelectionColors??5G      5H      5I      ?? 5K   
   -   5        $??2??5K      $	??0,4q?6   $??60,10q?6+   $??Center=?6;   .??6n   Examine All Items6?   5L      5M      