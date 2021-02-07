using System;
using System.Data;

namespace PagaAPI.DAL
{
    public  interface IConnection
    {
        string Server { get; }
        string DataBase { get; }
        string User { get; }
        string Password { get; }
        string ConnectionString { get; }

        void Executar(string pValor);

        DataTable ObterRegistros(string pValor);
    }
}
