   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProWPF.ConvertersProWPF.Converters  5   	   ,    &ProWPF.ShapeAndAnimation.ViewboxResize   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6
convertersclr-namespace:ProWPF.Converters     5   	     ? Title$%  使用Viewbox控件缩放形状??5   	   $	??450??6!   $	??800??6.    ? 	Resources 5	      .  (ProWPF.Converters.CheckedToEnumConverter &  "CheckedToStretchDirectionConverter   
TargetEnum.  (System.Windows.Controls.StretchDirection  CheckedToStretchConverter"  System.Windows.Media.Stretch??%D   &	        &	        5
   
   "  6W     5   
   "  6N   5      .??5      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??4q?6.    5       ?? 
TargetType ?? Property ?? Value??%?   '	?       ?? 5      " 	?6   .?5      ??  ? ??$	 8,4q?6/   ?? 5       ? ??$ Center=?6A   ?? 5       ? ??$ Center=?6C   5      5      .+?5      ?? $??Viewbox-Stretch??6   $	??8,4q?60   $??4q?6=   .??5      ?? $ 
Horizontal=?6   .+?5       	?  d? 	IsChecked 6"   ?? 	 ?? ElementName$	 viewbox??
 ?? Path$
 Stretch? ?? ConverterParameter$
 Fill?? ?? 	Converter# [ .??6?   Fill6?   	? 5!       6"   ?? $	 viewbox??$
 Stretch?$
 None??# [ .??6?   None6?   	? 5"       6"   ?? $	 viewbox??$
 Stretch?$ Uniform??# [ .??6?   Uniform(默认)6?   	? 5#       6"   ?? $	 viewbox??$
 Stretch?$ UniformToFill??# [ .??6?   UniformToFill6?   5$      5%      ?? 5'      $??Viewbox-StretchDirection??6   $	??8,4q?69   $??4q?6F   .??5(      ?? $ 
Horizontal=?6   .+?5)      	?  6"   ?? $	 viewbox??$
 StretchDirection?$
 Both??# [  .??6?   Both(默认)6?   	? 5*       ? ToolTip$? 9只会缩小而不会增长超过其原始尺寸的内容??6?    6"   ?? $	 viewbox??$
 StretchDirection?$ DownOnly??# [  .??6?   
DownOnly6?   	? 5+      $? 9只会增长而不会收缩超过其原始尺寸的内容??6?    6"   ?? $	 viewbox??$
 StretchDirection?$ UpOnly??# [  .??6?   UpOnly6?   5,      5-      5.      ?? 50   
   $??1??6   $??4q?6!   $
??Wrap=?6,   
???  ??SQ* 为使Viewbox元素执行其缩放工作，需要能够确定两部分信息：?? 52      ??1.内容应当具有的原始尺寸--Viewbox不缩放时的尺寸（如下面的示例Canvas被明确设置300x400单位大小），Viewbox以该尺寸缩放图像。?? 54      wu2.希望内容具有的新尺寸--根据Viewbox的Stretch属性，让其内部的内容使用所有可用的空间。56      (? 58   
   -   5         (?Name$ viewbox??58      $??2??6#   $
??Left=?60   $??4q?6K   .??5:      ?? $	??300??6   $	??480??6"   ??5;      ?? 5<       j? TileMode$
 Tile=?6!    j? ViewportUnits$ Absolute=?61    j? Viewport$ 	0,0,60,60?6J    ?? ImageSource 5=      H? 5>       H? Drawing 5?   "   I? 5@   &   .??5A   *   ?  ? Geometry 5B   .   ?? 5C   2    ?? Rect$ 	0,0,10,10?6D    ? Brush 5E   .   ?? 5F   2    ?? Color$
 Gray??6B   
 ? Pen 5H   .   >? 5I   2    >? Brush
 ????? >? 	Thickness$ 1Q?6C   5K   +   ? 5L   *    5M   .   ?? 5N   2   $ 10,10,10,10?6D    5P   .   ?? 5Q   2   $
 Gray??6B    5S   .   >? 5T   2   
 ?????$ 1Q?6C   5V   +   5W   '   5Y      5[      .+?5^      ?? $	??100??6   $??50??6(   
??? ???
????  ? ?? Left$ 10??6P   
 ?? Top$ 10??6a    ?? RadiusX$ 10??5_       ?? RadiusY$ 50??6)   A? 5`      
??? ???
????  ?$ 30??66   $ 40??6G   $	??100??6W   $??50??6c   5a      5b      5c      5d      