   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProWPF.TemplateAndCustomProWPF.TemplateAndCustom  5   	   3    -ProWPF.TemplateAndCustom.CustomButtonTemplate   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProWPF.TemplateAndCustom     5   	     ? Title$  自定义按钮模板??5   	   $	??550??6   $	??860??6&    ? 	Resources 5
       ?? MergedDictionaries ?? Source   ButtonStyle ?? 
TargetType ?? Property ?? Value  ButtonTemplate ?? 
TargetType ??Name	 ?? CornerRadius
 J? SnapsToDevicePixels ??Name ?? StrokeDashArray ?? Triggers P? Property P? Value ?? 
TargetName :? RoutedEvent ?? 
TargetName ?? TargetProperty	 ?? To g? Duration g? AutoReverse g? RepeatBehavior?? 5   
    5      ?? 5      $ /Themes/Button.xaml??6%   %U  &	        &	 s     ?? 5      " ??6(   .?5      ??  ? ??$ 15,10q?6,   ?? 5       ? ??$ 100,10q?6+   5      ?? 5      " ??65   .R?5      ?? $ border??6   $??3q?6)   $	 6??6=   
???  ??
???????
 . ._?5      ? $??2q?6   .+?5      ?? $
 rect??6$   
???   ?$??1??6A   $	 1 2R?6U   $y?Hidden=?6k   ?? 5      ??. #??z??6F   5      5       5      P? 5       ?@J?IsKeyboardFocused . . ?5       ?? $
 rect??6!    ? y?$ Visible=?6I   5!      P? 5#       ? {? .  . ?5$      ?? $ border??6!    ? ??
 ?????6U   ?? 5%      $ border??6!    ? ??
 ?????6K   5&      :? 5(      $ 
MouseEnter??6#   .[?5)      ?? .??5*      ?? $ border??6)   $ Background.Color?6=   .??5+   "   ?? $
 BlueX?61   $ 0:0:1D?6;    . $ Forever??6_   5,      5-      5.      :? 5/      $ 
MouseLeave??6#   .[?50      ?? .??51      ?? $ border??6)   $ Background.Color?6=   .??52   "   ?? $ 0:0:0.5D?61   53      54      55      57      58      .??5;      ?? .+?5<   
   ?? $
??Wrap=?6   $??8,8,8,20q?6(   ??继承自ContentControl类的控件，其模板包含一个ContentPresent元素，该元素指示如何放置内容。 ContentPresent.RecognizesAccessKey属性设置为True时，表示支持访问键（下划线加字母，用Alt+字母访问）。 ContentPresent.Content属性隐式绑定了控件的Content属性，不需要自行使用绑定。?? 5@      vt模板中Padding属性值无效，可通过将目标的Margin属性TemplateBinding绑定到控件的Padding属性。?? 5B      b`如果在控件模板和样式中都设置了触发器，那么样式触发器具有优先权。?? 5D      ??样式触发器中不能使用Setter.TragetName属性，因为样式不包含控件模板（只是引用模板而已）。因此样式不能深入到可视化树中改变嵌套的元素。5F      ?? 5H   
   #??[  6   #??[ 66   $/??)A Simple Button With a Custom Template _A??6a   ?? 5I   
   #??[  6   #??[ 66   $/??)A Simple Button With a Custom Template _B??6a   ?? 5J   
   #??[  6   #??[ 66   $/??)A Simple Button With a Custom Template _C??6a   {?.  6?   ?? 5L   
     GradientButtonStyle#??[ 6   $??100,10q?6>   $??15,10q?6N   $??A Gradient Button _D??6^   ?? 5M   
   #??[ 6   $??100,10q?6>   $??15,10q?6N   $??A Gradient Button _E??6^   ?? 5N   
   #??[ 6   $??100,10q?6>   $??15,10q?6N   $??A Gradient Button _F??6^   {?.  6}   5O      5P      