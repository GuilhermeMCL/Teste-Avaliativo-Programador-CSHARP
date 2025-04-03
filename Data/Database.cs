using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cadastroFornecedores.Data
{
   public sealed class Database 
   {
        private static Database _instance;
        private MySqlConnection _connection;

        private string _connectionString = "Server=localhost;Database=fornecedores_db;User=root;Password=root;";

        private Database()
        {
            _connection = new MySqlConnection(_connectionString);
        }

        public static Database GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Database();
            }
            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

    }
}
