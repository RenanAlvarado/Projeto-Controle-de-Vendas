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
    //Criação do CRUD e adicionais 

    public class ClienteDAO
    {

        private MySqlConnection conexao;
        //Construtor
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection(); //Instancia e recebe a conexão pronta
        }

        //Region pode ocular códigos e criar espaços 
        #region CadastrarCliente

        //Método Cadastrar Cliente
        //Parametro é um obj do tipo Cliente (lampada para colocar o using)
        public void cadastrar_cliente(Cliente obj)
        {
            try
            {
                //1ºPasso - Definição comando Sql (INSERT INTO)
                //@ é a definição da variável
                string sql = "insert into tb_clientes (nome,rg,cpf,email,telefone," +
                    "celular,cep,endereco,numero,complemento,bairro,cidade,estado)" +
                    "values(@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco," +
                    "@numero, @complemento, @bairro, @cidade, @estado)";

                //2ºPasso - Organizar o comando Sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", obj.nome);
                executar_comando.Parameters.AddWithValue("@rg", obj.rg);
                executar_comando.Parameters.AddWithValue("@cpf", obj.cpf);
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

                //3ºPasso - Abrir a conexão e Executar comando SQL

                conexao.Open(); //Abrir conexão
                executar_comando.ExecuteNonQuery(); //Execução

                MessageBox.Show("Cliente cadastrado com sucesso!");

                //Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }
        #endregion

        #region ListarCliente

        //Retorna a lista já filtrada de dados 
        public DataTable listar_clientes()
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_cliente = new DataTable(); //Quem recebe os dados

                string sql = "select * from tb_clientes";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_cliente); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_cliente;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }

        }
        #endregion

        #region EditarCliente

        public void editar_cliente(Cliente obj)
        {
            try
            {
                //1ºPasso - Definição comando Sql (INSERT INTO)
                //@ é a definição da variável
                string sql = "update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email," +
                    "telefone=@telefone," +
                    "celular=@celular,cep=@cep,endereco=@endereco,numero=@numero," +
                    "complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado " +
                    "where id=@id";

                //2ºPasso - Organizar o comando Sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", obj.nome);
                executar_comando.Parameters.AddWithValue("@rg", obj.rg);
                executar_comando.Parameters.AddWithValue("@cpf", obj.cpf);
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

                //3ºPasso - Abri a conexão e Executar comando SQL

                conexao.Open(); //Abrir conexão
                executar_comando.ExecuteNonQuery(); //Execução

                MessageBox.Show("Cliente alterado com sucesso!");

                //Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
            }

        }
        #endregion

        #region ExcluirCliente 

        public void excluir_cliente(Cliente obj)
        {
            try
            {
                //1ºPasso - Definição comando Sql (INSERT INTO)
                //@ é a definição da variável
                string sql = "delete from tb_clientes where id=@id";

                //2ºPasso - Organizar o comando Sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@id", obj.codigo);

                //3ºPasso - Abri a conexão e Executar comando SQL

                conexao.Open(); //Abrir conexão
                executar_comando.ExecuteNonQuery(); //Execução

                MessageBox.Show("Cliente excluido com sucesso!");

                //Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
            }

        }



        #endregion

        #region buscarClientePorNome
 
        public DataTable buscar_clientes_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_cliente = new DataTable(); //Quem recebe os dados

                string sql = "select * from tb_clientes where nome=@nome"; //Alteração do Sql do método listar

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome); //Adicionar a variavel nome

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_cliente); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_cliente;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }

        }


        #endregion

        #region ListarClientePorNome

        public DataTable listar_clientes_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_cliente = new DataTable(); //Quem recebe os dados

                //Like é a pesquisa aproximada 
                string sql = "select * from tb_clientes where nome like @nome"; //Alteração do Sql do método listar

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome); //Adicionar a variavel nome

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_cliente); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_cliente;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }

        }


        #endregion

        #region BuscarClientePorCPF

        public Cliente buscar_cliente_cpf(string cpf)
        {
            try
            {
                //1ºPasso - Comando SQL
                Cliente obj = new Cliente(); //Instancia o objeto Cliente

                string sql = "select * from tb_clientes where cpf=@cpf"; //Alteração do Sql do método 

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@cpf", cpf); //Adicionar a variavel nome

                conexao.Open();

                //Para retornar apenas um registro
                MySqlDataReader registro = executar_comando.ExecuteReader(); //Retorna os dados filtrados

                //Se encontrar algo
                if (registro.Read())
                {
                    obj.codigo = registro.GetInt32("id");
                    obj.nome = registro.GetString("nome");
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado");
                    conexao.Close();
                    return null;
                   
                }

                conexao.Close();
                    return obj;

            }
            catch (Exception erro)
            {

               MessageBox.Show("Aconteceu erro: " + erro);
               return null;
            }
        }

        #endregion
    }
}
