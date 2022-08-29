using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StoreDataBase.Model
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set 
            { 
                categoryName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CategoryName"));
            }
        }

        private int categoryId;
        public int CategoryID
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CategoryID"));
            }
        }

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set 
            { 
                products = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Products"));
            }
        }

        public Category(string categoryName, ObservableCollection<Product> products)
        {
            CategoryName = categoryName;
            Products = products;
        }

        public Category(string categoryName, int categoryId)
        {
            CategoryName = categoryName;
            CategoryID = categoryId;
        }
    }
}
