   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   3clr-namespace:ProWPF.BehaviorsProWPF.Behaviors  5	   	   &     ProWPF.Advanced.StyleAndBehavior   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   4	behaviorsclr-namespace:ProWPF.Behaviors     5	   	     ? Title$  样式和行为??5   	   $	??500??6   $	??800??6$    ? 	Resources 5         BigSize  
NormalSize  BaseButtonStyle ?? 
TargetType ?? Property ?? Value  MouseOverEventSetterStyle ?? BasedOn  MouseOverTriggerStyle ?? Triggers P? Property P? Value	 ]? 
Conditions
 ?? Property ?? Value  MouseOverEventTriggerStyle :? RoutedEvent ?? TargetProperty	 W? To g? Duration " MouseOverTriggerAnimationStyle N? EnterActions N? ExitActions??%?  &	        &	      &	 4     7  &	 L    7  &	 ?    7  7   &	 ?    7  7   &	 7    7  7   X?5   
   24Q?6)   X?5   
   14Q?6,   ?? 5   
   " ??6(   .?5      ??  ? ??$ Times New Roman)?6+   ?? 5       ? ??8   6)   ?? 5       ? ??$
 Bold"?6+   ?? 5       ? ??$	 8,4q?6(   ?? 5       ? ??$ 4q?6'   ?? 5       ? ??$ A Mouse Over Button??6(   5      ?? 5    
   8   " ??6]   .?5!      -   5        5#      ?? 5&   
   8   " ??6Y    5'      P? 5(       ?@J?IsMouseOver . . ?5)      ??  ? ??8  61   5*      ]? 5-      	 5.      ?? 5/      
 ?@J?	IsFocused . 69   ?? 51      
 ? ?? . 69   /?53      ?? 54       ? ??
 ?  ??67   56      58      ?? 5;   
   8   " ??6^    5<      :? 5=      $ 
MouseEnter??6   [?5>      ?? 5?      .??5@      ?? .??5A   "   W? $ FontSize?62   8  $ 0:0:0.4D?6u   5B      5C      5E      :? 5G      $ 
MouseLeave??6   [?5H      ?? 5I      .??5J      ?? .??5L   "   W? $ FontSize?62   $ 0:0:0.4D?6W   5M      5N      5P      5R      ?? 5U   
   8   " ??6b    5V      P? 5W       ?@J?IsMouseOver .  5X      ?? 5Y      .??5Z      ?? .??5[   "   W? $ FontSize?62   8  $ 0:0:0.4D?6u   5\      5]       5`      ?? 5a      .??5b      ?? .??5d   "   W? $ FontSize?62   $ 0:0:0.4D?6W   5e      5f      5h      5j      5l      .??5n      ? $??4q?6    ? RowDefinitions 5o   
   ?? 5p      $??* ?6   ?? 5q      $??2* ?6   .+?5t   
   A?  A? Columns$ 4??6   .+?5u      ?? $3??-事件设置器（关联事件处理程序）??6   .??5v      ?? #??[ 6   5w      ?? 5y      $??属性触发器??6   .??5z      ?  5{      ?? 5|      ?? 5}      $
??Auto ?6(   .+?5?      ?? $??0??6   #??[ 6*   $??点击此按钮!??6Y   ?? 5?      $p??j*触发器不需要编写翻转逻辑，只要停止应用触发器，元素就会恢复到正常外观。??6    $??1??5?      $??4q?6)   
??? ? ?$
??Wrap=?6G   5?      5?      ?? 5?      $??事件触发器??6   .??5?      ?? #??[ 6   5?      ?? 5?      $!??属性触发器使用动画??6   .??5?      ?? #??[ 6   5?      5?      ?? 5?   
   $??1??6   $??行为??6    $??4q?6,   .??5?      ?? .+?5?      ?? $??12(?6   
???  ??$
??Wrap=?6;   <:* 安装Expression Blend，Nuget安装Expression.Blend.Sdk?? 5?      ??System.Windows.Interactivity.dll 该程序集定义了支持行为的基本类，它是行为特征的基础。（本例中只添加了该程序集）?? 5?      ??Microsoft.Expression.Interactions.dll 该程序集通过添加可选的以核心行为类为基础的动作和触发器类，增加了一些扩展。5?      ?? 5?      $??拖拽这个Button??6   $??12q?6.    ?? Left$	 100??6;   
 ?? Top$	 100??6M   .  (System.Windows.Interactivity.Interaction   	Behaviors 5?      +  %ProWPF.Behaviors.DragInCanvasBehavior  5?      5?      ?? 5?      $??拖拽这个Label??6   $??12q?6,   $	 300??69   $	 100??6K   
??? ???$??1q?6q    5?        5?      5?      A? 5?      $	 500??6   $	 100??6,   $??50??6=   $??50??6I   
??? ? ? 5?        5?      5?      ?? 5?      $	 700??6   $	 100??6.   $??50??6?   $??50??6K   
????  ? 5?        5?      5?      ?? 5?      $	 100??6   $	 200??6,   $??90??6=   $??30??6K   $??Center=?6Z   $??4q?6|   .??6?    5?      +  %ProWPF.Behaviors.WatermarkTexBehavior  5?         	Watermark$% 带水印，可拖动的TextBox??69     5?      .??5?   /   5?      ?? 5?      $	 300??6   $	 200??6,   $??90??6=   $??30??6K   $??Center=?6Z   $??4q?6|   .??6?    5?        5?      $% 带水印，可拖动的TextBox??69      WatermarkBrush
 ? E??6U     5?      .??5?   /   5?      ?? 5?      $	 500??6   $	 200??6,   $??90??6=   $??30??6K   $??Center=?6Z   $??4q?6|   .??6?    5?        5?      $% 带水印，可拖动的TextBox??69   
 ? ???6U     5?      .??5?   /   5?      5?      5?      5?      5?      