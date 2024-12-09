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
    public partial class FrmTipoProduto : Form
    {
        DataTable Tabela_TipoProd;
        Boolean novo;
        int posicao;
        List<Tipoproduto> lista_tipoprod = new List<Tipoproduto>();


        public FrmTipoProduto()
        {
            InitializeComponent();
            CarregaTabela();

            lista_tipoprod = carregaListaTipoProd();
            if(lista_tipoprod.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_tipoprod[posicao].codtipoproduto.ToString();
            txtTipoProd.Text = lista_tipoprod[posicao].nometipoproduto.ToString();
        }

        List<Tipoproduto> carregaListaTipoProd()
        {
            List<Tipoproduto> lista = new List<Tipoproduto>();

            C_TipoProduto c_tipoprod = new C_TipoProduto();
            lista = c_tipoprod.DadosTipoProduto();

            return lista;
        }

        List<Tipoproduto> carregaListaTipoProdFiltro()
        {
            List<Tipoproduto> lista = new List<Tipoproduto>();

            C_TipoProduto c_tipoprod = new C_TipoProduto();
            lista = c_tipoprod.DadosTipoProdutoFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_TipoProduto c_TipoProduto = new C_TipoProduto();
            DataTable dt = new DataTable();
            dt = c_TipoProduto.Buscar_Todos();
            Tabela_TipoProd = dt;
            dataGridView1.DataSource = Tabela_TipoProd;
        }

        private void FrmTipoProduto_Load(object sender, EventArgs e)
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
            txtTipoProd.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtTipoProd.Text = "";
        }

        private void desativaCampos()
        {
            txtTipoProd.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Tipoproduto tipoproduto = new Tipoproduto();
            tipoproduto.nometipoproduto = txtTipoProd.Text;

            C_TipoProduto c_TipoProduto = new C_TipoProduto();
            if(novo == true)
            {
                c_TipoProduto.Insere_Dados(tipoproduto);
            }
            else
            {
                tipoproduto.codtipoproduto = Int32.Parse(txtCodigo.Text);
                c_TipoProduto.Atualizar_Dados(tipoproduto);
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
                C_TipoProduto tipoproduto = new C_TipoProduto();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    tipoproduto.Apaga_Dados(valor);
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
            int total = lista_tipoprod.Count - 1;
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
            posicao = lista_tipoprod.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_TipoProduto c_tipoproduto = new C_TipoProduto();
            DataTable dt = new DataTable();
            dt = c_tipoproduto.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_TipoProd = dt;
            dataGridView1.DataSource = Tabela_TipoProd;

            if(lista_tipoprod.Count - 1 > 0)
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
            txtTipoProd.Text = dr.Cells[1].Value.ToString();
        }
    }
}
