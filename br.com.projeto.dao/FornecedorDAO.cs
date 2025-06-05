using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.projeto.connection;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.dao
{
    public class FornecedorDAO
    {
        private MySqlConnection conexao;
        //Construtor
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().getconnection(); //Instancia e recebe a conexão pronta
        }

        #region CadastrarFornecedor 

        public void cadastrar_fornecedor(Fornecedor obj)
        {
            try
            {
                //1º Passo --> Comando Sql

                string sql = "insert into tb_fornecedores (nome, cnpj, email," +
                    "telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)" +
                    "values (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco," +
                    "@numero, @complemento, @bairro, @cidade, @estado)";

                //2º Passo -> Organizar e executar comando sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", obj.nome);
                executar_comando.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executar_comando.Parameters.AddWithValue("@email", obj.email);
                executar_comando.Parameters.AddWithValue("@telefone", obj.telefone);
                executar_comando.Parameters.AddWithValue("@celular", obj.celular);
                executar_comando.Parameters.AddWithValue("@cep", obj.cep);
                executar_comando.Parameters.AddWithValue("@endereco", obj.endereço);
                executar_comando.Parameters.AddWithValue("@numero", obj.numero);
                executar_comando.Parameters.AddWithValue("@complemento", obj.complemento);
                executar_comando.Parameters.AddWithValue("@bairro", obj.bairro);
                executar_comando.Parameters.AddWithValue("@cidade", obj.cidade);
                executar_comando.Parameters.AddWithValue("@estado", obj.estado);

                //3ºPasso --> Abrir conexão e executar comando sql
                conexao.Open(); //Abrir conexão
                executar_comando.ExecuteNonQuery(); //Execução

                MessageBox.Show("Fornecedor cadastrado com sucesso!");

                //Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }

        #endregion

        #region ListarFornecedores

        public DataTable listar_fornecedores()
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_fornecedores = new DataTable(); //Recebe os dados 

                string sql = "select * from tb_fornecedores";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_fornecedores); //Preenche os dados 

                conexao.Close();

                return tabela_fornecedores;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro " + erro);
                return null;
            }
        }

        #endregion

        #region EditarFornecedores 

        public void editar_fornecedores(Fornecedor obj)
        {
            try
            {
                //1ºPasso --> Comando Sql  
                string sql = "update tb_fornecedores set nome = @nome, cnpj = @cnpj, email = @email," +
                    "telefone = @telefone, celular = @celular, cep = @cep, endereco = @endereco, numero = @numero, complemento = @complemento, bairro = @bairro, " +
                    "cidade = @cidade, estado = @estado where id=@id";

                //2ºPasso --> Organizar e executar o comando sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", obj.nome);
                executar_comando.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executar_comando.Parameters.AddWithValue("@email", obj.email);
                executar_comando.Parameters.AddWithValue("@telefone", obj.telefone);
                executar_comando.Parameters.AddWithValue("@celular", obj.celular);
                executar_comando.Parameters.AddWithValue("@cep", obj.cep);
                executar_comando.Parameters.AddWithValue("@endereco", obj.endereço);
                executar_comando.Parameters.AddWithValue("@numero", obj.numero);
                executar_comando.Parameters.AddWithValue("@complemento", obj.complemento);
                executar_comando.Parameters.AddWithValue("@bairro", obj.bairro);
                executar_comando.Parameters.AddWithValue("@cidade", obj.cidade);
                executar_comando.Parameters.AddWithValue("@estado", obj.estado);

                executar_comando.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Fornecedor alterado com sucesso!");

                //Fechar conexão
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
            }

        }

        #endregion

        #region ExcluirFornecedores

        public void excluir_fornecedores(Fornecedor obj)
        {
            try
            {
                string sql = "delete from tb_fornecedores where id=@id";

                //2º Passo -> Organizar e executar comando sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluído com sucesso!");

                //Fechar conexão
                conexao.Close();



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro " + erro);
            }
        }

        #endregion

        #region ListarFornecedoresPorNome (Busca aproximada)

        public DataTable listar_fornecedores_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_fornecedores = new DataTable(); //Recebe os dados 

                string sql = "select * from tb_fornecedores where nome like @nome";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_fornecedores); //Preenche os dados 

                conexao.Close();

                return tabela_fornecedores;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro " + erro);
                return null;
            }
        }
        #endregion

        #region BuscarFornecedorPorNome (Busca exata)

        public DataTable buscar_fornecedores_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_fornecedores = new DataTable(); //Recebe os dados 

                string sql = "select * from tb_fornecedores where nome = @nome";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_fornecedores); //Preenche os dados 

                conexao.Close();

                return tabela_fornecedores;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro " + erro);
                return null;
            }
        }



        #endregion
    }

}
