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
    public partial class FrmVenda : Form
    {
        DataTable Tabela_Venda;
        Boolean novo;
        int posicao;
        List<Venda> lista_venda = new List<Venda>();

        List<Cliente> clientes = new List<Cliente>();
        int posicao_cliente;
        int codcliente;
        List<Funcionario> funcionarios = new List<Funcionario>();
        int posicao_funcionario;
        int codfuncionario;
        List<Loja> lojas = new List<Loja>();
        int posicao_loja;
        int codloja;

        public FrmVenda()
        {
            InitializeComponent();
            CarregaTabela();

            lista_venda = carregaListaVenda();
            if (lista_venda.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

            preencheComboCliente();
            preencheComboFuncionario();
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

        private void preencheComboFuncionario()
        {
            C_Funcionario c_Funcionario = new C_Funcionario();

            funcionarios = c_Funcionario.DadosFuncionario();
            foreach(Funcionario funcionario in funcionarios)
            {
                cbFuncionario.Items.Add(funcionario.nomefuncionario);
            }
        }

        private void preencheComboCliente()
        {
            C_Cliente c_Cliente = new C_Cliente();

            clientes = c_Cliente.DadosCliente();
            foreach (Cliente cliente in clientes)
            {
                cbCliente.Items.Add(cliente.nomecliente);
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_venda[posicao].ToString();
            txtDataVenda.Text = lista_venda[posicao].ToString();
            cbCliente.Text = lista_venda[posicao].ToString();
            cbFuncionario.Text = lista_venda[posicao].ToString();
            cbLoja.Text = lista_venda[posicao].ToString();
        }

        List<Venda> carregaListaVenda()
        {
            List<Venda> lista = new List<Venda>();

            C_Venda c_Venda = new C_Venda();
            lista = c_Venda.DadosVenda();

            return lista;
        }

        List<Venda> carregaListaVendaFiltro()
        {
            List<Venda> lista = new List<Venda>();

            C_Venda c_Venda = new C_Venda();
            lista = c_Venda.DadosVendaFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_Venda c_Venda = new C_Venda();
            DataTable dt = new DataTable();
            dt = c_Venda.Buscar_Todos();
            Tabela_Venda = dt;
            dataGridView1.DataSource = Tabela_Venda;
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            
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
            txtDataVenda.Enabled = true;
            cbCliente.Enabled = true;
            cbFuncionario.Enabled = true;
            cbLoja.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtDataVenda.Text = "";
            cbCliente.Text = "";
            cbFuncionario.Text = "";
            cbLoja.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            ativarCampos();
            ativaBotoes();

            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Venda venda = new Venda();
            venda.datavenda = txtDataVenda.Text;

            Cliente cliente = new Cliente();
            cliente.codcliente = codcliente;
            venda.cliente = cliente;

            Funcionario funcionario = new Funcionario();
            funcionario.codfuncionario = codfuncionario;
            venda.funcionario = funcionario;

            Loja loja = new Loja();
            loja.codloja = codloja;
            venda.loja = loja;

            C_Venda c_Venda = new C_Venda();
            if (novo == true)
            {
                c_Venda.Insere_Dados(venda);
            }
            else
            {
                venda.codvenda = Int32.Parse(txtCodigo.Text);
                c_Venda.Atualizar_Dados(venda);
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

        private void desativaCampos()
        {
            txtDataVenda.Enabled = false;
            cbCliente.Enabled = false;
            cbFuncionario.Enabled = false;
            cbLoja.Enabled = false;
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
                C_Venda venda = new C_Venda();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    venda.Apaga_Dados(valor);
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
            int total = lista_venda.Count - 1;
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
            posicao = lista_venda.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Venda c_Venda = new C_Venda();
            DataTable dt = new DataTable();
            dt = c_Venda.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Venda = dt;
            dataGridView1.DataSource = Tabela_Venda;

            lista_venda = carregaListaVendaFiltro();

            if (lista_venda.Count - 1 > 0)
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
            txtDataVenda.Text = dr.Cells[1].Value.ToString();
            cbCliente.Text = dr.Cells[2].Value.ToString();
            cbFuncionario.Text = dr.Cells[3].Value.ToString();
            cbLoja.Text = dr.Cells[4].Value.ToString();
        }

        private void cbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_cliente = cbCliente.SelectedIndex;
            codcliente = clientes[posicao_cliente].codcliente;
        }

        private void cbFuncionario_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_funcionario = cbFuncionario.SelectedIndex;
            codfuncionario = funcionarios[posicao_funcionario].codfuncionario;
        }

        private void cbLoja_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_loja = cbLoja.SelectedIndex;
            codloja = lojas[posicao_loja].codloja;
        }
    }
}
