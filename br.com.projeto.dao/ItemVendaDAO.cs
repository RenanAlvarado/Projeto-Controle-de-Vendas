using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.projeto.connection;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
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
                executar_comando.Parameters.AddWithValue("@data_venda", obj.id_produto);
                executar_comando.Parameters.AddWithValue("@total_venda", obj.quantidade);
                executar_comando.Parameters.AddWithValue("@observacoes", obj.subtotal);


                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Item_Venda Cadastrado com sucesso");

                conexao.Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
            }

        }

        #endregion
    }
}
