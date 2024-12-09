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
    public partial class FrmTipoServico : Form
    {
        DataTable Tabela_TipoServ;
        Boolean novo;
        int posicao;
        List<Tiposervico> lista_tiposerv = new List<Tiposervico>();
        public FrmTipoServico()
        {
            InitializeComponent();
            CarregaTabela();

            lista_tiposerv = carregaListaTipoServ();
            if(lista_tiposerv.Count - 1 > 0 )
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_tiposerv[posicao].codtiposervico.ToString();
            txtTipoServ.Text = lista_tiposerv[posicao].nometiposervico.ToString();
            txtValorServico.Text = lista_tiposerv[posicao].valortiposervico.ToString();
        }

        List<Tiposervico> carregaListaTipoServ()
        {
            List<Tiposervico> lista = new List<Tiposervico>();

            C_TipoServico c_TipoServico = new C_TipoServico();
            lista = c_TipoServico.DadosTipoServ();

            return lista;
        }

        List<Tiposervico> carregaListaTipoServFiltro()
        {
            List<Tiposervico> lista = new List<Tiposervico>();

            C_TipoServico c_TipoServico = new C_TipoServico();
            lista = c_TipoServico.DadosTipoServFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_TipoServico c_TipoServico = new C_TipoServico();
            DataTable dt = new DataTable();
            dt = c_TipoServico.Buscar_Todos();
            Tabela_TipoServ = dt;
            dataGridView1.DataSource = Tabela_TipoServ;
        }

        private void FrmTipoServico_Load(object sender, EventArgs e)
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
            txtTipoServ.Enabled = true;
            txtValorServico.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtTipoServ.Text = "";
            txtValorServico.Text = "";
        }

        private void desativaCampos()
        {
            txtTipoServ.Enabled = false;
            txtValorServico.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Tiposervico tiposervico = new Tiposervico();
            tiposervico.nometiposervico = txtTipoServ.Text;
            tiposervico.valortiposervico = txtValorServico.Text;

            C_TipoServico c_TipoServico = new C_TipoServico();
            if(novo == true)
            {
                c_TipoServico.Insere_Dados(tiposervico);
            }
            else
            {
                tiposervico.codtiposervico = Int32.Parse(txtCodigo.Text);
                c_TipoServico.Atualizar_Dados(tiposervico);
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
                C_TipoServico tipoServico = new C_TipoServico();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    tipoServico.Apaga_Dados(valor);
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
            int total = lista_tiposerv.Count - 1;
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
            posicao = lista_tiposerv.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_TipoServico c_TipoServico = new C_TipoServico();
            DataTable dt = new DataTable();
            dt = c_TipoServico.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_TipoServ = dt;
            lista_tiposerv = carregaListaTipoServFiltro();

            if(lista_tiposerv.Count - 1 > 0)
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
            txtTipoServ.Text = dr.Cells[1].Value.ToString();
            txtValorServico.Text = dr.Cells[2].Value.ToString();
        }
    }
}
