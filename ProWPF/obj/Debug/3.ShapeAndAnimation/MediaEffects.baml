   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProWPF.ShapeAndAnimationProWPF.ShapeAndAnimation  5   	   O KCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary 5   	   /clr-namespace:ProWPF.EffectsProWPF.Effects  5   	   +    %ProWPF.ShapeAndAnimation.MediaEffects   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProWPF.ShapeAndAnimation     5   	   Rctrls@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary     5   	   0effectsclr-namespace:ProWPF.Effects     5   	     ? Title$  效果??5
   	   $	??450??6   $	??800??6!    ? 	Resources 5       ?? 
TargetType ?? Property ?? Value??%Z  '??       '?? ?     ?? 5   
   " ??6   .?5      ??  ? ??$ 6q?6'   ?? 5       ? ??$
 Wrap=?6-   ?? 5       ? ??$ Center=?62   5      ?? 5   
   " ??6   .?5      ??  ?@??IsSnapToTickEnabled . 64   ?? 5       ?@??TickPlacement$
 Both=?6.   ?? 5       ? ??$ 6q?6'   5      5      .??5      ?? .@?5   
   ?? $'??!模糊、阴影、像素着色器??6   .??5      ?  ? ColumnDefinitions 5      ?? 5      $
??Auto ?6'   ?? 5      ?? 5        ? RowDefinitions 5"      ?? 5#      $
??Auto ?6$   ?? 5$      $
??Auto ?6$   ?? 5%      $
??Auto ?6$   ?? 5&      $
??Auto ?6$   ?? 5'      $
??Auto ?6$   .+?5*      ?? $??3??6   $??8q?60   $??Center=?6;   $
??Bold"?6X   ?=Effect类（位于System.Windows.Media.Effects名称空间）5,      ?? 5.      $??1??6   $??0??6)   $??
BlurEffect??69   ?? 5/      $??1??6   $??1??6)   $??模糊元素中的内容??69   ?? 50      $??1??6   $??2??6)   $)??#Radius、KernelType、RenderingBias??69   ?? 52      $??2??6   $??0??6)   $??DropShadowEffect??69   ?? 53      $??2??6   $??1??6)   $'??!在元素背后添加矩形阴影??69   ?? 54      $??2??6   $??2??6)   $L??FBlurRadius、Color、Direction、Opacity、ShadowDepth、RenderingBias??69   ?? 56      $??3??6   $??0??6)   $??ShaderEffect??69   ?? 57      $??3??6   $??1??6)   $????应用像素着色器，像素着色器是使用高级着色语言（High Level Shading Language，HLSL）事件制作好的并且已经编译过的效果??69   ?? 58      $??3??6   $??2??6)   $??PixelShader??69   ?? 5:      $??4??6   $??3??6)   
???  ??$
??Wrap=?6N   ??* 表中列出的是Effect类的派生类，请勿将位图效果类（派生自BitmpapEffect，该类与Effect类位于相同的名称空间）相混淆。?? 5<      ,*位图效果类存在几个严重缺陷：?? 5>      +)1.位图效果不支持像素着色器。?? 5@      [Y2.位图效果是用非托管代码实现的，从而需要完全信任的应用程序。?? 5B      ??3.位图效果总是使用软件进行渲染，不使用显卡资源。这使得它们的速度较慢，当处理大量元素或具有较大可视化表面的元素尤其如此。5D      5E      5F      ?? 5H   
   $??	BlurEffec??6   .??5I      ]? ??. $??8q?6-   .+?5J      ?? $	??Top=?6   .+?5K      ?? $??8q?6    模糊系数：?? 5L      ?6#   ??  ?? ElementName$ sdBlurRadius?? ?? Path$ Value?	 ?? Mode$	 OneWay=?5M      ?? 5N      -   5        
 ??Name$
 sdBlurRadius??5N      $??8q?63    ? Maximum$ 10Q?6>    ? Minimum$ 0Q?6K    ? Value$ 0Q?6W    ?? TickFrequency$ 1Q?5O       ?? IsSnapToTickEnabled .  ?? TickPlacement$
 Both=?6J   5P      ?? 5R      $	??300??6   $	??200??6%   ??5S      ?? 5T       ?? ImageSource$ /Images/happyface.png??6%    j? TileMode$
 Tile=?6I    j? ViewportUnits$ Absolute=?6Y    j? Viewport$ 0,0,128,128?6r   .??5W      ?? 
??? E??$??这是一个模糊按钮??67   $??30(?6G    J? Effect 5Y      -  'System.Windows.Media.Effects.BlurEffect  5Z         Radius 6%   ?? $ sdBlurRadius??$ Value?$	 OneWay=?5\      5]      5^      ?? 5`   
   $??DropShadowEffect??6   .??5a      ?  5b      ?? 5c      $??* ?6'   ?? 5d      $
??1.5* ?6'    5f      ?? 5g      $
??Auto ?6$   ?? 5h      $
??Auto ?6$   ?? 5i      $
??Auto ?6$   ?? 5j      $
??Auto ?6$   ?? 5k      $
??Auto ?6$   ?? 5l      .+?5o      ?? $!??Color 设置阴影的颜色??6   $??Center=?61   '  !CustomControlLibrary.ColorListBox  5p      -   5          Name$ shadowColor??5p   %   $
??10,0q?6:   $??1??6H      IsDisplayColorName .     Orientation$ 
Horizontal=?6s   ?? 5r      $??1??6   ??ShadowDepth 确定阴影离开内容多远，单位为像素（默认为5）。将属性设置为0时会创建外侧光辉效果，该效果会在内容周围添加晕彩5t      ?? 5u      -   5        $
 sdShadowDepth??5u      $??1??60   $??1??6=   $??Center=?6M   $
??10,0q?6h   $	 100Q?5v      $ 0Q?6'   $ 1Q?63   $ 5Q?6E   ?? 5x      $??2??6   USBlurRadius 模糊阴影，该属性与BlurEffect.Radius属性类似（默认为5）5z      ?? 5{      -   5        $
 sdShadowBlur??5{      $??2??6/   $??1??6<   $??Center=?6L   $
??10,0q?6g   $ 20Q?5|      $ 0Q?6&   $ 1Q?62   $ 5Q?6D   ?? 5~      $??3??6   caOpacity 使用1（完全不透明）到0（完全透明）之间的小数，使阴影部分透明5?      ?? 5?      -   5        $
 sdShadowOpacity??5?      $??3??62   $??1??6?   $??Center=?6O   $
??10,0q?6j   $ 1Q?5?      $ 0Q?6%   $	 0.1Q?61   $ 1Q?6E   ?? 5?      $??4??6   ??Direction 使用从0到360之间的角度值指定阴影相对于内容的位置。将该属性设置为0时会将阴影放置在右边，增加该属性会逆时针移动阴影。默认为315，该值会将阴影放置在元素右下方。5?      ?? 5?      -   5        $
 sdShadowDirection??5?      $??4??64   $??1??6A   $??Center=?6Q   $
??10,0q?6l   $	 360Q?5?      $ 0Q?6'   $ 50Q?63   $	 315Q?6F   ?? 5?      $??5??6   $??2??6)   $??Center=?6=   $??36(?6Z   DropShadowEffect 阴影文字 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5?         Color 6+   ?? $ shadowColor??$ SelectedValue?$	 OneWay=?   ShadowDepth 5?   +   ?? $ sdShadowDepth??$ Value?$	 OneWay=?   
BlurRadius 5?   +   ?? $ sdShadowBlur??$ Value?$	 OneWay=?   Opacity 5?   +   ?? $ sdShadowOpacity??$ Value?$	 OneWay=?   	Direction 5?   +   ?? $ sdShadowDirection??$ Value?$	 OneWay=?5?      5?      5?      ?? 5?   
   $??ShaderEffect??6   .??5?      ]? ??. .+?5?      ?? $	??Top=?6   YWShaderEffect是一个抽象类，可继承该类以创建自定义的像素着色器。?? 5?      ??像素着色器是用高级着色语言（High Level Shader Language，HLSL）编写的，该语言是Microsoft DirectX的一部分，使用fxc.exe命令行工具进行编译。?? 5?      ??一旦将HLSL文件编译成.ps文件，就可以将其添加入项目中，并将Build Action设置为Resource。 最后再创建一个继承自ShaderEffect的自定义类并使用该资源。?? 5?      ??如果需要输入参数的像素着色器，需要调用RegisterPixelShaderSampleProperty()静态方法创建相应的依赖项属性5?      ?? 5?      $+??%自定义像素着色器 ShaderEffect??6   $??24(?6:   .??5?      A? .+?5?      ?? $??Grayscale 灰度级??6$    5?      $  ProWPF.Effects.GrayscaleEffect  5?   "   5?      ?? 5?      $??MotionBlur 运动模糊??6$    5?      %   ProWPF.Effects.MotionBlurEffect  5?   "      	BlurAngle$ 30Q?6;   5?      ?? 5?      $??Negative 消极的??6$    5?      #   ProWPF.Effects.NegativeEffect  5?   "   5?      ?? 5?      $??ZoomBlur 缩放模糊??6$    5?      #   ProWPF.Effects.ZoomBlurEffect  5?   "   5?      5?      5?      5?      5?      5?      5?      