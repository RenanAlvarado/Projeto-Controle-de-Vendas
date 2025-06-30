using MySql.Data.MySqlClient;
using Mysqlx;
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
                executar_comando.Parameters.AddWithValue("@obs", obj.obs);


                //3º --> Abrir a conexao e executar 

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                //MessageBox.Show("Venda Cadastrada com sucesso");

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
                string sql = @"select max(id) id from tb_vendas";

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

        #region ListarVendasPeriodo

        public DataTable listar_vendas_periodo(DateTime inicio, DateTime fim)
        {
            try
            {
                //1ºPasso - Comando SQl e criar o datatable 

                DataTable historico = new DataTable();

                string sql = "select v.id as 'Codigo', v.data_venda as 'Data da venda'," +
                    "c.nome as 'Cliente', v.total_venda as 'Total', v.observacoes as 'Obs'" +
                    "from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)" +
                    "where v.data_venda between @data_inicio and @data_fim";

                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@data_inicio", inicio);
                executar_comando.Parameters.AddWithValue("@data_fim", fim);

                //3º --> Abrir a conexao e executar e mysqlDataAdapter

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando);
                da.Fill(historico);

                conexao.Close();

                return historico;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro!!" + erro);
                return null;
            }
        }

        #endregion

        #region ListarTodasVendas

        public DataTable listar_vendas()
        {
            try
            {
                //1ºPasso - Comando SQl e criar o datatable 

                DataTable historico = new DataTable();

                string sql = "select v.id as 'Codigo', v.data_venda as 'Data da venda'," +
                    " c.nome as 'Cliente', v.total_venda as 'Total', " +
                    "v.observacoes as 'Obs' from tb_vendas as v join tb_clientes as c " +
                    "on (v.cliente_id = c.id)";


                //2º --> Organizar e executar o comando 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                //3º --> Abrir a conexao e executar e mysqlDataAdapter

                conexao.Open();
                executar_comando.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando);
                da.Fill(historico);

                conexao.Close();

                return historico;

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
