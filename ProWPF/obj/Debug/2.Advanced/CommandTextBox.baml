   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProWPF.AdvancedProWPF.Advanced  5   	   $    ProWPF.Advanced.CommandTextBox   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProWPF.Advanced     5   	     ? Title$#  自定义 TextBox命令控件??5   	   $	??450??6!   $	??800??6.   .??5
      ? $??4q?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   ?? $??4q?6   $B??<支持命令的TextBox（超过30个字符将无法输入）??6       ProWPF.Advanced.CmdTextBox  5   
   -   5          Name$ cmdText??5      $??4q?6,   $??1??67   $   ProWPF.Advanced.CommandTextBox   PrintTextCommand   Command# Z 6D      CommandParameter$ Print:??6   .??6?    J? CommandBindings 5      )  #System.Windows.Input.CommandBinding  5      -   5           Command# Z 5   !   5   !   .??5   0   5      ?? 5   
   $??2??6   $??4q?6!   $??Right=?6,   
字数： ?? 5      -   5         ??Name$ 
numberText??5      $?0??6&   5       ?? 5#   
   $??4q?6   $??3??6   $??普通的TextBox??6,   ?? 5$   
   -   5        	 ??Name$
	 text??5$      $??4q?6    $??4??6+   ?? 5&   
   -   5        $??5??5&      $??Right=?6   $??4q?6:   $??Clear??6E   $	??8,2q?6U   6c   5'      5(      