   M S B A M L   `   `   `  ????A  =ProWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProWPF.DataProWPF.Data  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5   	       ProWPF.Data.DataView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProWPF.Data     5   	   N	component8clr-namespace:System.ComponentModel;assembly=WindowsBase     5   	   -   5          ? Title$  数据视图??5	   	   $	??450??6   $	??800??6#    ? 	Resources 5      *  $ProWPF.Data.PriceRangeProductGrouper   Price50Grouper   GroupInterval  GroupByRangeView ?? SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName   	Direction ?? GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName   	Converter  SimpleProductsList	 ?? 
TargetType
 ?? Property ?? Value ?? StringFormat ?? Path??%?  &	        &	      7   &	 ?       5   
   $ 50??6@   ?? 5   
    5        5      $ UnitCost??6,   $ 	Ascending=?6D    5        5      $ UnitCost??6+   8   6C   5      ?? 5   
   "	 ??6+   .?5      ?? 
 ? ?? 5      ?? 5      .R?5      ?? ??5      `? 5   "   $ {0:C} - {1}??6/   .1?5   &   ?? $ UnitCost?6.   ?? 5    &   $ 	ModelName?6.   5!   #   5#      5$      5&      5'      5(      .??5*      ?? .@?5+   
   ?? $??数据视图??6   .??5,      ?? $??8q?6   $
??Wrap=?6#   ??数据视图--介于数据源与绑定的控件之间。数据视图是进入数据源的窗口，可以跟踪当前项，并且支持各种功能，如排序、过滤及分组。?? 5.      ??所有视图都继承自CollectionView类；并有两个特殊的派生类：ListCollectionView类和BindingListCollectionView类。?? 50      ??1.如果数据源实现了IBindingList接口，就会创建BindingListCollectionView视图。当绑定到ADO.NET中的DataTable对象时会创建该视图。?? 52      ??2.如果数据源没有实现IBindingList接口，但实现了IList接口，就会创建ListCollectionView视图。当绑定到ObservableCollection集合时会创建该视图。?? 54      ??3.如果数据源没有实现IList或IBindingList接口，但实现了IEnumerable接口，就会得到基本的CollectionView视图。?? 56      ??检索视图对象：使用System.Windows.Data.CollectionViewSource类的GetDefaultView()静态方法，该方法总是返回ICollectionView引用， 根据数据源将视图对象转换为合适的类。?? 59      ??ItemsControl.IsSynchronizedWithCurrentItem属性设置为True时，当前选择项会被自动同步，从而匹配视图的当前位置。?? 5;      ?? 5<      ??CollectionViewSource类中，View属性封装视图对象，Source属性封装数据源，SortDescription属性负责排序，GroupDescription属性负责分组， 同时还提供Filter事件。5?      5@      ?? 5B   
   $??视图导航??6   .??5C      ?  ? RowDefinitions 5D      ?? 5E      $
??Auto ?6$   ?? 5F      ?? 5G      $
??Auto ?6$   .+?5K      ?? $??8q?6    ?? DisplayMemberPath$ 	ModelName??6&   $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5L       ?? 
IsReadOnly .   ?? 
IsEditable .  ?? Text 5K   D   ?? $ 	ModelName???5M      ??  ?? ElementName$ gridProduct??$ DataContext?? 5O      -   5         ?Name$ gridProduct??5O      $??1??6,   $??8q?69    5P      ?? 5Q      $
??Auto ?6(   ?? 5R      $
??Auto ?6(   ?? 5S      $
??Auto ?6(   ?? 5T      $
??Auto ?6(   ?? 5U       ? ColumnDefinitions 5W      ?? 5X      $
??Auto ?6+   ?? 5Y       5\      ??%?   '??       '?? q     ?? 5]      "	 ??6    .?5^      ?? 
 ? ??$	 8,6q?67   ?? 5_      
 ? ??$ Center=?6B   5`      ?? 5a      "	 ??6    .?5b      ?? 
 ? ??$	 8,6q?67   ?? 5c      
 ? ??$ 4q?68   5d      5e      .+?5g      ?? $??5??6   $??2??6.    ?? CornerRadius$ 6??6B   
???????$??0, -4q?6k   ?? 5i      $??0??6    $??0??6-   $??ModelNumber:??6=   ?? 5j      $??0??6   $??1??6+   ??6;   ?? *ModelNumber+?? 5l      $??1??6    $??0??6-   $??
ModelName:??6=   ?? 5m      $??1??6   $??1??6+   ??6;   ?? *	ModelName+?? 5o      $??2??6    $??0??6-   $??	UintCost:??6=   ?? 5p      $??2??6   $??1??6+   ??6;   ?? *
UnitCost+?? 5r      $??3??6    $??0??6-   $??Description:??6=   ?? 5s      $??4??6   $??2??6+    ?? TextWrapping$
 Wrap=?6\   ??6?   ?? *Description+6\   5u      ?? 5w      $??2??6   $??8q?6*   $
??Left=?65    ?? Orientation$ 
Horizontal=?6P   .+?5x      ?? -   5         ??Name$ btnPrev??5x      $??<??6.   $	??3,4q?6=   6K   ?? 5y      -   5         ??Name$ txtPosition??5y       $	??4,0q?65   $??Record 0 of 0??6B   $??Center=?6W   ?? 5z      -   5        $ btnNext??5z      $??>??6.   $	??3,4q?6=   6K   5{      5|      5}      ?? 5   
   $??声明方式创建视图??6   .??5?      ?? $??8q?6W   $ UnitCost??6b   ??6   ??  ?? Source# [ 6b   5?      ?? 5?   
   $??过滤集合对象??6   .??5?      ?  5?      ?? 5?      $
??Auto ?6$   ?? 5?      .+?5?      ?? $??8q?6   $
??Wrap=?6'   ??使用Filter属性接收一个Predicate委托，该委托指向自定义的过滤方法。如果被检查项目满足过滤条件就返回true，否则则返回false。?? 5?      mk当创建Predicate对象时，需指定进行检查的对象类型。可以使用Predicate<object>实例。5?      ]? 5?      $??1??6   ??. $??8q?6>   .+?5?      ?? $ 
Horizontal=?6!   $	??Top=?6:   .+?5?      ?? $??Price > Than: ??6$   $??4q?6:   $??Center=?6E   ?? 5?      -   5         ??Name$ txtMinPrice??5?   "   $??1??67   $??50??6G   $??50??6Q   $??4q?6_   $??10,4,4,4q?6k   $??Center=?6}   5?   &   ?? 5?      -   5        $??1??5?   !   $??Filter??6.   $??10,4,4,4q?6?   $??4q?6Q   6]   ?? 5?      -   5        $??1??5?   !   $??1??6.   $??Remove Filter??6>   $??10,4,4,4q?6V   $??4q?6h   6t   5?      ?? 5?      $	??Top=?6    $??4q?65   $
??Wrap=?6@   
???  ??$??Center=?6e   $????此处过滤后也会影响 视图导航 标签中的列表，因为它们共用的一个数据视图对象（ListCollectionView）。??5?   $   ?? 5?      ??6   ?? $ gridProduct??$ DataContext?5?      5?      5?      ?? 5?   
   $??过滤DataTable对象??6   .??5?      ]? ??. .+?5?      ?? $??8q?6   $	??Top=?6'   $
??Wrap=?6<   ??DataTable对象都与一个DataView对象相关联（System.Data名称空间中定义），可使用DataView对象过滤记录（使用RowFilter属性进行过滤，或者使用RowStateFilter属性通知状态进行过滤）。 DataView对象还通过Sort属性支持排序。与WPF视图对象不同，DataView对象不跟踪数据集中的位置，DataView对象还提供了用于锁定编辑能力的附加属性（AllowDelete、AllowEdit以及AllowNew）。?? 5?      ??DataView对象使用BindingListCollectionView视图不支持Filter属性，但可使用CustomFilter属性，该属性本身不做任何工作--只是接收指定的过滤字符串，并使用该字符串设置DataView.RowFilter属性。?? 5?      ??DataView.RowFilter属性将基于字符串过滤表达式作为参数，类似于SELECT查询中用于构造WHERE子句的SQL代码段，因此需要遵循所有的SQL约定，例如需使用单引号（‘’）将字符串和和日期值括起来， 如果希望使用多个条件，还需使用OR和AND关键字进行结合。5?      ?? 5?      $	??Top=?6   $ 
Horizontal=?62   $??8q?6K   .+?5?      ?? $??Price > Than: ??6    $??4q?66   $??Center=?6A   ?? 5?      -	   5        $ txtMiniTablePrice??5?      $??50??69   $??50??6C   $??4q?6Q   $??10,4,4,4q?6]   $??Center=?6o   ?? 5?      -
   5        $??Filter??5?      $??10,4,4,4q?6.   $??4q?6@   6L   ?? 5?      -   5        $??Remove Filter??5?      $??10,4,4,4q?65   $??4q?6G   6S   5?      ?? 5?      -   5         ??Name$ tableProducts??5?      $??8q?61   $ UnitCost??6<    ?? ItemStringFormat$ 单价{0:C}??6Y   5?      5?      ?? 5?   
   $??排序??6   .??5?      ]? ??. .+?5?      ?? $	??Top=?6   $
??Wrap=?61   $??8q?6E   ??使用System.ComponentModel.SortDescription对象对每个数据项中的一个或多个属性进行排序，并确定排序的方法（升序或降序）。?? 5?      ??自定义排序规则，但只能用于ListCollectionView视图，不能用于BindingListCollectionView视图（可使用DataView对象的Sort属性）。ListCollectionView.CustomSort属性接收一个ICompare对象， 该对象在两个对象直接进行比较，并且指示较大项。5?      ? 5?      $??8q?6    5?      ?? 5?      $
??Auto ?6(   ?? 5?      ?? 5?      .+?5?      ?? $??排序规则??6   .??5?      ?? $ 
Horizontal=?6%   .+?5?      ?? -   5        $??UnicCost单价??5?   '   $??8q?6<   6d   ?? 5?      -   5        $0??*ModelName名称长度（自定义排序）??5?   '   $??8q?6F   6o   5?      5?      ?? 5?      $??1??6   $??集合对象的排序??6,   .??5?      ?? #??[ 6"   $??4q?6N   ??6Y   ?? $ gridProduct??$ DataContext?5?      ?? 5?      $??2??6   $??DataTable对象的排序??6,   .??5?      ?? #??[ 6"   $??4q?6N   ??6Y   ?? $ tableProducts??$ ItemsSource?5?      5?      5?      5?      ?? 5?   
   $??分组??6   .??5?      ?  5?      ?? 5?      $
??Auto ?6$   ?? 5?      $
??Auto ?6$   ?? 5?      .+?5?      ?? $??8q?6   $
??Wrap=?6'   mk需要为CollectionView.GroupDescription集合添加System.ComponentModel.PropertyGroupDescription对象。?? 5?      ??使用分组时，列表为每个分组创建单独的GroupItem对象，并且为列表添加这些GroupItem对象。GroupItem是内容控件，所以每个GroupItem对象都包含一个适当的具有 实际数据的容器（如ListBoxItem对象）。?? 5?      zx可通过ItemsControl.GroupStyle属性更改GroupItem对象格式，该属性提供了一个GroupStyle对象的集合。?? 5?      ??为添加分组标题，需要设置GroupStyle.HeaderTemplate属性。当编写表达式时，不能绑定到列表中的数据（本例中Product对象），而要绑定到分组的 PropertyGroupDescription对象，即如果要显示分组的字段值，需要使用PropertyGroupDescription.Name属性（而不是使用Product.CategoryName属性）。?? 5?      ??分组虚拟化，使用VirtualizingStackPanel.IsVirtualizingWhenGrouping属性设置为true时，分组列表将与未分组列表获得相同的虚拟化性能。 （组合使用分组和长列表时，会导致速度明显变缓，因此谨慎使用）5?      ?? 5?      $??1??6   $??8q?6*   $ 
Horizontal=?65   .+?5?      ?? -   5        $??按种类分组??5?      $
??12,4q?6B   ?? 5?      -   5        $??按价格的范围分组??5?      $??12, 4q?6I   $
??10,0q?6Y   ?? 5?      -   5        $??移除分组??5?      $
??12,4q?6F   5?      ?? 5?      $??2??6   $??8q?6'   #??[ 5?      ??5?   2   ?? $ gridProduct??$ DataContext?  ?? 
GroupStyle  5?      (  "System.Windows.Controls.GroupStyle  5?      !   HeaderTemplate! 5?      ?? 5?   "   .R?5?   &   ?? $
??Bold"?6F   
???????
???????$??0,5,0,0q?6?   " ?? Padding$" 3q?6?   ??60   ?? *Name+6?   5   #   5     5     5     5     ?? 5  
   $??实时成型??6   .??5	     ?  5
     ?? 5     $
??Auto ?6$   ?? 5     $
??Auto ?6$   ?? 5     .+?5     ?? $??8q?6   $
??Wrap=?6'   ??如果改变正在使用的视图过滤、排序或分组，就需要调用ICollectionViewSource.Refresh()方法刷新视图，并确保正确的项目出现在列表中。 但对于一些特殊情况，如某个编辑操作将产品价格降低至视图过滤条件最低值以下，这会导致该记录从当前视图上消失，但除非强制执行，否则看不到任何的更改。?? 5     ??实时成型：监视特定属性的变化，如果发现变化，就确定相应更改会影响当前视图并触发刷新操作。?? 5     实时成型的3个标准：?? 5     ;91.数据对象必须实现INotifyPropertyChanged接口。?? 5     ??2.集合必须实现ICollectionViewLiveShaping。标准的ListCollectionView和BindingListCollectionView类都实现了该接口。?? 5     ??3.必须明确启用实时成型。为此需要在ListCollectionView和BindingListCollectionView对象上设置多个属性。（实时成型会增加开销，因此是否启用要酌情而定）?? 5     ??IsLiveFiltering、IsLiveSorting、IsLiveGrouping，每个属性为不同的视图功能启用实时成型。启用实时成型后，还需要告知需要监控哪些属性， LiveFilteringProperties、LiveSortingProperties、LiveGroupProperties，此设计旨在确保获得最佳性能，忽略那些不重要的属性。5     ?? 5!     $??1??6   $??8q?6*   $ 
Horizontal=?65   .+?5"     ?? -   5        $??过滤大于50的单价??5"     $??4q?63   6\   ?? 5#     -   5        $??启用实时成型??5#     $??4q?60   6W   5$     &   System.Windows.Controls.DataGrid  5'     $??2??6   $??8q?6(   #   AutoGenerateColumns# .  ??63   ?? $ gridProduct??$ DataContext?$   Columns$ 5(     0  *System.Windows.Controls.DataGridTextColumn  5)     ,  &System.Windows.Controls.DataGridColumn%   Width5  /System.Windows.Controls.DataGridLengthConverter$% * 6-   1	  +System.Windows.Controls.DataGridBoundColumn& 	  Binding& 67   ?? $ UnitCost?5+     5,     5-     5.     5/     