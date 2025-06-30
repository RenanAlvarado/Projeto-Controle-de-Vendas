using Projeto_Controle_de_Vendas.br.com.projeto.dao;
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
    public partial class Form_detalhes : Form
    {
        int venda_id;
        public Form_detalhes(int id_venda)
        {
            venda_id = id_venda;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form_detalhes_Load(object sender, EventArgs e)
        {
            //Carregamento de formulário 
            ItemVendaDAO itemVendaDAO = new ItemVendaDAO();
            dgvDetalhes.DataSource = itemVendaDAO.listar_itens_por_venda(venda_id);
        }
    }
}
