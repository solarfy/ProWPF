   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProWPF.DataProWPF.Data  5   	   H DStoreDataBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP8clr-namespace:StoreDataBase.Model;assembly=StoreDataBaseStoreDataBase.Model 5   	   D2clr-namespace:StoreDataBase;assembly=StoreDataBaseStoreDataBase 5   	       ProWPF.Data.DataTemplates   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProWPF.Data     5   	   Jmodel8clr-namespace:StoreDataBase.Model;assembly=StoreDataBase     5   	   Adb2clr-namespace:StoreDataBase;assembly=StoreDataBase     5   	     ? Title$  数据模板??5
   	   $	??450??6   $	??800??6#    ? 	Resources 5         Products S? 
MethodName S? 
ObjectType  StoreDataBase.StoreDB$  ProWPF.Data.ImagePathConverter  ImagePathConverter ?? DataType!  StoreDataBase.Model.Product J? SnapsToDevicePixels ?? CornerRadius ?? RelativeSource ?? Mode	 ?? AncestorType
 ?? Path ? RowDefinitions ? ColumnDefinitions z? SharedSizeGroup ?? 	Converter
 ? Tag ?? Triggers ?? Value ?? Binding ?? Property ?? Value??%   &	        &	 /     (?? B     5      *, +)7  S? 5   
   $ GetProducts??6.   "  6G     5   
   6#   ?? 5   
   "  6   .R?5      ? 
??????? . .+?5      ?? $??4q?6   $??1q?6$   
?????F?$ 4??5      ??5      ??  ?? $ FindAncestor=?"	 ??$
 
Background?._?5      ? $??4q?6    5      ?? 5      ?? 5      ?? 5      $
??Auto ?6,    5      ?? 5      $
??Auto ?6/   $
 col1??6<   ?? 5       $
??Auto ?6/   $
 col2??6<   .+?5#      ?? $
??Bold"?6$   ??66   ?? $
 ModelNumber?6Z   ?? 5$      $??1??6$   ??61   ?? $
 	ModelName?6S   ?? 5&      $??2??6    $??2??6-   $??4q?6A   ??5'       ?? $
 ProductImagePath?8   ?? 5*      -   5        $??1??5*   !   $??View ...??61   $	??4,2q?6D   $??4q?6R    5+   4   ?? 5,      5-      5.       50      ?? 52      $ Tools??6D    6   ?? $
 CategoryName?.a?53      ??  ? ??
 ?  ??6?   54      57      58      .??5:      ?? .@?5;   
   ?? $??数据模板选择器??6   .??5>      ?? -   5         ??Name$ lstProducts??5>       ? IsSharedSizeScope . $??8q?6?   ??6I   ??  ?? Source# [  ??5?      ?? 5@       ?? 
TargetType" ??6    ?? Triggers 5A      P? 5C       P? Property ?@??
IsSelected P? Value . . ?5D   "   ??  ? ??
 ?  ??6?   5E      5G      ??5J      9  3ProWPF.Data.SingleCriteriaHighlightTemplateSelector  5K         PropertyToEvaluate$ CategoryName??6D       PropertyValuteToHighlight$ Travel??6f      HighlightTemplate 5M      ?? 5N      .R?5O   "   ?? $??4q?6)   $??1q?64   
?????F?$ 4??6`   
???????._?5P   &   ? $??4q?6+    5Q   *   ?? 5R   .   ?? 5S   .   ?? 5T   .   .+?5W   *   ?? $
??Bold"?64   ??6F   ?? $
 ModelNumber?6j   ?? 5X   *   $??1??64   $
??Bold"?6A   ??6S   ?? $
 	ModelName?6u   ?? 5Y   *   $??2??64   $??Italic$?6A   $??Right=?6T   $!??*** Great for vacations ***??6p   5Z   '   5[   #   5\      5^      5`      5a      ?? 5c   
   $??数据触发器??6   .??5e      ?? $??8q?6   ??6!   ?? # [  ??5f      ?? 5g      .R?5h      ?? $??5q?6!   $??1q?6,   
?????F?$ 4??6X   $	??700??6i   ._?5i      ?? $??3q?6)   .+?5j   "   ?? ??6,   ?? $
 	ModelName??? 5k   "   ??5l   &   ?? 5m   *    5n   .   ?? 5p   2    6>   ?? $
 
IsSelected? ?? $ FindAncestor=?$	 ListBoxItemL?	 False6?   .a?5q   6   ??  ? y?$ 	Collapsed=?6^   5r   3   5t   +   .+?5v   &   ?? $??3q?60   $
??Wrap=?6]   $
??Left=?6q   ??6;   ?? $
 Description?6q   ?? 5w   &   $
??None=?6?   ??6,   ?? $
 ProductImagePath?# [ 6?   ?? 5x   &   -   5        $??Regular"?5x   -   $??Right=?6B   $??1q?6^   $??View Details...??6z    6j   ?? 6?   5y   #   5z      5{      5|      5~      5      ?? 5?   
   $??改变项的容器??6   .??5?      ]? ??. .+?5?      ?? $??8q?6   $
??Wrap=?6'   $	??Top=?6;   ??通过设置ItemsPanel属性，来修改项的布局。改面板可以是继承自System.Windows.Controls.Panel的任意类。 这里使用WrapPanel面板，为了使该面板奏效，还须将ScrollViewer.HorizontalScrollBarVisiblity附加属性设置为Disabled， 从而确保WrapPanel不会使用无限宽度来布局。?? 5?      ??VirtualizingStackPanel面板确保能够高效地处理大量的绑定数据，所以处理大量数据时推荐使用改面板。5?      ?? 5?      $??Disabled=?6S   ??6   ?? # [  ??5?      ?? 5?      .R?5?      ? 5?      ??5?      ?? 5?      .R?5?      ?? $ 4??6%   $??1q?66   
???????._?5?   "   ?? $??8q?6-   .+?5?   &   ?? $??Center=?6K   ??60   ?? *	ModelName+6K   ?? 5?   &   $
??None=?6?   $??Center=?5?   ,   ??5?   ,   ?? $
 ProductImagePath?# [ 5?   ,   5?   #   5?      5?      5?      5?      5?      5?      5?      