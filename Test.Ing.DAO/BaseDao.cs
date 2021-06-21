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

        public IEnumerable<ViewListResult> GetAllData()
        {
            return _dataBaseServer.GetAllData();
        }
    }
}
