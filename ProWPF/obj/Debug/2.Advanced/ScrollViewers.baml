   M S B A M L   `   `   `  ????W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media  5   	   
 ProWPF#   ProWPF.Advanced.ScrollViewers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore      5   	     ? Title$  可滚动的视图??5   	   $	??450??6   $	??800??6%    ? 	Resources 5
       ?? 
TargetType   OperatorButton ?? Property ?? Value??%v   &	        ?? 5   
   " ??6   .?5      ??  ? ??$ 4q?6'   ?? 5       ? ??$	 8,4q?6(   5      5      .??5      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??4q?6   $??←→横向滚动??6   {?.  .??5      A?  A? Rows$ 2??6   $??4q?6#   .+?5      ?? #??[  6   .??6A   
LineLeft6K   ?? 5      #??[  6   .??6A   	LineRight6L   ?? 5      #??[  6   .??6A   
PageLeft6K   ?? 5      #??[  6   .??6A   	PageRight6L   ?? 5      #??[  6   .??6A   ScrollToLeftEnd6R   ?? 5       #??[  6   .??6A   ScrollToRightEnd6S   ?? 5!      #??[  6   .??6A   ScrollToHorizontalOffset6[   5"      5#      ?? 5%   
   $??1??6   $??4q?6    $??↑↓ 纵向滚动??6+   .??5&      A? $ 2??6   $??4q?6#   .+?5'      ?? -   5        #??[  5'      .??6V   LineUp6^   ?? 5(      -   5        #??[  5(      .??6X   
LineDown6b   ?? 5)      -   5        #??[  5)      .??6V   PageUp6^   ?? 5*      -   5        #??[  5*      .??6X   
PageDown6b   ?? 5+      -   5        #??[  5+      .??6[   ScrollToEnd6h   ?? 5,      -   5        #??[  5,      .??6\   ScrollToHome6j   ?? 5-      -   5        #??[  5-      .??6f   ScrollToVerticalOffset6~   5.      5/      ]? 51   
   $??2??6   $??4q?6!   ??. .+?52      ?? -   5         ??Name$ chkContentScroll??52      $??4q?61   $??Center=?6<   $	??Top=?6^   .??6s   *(内容滚动(True) | 像素滚动(False)6?   ?? 54      -	   5         ??Name$
 scrv??54      $??Center=?6s   ??6)   ?? 	 ?? ElementName$	 chkContentScroll??
 ?? Path$
 	IsChecked?.??56      ?? $??4q?6   .+?57      ?? $	??200??6   $??/Images/p1.jpeg??6,   ?? 58      $	??200??6   $??/Images/p2.jpeg??6,   ?? 59      $	??200??6   $??/Images/p3.jpeg??6,   ?? 5:      $	??200??6   $??/Images/p4.jpeg??6,   5;      5<      5=      5?      5@      