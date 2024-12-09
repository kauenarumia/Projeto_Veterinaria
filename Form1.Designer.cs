namespace Veterinaria
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosSimplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lojaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bairroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cEPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeFuncionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeServicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.telefonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosSimplesToolStripMenuItem,
            this.racaToolStripMenuItem,
            this.tipoDeAnimalToolStripMenuItem,
            this.bairroToolStripMenuItem,
            this.ruaToolStripMenuItem,
            this.cEPToolStripMenuItem,
            this.paisToolStripMenuItem,
            this.telefoneToolStripMenuItem,
            this.tipoDeFuncionarioToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.tipoDeProdutoToolStripMenuItem,
            this.tipoDeServicoToolStripMenuItem,
            this.cidAnimalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosSimplesToolStripMenuItem
            // 
            this.cadastrosSimplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lojaToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.funcionarioToolStripMenuItem,
            this.animalToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.telefonesToolStripMenuItem});
            this.cadastrosSimplesToolStripMenuItem.Name = "cadastrosSimplesToolStripMenuItem";
            this.cadastrosSimplesToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.cadastrosSimplesToolStripMenuItem.Text = "Cadastros Avançados";
            // 
            // lojaToolStripMenuItem
            // 
            this.lojaToolStripMenuItem.Name = "lojaToolStripMenuItem";
            this.lojaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lojaToolStripMenuItem.Text = "Loja";
            this.lojaToolStripMenuItem.Click += new System.EventHandler(this.lojaToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.funcionarioToolStripMenuItem.Text = "Funcionario";
            this.funcionarioToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // animalToolStripMenuItem
            // 
            this.animalToolStripMenuItem.Name = "animalToolStripMenuItem";
            this.animalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.animalToolStripMenuItem.Text = "Animal";
            this.animalToolStripMenuItem.Click += new System.EventHandler(this.animalToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendasProdutosToolStripMenuItem,
            this.vendaToolStripMenuItem});
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vendasToolStripMenuItem.Text = "Vendas";
            // 
            // vendasProdutosToolStripMenuItem
            // 
            this.vendasProdutosToolStripMenuItem.Name = "vendasProdutosToolStripMenuItem";
            this.vendasProdutosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vendasProdutosToolStripMenuItem.Text = "Vendas Produtos";
            this.vendasProdutosToolStripMenuItem.Click += new System.EventHandler(this.vendasProdutosToolStripMenuItem_Click);
            // 
            // vendaToolStripMenuItem
            // 
            this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
            this.vendaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vendaToolStripMenuItem.Text = "Venda";
            this.vendaToolStripMenuItem.Click += new System.EventHandler(this.vendaToolStripMenuItem_Click);
            // 
            // racaToolStripMenuItem
            // 
            this.racaToolStripMenuItem.Name = "racaToolStripMenuItem";
            this.racaToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.racaToolStripMenuItem.Text = "Raca";
            this.racaToolStripMenuItem.Click += new System.EventHandler(this.racaToolStripMenuItem_Click);
            // 
            // tipoDeAnimalToolStripMenuItem
            // 
            this.tipoDeAnimalToolStripMenuItem.Name = "tipoDeAnimalToolStripMenuItem";
            this.tipoDeAnimalToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.tipoDeAnimalToolStripMenuItem.Text = "Tipo de Animal";
            this.tipoDeAnimalToolStripMenuItem.Click += new System.EventHandler(this.tipoDeAnimalToolStripMenuItem_Click);
            // 
            // bairroToolStripMenuItem
            // 
            this.bairroToolStripMenuItem.Name = "bairroToolStripMenuItem";
            this.bairroToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.bairroToolStripMenuItem.Text = "Bairro";
            this.bairroToolStripMenuItem.Click += new System.EventHandler(this.bairroToolStripMenuItem_Click);
            // 
            // ruaToolStripMenuItem
            // 
            this.ruaToolStripMenuItem.Name = "ruaToolStripMenuItem";
            this.ruaToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.ruaToolStripMenuItem.Text = "Rua";
            this.ruaToolStripMenuItem.Click += new System.EventHandler(this.ruaToolStripMenuItem_Click);
            // 
            // cEPToolStripMenuItem
            // 
            this.cEPToolStripMenuItem.Name = "cEPToolStripMenuItem";
            this.cEPToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.cEPToolStripMenuItem.Text = "CEP";
            this.cEPToolStripMenuItem.Click += new System.EventHandler(this.cEPToolStripMenuItem_Click);
            // 
            // paisToolStripMenuItem
            // 
            this.paisToolStripMenuItem.Name = "paisToolStripMenuItem";
            this.paisToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.paisToolStripMenuItem.Text = "Pais";
            this.paisToolStripMenuItem.Click += new System.EventHandler(this.paisToolStripMenuItem_Click);
            // 
            // telefoneToolStripMenuItem
            // 
            this.telefoneToolStripMenuItem.Name = "telefoneToolStripMenuItem";
            this.telefoneToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.telefoneToolStripMenuItem.Text = "Telefone";
            this.telefoneToolStripMenuItem.Click += new System.EventHandler(this.telefoneToolStripMenuItem_Click);
            // 
            // tipoDeFuncionarioToolStripMenuItem
            // 
            this.tipoDeFuncionarioToolStripMenuItem.Name = "tipoDeFuncionarioToolStripMenuItem";
            this.tipoDeFuncionarioToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.tipoDeFuncionarioToolStripMenuItem.Text = "Tipo de Funcionario";
            this.tipoDeFuncionarioToolStripMenuItem.Click += new System.EventHandler(this.tipoDeFuncionarioToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // tipoDeProdutoToolStripMenuItem
            // 
            this.tipoDeProdutoToolStripMenuItem.Name = "tipoDeProdutoToolStripMenuItem";
            this.tipoDeProdutoToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.tipoDeProdutoToolStripMenuItem.Text = "Tipo de Produto";
            this.tipoDeProdutoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeProdutoToolStripMenuItem_Click);
            // 
            // tipoDeServicoToolStripMenuItem
            // 
            this.tipoDeServicoToolStripMenuItem.Name = "tipoDeServicoToolStripMenuItem";
            this.tipoDeServicoToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.tipoDeServicoToolStripMenuItem.Text = "Tipo de Servico";
            this.tipoDeServicoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeServicoToolStripMenuItem_Click);
            // 
            // cidAnimalToolStripMenuItem
            // 
            this.cidAnimalToolStripMenuItem.Name = "cidAnimalToolStripMenuItem";
            this.cidAnimalToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.cidAnimalToolStripMenuItem.Text = "Cid Animal";
            this.cidAnimalToolStripMenuItem.Click += new System.EventHandler(this.cidAnimalToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // telefonesToolStripMenuItem
            // 
            this.telefonesToolStripMenuItem.Name = "telefonesToolStripMenuItem";
            this.telefonesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.telefonesToolStripMenuItem.Text = "Telefones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 516);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem racaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeAnimalToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bairroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cEPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telefoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeFuncionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeServicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosSimplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lojaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telefonesToolStripMenuItem;
    }
}

