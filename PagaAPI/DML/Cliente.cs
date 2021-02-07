using System;
using System.Collections.Generic;

namespace PagaAPI.DML
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string Referencia { get; set; }
        public string CEP { get; set; }
    }

    public class Clientes : List<Cliente>
    {

    }
}
