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
    public partial class FrmPais : Form
    {
        DataTable Tabela_Pais;
        Boolean novo;
        int posicao;
        List<Pais> lista_pais = new List<Pais>();


        public FrmPais()
        {
            InitializeComponent();
            CarregaTabela();

            lista_pais = carregaListaPais();
            if(lista_pais.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_pais[posicao].codpais.ToString();
            txtPais.Text = lista_pais[posicao].nomepais.ToString();
        }

        private List<Pais> carregaListaPais()
        {
            List<Pais> lista = new List<Pais>();

            C_Pais c_Pais = new C_Pais();
            lista = c_Pais.DadosPais();

            return lista;
        }

        List<Pais> carregaListaPaisFiltro()
        {
            List<Pais> lista = new List<Pais>();

            C_Pais c_Pais = new C_Pais();
            lista = c_Pais.DadosPaisFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_Pais c_Pais = new C_Pais();
            DataTable dt = new DataTable();
            dt = c_Pais.Buscar_Todos();
            Tabela_Pais = dt;
            dataGridView1.DataSource = Tabela_Pais;
        }

        private void FrmPais_Load(object sender, EventArgs e)
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
            txtPais.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtPais.Text = "";
        }

        public void desativaCampos()
        {
            txtPais.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pais pais = new Pais();
            pais.nomepais = txtPais.Text;

            C_Pais c_Pais = new C_Pais();
            if (novo == true)
            {
                c_Pais.Insere_Dados(pais);
            }
            else
            {
                pais.codpais = Int32.Parse(txtCodigo.Text);
                c_Pais.Atualizar_Dados(pais);
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
                C_Pais pais = new C_Pais();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    pais.Apaga_Dados(valor);
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
            dataGridView1.Rows[posicao].Selected = false;
            posicao--;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int total = lista_pais.Count - 1;
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
            posicao = lista_pais.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Pais c_Pais = new C_Pais();
            DataTable dt = new DataTable();
            dt = c_Pais.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Pais = dt;
            dataGridView1.DataSource = Tabela_Pais;

            lista_pais = carregaListaPaisFiltro();

            if(lista_pais.Count - 1 > 0)
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
            txtPais.Text = dr.Cells[1].Value.ToString();
        }
    }
}
