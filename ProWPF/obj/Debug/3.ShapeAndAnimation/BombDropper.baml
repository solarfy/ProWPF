   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProWPF.ShapeAndAnimationProWPF.ShapeAndAnimation  5   	   *    $ProWPF.ShapeAndAnimation.BombDropper   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProWPF.ShapeAndAnimation     5   	     ? Title$  拦截炸弹??5   	   $	??450??6   $	??800??6#   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ?? $??0??6   
?????F?$??1q?69   $??5q?6M   ._?5      ?? -   5         ??Name$ canvas??5      $??50??6%   ??5      
? 5       
? RadiusX$ 1Q?6*    
? RadiusY$ 1Q?66    
? Center$ 0 0.5&?6B    
? GradientOrigin$ 0.3 0&?6Q   .??5      ?  ? Color$ 	LawnGreen??6'    ? Offset$ 0Q?69   ? 5      $ 	AliceBlue??6'   $	 0.7Q?69   5      5      5      ?? 5   
   $??1??6   
?????F?$??1q?69   $??5q?6M   ??5      
? 5      $ 1 0.7&?6&   $ 1, 0.7&?6=   $ 1Q?6M   $ 1Q?6Y   .??5      ? $ Orange??6#   $ 0Q?62   ? 5      $ 	AliceBlue??6#   $ 1Q?65   5       ._?5#      ?? $??15q?6   $??Center=?6%   $??Center=?6@   .+?5$      ?? $??35(?6   
??? ? ?炸弹拯救者6D   ?? 5%      -   5        	 ??Name$	 
txtblkRate??5%      $??0,30,0,0q?60   $
??Wrap=?6B   ?? 5&      -   5        $	 txtblkSpeed??5&      $??0,30,0,0q?61   $
??Wrap=?6C   ?? 5'      -   5        $	 txtblkState??5'      $??0,30,0,0q?61   $
??Wrap=?6C   $??没有炸弹被投下??6W   ?? 5)      -   5        
 ??Name$
 btnStart??5)      $??5q?6+   $
??0,30q?67   $??80??6E   .??6d   开始5+      5,      5-      5.      5/      