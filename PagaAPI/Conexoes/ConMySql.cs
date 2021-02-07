using System;
using System.Data;
using MySql.Data.MySqlClient;
using PagaAPI.DAL;

namespace PagaAPI.Conexoes
{
    public class ConMySql : IConnection
    {
        public string Server { get => "pagaapi.mysql.uhserver.com"; }
        public string DataBase { get => "pagaapi"; }
        public string User { get => "testeapi"; }
        public string Password { get => "Teste@12"; }
        public string ConnectionString { get => $"Server={Server}; Database={DataBase}; Uid={User}; Pwd={Password};"; }
        private MySqlConnection connection;
        private MySqlCommand command;

        public ConMySql()
        {
            connection = new MySqlConnection(ConnectionString);
            connection.Open();
        }

        public void Executar(string pValor)
        {
            command = new MySqlCommand(pValor, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable ObterRegistros(string pValor)
        {
            command = new MySqlCommand(pValor, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
    }
}
