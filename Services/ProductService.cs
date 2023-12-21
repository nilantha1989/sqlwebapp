
using sqlwebapp.Models;
using System.Data.SqlClient;

namespace sqlwebapp.Services
{
    public class ProductService
    {
        private static string db_source = "niappserver.database.windows.net";
        private static string db_user = "nilantha";
        private static string db_password = "Gayanila8911!";
        private static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
          var _builder=new  SqlConnectionStringBuilder();
             _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _product_list=new List<Product>();
            string statement = "select * from products";

            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)

                    };
                    _product_list.Add(_product);

                }
            }
            conn.Close();
            return _product_list;
        }
    }
}
