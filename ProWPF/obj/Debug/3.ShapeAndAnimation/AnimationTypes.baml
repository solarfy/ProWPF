   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProWPF.ShapeAndAnimationProWPF.ShapeAndAnimation  5   	   -    'ProWPF.ShapeAndAnimation.AnimationTypes   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProWPF.ShapeAndAnimation     5   	   -   5          ? Title$  	动画类??5   	   $	??450??6   $	??800??6"   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ?? $??1??6   $??0??6    $??抽象动画基类??60   $??4q?6@   .??5      ??  ?? DisplayMemberPath$
 Name??5      ??5      ??  ?? RelativeSource ??  ?? AncestorType$ local:AnimationTypesL? ?? Mode$ FindAncestor=? ?? Path$ AnimationBaseTypes? ?? Mode$ OneTime=?5      5      ?? 5   
   $??1??6   $??1??6    $??线性插值动画类??60   $??4q?6A   .??5      ?? $
 Name??5      ??5      ??  ?? $ local:AnimationTypesL?$ FindAncestor=?$ AnimationLinearTypes?$ OneTime=?5      5      ?? 5    
   $??1??6   $??2??6    $??关键帧动画类??60   $??4q?6@   .??5!      ?? $
 Name??5"      ??5!      ??  ?? $ local:AnimationTypesL?$ FindAncestor=?$ AnimationKeyFramesTypes?$ OneTime=?5"      5#      ?? 5%   
   $??1??6   $??3??6    $??路径动画类??60   $??4q?6?   .??5&      ?? $
 Name??5'      ??5&      ??  ?? $ local:AnimationTypesL?$ FindAncestor=?$ AnimationPathTypes?$ OneTime=?5'      5(      5*      5+      