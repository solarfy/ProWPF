   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProWPF.BasicProWPF.Basic  5   	        ProWPF.Basic.KeyboardEvent   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProWPF.Basic     5   	   -   5          ? Title$  键盘输入事件??5   	   $	??450??6   $	??800??6%   .??5      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   .+?5   
   ]? $??0??6   $??4q?6!   ??. .+?5      ?? $
??Left=?6   $??4q?6.   $??
Type here:??69   ?? 5      -   5         ??Name$
 text??5      $??4q?6$   6J   5      ?? 5   
   -   5         ??Name$ lstMessages??5      $??1??6'   $??4q?64   ?? 5   
   $??2??6   $??4q?6"    ?? Orientation$ 
Horizontal=?6-   .+?5      ?? -   5         ??Name$ chkIgnoreRepeat??5      $??4q?60   $??忽略重复键??6;   ?? 5      -   5        $??4q?5      $??只能输入数字??6"   6N   5      ?? 5   
   -   5        $??3??5      $??
Clear List??6   $??Right=?63   $??4q?6O   5       5!      5"      