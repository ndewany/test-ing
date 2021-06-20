using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ing.DAO
{
    public class MySqlDatabase : IDataBaseServer
    {
        public IDbConnection DbConn => throw new NotImplementedException();

        public bool Connect()
        {
            throw new NotImplementedException();
        }
    }
}
