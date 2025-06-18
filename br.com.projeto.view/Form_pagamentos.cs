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

        }
    }
}
