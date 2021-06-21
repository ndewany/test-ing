using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ing.DAO
{
    public class SqlServerDatabase : IDataBaseServer
    {
        private readonly SqlConnection _cnn;
        public IDbConnection DbConn { get => _cnn; }

        public SqlServerDatabase()
        {
            string connetionString = @"Data Source=ServerName;Initial Catalog=DbName;User ID=UserID;Password=secret";
            _cnn = new SqlConnection(connetionString);
        }

        public bool Connect()
        {
            try
            {
                _cnn.Open();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                _cnn.Close();
            }
            return true;
        }

        public IEnumerable<ViewListResult> GetAllData()
        {
            List<ViewListResult> viewListResult = new List<ViewListResult> { };

            using (SqlConnection conn = _cnn)
            {
                conn.Open();

                try
                {
                    string query = $"SELECT * FROM ViewList";
                    SqlCommand command = new SqlCommand(query, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Int64.TryParse(reader[0].ToString(), out long ID_Categorie);
                            string categorieName = reader[1].ToString();
                            Int64.TryParse(reader[2].ToString(), out long ID_Element);
                            string elementName = reader[3].ToString();

                            viewListResult.Add(new ViewListResult { ID_Categorie = ID_Categorie, CategorieName = categorieName, ID_Element = ID_Element, ElementName = elementName });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }

                return viewListResult;
            }
        }
    }
}
