   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	   I EProWPFResource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:ProWPFResource;assembly=ProWPFResourceProWPFResource 5   	   $    ProWPF.Advanced.ObjectResource   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	   Dres4clr-namespace:ProWPFResource;assembly=ProWPFResource     5   	     ? Title$  对象资源??5	   	   $	??650??6   $	??800??6#    ? 	Resources 5       ?? MergedDictionaries ?? Source   	TileBrush j? TileMode ?? ImageSource j? ViewportUnits j? Viewport ?? Opacity  UnsharedBrush	 ?? Color?? 5   
    5      ?? 5      $ /Themes/generic.xaml??6%   %?   &	        &	 {    ?? 5      $
 Tile=?6+   $ /Images/happyface.png??6;   $ Absolute=?5      $ 	0 0 32 32?6.   $	 0.3Q?6C   ?? 5      $	 Orange??6E   $	 0.3Q?6T   5      .??5      ? $??4q?6   
 ? ColumnDefinitions
 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5       $
??Auto ?6   ?? 5!      $
??Auto ?6   ?? 5"      $
??Auto ?6   .+?5%   
   ?? $??4q?6   $??2??6   
???  ??$??12(?6D   $
??Wrap=?6R   }* 程序集资源：嵌入到编译过的程序集中的二进制数据，确保应用程序所需的图像或声音文件。?? 5'      ??* 对象资源：在某个位置定义并且其他几个位置重复使用的.NET对象。（可实例化任何.NET类及自定义类--公有的无参构造函数和可写的属性）?? 5)      ??* 使用系统资源SystemColors（颜色），SystemFonts（字体），SystemParameters（描述各种屏幕元素的标准尺寸、键盘和鼠标设置、屏幕尺寸以及各种图形效果） 它们的命名空间在System.Windows。5,      ?? 5.   
   $??1??6   $??0??6    $??StaticResource??60   $??4q?6H   .??5/      ?? $??4q?6   .+?50      ?? $??4q?6   $
??Wrap=?6'   $????静态资源在创建窗口时加载。只获取对象一次，根据对象的类型及使用对象的方式，对象的任何变化都可能注意到。??51      ?? 53      #??[  6   $??5q?6A   $??5q?6L   $
??Bold"?54      $??14(?6+   $??A Tiled Button??69   ?? 56      $??4q?6   $3??-静态资源须在资源定义之后使用。??6'   ?? 5:      $??5q?6   $??5q?6$   $
??Bold"?60   $??14(?6B    5;      ??%?   &	        ?? 5<      $
 Tile=?67   $ Absolute=?6G   $ 	0 0 10 10?6`   $ /Images/happyface.png??5=   %   $	 0.3Q?6I   5>      ??5@      ?? 5A       ?? ResourceKey$ 	TileBrush??6)   .??5B   )   Another Tiled Button5D      ?? 5F      $??4q?6   $E???非共享资源，每次使用时创建单独的对象实例。??6'   ?? 5H      $??5q?6   $??5q?6$   $
??Bold"?60   $??14(?6B   #??[ 6P   $??Unshared Button??5I      ?? 5K      $??4q?6   $W??Q直接使用系统资源，当系统资源变化时，使用者不随之更改。??6'   ?? 5M      $??5q?6   $??5q?6#   $??Ordinary text??6/   $??Center=?6G   #??Z??5N      #??["??5O      #??Z??5P      ?? 5R      $??4q?6   $??资源字典??6'   ?? 5T        WizardBrush#??[ 6   $??5q?6C   $??5q?6N   $
??Bold"?5U      $??14(?6+   $??A Wizard Button??69   5V      5W      ?? 5Y   
   $??1??6   $??1??6    $??DynamicResource??60   $??4q?6I   .??5Z      ?? $??4q?6   .+?5[      ?? $??4q?6   $
??Wrap=?6'   $????动态资源在第一此使用它们时加载，如果发生了改变就会重新应用资源。需要对象时都会重新从资源集合中查找对象。??6;   ?? 5]      #???   6   $??5q?6B   $??5q?6M   $
??Bold"?5^      $??14(?6+   $??A Tiled Button??69   ?? 5`      $??4q?6   $3??-动态资源可在资源定义之前使用。??6'   ?? 5c      $??5q?6   $??5q?6$   $
??Bold"?60   $??14(?6B   #???   6P    5d      ??%?   &	        ?? 5e      $
 Tile=?67   $ Absolute=?6G   $ 	0 0 10 10?6`   $ /Images/happyface.png??5f   %   $	 0.3Q?6I   5g      .??6(   Another Tiled Button5i      ?? 5k      $??4q?6   $Q??K非共享资源有单独的对象实例，实例与实例间互不影响。??6'   ?? 5m      $??5q?6   $??5q?6$   $
??Bold"?60   $??14(?6B   #???  6P   $??Unshared Button??5n      ?? 5p      $??4q?6   $T??N动态使用系统资源，当系统资源变化时，使用者随着变化。??6'   ?? 5r      $??5q?6   $??5q?6#   $??Ordinary text??6/   $??Center=?6G   #??? ??5s      #??? ??5t      #??? ??5u      ?? 5w      $??4q?6   $
??Wrap=?6'   pn程序集共享资源；当使用ComponentResourceKey时，只能使用动态资源，不能使用静态资源5y      ?? 5{      $??5q?5|      $??5q?6$   $
??Bold"?60   $??14(?6B   $??SadTileBrush??6P   ??5{      C? *??  ?? TypeInTargetAssembly$  ProWPFResource.CustomResources"   ?? 
ResourceId$ SadTileBrush??+5|   P   ?? 5~         SadTileBrushKey#???  6   $??5q?5      $??5q?6$   $
??Bold"?60   $??14(?6B   $??SadTileBrushKey??6P   5?      5?      ? 5?   
   $??2??6   $??2??6   $??4q?60    5?      ?? 5?      $
??Auto ?6    ?? 5?      .+?5?      ?? $
??Wrap=?6   $??4q?6,   $??12(?67   
???  ????Brush类继承自Freezable类。Freezable类有一个基本的变化跟踪特性（如果不需要改变，被“冻结”为只读状态）。 所以无论何时在WPF中改变画刷，所有使用该画刷的控件都会自动更新。控件是否通过资源获取其画刷无关紧要。5?      ?? 5?      $??1??6   $??4q?6&    ?? Orientation$ 
Horizontal=?61   $??Center=?6J   .+?5?      ?? -   5        $??改变画刷??5?      $??4q?6(   $	??8,4q?63   6A   ?? 5?      -   5        $??替换画刷??5?      $??4q?6(   $	??8,4q?63   6A   ?? 5?      -   5        $??改变非共享画刷??5?      $??4q?6+   $	??8,4q?66    ? ToolTip$q k非共享资源，每次使用都有单独的实例，所有此处更改资源无效（即使是Brush类）??5?      5?      5?      5?      5?      