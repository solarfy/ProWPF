   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProWPF.DataProWPF.Data  5   	   O KCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary 5   	       ProWPF.Data.AboutListView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProWPF.Data     5   	   Rctrls@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary     5   	   -   5          ? Title$  关于ListView??5	   	   $	??450??6   $	??800??6)    ? 	Resources 5      $  ProWPF.Data.ImagePathConverter   ImagePathConverter  GridView! ?? ColumnHeaderContainerStyle ?? 
TargetType ?? Property ?? Value ?? DisplayMemberBinding ?? Path ?? Width	 ?? CellTemplate
 ?? 	Converter ?? StringFormat#  CustomControlLibrary.TileView  	ImageView   SelectedBackground   SelectedBorderBrush   ItemTemplate  ImageDetailView ? ColumnDefinitions z? SharedSizeGroup??%?  &	        &	      7   &	 ?    7   &	 ?    7     5   
   6#   ?? 5   
    5      ?? 5      " ??6   .?5      ??  ? ??$
 Bold"?63   ?? 5       ? ??$ Center=?6C   5      P?5      ?? 5      $??名称??6!    6-   ?? $ 	ModelName??? 5      $??型号??6!    6-   ?? $ ModelNumber??? 5      $??描述??6!   $	 300??6-   	 5      ?? 5      .R?5      ?? $
??Wrap=?6J   ??6(   ?? $ Description?6J   5      5      ?? 5       $??图片??6!   	 5!      ?? 5"      .R?5#      ?? ??6$   ?? $ ProductImagePath?8
   5$      5&      ?? 5'      $??单价??6!    6-   ?? $ UnitCost?$ {0:C}??5)        5+   
   
 ??·?
 ?? ? 5,      ?? 5-      .R?5.      ?? $	??150??6!   $	??Top=?6-   .+?5/      ?? ??6    ?? $ ProductImagePath?8
   ?? 50      $
??Wrap=?6$   $??Center=?68   ??6U   ?? $ 	ModelName?51      52      54        56   
   
 ?"?"?
 ? ??? 57      ?? 58      .R?59      ?  5:      ?? 5;      $
??Auto ?6/   ?? 5<      $
??Auto ?6/   $
 Col2??6<   .+?5?      ?? $??5q?6    $	??100??6+   ??67   ?? $ ProductImagePath?8
   ?? 5A      $??1??6%   $??Center=?65   .+?5B      ?? $
??Bold"?6(   ??6:   ?? $ 	ModelName??? 5C      ??6(   ?? $ ModelNumber??? 5D      ??6(   ?? $ UnitCost?$ {0:C}??5E      5F      5G      5I      5J      .??5L      ?  ? RowDefinitions 5M   
   ?? 5N      $
??Auto ?6   ?? 5O      $
??Auto ?6   ?? 5P      .+?5S   
   ?? $??8q?6   $
??Wrap=?6   ??如果同时设置了DisplayMember和CellTemplate属性，GridViewColumn就会使用DisplayMember属性为单元格设置内容并完全忽略模板。5U      ?? 5W   
    ?? Orientation$ 
Horizontal=?6   $??8q?6.   $??1??69   .+?5X      ?? $??选择视图??6   $??Center=?6$   $??0,0,10,0q?6?   ?? 5Y      -   5         ??Name$ cboxView??5Y       ?? 
IsReadOnly .  ?? 
IsEditable .   ?? SelectedIndex$ 0??6N   .@?5Z      ?? $??GridView??6   ?? 5[      $??	ImageView??6   ?? 5\      $??ImageDetailView??6   5]      5^      ?? 5`   
   -   5         ??Name$ lstvProducts??5`      $??2??6)   $??8q?66    ?? View 5a      ?? 5b       5c      ?? 5d      " ??6    .?5e      ??  ? ??$
 Bold"?6;   ?? 5f       ? ??$ Center=?6K   5g      P?5i      ?? 5j      $??名称??6)    65   ?? $ 	ModelName??? 5k      $??型号??6)    65   ?? $ ModelNumber??? 5l      $??描述??6)   $	 300??65   	 5m      ?? 5n   "   .R?5p   &   ?? $
??Wrap=?6R   ??60   ?? $ Description?6R   5q   #   5s      ?? 5t      $??图片??6)   	 5u      ?? 5v   "   .R?5w   &   ?? ??6,   ?? $ ProductImagePath?#
 [  5x   #   5z      ?? 5{      $??单价??6)    65   ?? $ UnitCost?$ {0:C}??5}      5      5?      5?      