   M S B A M L   `   `   `  ????O  KCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CustomControlLibraryCustomControlLibrary  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089$    CustomControlLibrary.FlipPanel  ?? 
TargetType ?? Property ?? Value ?? 
TargetType ? RowDefinitions ??Name    CornerRadius ?? CornerRadius    FrontContent	    BackContent
 d?Name J? RenderTransformOrigin ?? Angle'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard ?? 
TargetName ?? TargetProperty	 W? To g? Duration   Transitions%  System.Windows.VisualTransition	   To   GeneratedDuration   
Storyboard?? 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,local"clr-namespace:CustomControlLibrary  5      %?  '         ?? 5      "    6   .?5   
   ??  ? ?? 5      ?? 5      "   6"   .R?5	      ?  5
      ?? 5      $
??Auto ?6,   ?? 5      $
??Auto ?6,   .+?5      ?? $ FrontContent??6!   #??z??67   #??z??6c   # z 5   !   #??z??6O   ._?5      ?? #??z 6/   5      ?? 5      $ BackContent??6!   #??z??66   #??z??6b   # z 5   !   #??z??6O   ._?5      ?? #??z	 6/   5      d? 5      $
 
FlipButton??6'   $??1??6;   $??0 10 0 0q?6H   $ 0.5 0.5&?6Z   $??19??6z   $??19??6?   ??5      ?? 5!   "   .R?5"   &   ? .+?5#   *   A? ???	#FFA9A9A9
???????6E   F? 5$   *   "????@B `? ? ?D @KL ? z `? 	???	#FF666666$??2??6^   $??Center=?6r   $??Center=?6?   5%   '   5&   #   z?5(      ?? 5)   "   $	 -90Q?62   5+       50        51      
ViewStates??. 52   "     
Normal??. 53   &   ?? .??54   *   W? $ BackContent??6:   $ Opacity?6^   $ 0X?6?   $ 0D?6?   55   '   56   #     57   "   Flipped??. 58   &   ?? .??59   *   W? $ FrontContent??6:   $ Opacity?6_   $ 0X?6?   $ 0D?6?   W? 5:   *   $ 
FlipButton??6:   $ RenderTransform.Angle?5;   :   $ 90X?5<   :   $ 0D?6B   5=   '   5>   #    5A   "     5K   &   $ Flipped??67   $ 0:0:0.7D?6D   . 5L   *   ?? .??5M   .   W? $ 
FlipButton??6>   $ RenderTransform.Angle?5N   >   $ 90X?5O   >   $ 0:0:0.2D?6F   5P   +   5Q   '     5R   &   $ Normal??67   $ 0:0:0.7D?6C   . 5S   *   ?? .??5T   .   W? $ 
FlipButton??6>   $ RenderTransform.Angle?5U   >   $	 -90X?5V   >   $ 0:0:0.2D?6G   5W   +   5X   '   5Z      5\      5]      5_      5`      5a      