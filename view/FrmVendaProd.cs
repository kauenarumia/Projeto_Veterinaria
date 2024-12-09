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

namespace Veterinaria.view
{
    public partial class FrmVendaProd : Form
    {
        DataTable Tabela_VendaProduto;
        Boolean novo;
        int posicao;

        List<VendaProduto> lista_vendaprod = new List<VendaProduto>();

        List<Venda> vendas = new List<Venda>();
        int posicao_venda;
        int codvenda;
        List<Produto> produtos = new List<Produto>();
        int posicao_produto;
        int codproduto;
        public FrmVendaProd()
        {
            InitializeComponent();
            CarregaTabela();

            lista_vendaprod = carregaListaVendaProduto();
            if (lista_vendaprod.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

            preencheComboVenda();
            preencheComboProduto();
        }

        private void preencheComboProduto()
        {
            C_Produto c_Produto = new C_Produto();
            produtos = c_Produto.DadosProduto();
            foreach(Produto produto in produtos)
            {
                cbCodProduto.Items.Add(produto.nomeproduto);
            }
        }

        private void preencheComboVenda()
        {
            C_Venda c_Venda = new C_Venda();
            vendas = c_Venda.DadosVenda();
            foreach(Venda venda in vendas)
            {
                cbCodVenda.Items.Add(venda.datavenda);
            }
        }

        private void atualizaCampos()
        {
            cbCodVenda.Text = lista_vendaprod[posicao].venda.ToString();
            cbCodProduto.Text = lista_vendaprod[posicao].produto.ToString();
            txtQuantidade.Text = lista_vendaprod[posicao].quantidade.ToString();
            txtValor.Text = lista_vendaprod[posicao ].valor.ToString();
        }

        List<VendaProduto> carregaListaVendaProduto()
        {
            List<VendaProduto> lista = new List<VendaProduto>();

            C_VendaProduto c_VendaProduto = new C_VendaProduto();
            lista = c_VendaProduto.DadosVendaProduto();

            return lista;
        }

        List<VendaProduto> carregaListaVendaProdutoFiltro()
        {
            List<VendaProduto> lista = new List<VendaProduto>();

            C_VendaProduto c_VendaProduto = new C_VendaProduto();
            lista = c_VendaProduto.DadosVendaProdutoFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_VendaProduto c_VendaProduto = new C_VendaProduto();
            DataTable dt = new DataTable();
            dt = c_VendaProduto.Buscar_Todos();
            Tabela_VendaProduto = dt;
            dataGridView1.DataSource = Tabela_VendaProduto;
        }

        private void FrmVendaProd_Load(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            ativarCampos();
            ativaBotoes();

            novo = true;
        }

        private void ativaBotoes()
        {
            btnNovo.Enabled = false;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void ativarCampos()
        {
            cbCodProduto.Enabled = true;
            cbCodVenda.Enabled = true;
            txtQuantidade.Enabled = true;
            txtValor.Enabled = true;
        }

        private void limparCampos()
        {
            cbCodProduto.Text = "";
            cbCodVenda.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
        }

        private void desativarCampos()
        {
            cbCodProduto.Enabled = false;
            cbCodVenda.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValor.Enabled = false;
        }

        /* TABELA A TERMINAR 
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            VendaProduto vendaProduto = new VendaProduto();
            vendaProduto.quantidade = txtQuantidade.Text;
            vendaProduto.valor = txtValor.Text;

            Venda venda = new Venda();
            venda.codvenda = codvenda;
            vendaProduto.venda = venda;

            Produto produto = new Produto();
            produto.codproduto = codproduto;
            vendaProduto.produto = produto;

            C_VendaProduto c_VendaProduto = new C_VendaProduto();
            if(novo == true)
            {
                c_VendaProduto.Insere_Dados(vendaProduto);
            }
            else
            {
                vendaProduto 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        */
    }
}
