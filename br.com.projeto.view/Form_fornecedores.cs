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
    public partial class Form_fornecedores : Form
    {
        public Form_fornecedores()
        {
            InitializeComponent();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Forma Manual
            //txtNome.Clear(); ou  txtNome.Text = "";

            //Chama o comando 
            new Helpers().limpar_tela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();

            obj.nome = txtNome.Text;
            obj.cnpj = txtCNPJ.Text;
            obj.email = txtEmail.Text;
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

            FornecedorDAO dao = new FornecedorDAO();
            dao.cadastrar_fornecedor(obj);

            //Atualizar a tabela após inserção
            dgvFornecedores.DataSource = dao.listar_fornecedores();
        }

        private void Form_fornecedores_Load(object sender, EventArgs e)
        {
            FornecedorDAO dao = new FornecedorDAO();

            dgvFornecedores.DataSource = dao.listar_fornecedores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //1º passo -- Armazenar os dados em  um objeto Model
            Fornecedor obj = new Fornecedor();

            //Padrão Windows
            obj.nome = txtNome.Text;
            obj.cnpj = txtCNPJ.Text;
            obj.email = txtEmail.Text;
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

            FornecedorDAO dao = new FornecedorDAO();

            dao.editar_fornecedores(obj);

            //Atualizar a tabela após edição
            dgvFornecedores.DataSource = dao.listar_fornecedores();

            //Chama o comando 
            new Helpers().limpar_tela(this);


        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Método para passar os dados da linha para a guia de dados pessoais 

            txtCodigo.Text = dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCNPJ.Text = dgvFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dgvFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = dgvFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = dgvFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtCEP.Text = dgvFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEndereço.Text = dgvFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = dgvFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = dgvFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = dgvFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = dgvFornecedores.CurrentRow.Cells[11].Value.ToString();
            cbUF.Text = dgvFornecedores.CurrentRow.Cells[12].Value.ToString();

            //Muda a guia selecionada 
            tabFornecedores.SelectedTab = tabPage1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();

            obj.codigo = int.Parse(txtCodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();

            dao.excluir_fornecedores(obj);

            //Atualizar a tabela após edição
            dgvFornecedores.DataSource = dao.listar_fornecedores();

            //Chama o comando 
            new Helpers().limpar_tela(this);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            FornecedorDAO dao =  new FornecedorDAO();

            dgvFornecedores.DataSource = dao.buscar_fornecedores_nome(nome);

            if (dgvFornecedores.Rows.Count == 0 )
            {
                MessageBox.Show("Fornecedor Não encontrado");
                dgvFornecedores.DataSource = dao.listar_fornecedores();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text + "%";

           FornecedorDAO dao = new FornecedorDAO();

            dgvFornecedores.DataSource = dao.listar_fornecedores_nome(nome); //Atualização da DGV com os resultados
        }
    }
}
