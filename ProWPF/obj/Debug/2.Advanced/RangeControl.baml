   M S B A M L   `   `   `  ????
  ProWPF"    ProWPF.Advanced.RangeControl   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  基于范围的控件??5   	   $	??600??6   $	??800??6&   .??5	      ?? $??4q?6   $??16(?6   .+?5
   
   ?? $??4q?6   !Normal Slider (Max=100, Val=10)6@   ?? 5   
   $??4q?6    ? Maximum$	 100Q?6    ? Value$ 10Q?6*    ?? TickPlacement$
 Both=?65    ? ToolTip 6J   ??  ?? RelativeSource ??  ?? Mode$
 Self=? ?? Path$ Value??? 5   
   $??4q?6   $
??Wrap=?6   FDSlider with Tick Marks (TickFrequency=10, TickPlacement=BottomRight)?? 5      \ZTickFrequency设置刻度之间的间隔；例如，每隔10个单位放置一个刻度。?? 5      '%TikcPlacement刻度显示的位置。5      ?? 5   
   $??4q?6   $ 10Q?6   $	 100Q?6'    ?? TickFrequency$ 10Q?65   $ BottomRight=?6H    5      ??  ?? $
 Self=?$ Value??? 5   
   $??4q?6   ><Slider with Irregular Tick Marks (Ticks=0,5,10,15,25,50,100)?? 5      PNTicks 在特定的不规则位置放置刻度。（双精度浮点数集合）?? 5      kiIsSanpToTickEnabled = True 滑块移动时，自动跳转到合适的刻度。（最近的刻度标记）5      ?? 5   
   $??4q?6   $ 10Q?6   $	 100Q?6'   	 ?? Ticks$	 0 5 10 15 25 50 100R?65   
 ?? IsSnapToTickEnabled
 . $ TopLeft=?6l    5      ??  ?? $
 Self=?$ Value??? 5!   
   $??4q?6   _]Slider with Selection Range (IsSelectionRangeEnabled=True, SlectionStart=25, SelectionEnd=75)?? 5#      MKIsSelectionRangeEnabled 选择范围内滑动条的一部分显示阴影。?? 5%      =;SelectionStart 起始范围； SelectionEnd 结束范围。?? 5'      5)      ?? 5*   
   $??4q?6   $	 100Q?6   $ 10Q?6*   $ BottomRight=?65    ?? IsSelectionRangeEnabled .  ?? SelectionStart$ 25Q?5+   0    ?? SelectionEnd$ 75Q?6D    5,      ??  ?? $
 Self=?$ Value?5-      ?? 5/   
   $??4q?6   Normal ProgressBar?? 51      " 由代码递增Value属性值。53      ? 54   
   $??4q?6   $??10??6!   $	 100Q?6-   $ 10Q?6;   $ 10??6F   ? 55   
   $??4q?6   $??10??6!   $	 100Q?6-   $ 50Q?6;   $ 50??6F   ? 56   
   $??4q?6   $??10??6!   $	 100Q?6-   $ 90Q?6;   $ 90??6F   ?? 58   
   $??4q?6    ProgressBar with Indeterminate?? 5:      fdIndeterminate 不确定状态；设置为该状态时将不再使用Maximum，Minimum,Value属性。5<      ? 5=   
   $??4q?6   $??10??6!    ? IsIndeterminate . 6-   5>      5?      