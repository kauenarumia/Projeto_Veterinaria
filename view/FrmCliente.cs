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
    public partial class FrmCliente : Form
    {
        DataTable Tabela_Cliente;
        Boolean novo;
        int posicao;
        List<Cliente> lista_cliente = new List<Cliente>();

        List<Rua> ruas = new List<Rua>();
        int posicao_rua;
        int codrua;
        List<Bairro> bairros = new List<Bairro>();
        int posicao_bairro;
        int codbairro;
        List<Cidade> cidades = new List<Cidade>();
        int posicao_cidade;
        int codcidade;
        List<Pais> paises = new List<Pais>();
        int posicao_pais;
        int codpais;
        List<Cep> ceps = new List<Cep>();
        int posicao_cep;
        int codcep;
        List<Estado> estados = new List<Estado>();
        int posicao_estado;
        int codestado;


        public FrmCliente()
        {
            InitializeComponent();
            CarregaTabela();

            lista_cliente = carregaListaCliente();
            if (lista_cliente.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

            preencheComboRua();
            preencheComboBairro();
            preencheComboCidade();
            preencheComboPais();
            preencheComboCep();
            preencheComboEstado();
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_cliente[posicao].codcliente.ToString();
            txtNome.Text = lista_cliente[posicao].nomecliente.ToString();
            txtCPF.Text = lista_cliente[posicao].cpf.ToString();
            cbBairro.Text = lista_cliente[posicao].bairro.ToString();
            cbRua.Text = lista_cliente[posicao].rua.ToString();
            cbCEP.Text = lista_cliente[posicao].cep.ToString();
            cbCidade.Text = lista_cliente[posicao].cidade.ToString();
            cbEstado.Text = lista_cliente[posicao].estado.ToString();
            cbPais.Text = lista_cliente[posicao].pais.ToString();
            txtNumeroCasa.Text = lista_cliente[posicao].numerocasa.ToString();
        }

        List<Cliente> carregaListaCliente()
        {
            List<Cliente> lista = new List<Cliente>();

            C_Cliente c_Cliente = new C_Cliente();
            lista = c_Cliente.DadosCliente();

            return lista;
        }

        List<Cliente> carregaListaClienteFiltro()
        {
            List<Cliente> lista = new List<Cliente>();

            C_Cliente c_Cliente = new C_Cliente();
            lista = c_Cliente.DadosClienteFiltro(txtBuscar.Text);

            return lista;
        }

        private void CarregaTabela()
        {
            C_Cliente c_Cliente = new C_Cliente();
            DataTable dt = new DataTable();
            dt = c_Cliente.Buscar_Todos();
            Tabela_Cliente = dt;
            dataGridView1.DataSource = Tabela_Cliente;
        }

        private void preencheComboEstado()
        {
            C_Estado c_Estado = new C_Estado();

            estados = c_Estado.DadosEstado();
            foreach (Estado estado in estados)
            {
                cbEstado.Items.Add(estado.nomeestado);
            }
        }

        private void preencheComboCep()
        {
            C_Cep c_Cep = new C_Cep();

            ceps = c_Cep.DadosCep();
            foreach (Cep cep in ceps)
            {
                cbCEP.Items.Add(cep.numerocep);
            }
        }

        private void preencheComboPais()
        {
            C_Pais c_Pais = new C_Pais();

            paises = c_Pais.DadosPais();
            foreach (Pais pais in paises)
            {
                cbPais.Items.Add(pais.nomepais);
            }
        }

        private void preencheComboCidade()
        {
            C_Cidade c_Cidade = new C_Cidade();

            cidades = c_Cidade.DadosCidade();
            foreach (Cidade c in cidades)
            {
                cbCidade.Items.Add(c.nomecidade);
            }

        }

        private void preencheComboBairro()
        {
            C_Bairro c_Bairro = new C_Bairro();

            bairros = c_Bairro.DadosBairro();
            foreach (Bairro b in bairros)
            {
                cbBairro.Items.Add(b.nomebairro);
            }
        }

        private void preencheComboRua()
        {
            C_Rua c_Rua = new C_Rua();

            ruas = c_Rua.DadosRua();
            foreach (Rua rua in ruas)
            {
                cbRua.Items.Add(rua.nomerua);
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
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
            txtCPF.Enabled = true;
            cbBairro.Enabled = true;
            cbRua.Enabled = true;
            cbCEP.Enabled = true;
            cbCidade.Enabled = true;
            cbEstado.Enabled = true;
            cbPais.Enabled = true;
            txtNumeroCasa.Enabled = true;
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            cbBairro.Text = "";
            cbRua.Text = "";
            cbCEP.Text = "";
            cbCidade.Text = "";
            cbEstado.Text = "";
            cbPais.Text = "";
            txtNumeroCasa.Text = "";
        }

        private void desativaCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            cbBairro.Enabled = false;
            cbRua.Enabled = false;
            cbCEP.Enabled = false;
            cbCidade.Enabled = false;
            cbEstado.Enabled = false;
            cbPais.Enabled = false;
            txtNumeroCasa.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.nomecliente = txtNome.Text;

            Bairro bairro = new Bairro();
            bairro.codbairro = codbairro;
            cliente.bairro = bairro;

            Rua rua = new Rua();
            rua.codrua = codrua;
            cliente.rua = rua;

            Cep cep = new Cep();
            cep.codcep = codcep;
            cliente.cep = cep;

            Cidade cidade = new Cidade();
            cidade.codcidade = codcidade;

            cliente.cidade = cidade;

            Estado estado = new Estado();
            estado.codestado = codestado;
            cliente.estado = estado;

            Pais pais = new Pais();
            pais.codpais = codpais;
            cliente.pais = pais;

            cliente.numerocasa = txtNumeroCasa.Text;
            cliente.cpf = txtCPF.Text;

            C_Cliente c_Cliente = new C_Cliente();
            if (novo == true)
            {
                c_Cliente.Insere_Dados(cliente);
            }
            else
            {
                cliente.codcliente = Int32.Parse(txtNome.Text);
                c_Cliente.Atualizar_Dados(cliente);
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
                C_Cliente cliente = new C_Cliente();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    cliente.Apaga_Dados(valor);
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
            int total = lista_cliente.Count - 1;
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
            posicao = lista_cliente.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Cliente c_Cliente = new C_Cliente();
            DataTable dt = new DataTable();
            dt = c_Cliente.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Cliente = dt;
            dataGridView1.DataSource = Tabela_Cliente;

            lista_cliente = carregaListaClienteFiltro();

            if (lista_cliente.Count - 1 > 0)
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
            txtCPF.Text = dr.Cells[2].Value.ToString();
            cbBairro.Text = dr.Cells[3].Value.ToString();
            cbRua.Text = dr.Cells[4].Value.ToString();
            cbCEP.Text = dr.Cells[5].Value.ToString();
            cbCidade.Text = dr.Cells[6].Value.ToString();
            cbEstado.Text = dr.Cells[7].Value.ToString();
            cbPais.Text = dr.Cells[8].Value.ToString();
            txtNumeroCasa.Text = dr.Cells[9].Value.ToString();
        }

        private void cbRua_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_rua = cbRua.SelectedIndex;
            codrua = ruas[posicao_rua].codrua;
        }

      

     

        private void cbPais_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_pais = cbPais.SelectedIndex;
            codpais = paises[posicao_pais].codpais;
        }

        private void cbCEP_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_cep = cbCEP.SelectedIndex;
            codcep = ceps[posicao_cep].codcep;
        }

        private void cbEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_estado = cbEstado.SelectedIndex;
            codestado = estados[posicao_estado].codestado;
        }

        private void cbBairro_SelectedValueChanged_1(object sender, EventArgs e)
        {
            posicao_bairro = cbBairro.SelectedIndex;
            codbairro = bairros[posicao_bairro].codbairro;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbCidade_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_cidade = cbCidade.SelectedIndex;
            codcidade = cidades[posicao_cidade].codcidade;
        }
    }
}
