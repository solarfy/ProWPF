using System.Data;

namespace StoreDataBase
{
    internal class StoreDBDataSet
    {
        internal static DataSet ReadDataSet()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema("Store.xsd");
            ds.ReadXml("Store.xml");
            return ds;
        }
    }
}
