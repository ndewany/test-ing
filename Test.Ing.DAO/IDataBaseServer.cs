using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ing.DAO
{
    public interface IDataBaseServer
    {
        IDbConnection DbConn { get; }
        bool Connect();        
    }
}
