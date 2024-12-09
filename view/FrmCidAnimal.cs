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
    public partial class FrmCidAnimal : Form
    {
        DataTable Tabela_Cid;
        Boolean novo;
        int posicao;
        List<Cidanimal> lista_cid = new List<Cidanimal>();
        public FrmCidAnimal()
        {
            InitializeComponent();
            CarregaTabela();

            lista_cid = carregaListaCid();
            if (lista_cid.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_cid[posicao].codcidanimal.ToString();
            txtCid.Text = lista_cid[posicao].nomecidanimal.ToString();
            txtDesc.Text = lista_cid[posicao].descricao.ToString();
        }

        private List<Cidanimal> carregaListaCid()
        {
            List<Cidanimal> lista = new List<Cidanimal>();

            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            lista = c_CidAnimal.DadosCidAnimal();

            return lista;
        }

        private List<Cidanimal> carregaListaCidFiltro()
        {
            List<Cidanimal> lista = new List<Cidanimal>();

            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            lista = c_CidAnimal.DadosCidAnimalFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            DataTable dt = new DataTable();
            dt = c_CidAnimal.Buscar_Todos();
            Tabela_Cid = dt;
            dataGridView1.DataSource = Tabela_Cid;
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
            txtCid.Enabled = true;
            txtDesc.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtCid.Text = "";
            txtDesc.Text = "";
        }

        private void desativaCampos()
        {
            txtCid.Enabled = false;
            txtDesc.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cidanimal cidanimal = new Cidanimal();
            cidanimal.nomecidanimal = txtCid.Text;
            cidanimal.descricao = txtDesc.Text;

            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            if (novo == true)
            {
                c_CidAnimal.Insere_Dados(cidanimal);
            }
            else
            {
                cidanimal.codcidanimal = Int32.Parse(txtCodigo.Text);
                c_CidAnimal.Atualizar_Dados(cidanimal);
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
                C_CidAnimal cidAnimal = new C_CidAnimal();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    cidAnimal.Apaga_Dados(valor);
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
            int total = lista_cid.Count - 1;
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
            posicao = lista_cid.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            DataTable dt = new DataTable();
            dt = c_CidAnimal.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Cid = dt;
            lista_cid = carregaListaCidFiltro();

            if(lista_cid.Count - 1 > 0)
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
            txtCid.Text = dr.Cells[1].Value.ToString();
            txtDesc.Text = dr.Cells[2].Value.ToString();
        }
    }
}
