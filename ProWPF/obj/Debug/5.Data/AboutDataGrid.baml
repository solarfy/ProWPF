   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProWPF.DataProWPF.Data  5   	   5clr-namespace:ProWPF.ConvertersProWPF.Converters  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5	   	       ProWPF.Data.AboutDataGrid   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProWPF.Data     5   	   5	converterclr-namespace:ProWPF.Converters     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5	   	   -   5          ? Title$  关于DataGrid??5   	   $	??450??6   $	??800??6)    ? 	Resources 5      "  System.Collections.ArrayList   
Categories$  ProWPF.Data.ImagePathConverter  ImagePathConverter??%"  &	        &	 ?       5   
   ??5      General??6"   ??5      Communications??6)   ??5      	Deception??6$   ??5      	Munitions??6$   ??5      
Protection??6%   ??5      	Tools??6    ??5      
Travel??6!   5        5   
   6#   5      .??5      ?? .@?5   
   ?? $??属性介绍??6   .??5      &   System.Windows.Controls.DataGrid  $??8q?6   $   ProWPF.Data.DataGridProperties   
Properties#??Z 6"      AutoGenerateColumns .     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 名称??6-      CellTemplate 5       ?? 5!      .R?5"   "   ?? $??Center=?6G   $	??4,6q?6b   ??6,   ??  ?? Path$
 Name?6b   5#      5%        5&      $ 说明??6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69    5'      ?? 5(      .R?5)   "   ?? $
??Wrap=?6,   $??Center=?6b   $	??4,6q?6}   ??6@   ?? $ Description?6}   5*      5,      5.      5/      ?? 51   
   $??	定义列??6   .??52      ]? ??. .+?53      ?? $	??Top=?6   $??8q?61   $
??Wrap=?6<   nl使用CanUserResizeColumns属性或单个列的CanUserResize属性，是否允许用户改变列的尺寸。?? 55      ig使用CanUserRecorderColumns属性或单个列的CanUserRecorder属性，是否允许用户重排序。?? 57      ??冻结的列始终位于DataGrid控件的左边，将DataGrid.FrozenColumn属性设置大于0的数，例如，数值1只冻结第一列59        5;      $??8q?6   	   Columns#??Z	 6&    .   5<        5=      $ 名称??61    5>      ?? 5?   "   .R?5@   &   ?? $??Center=?6K   $	??4,6q?6f   ??60   ?? $
 Name?6f   5A   #   5C        5D      $ 说明??61   $ * 6=    5E      ?? 5F   "   .R?5G   &   ?? $
??Wrap=?60   $??Center=?6f   $	??4,6q?6?   ??6D   ?? $ Description?6?   5H   #   5J      5L      5M      5N      ?? 5P   
   $??DataGrid??6   .??5Q      ]? ??. .+?5R      ?? -   5        $??8q?5R      
 ?? Orientation$
 
Horizontal=?6(   $	??Top=?6A   $
??Left=?6V    5S       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5T      " ??6    .?5U      ??  ? ??$ 4q?67   ?? 5V       ? ??$ Center=?6I   ?? 5W       ?@d?	IsChecked$
 TrueY?6:   5X      5Y      .+?5Z      ?? $??产品??6   
 ? Tag$ 0??6,   ?? 5[      $??单价??6   $ 1??6,   ?? 5\      $??型号??6   $ 2??6,   ?? 5]      $??类别??6   $ 3??6,   ?? 5^      $??图片??6   $ 4??6,   ?? 5_      $??描述??6   $ 5??6,   5`        5b      -   5          Name$ 
dgProducts??5b      $??8q?6/    .     FrozenColumnCount$ 2??6V      RowDetailsVisibilityMode$ VisibleWhenSelected=?5c   D    5d      0  *System.Windows.Controls.DataGridTextColumn  5e      $ 产品??6-   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 69   ?? $ 	ModelName?  5f      $ 单价??6-    69   ?? $ UnitCost? ?? StringFormat$ {0:C}??  5g      $ 型号??6-    69   ?? $ ModelNumber?4
  .System.Windows.Controls.DataGridComboBoxColumn
  5k      -   5        categoryColumn??$ 类别??5k   I    
  DisplayMemberPath$ CategoryName??6U    
  SelectedValuePath$ 
CategoryID??6v    
  SelectedValueBinding 5l   1   ?? $ 
CategoryID?  5m      $ 图片??61    5n      ?? 5o   "   .R?5p   &   ?? $
??None=?6,   ??6;   ?? $ ProductImagePath? ?? 	Converter# [ 5q   #   5s        5u      $ 描述??6-      MaxWidth$	 500Q?6^    69   ?? $ Description? 	  ElementStyle 5v      ?? 5w   "   " ??6(   .?5x   &   ??  ? ??$
 Wrap=?6E   5y   #   5{         RowDetailsTemplate 5~      ?? 5      .R?5?      ?? $	??760??6%   $??10q?64   
?????F?$??3q?6X    ?? CornerRadius$ 5??6l   $
??Left=?6}   ._?5?   "   ?? $
??Wrap=?6N   $??Italic$?6b   ??6,   ?? $ Description?6b   5?      5?      5?      5?      5?      5?      5?      