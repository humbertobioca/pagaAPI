using System;
using PagaAPI.Conexoes;
using PagaAPI.DAL;
using PagaAPI.DML;

namespace PagaAPI.BLL
{
    public class BoCliente
    {
        private DispatcherCliente dsptCliente;

        public BoCliente()
        {
            dsptCliente = new DispatcherCliente(new ConMySql());
        }

        public void CadastrarCliente(Cliente pCLiente)
        {
            try
            {
                dsptCliente.CadastrarCliente(pCLiente);
            }
            catch (Exception)
            {

            }
        }

    }
}
