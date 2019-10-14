using CrudEstabelecimentos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudEstabelecimentos.Repository
{
    public class EstabelecimentosRepositorio
    {
        public List<EstabelecimentoModel> GetEstabelecimento()
        {
            var connectionDb = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
            SqlConnection Connect = new SqlConnection(connectionDb);

            var resultado = Connect.Query<EstabelecimentoModel>("select * from [ESTABELECIMENTOS]").ToList();
            
            return resultado;

        }


        public bool CreateEstabelecimentos(EstabelecimentoModel estabelecimento)
        {
            try
            {
                var connectionDb = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
                SqlConnection Connect = new SqlConnection(connectionDb);

                estabelecimento.Data_de_Cadastro = DateTime.Now;

                var resultado = Connect.Execute("insert into [ESTABELECIMENTOS] values (@Razao_Social, @Nome_Fantasia, @CNPJ, @Email, @Endereco, @Cidade, @Estado, @Telefone, @Data_de_Cadastro, @Categoria, @Status, @Agencia, @Conta)", estabelecimento);

                return true;
            }
            catch (Exception varNecessary)
            {
                return false;
            }

        }

        public EstabelecimentoModel LfEstabelecimentos(int id)
        {
            var connectionDb = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
            SqlConnection Connect = new SqlConnection(connectionDb);

            var LfID = Connect.Query<EstabelecimentoModel>("select * from [ESTABELECIMENTOS] where id = @Id", new { Id = id }).First();

            return LfID;
        }

        public bool UpdateEstabelecimentos(EstabelecimentoModel estabelecimento)
        {
            try
            {
                var connectionDb = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
                SqlConnection Connect = new SqlConnection(connectionDb);

                var UpdateClientes = Connect.Execute("update [ESTABELECIMENTOS] set Razao_Social = @Razao_Social, Nome_Fantasia = @Nome_Fantasia, CNPJ = @CNPJ, Email = @Email, Endereco = @Endereco, Cidade = @Cidade, Estado = @Estado, Telefone = @Telefone, Categoria = @Categoria, Status = @Status, Agencia = @Agencia, Conta = @Conta where id = @Id", estabelecimento);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEstabelecimentos(int id)
        {
            try
            {
                var connectionDb = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
                SqlConnection Connect = new SqlConnection(connectionDb);

                var DeleteCliente = Connect.Execute("delete from [ESTABELECIMENTOS] where id = @Id", new { Id = id });

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}