   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	       ProWPF.Advanced.Popups   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	     ? Title$  弹 窗??5   	   $	??500??6   $	??820??6"   $??20(?6.   .??5
      ? $??4q?6   .+?5   
   ?? $??4q?6   $
??Wrap=?6   ?? 5      .?6   ZXPopup控件永远不会自动显示，为显示Popup控件，必须设置IsOpen属性。6<   ?? 5      ?? 5      .?6   ??默认情况下StaysOpen属性为true，Popup控件会一直显示；当设置为false时，用户在其他地方点击鼠标，Popup控件将会消失6Y   ?? 5      ?? 5      .?6   [Y使用PopupAnimation的动画（默认值为None），需设置AllowsTransparency=True。6M   ?? 5      ?? 5      .?6   ki使用触发器时，只需创建Popup.IsMouseOver=True且Popup.IsOpen=True时进行响应的触发器。6Q   ?? 5      ?? 5      .?6   点击6    ?? 5      -   5        
????  ? ?? TextDecorations$ 	Underline{?5   %   .?6u   此处6y    ?? 5      -   5         ??Name$ runMouseOver??5      .?6(   移动6,   5      ? 5   
   -   5         ?Name$ popup??5       ? 	StaysOpen .  ? AllowsTransparency . $??Mouse=?6J   $
??None=?6\   .??5      ?? 
???????
??? ???$??2q?6A   ._?5      ?? $??4q?6   
??? ? ?.+?5      ?? -   5        $??None（默认值）??5       $??	Underline{?61   $
??10,4q?6M   6[   ?? 5      -   5        $4??.Fade（弹窗窗口的透明度逐渐增加）??5       $??	Underline{?6:   $
??10,4q?6V   6d   ?? 5       -   5        $Q??KScroll（如果空间允许，弹出窗口将从窗口的左上角滑入）??5        $??	Underline{?6E   $
??10,4q?6a   6o   ?? 5!      -   5        $M??GSlide（如果控件允许，弹出窗口将从上向下滑进位置）??5!       $??	Underline{?6C   $
??10,4q?6_   6m   5"      5#      5$      ? 5&   
   -   5        $ 	popupNone??5&       .   . $??Mouse=?6O   $
??None=?6a   .??5'      ?? 
???????
???????$??2q?6A   ._?5(      ?? Hello World5*      5+      5,      ? 5.   
   -	   5        $ 	popupFade??5.       .   . $??Mouse=?6O   $
??Fade=?6a   .??5/      ?? 
???????
????? ?$??2q?6?   ._?50      ?? 你好，世界！52      53      54      ? 56   
   -
   5        $ popupScroll??56       .   . $??Mouse=?6Q   $??Scroll=?6c   .??57      ?? 
???????
??? ???$??2q?6A   ._?58      ?? Hello World5:      5;      5<      ? 5>   
   -   5        $ 
popupSlide??5>       .   . $??Mouse=?6P   $??Slide=?6b   .??5?      ?? 
???????
????+??$??2q?6E   ._?5@      ?? 你好，世界！5B      5C      5D      5E      5F      