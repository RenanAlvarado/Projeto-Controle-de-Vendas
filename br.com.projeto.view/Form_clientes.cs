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
    public partial class Form_clientes: Form
    {
        public Form_clientes()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1º passo -- Armazenar os dados em  um objeto Model
            Cliente obj = new Cliente(); //Instanciar 

            //O set passa pelo nome a partir de um método 

            obj.setName(txtNome.Text); //Armazenando dentro do atributo nome do obj

            //Padrão Windows
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
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

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrar_cliente(obj);

            //Atualizar a tabela após inserção
            dgvCliente.DataSource = dao.listar_clientes();

        }

        //Load é o que é executado quando carrega o formulário
        private void Form_clientes_Load(object sender, EventArgs e)
        {
            //dgvCliente.DefaultCellStyle.ForeColor = Color.Black; --> Comando para edição de cor por código
            ClienteDAO dao = new ClienteDAO();

            //Mostrar os dados, falando qual a fonte 
            dgvCliente.DataSource = dao.listar_clientes();

        }

        //CellClick --> Quando o usuário seleciona o conteudo
        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada 

            //Coluna 0 é a coluna do ID (Começa pelo 0)
            txtCodigo.Text = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = dgvCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = dgvCliente.CurrentRow.Cells[6].Value.ToString();
            txtCEP.Text = dgvCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereço.Text = dgvCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = dgvCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = dgvCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = dgvCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = dgvCliente.CurrentRow.Cells[12].Value.ToString();
            cbUF.Text = dgvCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a guia Dados Pessoais 
            tabClientes.SelectedTab = tabPage1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botão Excluir 

            //1º passo -- Armazenar os dados em  um objeto Model
            Cliente obj = new Cliente(); //Instanciar 

            //Pegar o código 
            obj.codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();

            dao.excluir_cliente(obj);

            //Atualizar a tabela após exclusão
            dgvCliente.DataSource = dao.listar_clientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1º passo -- Armazenar os dados em  um objeto Model
            Cliente obj = new Cliente(); //Instanciar 

            //O set passa pelo nome a partir de um método 

            obj.setName(txtNome.Text); //Armazenando dentro do atributo nome do obj

            //Padrão Windows
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
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

            //2ºPasso - Criar objeto da classe ClienteDAO e chamar o método cadastrar cliente

            ClienteDAO dao = new ClienteDAO();
            dao.editar_cliente(obj);

            //Atualizar a tabela após edição
            dgvCliente.DataSource = dao.listar_clientes();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Botão Pesquisar 

            string nome = txtPesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            dgvCliente.DataSource = dao.buscar_clientes_nome(nome); //Atualização da DGV com os resultados

            //Se a contagem de linhas for 0, recarregue o DGV
            if (dgvCliente.Rows.Count == 0)
            {
                dgvCliente.DataSource = dao.listar_clientes();
            }
        }

        //Pesquisar enquanto digita
        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
           

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

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            dgvCliente.DataSource = dao.listar_clientes_nome(nome); //Atualização da DGV com os resultados
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
