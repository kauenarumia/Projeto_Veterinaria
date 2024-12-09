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
    public partial class FrmProduto : Form
    {
        DataTable Tabela_Produto;
        Boolean novo;
        int posicao;
        List<Produto> lista_produto = new List<Produto>();

        List<Marca> marcas = new List<Marca>();
        int posicao_marca;
        int codmarca;
        List<Tipoproduto> tipoprodutos = new List<Tipoproduto>();
        int posicao_tipoproduto;
        int codtipoproduto;

        public FrmProduto()
        {
            InitializeComponent();
            CarregaTabela();

            lista_produto = carregaListaProduto();
            if (lista_produto.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

            preencheComboMarca();
            preencheComboTipoproduto();
        }

        private void preencheComboTipoproduto()
        {
            C_TipoProduto c_TipoProduto = new C_TipoProduto();
            tipoprodutos = c_TipoProduto.DadosTipoProduto();
            foreach(Tipoproduto tipoproduto in tipoprodutos)
            {
                cbTipo.Items.Add(tipoproduto.nometipoproduto);
            }
        }

        private void preencheComboMarca()
        {
            C_Marca c_Marca = new C_Marca();
            marcas = c_Marca.DadosMarca();
            foreach(Marca marca in marcas)
            {
                cbMarca.Items.Add(marca.nomemarca);
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_produto[posicao].codproduto.ToString();
            txtNome.Text = lista_produto[posicao].nomeproduto.ToString();
            txtQuant.Text = lista_produto[posicao].quantidade.ToString();
            txtValor.Text = lista_produto[posicao].valor.ToString();
            cbMarca.Text = lista_produto[posicao].marca.ToString();
            cbTipo.Text = lista_produto[posicao].tipoproduto.ToString();
        }

        List<Produto> carregaListaProduto()
        {
            List<Produto> lista = new List<Produto>();

            C_Produto c_Produto = new C_Produto();
            lista = c_Produto.DadosProduto();

            return lista;
        }

        List<Produto> carregaListaProdutoFiltro()
        {
            List<Produto> lista = new List<Produto>();

            C_Produto c_Produto = new C_Produto();
            lista = c_Produto.DadosProdutoFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_Produto c_Produto = new C_Produto();
            DataTable dt = new DataTable();
            dt = c_Produto.Buscar_Todos();
            Tabela_Produto = dt;
            dataGridView1.DataSource = Tabela_Produto;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
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
            txtNome.Enabled = true;
            txtQuant.Enabled = true;
            txtValor.Enabled = true;
            cbMarca.Enabled = true;
            cbTipo.Enabled = true;
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtQuant.Text = "";
            txtValor.Text = "";
            cbMarca.Text = "";
            cbTipo.Text = "";
        }

        private void desativaCampos()
        {
            txtNome.Enabled = false;
            txtQuant.Enabled = false;
            txtValor.Enabled = false;
            cbMarca.Enabled = false;
            cbTipo.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.nomeproduto = txtNome.Text;

            Marca marca = new Marca();
            marca.codmarca = codmarca;
            produto.marca = marca;

            Tipoproduto tipoproduto = new Tipoproduto();
            tipoproduto.codtipoproduto = codtipoproduto;
            produto.tipoproduto = tipoproduto;

            produto.quantidade = txtQuant.Text;
            produto.valor = txtValor.Text;

            C_Produto c_Produto = new C_Produto();
            if(novo == true)
            {
                c_Produto.Insere_Dados(produto);
            }
            else
            {
                produto.codproduto = Int32.Parse(txtValor.Text);
                c_Produto.Atualizar_Dados(produto);
            }

            CarregaTabela();
            desativaCampos();
            desativaBotoes();
        }

        private void desativaBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desativaBotoes();
            desativaCampos();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Produto produto = new C_Produto();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    produto.Apaga_Dados(valor);
                    CarregaTabela();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ativarCampos();
            ativaBotoes();
            novo = false;
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[posicao].Selected = false;
            posicao = 0;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicao > 0)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao--;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int total = lista_produto.Count - 1;
            if (total > posicao)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao++;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[posicao].Selected = false;
            posicao = lista_produto.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Produto c_Produto = new C_Produto();
            DataTable dt = new DataTable();
            dt = c_Produto.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Produto = dt;
            dataGridView1.DataSource = Tabela_Produto;

            lista_produto = carregaListaProdutoFiltro();

            if (lista_produto.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow dr = dataGridView1.Rows[index];
            txtCodigo.Text = dr.Cells[0].Value.ToString();
            txtNome.Text = dr.Cells[1].Value.ToString();
            txtQuant.Text = dr.Cells[2].Value.ToString();
            txtValor.Text = dr.Cells[3].Value.ToString();
            cbMarca.Text = dr.Cells[4].Value.ToString();
            cbTipo.Text = dr.Cells[5].Value.ToString();
        }

        private void cbMarca_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_marca = cbMarca.SelectedIndex;
            codmarca = marcas[posicao_marca].codmarca;
        }

        private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_tipoproduto = cbTipo.SelectedIndex;
            codtipoproduto = tipoprodutos[posicao_tipoproduto].codtipoproduto;
        }
    }
}
