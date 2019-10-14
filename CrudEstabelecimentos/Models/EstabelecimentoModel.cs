using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEstabelecimentos.Models
{
    public class EstabelecimentoModel
    {
        public int Id { get; set; }
        public string Razao_Social { get; set; }
        public string Nome_Fantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public DateTime Data_de_Cadastro { get; set; }
        public string Categoria { get; set; }
        public bool Status { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }

        public string DataString { get; set; }
        public string StatusString { get; set; }

    }
}