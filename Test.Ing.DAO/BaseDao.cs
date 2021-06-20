using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ing.DAO
{
    public class BaseDao
    {
        public readonly IDataBaseServer _dataBaseServer;

        public BaseDao(IDataBaseServer dataBaseServer)
        {
            _dataBaseServer = dataBaseServer;
        }

        public bool TestConnection()
        {
            return _dataBaseServer.Connect();
        }

        public bool DoesExist(string dataName)
        {

            return false;
        }

        public void InsertData()
        {

        }        

        public IEnumerable<ViewListResult> GetAllDataFromView()
        {

            List<ViewListResult> viewListResult = new List<ViewListResult> { };

            using (SqlConnection conn = (SqlConnection)_dataBaseServer.DbConn)
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
