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
    public partial class FrmTipoFuncionario : Form
    {
        DataTable Tabela_TipoFunc;
        Boolean novo;
        int posicao;
        List<Tipofuncionario> lista_tipofunc = new List<Tipofuncionario>();
        

        public FrmTipoFuncionario()
        {
            InitializeComponent();
            CarregaTabela();

            lista_tipofunc = carregaListaTipoFunc();
            if(lista_tipofunc.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_tipofunc[posicao].codtipofuncionario.ToString();
            txtTipoFunc.Text = lista_tipofunc[posicao].nometipofuncionario.ToString();
        }

        List<Tipofuncionario> carregaListaTipoFunc()
        {
            List<Tipofuncionario> lista = new List<Tipofuncionario>();

            C_TipoFunc c_TipoFunc = new C_TipoFunc();
            lista = c_TipoFunc.DadosTipoFunc();

            return lista;
        }

        List<Tipofuncionario> carregaListaTipoFuncFiltro()
        {
            List<Tipofuncionario> lista = new List<Tipofuncionario>();

            C_TipoFunc c_TipoFunc = new C_TipoFunc();
            lista = c_TipoFunc.DadosTipoFuncFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_TipoFunc c_TipoFunc = new C_TipoFunc();
            DataTable dt = new DataTable();
            dt = c_TipoFunc.Buscar_Todos();
            Tabela_TipoFunc = dt;
            dataGridView1.DataSource = Tabela_TipoFunc;
        }

        private void FrmTipoFuncionario_Load(object sender, EventArgs e)
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
            txtTipoFunc.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtTipoFunc.Text = "";
        }

        private void desativaCampos()
        {
            txtTipoFunc.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Tipofuncionario tipofuncionario = new Tipofuncionario();
            tipofuncionario.nometipofuncionario = txtTipoFunc.Text;

            C_TipoFunc c_TipoFunc = new C_TipoFunc();
            if(novo == true)
            {
                c_TipoFunc.Insere_Dados(tipofuncionario);
            }
            else
            {
                tipofuncionario.codtipofuncionario = Int32.Parse(txtCodigo.Text);
                c_TipoFunc.Atualizar_Dados(tipofuncionario);
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
                C_TipoFunc tipoFunc = new C_TipoFunc();
                
                if(txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    tipoFunc.Apaga_Dados(valor);
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
            int total = lista_tipofunc.Count - 1;
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
            posicao = lista_tipofunc.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_TipoFunc c_TipoFunc = new C_TipoFunc();
            DataTable dt = new DataTable();
            dt = c_TipoFunc.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_TipoFunc = dt;
            dataGridView1.DataSource = Tabela_TipoFunc;

            lista_tipofunc = carregaListaTipoFuncFiltro();

            if(lista_tipofunc.Count - 1 > 0)
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
            txtTipoFunc.Text = dr.Cells[1].Value.ToString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtTipoFunc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
