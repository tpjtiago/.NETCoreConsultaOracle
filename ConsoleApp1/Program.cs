using Oracle.ManagedDataAccess.Client;
using System;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string connectinString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.1)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = SEUNOME)));Persist Security Info=True;User ID=USUARIO;Password=PASS;Pooling=True;Connection Timeout=60;";
        static void Main(string[] args)
        {

            Console.WriteLine("Hello Oracle!");
            using (var conn = new OracleConnection(connectinString))
            {


                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT * FROM V_CENTRO_CUSTO";

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("===========================");
                        Console.WriteLine($"CENTRO_CUSTO: {reader["NOM_CENCUSTO"]}");
                    }

                    Console.WriteLine("===========================");

                    reader.Dispose();
                }
            }


            Console.ReadKey();
        }
    }
}
