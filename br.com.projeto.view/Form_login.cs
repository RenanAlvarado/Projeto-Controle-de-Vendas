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
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Botão de realizar login 
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            

            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

            if (funcionarioDAO.efetuar_login(email, senha) == true)
            {
                
                this.Hide(); //Fechar a tela de login
            }
            
        }

        private void Form_login_Load(object sender, EventArgs e)
        {

        }
    }
}
