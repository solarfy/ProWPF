   M S B A M L   `   `   `  ????W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media  5   	   
 ProWPF   ProWPF.Advanced.TextText   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore      5   	     ? Title$  文 本??5   	   $	??450??6   $	??800??6"    ? 	Resources 5
      ??%    5      .??5      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? $??4q?6   $$??系统中已安装的字体：??6   ?? 5   
   $??1??6   $??4q?6       System.Windows.Media.Fonts   SystemFontFamilies#??Z 6*   ?? 5   
   $??2??6   $??4q?6"    ?? Orientation$ 
Horizontal=?6-   $??24(?6F   .+?5      ?? $??4q?6   $??基准线 Baseline??6#   $??Baseline{?67   $??./Fonts/#FZYanSJW_Cu)?6R   ?? 5      $??4q?6   $??上划线 OverLine??6#   $??OverLine{?67   $??./Fonts/#FZYanSJW)?6R   ?? 5       $??4q?6   $??中划线 Strikethrough??6#   $??Strikethrough{?6<   $??./Fonts/#FZYanSJW_Xian)?6\   ?? 5!      $??4q?6   $??下划线 Underline??6#   $??	Underline{?68   $??./Fonts/FZYanSJW.ttf)?6T   5"      ?? 5$   
   $??3??6   $??4q?6!   $??12(?6,   $b??\小字体文本会变得模糊，可通过设置TextOptions.TextFormattingMode=Display调整??6:   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=?5%      5&      5'      