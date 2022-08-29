using System;
using System.Collections;
using System.Reflection;

namespace ProWPF.Data
{
    class SortByTextLength<T> : IComparer
    {
        public string PropertyName { get; set; }

        public SortByTextLength(string propertyName)
        {
            PropertyName = propertyName;
        }
    
        public int Compare(object x, object y)
        {
            PropertyInfo property = typeof(T).GetProperty(PropertyName);

            if (property != null)
            {
                string txtx = property.GetValue(x).ToString();
                string txty = property.GetValue(y).ToString();

                return txtx.Length.CompareTo(txty.Length);
            }

            throw new Exception("无效的属性名称");
        }
    }
}
