using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.projeto.connection;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.dao
{
    public class ProdutoDAO
    {

        private MySqlConnection conexao;
        public ProdutoDAO()
        {
            this.conexao = new ConnectionFactory().getconnection(); //Instancia e recebe a conexão pronta
        }

        #region CadastrarProduto

        public void cadastrar_produto(Produto obj)
        {
            try
            {
                //1º --> Criar sql 

                string sql = "insert into tb_produtos (descricao, preco, qtd_estoque," +
                    "for_id) values (@descricao, @preco, @qtd, @for_id)";

                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@descricao", obj.descricao);
                executar_comando.Parameters.AddWithValue("@preco", obj.preco);
                executar_comando.Parameters.AddWithValue("@qtd", obj.qtd_estoque);
                executar_comando.Parameters.AddWithValue("@for_id", obj.for_id);

                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Produto Cadastrado com sucesso");

                conexao.Close();



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region ListarProdutos 

        public DataTable listar_produtos()
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_produtos = new DataTable(); //Quem recebe os dados

                string sql = "select tb_produtos.id as 'Código', tb_produtos.descricao" +
                    " as 'Descrição', tb_produtos.preco as 'Preço', tb_produtos.qtd_estoque" +
                    " as 'Qtd Estoque', tb_fornecedores.nome as 'Fornecedor' " +
                    " from tb_produtos join tb_fornecedores on (tb_produtos.for_id = " +
                    "tb_fornecedores.id)";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_produtos); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_produtos;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }

        }

        #endregion

        #region AlterarProduto

        public void alterar_produto (Produto obj)
        {
            try
            {
                //1º --> Criar sql 

                string sql = "update tb_produtos set descricao=@descricao, " +
                    "preco=@preco, qtd_estoque=@qtd, for_id=@for_id where id = @id";
                   

                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@descricao", obj.descricao);
                executar_comando.Parameters.AddWithValue("@preco", obj.preco);
                executar_comando.Parameters.AddWithValue("@qtd", obj.qtd_estoque);
                executar_comando.Parameters.AddWithValue("@for_id", obj.for_id);
                executar_comando.Parameters.AddWithValue("@id", obj.codigo);

                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Produto Alterado com sucesso");

                conexao.Close();



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }



        #endregion

        #region ExcluirProduto 

        public void excluir_produto(Produto obj)
        {
            try
            {
                //1º --> Criar sql 

                string sql = "delete from tb_produtos where id = @id";


                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@id", obj.codigo);

                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Produto Excluido com sucesso");

                conexao.Close();



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region BuscarProduto (exata)

        public DataTable buscar_produto_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_produtos = new DataTable(); //Quem recebe os dados

                string sql = "select tb_produtos.id as 'Código', tb_produtos.descricao" +
                    " as 'Descrição', tb_produtos.preco as 'Preço', tb_produtos.qtd_estoque" +
                    " as 'Qtd Estoque', tb_fornecedores.nome as 'Fornecedor' " +
                    " from tb_produtos join tb_fornecedores on (tb_produtos.for_id = " +
                    "tb_fornecedores.id) where tb_produtos.descricao = @nome"; 

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_produtos); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_produtos;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }
        }

        #endregion

        #region ListarProdutos (aproximada)

        public DataTable listar_produtos_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_produtos = new DataTable(); //Quem recebe os dados

                string sql = "select tb_produtos.id as 'Código', tb_produtos.descricao" +
                    " as 'Descrição', tb_produtos.preco as 'Preço', tb_produtos.qtd_estoque" +
                    " as 'Qtd Estoque', tb_fornecedores.nome as 'Fornecedor' " +
                    " from tb_produtos join tb_fornecedores on (tb_produtos.for_id = " +
                    "tb_fornecedores.id) where tb_produtos.descricao like @nome"; 

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_produtos); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_produtos;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }
        }
        #endregion

        #region RetornarProdutoId

        public Produto retornar_produto_id(int id)
        {
            try
            {
                Produto p = new Produto();
                //1ºPasso
                string sql = "select * from tb_produtos where id = @id";

                //2ºPasso - Organizar e executar comando 
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);
                executar_comando.Parameters.AddWithValue("id", id);

                conexao.Open();

                //3ºPasso - Criar o data reader 

                MySqlDataReader reader = executar_comando.ExecuteReader();

                if (reader.Read())
                {
                    

                    p.codigo = reader.GetInt32("id");
                    p.descricao = reader.GetString("descricao");
                    p.preco = reader.GetDecimal("preco");

                    
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!");
                    return null;
                }

                conexao.Close();
                return p;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro" + erro);
                return null;
            }
        }

        #endregion
    }
}
