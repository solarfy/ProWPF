/* 设计数据库访问组件应遵循以下几个原则：
 * 1.快速打开和关闭。在每个方法调用中打开数据库连接，并在方法结束之前关闭连接。这样，连接就不会无意中保持打开状态，确保在适当的时间关闭连接可以使用Using方法。
 * 2.实现错误处理。使用错误处理确保连接被关闭。
 * 3.遵循无状态的设计规则。通过参数接收方法需要的所有信息，并通过返回值返回检索到的所有数据。可避免复杂化（多线程应用或在服务器上驻留数据组件）
 * 4.在某个位置保持数据库连接字符串。一般保存在配置文件中。
 */

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using StoreDataBase.Model;

namespace StoreDataBase
{
    public class StoreDB
    {
        //private string connectingString = "数据库连接字符串";

        //public Product GetProduct(int ID)
        //{
        //    SqlConnection con = new SqlConnection(connectingString);
        //    SqlCommand cmd = new SqlCommand("GetProductByID", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ProductID", ID);

        //    try
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
        //        if (reader.Read())
        //        {
        //            Product product = new Product((string)reader["ModelNumber"], (string)reader["ModelName"], (decimal)reader["UnitCost"], (string)reader["Description"]);
        //            return product;
        //        }              
        //    }//这里没有提供任何异常处理代码，因此所有的异常都会上传到调用代码。
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return null;
        //}

        public Product GetProduct(int ID)
        {
            DataSet ds = StoreDBDataSet.ReadDataSet();
            DataRow dr = ds.Tables["Products"].Select($"ProductID = {ID}")[0];
            Product product = new Product((string)dr["ModelNumber"], (string)dr["ModelName"], (decimal)dr["UnitCost"], (string)dr["Description"], (string)dr["CategoryName"], (int)dr["CategoryID"], (string)dr["ProductImage"]);
            return product;
        }

        public ICollection<Product> GetProducts()
        {
            DataSet ds = StoreDBDataSet.ReadDataSet();
            ObservableCollection<Product> products = new ObservableCollection<Product>() { };
            foreach (DataRow dr in ds.Tables["Products"].Rows)
            {
                Product product = new Product((string)dr["ModelNumber"], (string)dr["ModelName"], (decimal)dr["UnitCost"], (string)dr["Description"], (string)dr["CategoryName"], (int)dr["CategoryID"], (string)dr["ProductImage"]);
                products.Add(product);
            }
            return products;
        }

        public DataTable GetProductTable()
        {
            DataSet ds = StoreDBDataSet.ReadDataSet();
            return ds.Tables["Products"];
        }

        public ICollection<Category> GetCategoriesAndProducts()
        {
            DataSet ds = StoreDBDataSet.ReadDataSet();
            DataRelation relCategoryProduct = ds.Relations[0];

            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            foreach (DataRow categoryRow in ds.Tables["Categories"].Rows)
            {
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                foreach (DataRow productRow in categoryRow.GetChildRows(relCategoryProduct))
                {
                    Product product = new Product((string)productRow["ModelNumber"], (string)productRow["ModelName"], (decimal)productRow["UnitCost"], 
                        (string)productRow["Description"], (string)productRow["CategoryName"], (int)productRow["CategoryID"], (string)productRow["ProductImage"]);
                    products.Add(product);
                }

                categories.Add(new Category(categoryRow["CategoryName"].ToString(), products));
            }

            return categories;
        }

        public DataSet GetCategoriesAndProductsDataSet()
        {
            DataSet ds = StoreDBDataSet.ReadDataSet();      //Categories表的CategoryID与Product表的CategoryID的映射关系 FK_Categories_Products
            return ds;
        }

        public ICollection<Category> GetCategories()
        {
            DataSet ds = StoreDBDataSet.ReadDataSet();
            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            foreach (DataRow dr in ds.Tables["Categories"].Rows)
            {
                Category category = new Category((string)dr["CategoryName"], (int)dr["CategoryID"]);
                categories.Add(category);
            }
            return categories;
        }
    }
}
