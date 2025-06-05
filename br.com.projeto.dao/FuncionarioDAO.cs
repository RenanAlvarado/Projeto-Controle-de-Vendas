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
    public class FuncionarioDAO
    {
        //Conexao
        private MySqlConnection conexao;

        //Construtor 
        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().getconnection(); //Instancia e recebe a conexão pronta
        }

        #region CadastrarFuncionario

        public void cadastrar_funcionario(Funcionario obj)
        {
            try
            {
                //1º Passo --> Comando Sql

                string sql = "insert into tb_funcionarios (nome, rg, cpf, email, senha, cargo, nivel_acesso," +
                    "telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)" +
                    "values (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel, @telefone, @celular, @cep, @endereco," +
                    "@numero, @complemento, @bairro, @cidade, @estado)";

                //2º Passo -> Organizar e executar comando sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", obj.nome);
                executar_comando.Parameters.AddWithValue("@rg", obj.rg);
                executar_comando.Parameters.AddWithValue("@cpf", obj.cpf);
                executar_comando.Parameters.AddWithValue("@email", obj.email);
                executar_comando.Parameters.AddWithValue("@senha", obj.senha);
                executar_comando.Parameters.AddWithValue("@cargo", obj.cargo);
                executar_comando.Parameters.AddWithValue("@nivel", obj.nivel_acesso);
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

                MessageBox.Show("Funcionário cadastrado com sucesso!");

                //Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }

        #endregion

        #region ListarFuncionarios 

        public DataTable listar_funcionarios()
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_funcionario = new DataTable(); //Quem recebe os dados

                string sql = "select * from tb_funcionarios";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_funcionario); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_funcionario;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }

        }

        #endregion

        #region AlterarFuncionário

        public void editar_funcionario(Funcionario obj)
        {
            try
            {
                //1ºPasso - Definição comando Sql (INSERT INTO)
                //@ é a definição da variável
                string sql = "update tb_funcionarios set nome=@nome,rg=@rg,cpf=@cpf,email=@email," +
                    "senha=@senha, cargo=@cargo, nivel_acesso=@nivel, telefone=@telefone," +
                    "celular=@celular,cep=@cep,endereco=@endereco,numero=@numero," +
                    "complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado " +
                    "where id=@id";

                //2ºPasso - Organizar o comando Sql
                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", obj.nome);
                executar_comando.Parameters.AddWithValue("@rg", obj.rg);
                executar_comando.Parameters.AddWithValue("@cpf", obj.cpf);
                executar_comando.Parameters.AddWithValue("@email", obj.email);
                executar_comando.Parameters.AddWithValue("@senha", obj.senha);
                executar_comando.Parameters.AddWithValue("@cargo", obj.cargo);
                executar_comando.Parameters.AddWithValue("@nivel", obj.nivel_acesso);
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

                MessageBox.Show("Funcionário alterado com sucesso!");

                //Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region ExcluirFuncionário 

        public void excluir_funcionario(Funcionario obj)
        {
            try
            {
                //1ºPasso - Definição comando Sql (INSERT INTO)
                //@ é a definição da variável
                string sql = "delete from tb_funcionarios where id=@id";

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

        #region BuscarFuncionarioPorNome (exata pelo botão pesquisar)

        public DataTable buscar_funcionarios_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_funcionario = new DataTable(); //Quem recebe os dados

                string sql = "select * from tb_funcionarios where nome = @nome";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_funcionario); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_funcionario;



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu erro: " + erro);
                return null;
            }

        }

        #endregion

        #region ListarFuncionarioPorNome (aproximada pela txtBox)

        //Uso do comando sql LIKE
        public DataTable listar_funcionarios_nome(string nome)
        {
            try
            {
                //1ºPasso - Criação do DataTable e comando sql

                DataTable tabela_funcionario = new DataTable(); //Quem recebe os dados

                string sql = "select * from tb_funcionarios where nome like @nome";

                //2ºPasso - Organizar comando SQL e executar 

                MySqlCommand executar_comando = new MySqlCommand(sql, conexao);

                executar_comando.Parameters.AddWithValue("@nome", nome);

                conexao.Open();

                executar_comando.ExecuteNonQuery();

                //3ºPasso  -- Criar MySqlDataAdapter para preencher DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executar_comando); //Passa o resultado

                da.Fill(tabela_funcionario); //Preenche com os dados 

                //Fechar conexão
                conexao.Close();


                return tabela_funcionario;



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
