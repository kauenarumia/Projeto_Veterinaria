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
    public partial class FrmMarca : Form
    {
        DataTable Tabela_Marca;
        Boolean novo;
        int posicao;
        List<Marca> lista_marca = new List<Marca>();


        public FrmMarca()
        {
            InitializeComponent();
            CarregaTabela();

            lista_marca = carregaListaMarca();
            if(lista_marca.Count -1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_marca[posicao].codmarca.ToString();
            txtMarca.Text = lista_marca[posicao].nomemarca.ToString();
        }

        List<Marca> carregaListaMarca()
        {
            List<Marca> lista = new List<Marca>();

            C_Marca c_Marca = new C_Marca();
            lista = c_Marca.DadosMarca();

            return lista;
        }

        List<Marca> carregaListaMarcaFiltro()
        {
            List<Marca> lista = new List<Marca>();

            C_Marca c_Marca = new C_Marca();
            lista = c_Marca.DadosMarcaFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_Marca c_Marca = new C_Marca();
            DataTable dt = new DataTable();
            dt = c_Marca.Buscar_Todos();
            Tabela_Marca = dt;
            dataGridView1.DataSource = Tabela_Marca;
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
            txtMarca.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtMarca.Text = "";
        }

        private void desativaCampos()
        {
            txtMarca.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.nomemarca = txtMarca.Text;

            C_Marca c_Marca = new C_Marca();
            if(novo == true)
            {
                c_Marca.Insere_Dados(marca);
            }
            else
            {
                marca.codmarca = Int32.Parse(txtCodigo.Text);
                c_Marca.Atualizar_Dados(marca);
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
            if(txtCodigo.Text != "")
            {
                C_Marca marca = new C_Marca();

                if(txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    marca.Apaga_Dados(valor);
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
            int total = lista_marca.Count - 1;
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
            posicao = lista_marca.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Marca c_Marca = new C_Marca();
            DataTable dt = new DataTable();
            dt = c_Marca.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Marca = dt;
            dataGridView1.DataSource = Tabela_Marca;

            lista_marca = carregaListaMarcaFiltro();

            if(lista_marca.Count - 1 > 0)
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
            txtMarca.Text = dr.Cells[1].Value.ToString();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
