   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	   !    ProWPF.Advanced.MouseCursor   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	     ? Title$  自定义光标??5   	   $	??450??6   $	??800??6$   .??5
      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6    ? 	Resources 5   
    ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5      " ??6   .?5      ??  ? ??$ 30q?64   ?? 5       ?@??CornerRadius$ 0??61   5      5      .+?5   
   ?? $??4q?6    ?? Orientation$ 
Horizontal=?6    $??20(?69   .+?5      ?? -   5         ??Name$ chkForceCursor??5      $??4q?6/   $??20(?6:   $??使用父元素的Cursor??6H   $??Center=?6_   ?? 5      -   5        $??20,4,4,4q?5      $??20(?6)   $??使用自定义光标??67   $??Center=?6I   5   3   5      ?? 5   
   $??1??6   $??4q?6   
??? ??? ? Cursor$
 Hand??6>   	 ? ForceCursor	 5      ?? 
 ?? ElementName$
 chkForceCursor?? ?? Path$ 	IsChecked?._?5       ?? 
???? K?$
 Help??6*   ._?5!      ?? 
???i??$ SizeAll??61   ._?5"      ?? 
???<??$	 Pen??63   ._?5#      ?? 
???????$ Cross??68   ._?5$      ?? $??自定义光标??6(   $??24(?65   $??Center=?6C   $??Center=?6^   5%      5&      5'      5(      5)      5*      5+      