namespace Projeto_Controle_de_Vendas.br.com.projeto.view
{
    partial class Form_menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoricoVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlterarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCliente,
            this.menuFuncionario,
            this.menuFornecedor,
            this.menuProduto,
            this.menuVenda,
            this.menuOpcoes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCliente
            // 
            this.menuCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroCliente,
            this.menuConsultaCliente});
            this.menuCliente.Image = global::Projeto_Controle_de_Vendas.Properties.Resources.icons8_cliente_30;
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(95, 24);
            this.menuCliente.Text = "Clientes";
            // 
            // menuCadastroCliente
            // 
            this.menuCadastroCliente.Name = "menuCadastroCliente";
            this.menuCadastroCliente.Size = new System.Drawing.Size(232, 26);
            this.menuCadastroCliente.Text = "Cadastro de Clientes ";
            this.menuCadastroCliente.Click += new System.EventHandler(this.menuCadastroCliente_Click);
            // 
            // menuConsultaCliente
            // 
            this.menuConsultaCliente.Name = "menuConsultaCliente";
            this.menuConsultaCliente.Size = new System.Drawing.Size(232, 26);
            this.menuConsultaCliente.Text = "Consulta de Clientes";
            this.menuConsultaCliente.Click += new System.EventHandler(this.menuConsultaCliente_Click);
            // 
            // menuFuncionario
            // 
            this.menuFuncionario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFuncionario,
            this.menuConsultaFuncionario});
            this.menuFuncionario.Image = global::Projeto_Controle_de_Vendas.Properties.Resources.icons8_funcionários_50;
            this.menuFuncionario.Name = "menuFuncionario";
            this.menuFuncionario.Size = new System.Drawing.Size(126, 24);
            this.menuFuncionario.Text = "Funcionários";
            // 
            // menuCadastroFuncionario
            // 
            this.menuCadastroFuncionario.Name = "menuCadastroFuncionario";
            this.menuCadastroFuncionario.Size = new System.Drawing.Size(259, 26);
            this.menuCadastroFuncionario.Text = "Cadastro de Funcionários";
            this.menuCadastroFuncionario.Click += new System.EventHandler(this.menuCadastroFuncionario_Click);
            // 
            // menuConsultaFuncionario
            // 
            this.menuConsultaFuncionario.Name = "menuConsultaFuncionario";
            this.menuConsultaFuncionario.Size = new System.Drawing.Size(259, 26);
            this.menuConsultaFuncionario.Text = "Consulta de Funcionários";
            this.menuConsultaFuncionario.Click += new System.EventHandler(this.menuConsultaFuncionario_Click);
            // 
            // menuFornecedor
            // 
            this.menuFornecedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFornecedor,
            this.menuConsultaFornecedor});
            this.menuFornecedor.Image = global::Projeto_Controle_de_Vendas.Properties.Resources.icons8_fornecedor_50;
            this.menuFornecedor.Name = "menuFornecedor";
            this.menuFornecedor.Size = new System.Drawing.Size(136, 24);
            this.menuFornecedor.Text = "Fornecedores ";
            // 
            // menuCadastroFornecedor
            // 
            this.menuCadastroFornecedor.Name = "menuCadastroFornecedor";
            this.menuCadastroFornecedor.Size = new System.Drawing.Size(269, 26);
            this.menuCadastroFornecedor.Text = "Cadastro de Fornecedores ";
            this.menuCadastroFornecedor.Click += new System.EventHandler(this.menuCadastroFornecedor_Click);
            // 
            // menuConsultaFornecedor
            // 
            this.menuConsultaFornecedor.Name = "menuConsultaFornecedor";
            this.menuConsultaFornecedor.Size = new System.Drawing.Size(269, 26);
            this.menuConsultaFornecedor.Text = "Consulta de Fornecedores";
            this.menuConsultaFornecedor.Click += new System.EventHandler(this.menuConsultaFornecedor_Click);
            // 
            // menuProduto
            // 
            this.menuProduto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroProduto,
            this.menuConsultaProduto});
            this.menuProduto.Image = global::Projeto_Controle_de_Vendas.Properties.Resources.icons8_box_50;
            this.menuProduto.Name = "menuProduto";
            this.menuProduto.Size = new System.Drawing.Size(102, 24);
            this.menuProduto.Text = "Produtos";
            // 
            // menuCadastroProduto
            // 
            this.menuCadastroProduto.Name = "menuCadastroProduto";
            this.menuCadastroProduto.Size = new System.Drawing.Size(239, 26);
            this.menuCadastroProduto.Text = "Cadastro de Produtos ";
            this.menuCadastroProduto.Click += new System.EventHandler(this.menuCadastroProduto_Click);
            // 
            // menuConsultaProduto
            // 
            this.menuConsultaProduto.Name = "menuConsultaProduto";
            this.menuConsultaProduto.Size = new System.Drawing.Size(239, 26);
            this.menuConsultaProduto.Text = "Consulta de Produtos ";
            this.menuConsultaProduto.Click += new System.EventHandler(this.menuConsultaProduto_Click);
            // 
            // menuVenda
            // 
            this.menuVenda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNovaVenda,
            this.menuHistoricoVenda});
            this.menuVenda.Image = global::Projeto_Controle_de_Vendas.Properties.Resources.icons8_saco_de_papel_64;
            this.menuVenda.Name = "menuVenda";
            this.menuVenda.Size = new System.Drawing.Size(90, 24);
            this.menuVenda.Text = "Vendas";
            // 
            // menuNovaVenda
            // 
            this.menuNovaVenda.Name = "menuNovaVenda";
            this.menuNovaVenda.Size = new System.Drawing.Size(224, 26);
            this.menuNovaVenda.Text = "Nova Venda";
            this.menuNovaVenda.Click += new System.EventHandler(this.menuNovaVenda_Click);
            // 
            // menuHistoricoVenda
            // 
            this.menuHistoricoVenda.Name = "menuHistoricoVenda";
            this.menuHistoricoVenda.Size = new System.Drawing.Size(224, 26);
            this.menuHistoricoVenda.Text = "Histórico de Vendas";
            this.menuHistoricoVenda.Click += new System.EventHandler(this.menuHistoricoVenda_Click);
            // 
            // menuOpcoes
            // 
            this.menuOpcoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAlterarUsuario,
            this.menuSair});
            this.menuOpcoes.Image = global::Projeto_Controle_de_Vendas.Properties.Resources.icons8_engrenagem_30;
            this.menuOpcoes.Name = "menuOpcoes";
            this.menuOpcoes.Size = new System.Drawing.Size(93, 24);
            this.menuOpcoes.Text = "Opções";
            // 
            // menuAlterarUsuario
            // 
            this.menuAlterarUsuario.Name = "menuAlterarUsuario";
            this.menuAlterarUsuario.Size = new System.Drawing.Size(191, 26);
            this.menuAlterarUsuario.Text = "Alterar Usuário";
            this.menuAlterarUsuario.Click += new System.EventHandler(this.trocarToolStripMenuItem_Click);
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(224, 26);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusData,
            this.toolStripStatusLabel3,
            this.statusHora,
            this.toolStripStatusLabel5,
            this.statusUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel1.Text = "Data Atual:";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statusData
            // 
            this.statusData.Name = "statusData";
            this.statusData.Size = new System.Drawing.Size(151, 20);
            this.statusData.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel3.Text = "Hora Atual:";
            // 
            // statusHora
            // 
            this.statusHora.Name = "statusHora";
            this.statusHora.Size = new System.Drawing.Size(151, 20);
            this.statusHora.Text = "toolStripStatusLabel4";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(62, 20);
            this.toolStripStatusLabel5.Text = "Usuário:";
            // 
            // statusUsuario
            // 
            this.statusUsuario.Name = "statusUsuario";
            this.statusUsuario.Size = new System.Drawing.Size(151, 20);
            this.statusUsuario.Text = "toolStripStatusLabel6";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projeto_Controle_de_Vendas.Properties.Resources.images;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(778, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_menu";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCliente;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaCliente;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuFornecedor;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFornecedor;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFornecedor;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroProduto;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaProduto;
        private System.Windows.Forms.ToolStripMenuItem menuVenda;
        private System.Windows.Forms.ToolStripMenuItem menuNovaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuOpcoes;
        private System.Windows.Forms.ToolStripMenuItem menuAlterarUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusHora;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        public System.Windows.Forms.ToolStripMenuItem menuProduto;
        public System.Windows.Forms.ToolStripMenuItem menuHistoricoVenda;
        public System.Windows.Forms.ToolStripStatusLabel statusUsuario;
        private System.Windows.Forms.Timer timer1;
    }
}