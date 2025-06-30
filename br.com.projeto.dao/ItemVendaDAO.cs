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
    public class ItemVendaDAO
    {
        private MySqlConnection conexao;

        public ItemVendaDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }


        #region CadastrarItemVenda

        public void cadastrar_itemvenda(Item_venda obj)
        {
            try
            {
                //1º --> Criar sql 

                string sql = "insert into tb_itensvendas (venda_id, produto_id, qtd," +
                    "subtotal) values (@venda_id, @produto_id, @qtd, @subtotal)";


                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@venda_id", obj.id_venda);
                executar_comando.Parameters.AddWithValue("@produto_id", obj.id_produto);
                executar_comando.Parameters.AddWithValue("@qtd", obj.quantidade);
                executar_comando.Parameters.AddWithValue("@subtotal", obj.subtotal);


                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                //MessageBox.Show("Item_Venda Cadastrado com sucesso");

                conexao.Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
            }

        }

        #endregion


        #region ListarItensDaVenda

        public DataTable listar_itens_por_venda(int id_venda)
        {
            try
            {
                //1ºPasso - Comando SQl e criar o datatable 

                DataTable itens = new DataTable();

                string sql = "select i.id as 'Codigo', p.descricao as 'Descrição'," +
                    "i.qtd as 'Quantidade', p.preco as 'Preço', i.subtotal as 'SubTotal'" +
                    "from tb_itensvendas as i join tb_produtos as p on (i.produto_id = p.id)" +
                    "where venda_id = @venda_id";

                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@venda_id", id_venda);
                

                //3º --> Abrir a conexao e executar e mysqlDataAdapter

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando);
                da.Fill(itens);

                conexao.Close();

                return itens;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro!!" + erro);
                return null;
            }
        }

        #endregion
    }
}
