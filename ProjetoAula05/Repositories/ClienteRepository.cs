using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjetoAula05.Entities;

namespace ProjetoAula05.Repositories
{
    /// <summary>
    /// Repositório de banco de dados para Cliente
    /// </summary>
    public class ClienteRepository
    {
        #region Atributos
        
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAula05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #endregion

        public void Inserir(Cliente cliente)
        {
            var query = @"
                INSERT INTO CLIENTE(ID, NOME, CPF, DATANASCIMENTO)
                VALUES(@Id, @Nome, @Cpf, @DataNascimento)
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, cliente);
            }
        }

        public void Alterar(Cliente cliente) 
        {
            var query = @"
                UPDATE CLIENTE
                SET NOME = @Nome,
                    CPF = @Cpf,
                    DATANASCIMENTO = @DataNascimento
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, cliente);
            }        
        }

        public void Excluir(Cliente cliente) 
        {
            var query = @"
                DELETE FROM CLIENTE
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, cliente);
            }        
        }

        /// <summary>
        /// Método para retornar todos os clientes cadastrados no banco de dados
        /// </summary>
        public List<Cliente> Consultar() 
        {
            var query = "SELECT * FROM CLIENTE";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(query).ToList();
            }  
        }
    }
}
