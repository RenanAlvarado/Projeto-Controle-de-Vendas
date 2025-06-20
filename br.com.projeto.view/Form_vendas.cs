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
    public partial class Form_vendas : Form
    {
        ClienteDAO dao = new ClienteDAO();
        Cliente cliente = new Cliente();

        ProdutoDAO dao_produto = new ProdutoDAO();
        Produto produto = new Produto();

        //Parte do carrinho 
        int qtd;
        decimal preco;
        decimal subtotal, total;

        //Carrinho 
        DataTable carrinho = new DataTable();

        public Form_vendas()
        {
            InitializeComponent();

            //Criação das colunas do carrinho
            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("SubTotal", typeof(decimal));

            dgvCarrinho.DataSource = carrinho;
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas quando aperta a tecla enter 
            if (e.KeyChar == 13)
            {
                cliente = dao.buscar_cliente_cpf(txtCPF.Text);

                
                //verificação para não fechar o programa 
                if (cliente != null)
                {
                    txtNome.Text = cliente.nome;
                }
                else
                {
                    txtCPF.Clear();
                    txtCPF.Focus();
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas quando aperta a tecla enter 
            if (e.KeyChar == 13)
            {
               produto = dao_produto.retornar_produto_id(int.Parse(txtCodigo.Text));

                if (produto != null)
                {
                    txtDescricao.Text = produto.descricao;
                    txtPreco.Text = produto.preco.ToString();
                }
                else
                {
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
               
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            try
            {
                //Botão de adicionar item 
                qtd = int.Parse(txtQuantidade.Text);
                preco = decimal.Parse(txtPreco.Text);

                subtotal = qtd * preco;

                total = total + subtotal;

                //Adicionar produto no carrinho
                carrinho.Rows.Add(int.Parse(txtCodigo.Text),
                    txtDescricao.Text, qtd, preco, subtotal);

                txtTotal.Text = total.ToString();

                //Limpar campos 
                txtCodigo.Clear();
                txtDescricao.Clear();
                txtQuantidade.Clear();
                txtPreco.Clear();

                txtCodigo.Focus(); //Deixa azul no DataTable 
            }
            catch (Exception)
            {

                MessageBox.Show("Adicione o código do produto");
            }
            
            
        }

        private void dgvCarrinho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Botao remover item 

            //Armazenar o subtotal que será removido 
            decimal subproduto = decimal.Parse(dgvCarrinho.CurrentRow.Cells[4].Value.ToString());

            //Saber qual linha será removida 
            int indice = dgvCarrinho.CurrentRow.Index;

            DataRow linha = carrinho.Rows[indice];

            //Remoção
            carrinho.Rows.Remove(linha);

            carrinho.AcceptChanges();

            total = total - subproduto;

            txtTotal.Text = total.ToString();

            MessageBox.Show("Item Removido com sucesso!");
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //Botão Pagamento 
            //DateTime.Parse(txtData.Text)
            DateTime data_atual = DateTime.Now;

            //Método pelo construtor 
            Form_pagamentos tela = new Form_pagamentos(cliente, carrinho, data_atual);

            //Passando o total para a tela de pagamentos 

            //Modifiers como público permite isso
            tela.txtTotal.Text = total.ToString();
            tela.ShowDialog(); //Abrir a tela encima da outra, sem permitir mexer na anteriorn 
            //tela.show abre outra tela, mas pode alterar a anterior 
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form_vendas_Load(object sender, EventArgs e)
        {
            //Pegando a data atual 
            txtData.Text = DateTime.Now.ToShortDateString();
        }
    }
}
