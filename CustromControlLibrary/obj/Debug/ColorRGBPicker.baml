   M S B A M L   `   `   `  ????  CustomControlLibrary)    #CustomControlLibrary.ColorRGBPicker   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	??360??5      $	??120??6     ? 	Resources  5       ?? 
TargetType ?? Property ?? Value??%J  '??       ?? 5   
   " ??6   .?5      ??  ?@?Minimum$ 0Q?6(   ?? 5	       ?@?Maximum$	 255Q?6(   ?? 5
       ?@??IsSnapToTickEnabled . 64   ?? 5       ?@?SmallChange$ 1Q?6,   ?? 5       ?@??IsMoveToPointEnabled . 65   ?? 5       ? ??$ Center=?62   5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   ?? $??0??6    ? Value 6   ??  ?? RelativeSource ??  ?? Mode$ FindAncestor=?	 ?? AncestorType$	 UserControlL?
 ?? Path$	
 Red??? 5   
   $??1??6    6   ??  ?? $ FindAncestor=?$	 UserControlL?$
 Green??? 5   
   $??2??6    6   ??  ?? $ FindAncestor=?$	 UserControlL?$

 Blue??? 5    
   $??1??6   $??3??6$   $	??100??65   $	??120??6A   
???   ?$??1??6]   ??5!      ?? 5"       ?? Color 6"   ??  ?? $ FindAncestor=?$	 UserControlL?$
 Color?5$      5%      5&      