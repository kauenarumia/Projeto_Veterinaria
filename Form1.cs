using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;
using Veterinaria.view;

namespace Veterinaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void racaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRaca frmraca = new FrmRaca();
            frmraca.ShowDialog();
        }

        private void tipoDeAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoAnimal frmTipoAnimal = new FrmTipoAnimal();
            frmTipoAnimal.ShowDialog();
        }

        private void bairroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBairro frmBairro = new FrmBairro();
            frmBairro.ShowDialog();
        }

        private void ruaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRua frmRua = new FrmRua();
            frmRua.ShowDialog();
        }

        private void cEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCep frmCep = new FrmCep();
            frmCep.ShowDialog();
        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPais frmPais = new FrmPais();
            frmPais.ShowDialog();
        }

        private void telefoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTelefone frmTelefone = new FrmTelefone();
            frmTelefone.ShowDialog();
        }

        private void tipoDeFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoFuncionario frmTipofuncionario = new FrmTipoFuncionario();
            frmTipofuncionario.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca frmMarca = new FrmMarca();
            frmMarca.ShowDialog();
        }

        private void tipoDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoProduto frmTipoProduto = new FrmTipoProduto();
            frmTipoProduto.ShowDialog();
        }

        private void tipoDeServicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoServico frmTipoServico = new FrmTipoServico();
            frmTipoServico.ShowDialog();
        }

        private void cidAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidAnimal frmCidAnimal = new FrmCidAnimal();
            frmCidAnimal.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoja frmLoja = new FrmLoja();
            frmLoja.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto();
            frmProduto.ShowDialog();
        }

        private void lojaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFuncionario frmFuncionario = new FrmFuncionario();
            frmFuncionario.ShowDialog();
        }

        private void animalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnimal frmAnimal = new FrmAnimal();
            frmAnimal.ShowDialog();
        }

        private void vendasProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenda frmVenda = new FrmVenda();
            frmVenda.ShowDialog();
        }
    }
}
