   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:ProWPF.PerFrameAnimations.MouseFollowWithTime-ProWPF.PerFrameAnimations.MouseFollowWithTime  5      G    AProWPF.PerFrameAnimations.MouseFollowWithTime.FollowMouseWithTime   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Mlocal;clr-namespace:ProWPF.PerFrameAnimations.MouseFollowWithTime     5      -   5          N? Title$&   鼠标跟随--根据时间更新??5	      .??5      ?? -   5         ??Name$ canvas??5      
?????? .+?5   
   F? -   5         F?Name$ 
followPath??5      
????  ?
??? ??? ?? Left$ 0??6?   
 ?? Top$ 0??6O   ??5      ? 5      .??5      @?  @? Center$ 20 20&?6&    @? RadiusX$ 20Q?65    @? RadiusY$ 10Q?6B    ? 	Transform 5      ?? 5      	 ?? Angle$	 0Q?6.   
 ?? CenterX$
 20Q?68    ?? CenterY$ 20Q?6E   5      @? 5      $ 20 20&?6&   $ 20Q?65   $ 10Q?6B    5      ?? 5      $	 45Q?6.   $
 20Q?69   $ 20Q?6F   5      @? 5      $ 20 20&?6&   $ 20Q?65   $ 10Q?6B    5      ?? 5      $	 90Q?6.   $
 20Q?69   $ 20Q?6F   5      @? 5      $ 20 20&?6&   $ 20Q?65   $ 10Q?6B    5      ?? 5       $		 135Q?6.   $
 20Q?6:   $ 20Q?6G   5"      5#       J? Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         ShadowDepth$ 0Q?6#      Color$ Orange??63   5(      5)      5*      