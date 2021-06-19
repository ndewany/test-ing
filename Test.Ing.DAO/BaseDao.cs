using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ing.DAO
{
    public static class BaseDao
    {
        public static bool TestConnection()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=Server;Initial Catalog=database;User ID=userID;Password=password";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (SqlException ex)
            {                
                throw;                
            }
            finally {
                cnn.Close();
            }
                        
            return true;
        }
    }
}
