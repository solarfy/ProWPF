   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProWPF.BasicProWPF.Basic  5   	   "    ProWPF.Basic.SharedSizeGroup   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProWPF.Basic     5   	   2  ,System.Windows.Markup.XmlAttributeProperties   XmlSpace  preserve5   0    ? Title$ 共享尺寸组??6	   $	??450??6   $	??800??6$   .??5
      ?  ? IsSharedSizeScope .  ? UseLayoutRounding . 
??????? ? RowDefinitions 5   
   ?? 5      ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ? $??0??6    ? ShowGridLines .  ? ColumnDefinitions 5      ?? 5       z? SharedSizeGroup$ A??6#   ?? 5      ?? 5      .+?5      ?? $??0??6   $??A vert long bit of text??6(   ?? 5      $??1??6   $??	More text??6(   ?? 5      $??2??6   $??
A text box??6&   ?? 5      $??1??6   $??4??6+    ?? ShowsPreview . $??Right=?5      $??Stretch=?67   
???????6S   5      ?? 5!   
   $??1??6   $??20(?6   $,??&Some text in between the two grids ...??6+   ? 5#   
   $??2??6    . 
??????? 5$      ?? 5%      $ A??6#   ?? 5&      .+?5)      ?? $??0??6   $+??%An event longer bit of text over here??6(   ?? 5*      $??1??6   $??
A text box??6&   5+      5,      5-      