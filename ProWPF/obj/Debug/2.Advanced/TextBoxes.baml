   M S B A M L   `   `   `  ????O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   
 ProWPF   ProWPF.Advanced.TextBoxes   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :runtime&clr-namespace:System;assembly=mscorlib     5   	     ? Title$  文本控件??5   	   $	??550??6   $	??800??6#    ? 	Resources 5
         春江花月夜??%{  &	        ??5   
   ??
            春江潮水连海平，海上明月共潮生。
            滟滟随波千万里，何处春江无月明！
            江流宛转绕芳甸，月照花林皆似霰；
            空里流霜不觉飞，汀上白沙看不见。
            江天一色无纤尘，皎皎空中孤月轮。
            江畔何人初见月？江月何年初照人？
            人生代代无穷已，江月年年望相似。
            不知江月待何人，但见长江送流水。
            白云一片去悠悠，青枫浦上不胜愁。
            谁家今夜扁舟子？何处相思明月楼？
            可怜楼上月裴回，应照离人妆镜台。
            玉户帘中卷不去，捣衣砧上拂还来。
            此时相望不相闻，愿逐月华流照君。
            鸿雁长飞光不度，鱼龙潜跃水成文。
            昨夜闲潭梦落花，可怜春半不还家。
            江水流春去欲尽，江潭落月复西斜。
            斜月沉沉藏海雾，碣石潇湘无限路。
            不知乘月几人归，落月摇情满江树。
        ??5      5      .??5!      ? $??4q?6    ? RowDefinitions 5"   
   ?? 5#      $
??Auto ?6   ?? 5$      $
??Auto ?6   ?? 5%      $
??Auto ?6   
 ? Tag$ 	主文本??6*   ?? 5&      $??* ?6   $ 选中的文本??6'   ?? 5'      $
??Auto ?6   ?? 5(      $
??Auto ?6   ?? 5)      $
??Auto ?6   .+?5,   
   ?? -   5        $??4q?5,       ?? Orientation$ 
Horizontal=?6     5-       ?? 
TargetType ?? Property ?? Value??%w   '??       ?? 5.      " ??6   .?5/      ??  ? ??$ 8q?6/   ?? 50       ? ??$
 10,5q?60   51      52      .+?54      ?? .??6   LineUp6   ?? 55      .??6   
LineDown6   ?? 56      .??6   PageUp6   ?? 57      .??6   
PageDown6   ?? 58      .??6   ScrollToHome6#   ?? 59      .??6   ScrollToEnd6"   ?? 5:      .??6   Undo6   5;      ?? 5=   
   $??1??6   $??4q?6!   $??10(?6,   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=?6:   
???  ??$
??Wrap=?6t   .,* 一个支持Enter键、Tab键的TextBox。?? 5?      b`* 不应当使用硬编码调整Height属性，可通过使用MaxLines和MinLines方式调整。?? 5A      ??* 如果容器空间不足，部分文本框可能会被裁剪掉。设置MaxLines属性能够显示最大行数，可突破这一限制。 （使用后当空间不足时，会显示垂直滑动条VerticalScrollBar）。?? 5D      ??* 拼写检查（SpellCheck.IsEnabled = True）;只支持英语、西班牙语、法语和德语。可通过SpellCheck.CheckDictionaries添加自定义拼写词典文件（.lex）。5F      ?? 5I   
   -   5        	 ??Name$
	 text??5I      $??2??6    $??4q?6-   
 ?? MinLines$
 2??68    ?? MaxLines$ 6??6E    ?? TextWrapping$
 Wrap=?6R   $??20(?6f    ?? AcceptsReturn .  ?? 
AcceptsTab . " ?? VerticalScrollBarVisibility$
 Auto=?5J   9    ?? AutoWordSelection . $??Center=?5K   ;   .??6_   ??5L      ?? 5M       ?? ResourceKey$ 春江花月夜??6!   .??5N      5O      ?? 5R   
   $??3??6   $??4q?6!   $
??Wrap=?6,   选中的内容：?? 5T      ?? 5U      -   5         ??Name$ runSelection??5U      5V      ?? 5X   
   $??4??6   $??4q?6!   $??10(?6,   $ Display=?6:   
???  ??$
??Wrap=?6t   ??* SecureString是纯文本对象，以加密的方式在内存中保存，用于加密的字符串密钥是随机生产的，存储在一块从来不会写入磁盘的内存中。 当调用SercureString.Dispose()方法时，内存的密码数据就会被改写；当控件销毁时会自动调用该方法。?? 5[      %#* PasswordChar设置屏蔽字符。5]      G? 5_   
   $??5??6   $??4q?6#    G? PasswordChar$ !??6.    G? Password$ 	123456789??6?   5`      5a      