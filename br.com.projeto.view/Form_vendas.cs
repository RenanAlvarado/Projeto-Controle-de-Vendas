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

        public Form_vendas()
        {
            InitializeComponent();
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas quando aperta a tecla enter 
            if (e.KeyChar == 13)
            {
                cliente = dao.buscar_cliente_cpf(txtCPF.Text);

                txtNome.Text = cliente.nome;
            }
        }
    }
}
