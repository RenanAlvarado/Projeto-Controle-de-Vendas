using MySql.Data.MySqlClient;
using Mysqlx;
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
    public class VendaDAO
    {
        private MySqlConnection conexao;

        public VendaDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarVenda

        public void cadastrar_venda(Venda obj)
        {
            try
            {
                //1º --> Criar sql 

                string sql = "insert into tb_vendas (cliente_id, data_venda, total_venda," +
                    "observacoes) values (@cliente_id, @data_venda, @total_venda, @obs)";
                    

                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@cliente_id", obj.cliente_id);
                executar_comando.Parameters.AddWithValue("@data_venda", obj.data_venda);
                executar_comando.Parameters.AddWithValue("@total_venda", obj.total_venda);
                executar_comando.Parameters.AddWithValue("@observacoes", obj.obs);


                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MessageBox.Show("Venda Cadastrada com sucesso");

                conexao.Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
            }

        }



        #endregion

        #region RetornarID_UltimaVenda

        public int retornar_id_ultima_venda()
        {
            try
            {
                int id_venda = 0;

                //1º --> Criar sql 

                //Função Max retorna o maior valor da coluna selecionada 
                string sql = "select max(id) id from tb_vendas";

                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                //3º --> Abrir a conexao e executar 

                conexao.Open();

                MySqlDataReader reader = executar_comando.ExecuteReader();

                if (reader.Read())
                {
                    id_venda = reader.GetInt32("id");

                   
                }

                conexao.Close();
                return id_venda;





            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                conexao.Close( );
                return 0;
            }
        }

        #endregion
    }
}
