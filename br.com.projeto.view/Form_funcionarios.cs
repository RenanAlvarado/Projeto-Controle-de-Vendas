using Projeto_Controle_de_Vendas.br.com.projeto.dao;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.view
{
    public partial class Form_funcionarios : Form
    {
        public Form_funcionarios()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1ºPasso - Armazenar os dados no  objeto model
            Funcionario obj = new Funcionario();

            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            //Novos
            obj.senha = Convert.ToString(txtSenha.Text);           
            obj.cargo = cbCargo.SelectedItem.ToString();  //Guardar o selecionado 
            obj.nivel_acesso = cbNivel.SelectedItem.ToString();
            //
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereço = txtEndereço.Text;
            obj.numero = int.Parse(txtNumero.Text); //Apenar converter pro tipo
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUF.Text;

            //2ºPasso - Criar objeto da classe ClienteDAO e chamar o método cadastrar cliente

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrar_funcionario(obj);

            //Atualizar a tabela após inserção
            dgvFuncionarios.DataSource = dao.listar_funcionarios();
        }

        private void dgvFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_funcionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            dgvFuncionarios.DataSource = dao.listar_funcionarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1º passo -- Armazenar os dados em  um objeto Model
            Funcionario obj = new Funcionario();

            //Padrão Windows
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            //Novos
            obj.senha = Convert.ToString(txtSenha.Text);
            obj.cargo = cbCargo.SelectedItem.ToString();  //Guardar o selecionado 
            obj.nivel_acesso = cbNivel.SelectedItem.ToString();
            //
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereço = txtEndereço.Text;
            obj.numero = int.Parse(txtNumero.Text); //Apenar converter pro tipo
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUF.Text;

            obj.codigo = int.Parse(txtCodigo.Text); //Alteração do cadastrar para editar

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.editar_funcionario(obj);

            //Atualizar a tabela após edição
            dgvFuncionarios.DataSource = dao.listar_funcionarios();



        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();

            obj.codigo = int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.excluir_funcionario(obj);

            //Atualizar a tabela após edição
            dgvFuncionarios.DataSource = dao.listar_funcionarios();
        }

        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Método para passar os dados da linha para a guia de dados pessoais 

            txtCodigo.Text = dgvFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = dgvFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = dgvFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = dgvFuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = dgvFuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbNivel.Text = dgvFuncionarios.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text = dgvFuncionarios.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text = dgvFuncionarios.CurrentRow.Cells[9].Value.ToString();
            txtCEP.Text = dgvFuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtEndereço.Text = dgvFuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = dgvFuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = dgvFuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = dgvFuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = dgvFuncionarios.CurrentRow.Cells[15].Value.ToString();
            cbUF.Text = dgvFuncionarios.CurrentRow.Cells[16].Value.ToString();

            //Muda a guia selecionada 
            tabFuncionarios.SelectedTab = tabPage1;


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Busca extremamente exata
            string nome = txtPesquisa.Text;

            FuncionarioDAO dao = new FuncionarioDAO();

            dgvFuncionarios.DataSource = dao.buscar_funcionarios_nome(nome);

            if (dgvFuncionarios.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionario não encontrado!");
                dgvFuncionarios.DataSource = dao.listar_funcionarios();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();

            dgvFuncionarios.DataSource = dao.listar_funcionarios_nome(nome); //Atualização da DGV com os resultados
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Forma Manual
            //txtNome.Clear(); ou  txtNome.Text = "";

            //Chama o comando 
            new Helpers().limpar_tela(this);
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            //Entrar no ViaCep
            //Botão consultar CEP
            try
            {
                string cep = txtCEP.Text;
                //Endereço da API
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                //Objeto que faz e recebe a requisição API
                DataSet dados = new DataSet();

                //Lê o retorno  
                dados.ReadXml(xml);

                //Pegar o retorno especifico pela Tag e colocar no texto
                txtEndereço.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbUF.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado, digite manualmente!");
            }

        }
    }
}
