using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ing.DAO;

namespace Test.Ing.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            int sum = 2;
            System.Console.WriteLine($"sum = {sum}");
            try
            {
                BaseDao baseDao = new BaseDao(new SqlServerDatabase());
                baseDao.TestConnection();
                System.Console.WriteLine("Connexion OK");
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine($"{ex.Message}");
            }
            System.Console.ReadKey();
        }
    }
}
