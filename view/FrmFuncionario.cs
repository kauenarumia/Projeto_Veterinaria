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
    public partial class FrmFuncionario : Form
    {
        DataTable Tabela_Funcionario;
        Boolean novo;
        int posicao;
        List<Funcionario> lista_funcionario = new List<Funcionario>();

        List<Tipofuncionario> tipofuncionarios = new List<Tipofuncionario>();
        int posicao_tipofuncionario;
        int codtipofuncionario;
        List<Loja> lojas = new List<Loja>();
        int posicao_loja;
        int codloja;

        public FrmFuncionario()
        {
            InitializeComponent();
            CarregaTabela();

            lista_funcionario = carregaListaFuncionario();
            if (lista_funcionario.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

            preencheComboTipoFunc();
            preencheComboLoja();
        }

        private void preencheComboLoja()
        {
            C_Loja c_Loja = new C_Loja();

            lojas = c_Loja.DadosLoja();
            foreach(Loja loja in lojas)
            {
                cbLoja.Items.Add(loja.nomeloja);
            }
        }

        private void preencheComboTipoFunc()
        {
            C_TipoFunc c_TipoFunc = new C_TipoFunc();

            tipofuncionarios = c_TipoFunc.DadosTipoFunc();
            foreach(Tipofuncionario tipofuncionario in tipofuncionarios)
            {
                cbTipoFunc.Items.Add(tipofuncionario.nometipofuncionario);
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_funcionario[posicao].codfuncionario.ToString();
            txtNomeFunc.Text = lista_funcionario[posicao].nomefuncionario.ToString();
            cbTipoFunc.Text = lista_funcionario[posicao].tipofuncionario.ToString();
            cbLoja.Text = lista_funcionario[posicao].loja.ToString();
        }

        List<Funcionario> carregaListaFuncionario()
        {
            List<Funcionario> lista = new List<Funcionario>();

            C_Funcionario c_Funcionario = new C_Funcionario();
            lista = c_Funcionario.DadosFuncionario();

            return lista;
        }

        List<Funcionario> carregaListaFuncionarioFiltro()
        {
            List<Funcionario> lista = new List<Funcionario>();

            C_Funcionario c_Funcionario = new C_Funcionario();
            lista = c_Funcionario.DadosFuncionarioFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_Funcionario c_Funcionario = new C_Funcionario();
            DataTable dt = new DataTable();
            dt = c_Funcionario.Buscar_Todos();
            Tabela_Funcionario = dt;
            dataGridView1.DataSource = Tabela_Funcionario;
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
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
            txtNomeFunc.Enabled = true;
            cbTipoFunc.Enabled = true;
            cbLoja.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtNomeFunc.Text = "";
            cbTipoFunc.Text = "";
            cbLoja.Text = "";
        }

        private void desativaCampos()
        {
            txtNomeFunc.Enabled = false;
            cbTipoFunc.Enabled = false;
            cbLoja.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.nomefuncionario = txtNomeFunc.Text;

            Tipofuncionario tipofuncionario = new Tipofuncionario();
            tipofuncionario.codtipofuncionario = codtipofuncionario;
            funcionario.tipofuncionario = tipofuncionario;

            Loja loja = new Loja();
            loja.codloja = codloja;
            funcionario.loja = loja;

            C_Funcionario c_Funcionario = new C_Funcionario();
            if(novo == true)
            {
                c_Funcionario.Insere_Dados(funcionario);
            }
            else
            {
                funcionario.codfuncionario = Int32.Parse(txtNomeFunc.Text);
                c_Funcionario.Atualizar_Dados(funcionario);
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
                C_Funcionario funcionario = new C_Funcionario();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    funcionario.Apaga_Dados(valor);
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
            int total = lista_funcionario.Count - 1;
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
            posicao = lista_funcionario.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Funcionario c_Funcionario = new C_Funcionario();
            DataTable dt = new DataTable();
            dt = c_Funcionario.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Funcionario = dt;
            dataGridView1.DataSource = Tabela_Funcionario;

            lista_funcionario = carregaListaFuncionarioFiltro();

            if (lista_funcionario.Count - 1 > 0)
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
            txtNomeFunc.Text = dr.Cells[1].Value.ToString();
            cbTipoFunc.Text = dr.Cells[2].Value.ToString();
            cbLoja.Text = dr.Cells[3].Value.ToString();
        }

        private void cbTipoFunc_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_tipofuncionario = cbTipoFunc.SelectedIndex;
            codtipofuncionario = tipofuncionarios[posicao_tipofuncionario].codtipofuncionario;
        }

        private void cbLoja_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_loja = cbLoja.SelectedIndex;
            codloja = lojas[posicao_loja].codloja;
        }
    }
}
