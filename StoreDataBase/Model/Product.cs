using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreDataBase.Model
{
    public class Product : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region 数据验证

        //在添加或删除错误时引发该事件
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //INotifyDataErrorInfo接口要求将错误链接到特定属性，每个属性可以有多个错误。所以使用Dictionary<T,K>集合，按属性名称为该集合编写索引。
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        //指示数据对象是否包含错误
        public bool HasErrors => errors.Count > 0;

        //提供完整的错误信息
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                //获取所有的错误集合
                return errors.Values;
            }
            else
            {
                //获取指定属性的错误集合
                if (errors.ContainsKey(propertyName))
                {
                    return errors[propertyName];
                }
                else
                {
                    return null;
                }
            }
        }

        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            //清除此属性已存在的任何错误
            errors.Remove(propertyName);

            //添加指定属性的错误集合
            errors.Add(propertyName, propertyErrors);

            //引发错误通知事件
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyName)
        {
            //清除此属性已存在的任何错误
            errors.Remove(propertyName);

            //引发错误通知事件
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #region 属性

        public event PropertyChangedEventHandler PropertyChanged;

        //如果几个数值都发生了变化，可调用该方法并传递空字符串，WPF会重新评估绑定到类的任何属性的绑定表达式。
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set 
            { 
                modelNumber = value;

                //限制只能使用字母和数字的字符串（不允许使用标点符号、空格以及其它特殊字符）
                bool valid = true;
                foreach (char c in modelNumber)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                {
                    List<string> modelNumberErrors = new List<string>();
                    modelNumberErrors.Add("ModelNumber只能使用字母和数字的字符串");
                    SetErrors("ModelNumber", modelNumberErrors);
                }
                else
                {
                    ClearErrors("ModelNumber");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
            }
        }

        private string modelName;
        public string ModelName
        {
            get { return modelName; }
            set 
            {
                modelName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModelName"));
            }
        }

        private decimal unitCost;
        public decimal UnitCost
        {
            get { return unitCost; }
            set 
            {
                //在数据对象中进行验证，但WPF会忽略当前发生的数据绑定错误，所以用户无法知道更新已被拒绝，非法的值仍被保留在文本框中--只是没有被应用于绑定的数据对象。
                if (value < 0)
                {
                    throw new ArgumentException("无效的价格");
                }
                else
                {
                    unitCost = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
                }
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        private string productImagePath;
        public string ProductImagePath 
        {
            get => productImagePath;
            set => productImagePath = value;
        }

        private string categoryName;
        public string CategoryName 
        {
            get => categoryName;
            set
            {
                categoryName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CategoryName"));
            }

        }

        private int categoryId;
        public int CategoryID
        {
            get => categoryId;
            set
            {
                categoryId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CategoryID"));
            }
        }
        #endregion

        public Product(string modelNumber, string modelName, decimal unitCost, string description, string categoryName, int categoryId)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
            CategoryName = categoryName;
            CategoryID = categoryId;
        }

        public Product(string modelNumber, string modelName, decimal unitCost, string description, string categoryName, int categoryID, string productImagePath) :
            this(modelNumber, modelName, unitCost, description, categoryName, categoryID)
        {
            ProductImagePath = productImagePath;
        }

        public override string ToString()
        {
            return $"{ModelNumber}-{modelName}-{unitCost}";
        }

    }
}
