   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProWPF.ShapeAndAnimationProWPF.ShapeAndAnimation  5   	   /    )ProWPF.ShapeAndAnimation.AboutTransparent   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProWPF.ShapeAndAnimation     5   	     ? Title$  透明与透明掩码??5   	   $	??450??6   $	??800??6&   .??5
      ?? $??4q?6   .@?5   
   ?? $??透明??6   .??5      ?? $??5q?6   ??5      ?? 5       ?? ImageSource$ /Images/celestial.jpg??6!    ?? Opacity$	 0.7Q?6E   .+?5      ?? 
???????$??16(?6,   $??10q?6:   
???????$??20q?6Z   ???	#60AA4030.??6~   A Semi-Transparent button5      ?? 5      $??10q?6   $??18(?6$   $
??Bold"?62   
???????.??6W   Some Label Text5      ?? 5      $??10q?6   ???	#AAAAAAAA
???????
???????.??6d   A Semi-Transparent text box5      ?? 5      $??10q?6   $??25q?6%   
?????????5      ?? 5      $ /Images/happyface.jpg??6%    j? TileMode$
 Tile=?6I   $	 0.6Q?6Y    j? Viewport$ 0 0 0.1 0.3?6g   .??5"      ?? .+?5#      ?? ???	#75FFFFFF ?? TextAlignment$ Center=?6;   $??20(?6R   $
??Bold"?6`   $
??Wrap=?6r   Semi-Transparent Layers5%      5&      5'      5(      5)      ?? 5+   
   $??透明掩码??6   .??5,      A?  A? Columns$ 3??6   .+?5-      ? $??4q?6   ??5.      ?? 5/      $ /Images/grandpiano.jpg??6%    j? Stretch$ Uniform=?6J   .+?52      ?? $??14(?6   $
??Bold"?6+   $??Center=?6=   $??Center=?6Z   $??50q?6u   
??? E?? J? OpacityMask 53      ?? 54      	 ?? 
StartPoint$		 0,0&?62   
 ?? EndPoint$	
 1,0&?6C   .??55   "   ?  ? Color$ Black??6/    ? Offset$ 0Q?6=   ? 56   "   $ Transparent??6/   $ 1Q?6C   57      .??58   .    A Partially Transparent Button5;      5<      ? 5>      $??4q?6   $??Center=?6"    ? RowDefinitions 5?      ?? 5@      ?? 5A      $
??Auto ?6(   ?? 5B      $
??Auto ?6(   .+?5E      ?? $??4q?6    
???  ??$??12(?6<   $
??Wrap=?6J   ??* 使用了RenderTransform翻转矩形，使反射的内容上下颠倒。因为使用了该变换，所以渐变过度点必须反向设置。5G      ?? 5I      -   5         ??Name$
 text??5I   +   $??1??6   $??20(?69   $??8q?6G    ?? TextWrapping$
 Wrap=?6S   .??6g   反射出来的文字5K      ?? 5M      $??2??6     J? RenderTransformOrigin$ 0, 0.5&?6-   ??6L   ??  ?? ElementName$
 text?? ?? Path$ ActualHeight???5N      !? 5O       !? Visual 6*   ?? $
 text??z?5R      ?? 5S       ?? ScaleY$ -1Q?6-    5V      ?? 5W      $		 0,0&?62   $	
 0,1&?6C   .??5X   "   ? $ 0Q?6/   $ 	#44000000??6:   ? 5Y   "   $	 0.8Q?6/   $ Transparent??6<   5Z      5\      5]      ? 5_      $??4q?6   ??5`      ?? 5a      $G Apack://application:,,,/ProWPFResource;component/Images/winter.jpg??6%    5d      ?? 5e      -   5        opacityMaskGradientBrush??$		 0 0&?5e   P   $	
 0 1&?6a   .??5f      ? $ Black??6+   $ 0Q?69   ? 5g      $ Transparent??6+   $ 0Q?6?   5h       ? Triggers 5k      :? 5l       :? RoutedEvent$ Loaded??6'   .[?5m      ?? .??5n   "   ??  g? RepeatBehavior$ 3x??6-   .??5o   &   W?  W? From$ 0X?66   	 W? To$ 1X?6?    g? Duration$ 0:0:3D?6F    ?? 
TargetName$ opacityMaskGradientBrush??5p   6    ?? TargetProperty$ GradientStops[1].Offset?5q   6   W? 5s   &   $ 0X?66   $ 1X?6?   $ 0:0:3D?6F    g? 	BeginTime$ 0:0:0.1X?6W   $ opacityMaskGradientBrush??5t   6   $ GradientStops[0].Offset?5u   6   5v   #   5w      5x      5z      5{      5|      5}      5~      