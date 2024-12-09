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
    public partial class FrmTipoAnimal : Form
    {
        DataTable Tabela_TpAnimal;
        Boolean novo;
        int posicao;
        List<Tipoanimal> lista_tipoanimal = new List<Tipoanimal>();
        public FrmTipoAnimal()
        {
            InitializeComponent();
            CarregaTabela();

            lista_tipoanimal = carregaListaTpAnimal();
            if(lista_tipoanimal.Count -1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_tipoanimal[posicao].codtipoanimal.ToString();
            txtTipoAnimal.Text = lista_tipoanimal[posicao].nometipoanimal.ToString();
        }

        List<Tipoanimal> carregaListaTpAnimal()
        {
            List<Tipoanimal> lista = new List<Tipoanimal>();
            
            C_TpAnimal c_TpAnimal = new C_TpAnimal();
            lista = c_TpAnimal.DadosTipoAnimal();

            return lista;
        }
        List<Tipoanimal> carregaListaTpAnimalFiltro()
        {
            List<Tipoanimal> lista = new List<Tipoanimal>();

            C_TpAnimal c_TpAnimal = new C_TpAnimal();
            lista = c_TpAnimal.DadosTpAnimalFiltro(txtBuscar.Text);

            return lista;
        }

        public void CarregaTabela()
        {
            C_TpAnimal c_tpanimal = new C_TpAnimal();
            DataTable dt = new DataTable();
            dt = c_tpanimal.Buscar_Todos();
            Tabela_TpAnimal = dt;
            dataGridView1.DataSource = Tabela_TpAnimal;
        }

        private void FrmTipoAnimal_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            txtTipoAnimal.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtTipoAnimal.Text = "";
        }

        private void desativaCampos()
        {
            txtTipoAnimal.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Tipoanimal tipoanimal = new Tipoanimal();
            tipoanimal.nometipoanimal = txtTipoAnimal.Text;

            C_TpAnimal c_TpAnimal = new C_TpAnimal();
            if(novo == true)
            {
                c_TpAnimal.Insere_Dados(tipoanimal);
            }
            else
            {
                tipoanimal.codtipoanimal = Int32.Parse(txtCodigo.Text);
                c_TpAnimal.Atualizar_Dados(tipoanimal);
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
            desativaBotoes();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                C_TpAnimal tpAnimal = new C_TpAnimal();

                if(txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    tpAnimal.Apaga_Dados(valor);
                    CarregaTabela();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow dr = dataGridView1.Rows[index];
            txtCodigo.Text = dr.Cells[0].Value.ToString();
            txtTipoAnimal.Text = dr.Cells[1].Value.ToString();
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

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[posicao].Selected = false;
            posicao = lista_tipoanimal.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if(posicao > 0)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao--;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int total = lista_tipoanimal.Count - 1;
            if(total > posicao)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao++;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_TpAnimal c_TpAnimal = new C_TpAnimal();
            DataTable dt = new DataTable();
            dt = c_TpAnimal.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_TpAnimal = dt;
            dataGridView1.DataSource = Tabela_TpAnimal;

            lista_tipoanimal = carregaListaTpAnimalFiltro();

            if(lista_tipoanimal.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }
    }
}
