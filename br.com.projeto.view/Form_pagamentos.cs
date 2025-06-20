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
    public partial class Form_pagamentos : Form
    {
        //Método construtor para passar dados entre telas 
        Cliente cliente = new Cliente();

        DataTable carrinho = new DataTable();

        DateTime data_atual;
        public Form_pagamentos(Cliente cliente, DataTable carrinho, DateTime data_atual)
        {
            this.data_atual = data_atual;
            this.cliente = cliente;
            this.carrinho = carrinho;
            InitializeComponent();


        }

        private void Form_pagamentos_Load(object sender, EventArgs e)
        {
            //Carregamento da tela 

            txtTroco.Text = "0,00";
            txtDinheiro.Text = "0,00";
            txtCartao.Text = "0,00";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão finalizar venda 

                decimal v_dinheiro, v_cartao, troco, total_pago, total;

                v_dinheiro = decimal.Parse(txtDinheiro.Text);
                v_cartao = decimal.Parse(txtCartao.Text);
                total = decimal.Parse(txtTotal.Text);

                //Calcular o total pago

                total_pago = v_dinheiro + v_cartao;

                if (total_pago < total)
                {
                    MessageBox.Show("Total pago menor que valor da Venda!!!!");
                }
                else
                {
                    //Calcular o troco 

                    troco = total_pago - total;

                    Venda venda = new Venda();

                    //Pegando ID do cliente
                    venda.cliente_id = cliente.codigo;

                    venda.data_venda = data_atual;

                    venda.total_venda = total;

                    venda.obs = txtObs.Text;

                    VendaDAO vendaDAO = new VendaDAO();

                    txtTroco.Text = troco.ToString();

                    vendaDAO.cadastrar_venda(venda);


                    //Cadastrar os itens da venda
                    //Percorrer itens do carrinho 

                    foreach (DataRow linha in carrinho.Rows)
                    {
                        Item_venda item_venda = new Item_venda();

                        item_venda.id_venda = vendaDAO.retornar_id_ultima_venda();

                        item_venda.id_produto = int.Parse(linha["Código"].ToString());
                        item_venda.quantidade = int.Parse(linha["Qtd"].ToString());
                        item_venda.subtotal = decimal.Parse(linha["SubTotal"].ToString());

                        ItemVendaDAO itemVendaDAO = new ItemVendaDAO();

                        itemVendaDAO.cadastrar_itemvenda(item_venda);

                    }

                    MessageBox.Show("Venda Finalizada com sucesso"); 
                    
                    //this.Close(); Fechar a tela
                    this.Dispose(); //Fecha o formulário

                    new Form_vendas().ShowDialog(); //Abrir nova tela de vendas 

                }
            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}
