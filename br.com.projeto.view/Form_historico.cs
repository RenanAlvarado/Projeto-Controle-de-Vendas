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
    public partial class Form_historico : Form
    {
        public Form_historico()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime data_inicio, data_fim;

            data_inicio = Convert.ToDateTime(dataInicio.Value.ToString("yyyy-MM-dd"));
            data_fim = Convert.ToDateTime(dataFim.Value.ToString("yyyy-MM-dd"));

            VendaDAO dao = new VendaDAO();

            dgvHistorico.DataSource = dao.listar_vendas_periodo(data_inicio, data_fim);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form_historico_Load(object sender, EventArgs e)
        {
            VendaDAO vendaDAO = new VendaDAO();

            dgvHistorico.DataSource = vendaDAO.listar_vendas();
        }

        private void dgvHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1ºPasso - Abrir formulário de detalhes e passar o id da venda 
            int id_venda = int.Parse(dgvHistorico.CurrentRow.Cells[0].Value.ToString());
            Form_detalhes tela = new Form_detalhes(id_venda);

            //Formatar a data 
            //DateTime data_venda = Convert.ToDateTime(dgvHistorico.CurrentRow.Cells[1].Value.ToString());

            tela.txtData.Text = dgvHistorico.CurrentRow.Cells[1].Value.ToString(); //ou data_venda.ToString("dd/MM/yyyy")
            tela.txtCliente.Text = dgvHistorico.CurrentRow.Cells[2].Value.ToString();
            tela.txtTotal.Text = dgvHistorico.CurrentRow.Cells[3].Value.ToString();
            tela.txtObs.Text = dgvHistorico.CurrentRow.Cells[4].Value.ToString();

           
            
            tela.ShowDialog();

            

        }
    }
}
