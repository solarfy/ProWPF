   M S B A M L   `   `   `  ????O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   
 ProWPF   ProWPF.Advanced.Expanders   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     ? Title$  扩展区域??5   	   $	??450??6   $	??800??6#    ? 	Resources 5
       	  words ?? 
TargetType ?? Property ?? Value??%[  &	        '9? ?     ??5   
   |x昨夜雨疏风骤，浓睡不消残酒。试问卷帘人，却道海棠依旧。知否，知否？应是绿肥红瘦。??5      ?? 5   
   " 9?6   .?5      ??  ? ??$ 4q?6'   ?? 5       ? ??$ 4q?6(   ?? 5       ? ??
 ? ? ?6,   ?? 5       ? ??$ 2q?60   5      5      .??5      ]? $??4q?6   $??20(?6   ??. .+?5   
   ?? $??4q?6   $	??Top=?6   $
??Wrap=?64   =;Expanded和Collapsed用于显示和隐藏内容前触发；?? 5      ??Grid 列设置比例改变尺寸，行设置自动改变尺寸。这样设置只是在垂直方向上进行延长，水平方向上无影响。5      ? 5   
   $??4q?6    ? RowDefinitions 5      ?? 5       $
??Auto ?6    ?? 5!      $
??Auto ?6     ? ColumnDefinitions 5#      ?? 5$      $??* ?6#   ?? 5%      $??* ?6#   .+?5(      9? $??
Region One??6   .??5)      ?? $
??Wrap=?6   #??[  60   5*      9? 5,      $??1??6   $??
Region Two??6'    9? ExpandDirection$ Right=?6;   .??5-      ?? $
??Wrap=?6   #??[  60   5.      9? 50      $??1??6   $??0??6$   $??Region Three??64   $ Up=?6J   .??51      ?? $
??Wrap=?6   #??[  60   52      9? 54      $??1??6   $??1??6$   $??Region Four??64   $
 Left=?6I   .??55      ?? $
??Wrap=?6   #??[  60   56      57      58      59      