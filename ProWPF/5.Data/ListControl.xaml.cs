using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Data
{
    /// <summary>
    /// ListControl.xaml 的交互逻辑
    /// </summary>
    public partial class ListControl : Window
    {
        public ListControl()
        {
            InitializeComponent();
        }

        private void RadioAlternationCount_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton radio)
            {
                if (radio.IsChecked == true)
                {
                    this.lstboxAlternation.AlternationCount = int.Parse(radio.Content.ToString());
                }
            }
        }
    }

    class SomePropeties
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public SomePropeties(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static ICollection<SomePropeties> Propeties
        {
            get => GetProperties();
         }

        private static ICollection<SomePropeties> GetProperties()
        {
            List<SomePropeties> somes = new List<SomePropeties>() { };

            somes.Add(new SomePropeties("ItemSource", "绑定数据源（希望在列表中显示的集合或DataView对象）"));
            somes.Add(new SomePropeties("DisplayMemberPath", "希望为每个数据项显示的属性。对于更复杂的表达形式或者为了使用多个属性而言，应改用ItemTemplate属性"));
            somes.Add(new SomePropeties("ItemStringFromat","该属性是一个.NET格式字符串，如果设置了该属性，将使用该属性为每个项格式化文本。类似与Binding.StringFormat属性"));
            somes.Add(new SomePropeties("ItemContainerStyle", "该属性是一个样式，通过该样式可以设置封装每个项的容器的多个属性。容器取决于列表的类型。ListBox使用ListBoxItem，ComboBox使用ComboBoxItem"));
            somes.Add(new SomePropeties("ItemContainerStyleSelector", "使用代码为列表中每项的封装器选择样式的StyleSelector对象。可以使用该属性为列表中的不同项提供不同的样式。必须创建自定义的StyleSelector对象"));
            somes.Add(new SomePropeties("AlternationCount", "在数据中设置交替集合数量。如设置为2，将在两个不同的行样式之间交替，设置为3，将在3个行样式之间交替"));
            somes.Add(new SomePropeties("ItemTemplate", "此类模板从绑定的对象提取合适的数据，并将提取的数据安排到合适的控件组合中"));
            somes.Add(new SomePropeties("ItemTemplateSelector", "使用代码为列表中每个项选择模板的DataTemplateSelector对象。可以通过这个属性为不同的项应用不同的模板。必须创建自定义的DataTemplateSelector类"));
            somes.Add(new SomePropeties("ItemsPanel", "定义用于包含列表中项的面板。所有封装器都添加到这个容器中。通常，使用垂直方向（自上而下）的VirtualizingStackPanel面板"));
            somes.Add(new SomePropeties("GroupStyle", "如果正在使用分组，这个样式定义了应当如何格式化每个分组。当使用分组时，项封装器（ListBoxItem和ComboBoxItem等）被添加到表示每个分组的GroupStyle封装器中，然后这些分组被添加到列表中"));
            somes.Add(new SomePropeties("GroupStyleSelector", "使用代码为每个分组选择样式的StyleSelector对象。可以通过这个属性为不同的分组使用不同的样式。必须创建自定义的StyleSelector类"));

            return somes;
        }

    }
}
