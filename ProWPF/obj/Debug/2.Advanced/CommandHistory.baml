   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	   $    ProWPF.Advanced.CommandHistory   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	   -   5          ?Name$  window??5   	    ? Title$ 跟踪和翻转命令??5   	   $	??450??6   $	??800??6&    J? CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5        $   ProWPF.Advanced.CommandHistory   ApplicationUndo   Command# Z 5      5      .??5      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $
??1.5* ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6    ? 	Resources 5       ?? 
TargetType	 ?? Property
 ?? Value??%v   '??       ?? 5      " ??6   .?5      ?? 	 ? ??$
 4q?6/   ?? 5      	 ? ??$	
 8,2q?60   5      5      .+?5!      c? .@?5"      ?? $ 
Horizontal=?6   .+?5#      ?? $??ApplicationCommands.Cut??6   ??6?   ??  ?? RelativeSource ?? *self+ ?? Path$ Command.Text??? 5$      $??ApplicationCommands.Copy??6   ??6@   ??  ?? *self+$ Command.Text??? 5%      $??ApplicationCommands.Paste??6   ??6A   ??  ?? *self+$ Command.Text??? 5&      $??ApplicationCommands.Undo??6    ? ToolTip$% 需要选中其中一个TextBox??5'      ??5&   @   ??  ?? *self+$ Command.Text?5'      5(      5)      c? 5+      .@?5,      ?? #??Z 6   ??6S   ??  ?? *self+$ Command.Text?5-      5.      ?? 50   
   $??1??6   $??4q?6   .??6*   Text typed here.52      ?? 54   
   $??2??6   $??4q?6   .??6*   Text typed here.56      ?? 58   
   $??3??6   $??4q?6    ?? DisplayMemberPath$ CommandName??59      $??Visible=?62   ??58   *   ??  ?? ElementName$ window??$ CommandCollection?5;      5<      5=      