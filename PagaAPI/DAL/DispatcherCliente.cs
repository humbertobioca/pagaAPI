using System;
using System.Data;
using PagaAPI.DML;

namespace PagaAPI.DAL
{
    internal class DispatcherCliente
    {
        private readonly IConnection _connection;

        #region Campos
        private const string CAMPO_ID_CLIENTE = "IDCLIENTE";
        private const string CAMPO_NOME = "NOME";
        private const string CAMPO_EMAIL = "EMAIL";
        private const string CAMPO_DATA_NASCIMENTO = "DATANASCIMENTO";
        private const string CAMPO_CPF = "CPF";
        private const string CAMPO_RG = "RG";
        private const string CAMPO_TELEFONE = "TELEFONE";
        private const string CAMPO_ENDERECO = "ENDERECO";
        private const string CAMPO_NUMERO_ENDERECO = "NUMEROENDERECO";
        private const string CAMPO_REFERENCIA = "REFERENCIA";
        private const string CAMPO_CEP = "CEP";
        #endregion

        #region Procedures

        private const string CAD_CLIENTE = "SP_CadClienteV1";

        #endregion

        public DispatcherCliente(IConnection pConnection)
        {
            _connection = pConnection;
        }

        internal void CadastrarCliente(Cliente pCliente)
        {
            _connection.Executar($"call {CAD_CLIENTE}('{pCliente.Nome}', '{pCliente.Email}', " +
                $"'{pCliente.DataNascimento.ToString("dd/MM/yyyy")}', '{pCliente.CPF}', '{pCliente.RG}', " +
                $"'{pCliente.Telefone}', '{pCliente.Endereco}', '{pCliente.NumeroEndereco}', '{pCliente.Referencia}', '{pCliente.CEP}')");
        }

        internal void AlterarCliente(int pClienteId)
        {

        }

        internal Clientes ListarClientes()
        {
            DataTable data = _connection.ObterRegistros("");
            Clientes clientes = Converter(data);

            return clientes;
        }

        private Clientes Converter(DataTable pData)
        {
            
            Clientes clientes = new Clientes();

            if (pData != null && pData.Rows.Count > 0)
            {
                for (int i = 0; i < pData.Rows.Count; i++)
                {
                    Cliente cli = Converter(pData.Rows[i]);
                    clientes.Add(cli);
                }
            }
            return clientes;
        }

        private Cliente Converter(DataRow pRow)
        {
            Cliente cliente = new Cliente();

            if (pRow[CAMPO_ID_CLIENTE] != null)
                cliente.IdCliente = Convert.ToInt32(pRow[CAMPO_ID_CLIENTE]);
            if (pRow[CAMPO_NOME] != null)
                cliente.Nome = pRow[CAMPO_NOME].ToString();
            if (pRow[CAMPO_EMAIL] != null)
                cliente.Email = pRow[CAMPO_EMAIL].ToString();
            if (pRow[CAMPO_DATA_NASCIMENTO] != null)
                cliente.DataNascimento = Convert.ToDateTime(pRow[CAMPO_DATA_NASCIMENTO].ToString());
            if (pRow[CAMPO_CPF] != null)
                cliente.CPF = pRow[CAMPO_CPF].ToString();
            if (pRow[CAMPO_RG] != null)
                cliente.RG = pRow[CAMPO_RG].ToString();
            if (pRow[CAMPO_TELEFONE] != null)
                cliente.Telefone = pRow[CAMPO_TELEFONE].ToString();
            if (pRow[CAMPO_ENDERECO] != null)
                cliente.Endereco = pRow[CAMPO_ENDERECO].ToString();
            if (pRow[CAMPO_NUMERO_ENDERECO] != null)
                cliente.NumeroEndereco = pRow[CAMPO_NUMERO_ENDERECO].ToString();
            if (pRow[CAMPO_REFERENCIA] != null)
                cliente.Referencia = pRow[CAMPO_REFERENCIA].ToString();
            if (pRow[CAMPO_CEP] != null)
                cliente.CEP = pRow[CAMPO_CEP].ToString();

            return cliente;
        }
    }
}
