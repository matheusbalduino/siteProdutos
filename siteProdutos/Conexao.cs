using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siteProdutos
{
    public class Conexao
    {
        private static string Server = "localhost";
        private static string Database = "sitetrab";
        private static string User = "root";
        private static string Password = "embauba";

        private static string connectionString = $@"Server={Server};Database={Database}; uid={User}; Pwd={Password}; SslMode=none; Charset=utf8";
        public static MySqlConnection Connection = new MySqlConnection(connectionString);

        public static void Conectar()
        {
            if(Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public static void Desconectar()
        {
            if(Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}