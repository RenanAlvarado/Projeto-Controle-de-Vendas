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
    public partial class Form_menu : Form
    {
        public Form_menu()
        {
            InitializeComponent();
        }

        private void trocarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form_menu_Load(object sender, EventArgs e)
        {
            //Pegando a data atual 
            statusData.Text = DateTime.Now.ToShortDateString();

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Programação dentro do Timer 
            statusHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void menuCadastroCliente_Click(object sender, EventArgs e)
        {
            //Abrir a tela 
            Form_clientes form_Clientes = new Form_clientes();  
            
            form_Clientes.Show();
        }

        private void menuConsultaCliente_Click(object sender, EventArgs e)
        {

            Form_clientes form_Clientes = new Form_clientes();
            form_Clientes.tabClientes.SelectedTab = form_Clientes.tabPage2;
            form_Clientes.Show();
        }

        private void menuCadastroFuncionario_Click(object sender, EventArgs e)
        {
           Form_funcionarios funcionarios = new Form_funcionarios();
           funcionarios.Show();
        }

        private void menuConsultaFuncionario_Click(object sender, EventArgs e)
        {
            Form_funcionarios funcionarios = new Form_funcionarios();
            funcionarios.tabFuncionarios.SelectedTab = funcionarios.tabPage2;
            funcionarios.Show();
        }

        private void menuCadastroFornecedor_Click(object sender, EventArgs e)
        {
            Form_fornecedores fornecedores = new Form_fornecedores();
            fornecedores.Show();
        }

        private void menuConsultaFornecedor_Click(object sender, EventArgs e)
        {
            Form_fornecedores fornecedores = new Form_fornecedores();
            fornecedores.tabFornecedores.SelectedTab = fornecedores.tabPage2;
            fornecedores.Show();
        }

        private void menuCadastroProduto_Click(object sender, EventArgs e)
        {
            Form_produtos produtos = new Form_produtos();
            produtos.Show();
        }

        private void menuConsultaProduto_Click(object sender, EventArgs e)
        {
            Form_produtos produtos = new Form_produtos();
            produtos.tabProdutos.SelectedTab = produtos.tabPage2;
            produtos.Show();
        }

        private void menuNovaVenda_Click(object sender, EventArgs e)
        {
            Form_vendas vendas = new Form_vendas();
            vendas.Show();  
        }

        private void menuHistoricoVenda_Click(object sender, EventArgs e)
        {
            Form_historico historico = new Form_historico();
            historico.Show();
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            //Fechar a aplicação 

            DialogResult result = MessageBox.Show("Tem certeza que deseja sair do sistema?"
                , "Saída", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
           

                
        }
    }
}
