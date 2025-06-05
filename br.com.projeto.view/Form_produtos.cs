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
    public partial class Form_produtos : Form
    {
        public Form_produtos()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form_produtos_Load(object sender, EventArgs e)
        {
            FornecedorDAO f_dao = new FornecedorDAO();

            cbFornecedor.DataSource = f_dao.listar_fornecedores();

            //Coluna que aparece para o usuário
            cbFornecedor.DisplayMember = "nome";
            //Valor que vai ser armazenado 
            cbFornecedor.ValueMember = "id";

            ProdutoDAO dao = new ProdutoDAO();

            dgvProdutos.DataSource = dao.listar_produtos();


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto obj = new Produto();

            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.qtd_estoque = int.Parse(txtQuantidade.Text);
            //Necessário usar Selected Value para converter 
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());
           

            //Criar objeto dao 

            ProdutoDAO dao = new ProdutoDAO();

            dao.cadastrar_produto(obj);

            new Helpers().limpar_tela(this);

            //Recarregar DGV

            dgvProdutos.DataSource= dao.listar_produtos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            new Helpers().limpar_tela(this);

        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os dados de um produto selecionado 

            txtCodigo.Text = dgvProdutos.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = dgvProdutos.CurrentRow.Cells[4].Value.ToString();

            tabProdutos.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Produto obj = new Produto();

            obj.codigo = int.Parse(txtCodigo.Text);
            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.qtd_estoque = int.Parse(txtQuantidade.Text);
            //Necessário usar Selected Value para converter 
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());

            ProdutoDAO dao = new ProdutoDAO();

            dao.alterar_produto(obj);

            new Helpers().limpar_tela(this);

            //Recarregar DGV 

            dgvProdutos.DataSource = dao.listar_produtos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Produto obj = new Produto();

            obj.codigo = int.Parse(txtCodigo.Text);
            

            ProdutoDAO dao = new ProdutoDAO();

            dao.excluir_produto(obj);

            new Helpers().limpar_tela(this);

            //Recarregar DGV 

            dgvProdutos.DataSource = dao.listar_produtos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Busca extremamente exata
            string nome = txtPesquisa.Text;

            ProdutoDAO dao = new ProdutoDAO();

            dgvProdutos.DataSource = dao.buscar_produto_nome(nome);

            if (dgvProdutos.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionario não encontrado!");
                dgvProdutos.DataSource = dao.listar_produtos();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text + "%";

            ProdutoDAO dao = new ProdutoDAO();

            dgvProdutos.DataSource = dao.listar_produtos_nome(nome); //Atualização da DGV com os resultados
        }
    }
}
