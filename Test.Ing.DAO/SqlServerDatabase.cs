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
        
    }
}
