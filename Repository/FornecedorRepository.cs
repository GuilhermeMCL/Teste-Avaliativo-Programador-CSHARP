using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cadastroFornecedores.Data;
using CadastroFornecedores.Models;
using MySql.Data.MySqlClient;

namespace cadastroFornecedores.Repository
{
    public class FornecedorRepository
    {
        private readonly MySqlConnection _connection;

        public FornecedorRepository()
        {
            _connection = Database.GetInstance().GetConnection();
        }

        public void AdicionarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                Database.GetInstance().OpenConnection();
                string query = "INSERT INTO fornecedores (nome, cnpj, endereco, telefone, email. responsavel)" +
                                "VALUES (@nome, @cnpj, @endereco, @telefone, @email @responsavel)";

                using (var cmd = new MySqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@name", fornecedor.Nome);
                    cmd.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                    cmd.Parameters.AddWithValue("@email", fornecedor.Email);
                    cmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                    cmd.Parameters.AddWithValue("@teledone", fornecedor.Telefone);
                    cmd.Parameters.AddWithValue("@responsavel", fornecedor.Reponsavel);

                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao adicionar fornecedor : " + ex.Message);
            }
            finally
            {
                Database.GetInstance().CloseConnection();
            }
        }

        public List<Fornecedor> ListarFornecedores()
        {
            var fornecedores = new List<Fornecedor>();

            try
            {
                Database.GetInstance().OpenConnection();

                string query = "SELECT * FROM fornecedores";
                using (var cmd = new MySqlCommand(query, _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fornecedores.Add(new Fornecedor
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            CNPJ = reader.GetString("cnpj"),
                            Endereco = reader.GetString("endereco"),
                            Telefone = reader.GetString("telefone"),
                            Email = reader.GetString("email"),
                            Reponsavel = reader.GetString("responsavel"),


                        });


                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Fornecedores: " + ex.Message);
            }
            finally
            {
                Database.GetInstance().CloseConnection();
            }

            return fornecedores;

        }
            


















    }
}
