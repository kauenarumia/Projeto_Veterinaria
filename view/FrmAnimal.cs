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
    public partial class FrmAnimal : Form
    {
        DataTable Tabela_Animal;
        Boolean novo;
        int posicao;
        List<Animal> lista_animal = new List<Animal>();

        List<Sexo> sexos = new List<Sexo>();
        int posicao_sexo;
        int codsexo;
        List<Raca> racas = new List<Raca>();
        int posicao_raca;
        int codraca;
        List<Tipoanimal> tipoanimais = new List<Tipoanimal>();
        int posicao_tipoanimal;
        int codtipoanimal;
        List<Cliente> clientes = new List<Cliente>();
        int posicao_cliente;
        int codcliente;

        public FrmAnimal()
        {
            InitializeComponent();
            CarregaTabela();

            lista_animal = carregaListaAnimal();
            if (lista_animal.Count - 1 > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

            preencheComboSexo();
            preencheComboRaca();
            preencheComboTipoAnimal();
            preencheComboCliente();
        }

        

        List<Animal> carregaListaAnimal()
        {
            List<Animal> lista = new List<Animal>();

            C_Animal c_Animal = new C_Animal();
            lista = c_Animal.DadosAnimal();

            return lista;
        }

        List<Animal> carregaListaAnimalFiltro()
        {
            List<Animal> lista = new List<Animal>();

            C_Animal c_Animal = new C_Animal();
            lista = c_Animal.DadosAnimalFiltro(txtBuscar.Text);

            return lista;
        }

        private void preencheComboCliente()
        {
            C_Cliente c_Cliente = new C_Cliente();

            clientes = c_Cliente.DadosCliente();
            foreach(Cliente cliente in clientes)
            {
                cbCliente.Items.Add(cliente.nomecliente);
            }
        }

        private void preencheComboTipoAnimal()
        {
            C_TpAnimal c_TpAnimal = new C_TpAnimal();

            tipoanimais = c_TpAnimal.DadosTipoAnimal();
            foreach(Tipoanimal tipoanimal in tipoanimais)
            {
                cbTipoAnimal.Items.Add(tipoanimal.nometipoanimal);
            }
        }

        private void preencheComboRaca()
        {
            C_Raca c_Raca = new C_Raca();

            racas = c_Raca.DadosRaca();
            foreach(Raca raca in racas)
            {
                cbRaca.Items.Add(raca.nomeraca);
            }
        }

        private void preencheComboSexo()
        {
            C_Sexo c_Sexo = new C_Sexo();

            sexos = c_Sexo.DadosSexo();
            foreach(Sexo sexo in sexos)
            {
                cbSexo.Items.Add(sexo.nomesexo);
            }
        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_animal[posicao].codanimal.ToString();
            txtNome.Text = lista_animal[posicao].nomeanimal.ToString();
            cbSexo.Text = lista_animal[posicao].sexo.ToString();
            cbRaca.Text = lista_animal[posicao].raca.ToString();
            cbTipoAnimal.Text = lista_animal[posicao].tipoanimal.ToString();
            cbCliente.Text = lista_animal[posicao].cliente.ToString();
        }

        private void CarregaTabela()
        {
            C_Animal c_Animal = new C_Animal();
            DataTable dt = new DataTable();
            dt = c_Animal.Buscar_Todos();
            Tabela_Animal = dt;
            dataGridView1.DataSource = Tabela_Animal;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
            cbSexo.Enabled = true;
            cbRaca.Enabled = true;
            cbTipoAnimal.Enabled = true;
            cbCliente.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            cbSexo.Text = "";
            cbRaca.Text = "";
            cbTipoAnimal.Text = "";
            cbCliente.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            animal.nomeanimal = txtNome.Text;

            Sexo sexo = new Sexo();
            sexo.codsexo = codsexo;
            animal.sexo = sexo;

            Raca raca = new Raca();
            raca.codraca = codraca;
            animal.raca = raca;

            Tipoanimal tipoanimal = new Tipoanimal();
            tipoanimal.codtipoanimal = codtipoanimal;
            animal.tipoanimal = tipoanimal;

            Cliente cliente = new Cliente();
            cliente.codcliente = codcliente;
            animal.cliente = cliente;

            C_Animal c_Animal = new C_Animal();
            if (novo == true)
            {
                c_Animal.Insere_Dados(animal);
            }
            else
            {
                animal.codanimal = Int32.Parse(txtCodigo.Text);
                c_Animal.Atualizar_Dados(animal);
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
            txtNome.Enabled = false;
            cbSexo.Enabled = false;
            cbRaca.Enabled = false;
            cbTipoAnimal.Enabled = false;
            cbCliente.Enabled = false;
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
                C_Animal animal = new C_Animal();

                if (txtCodigo.Text != "")
                {
                    int valor = Int32.Parse(txtCodigo.Text);
                    animal.Apaga_Dados(valor);
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
            int total = lista_animal.Count - 1;
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
            posicao = lista_animal.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            C_Animal c_Animal = new C_Animal();
            DataTable dt = new DataTable();
            dt = c_Animal.Buscar_Filtro(txtBuscar.Text.ToString() + "%");
            Tabela_Animal = dt;
            dataGridView1.DataSource = Tabela_Animal;

            lista_animal = carregaListaAnimalFiltro();

            if (lista_animal.Count - 1 > 0)
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
            cbSexo.Text = dr.Cells[2].Value.ToString();
            cbRaca.Text = dr.Cells[3].Value.ToString();
            cbTipoAnimal.Text = dr.Cells[4].Value.ToString();
            cbCliente.Text = dr.Cells[5].Value.ToString();
        }

        private void cbSexo_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_sexo = cbSexo.SelectedIndex;
            codsexo = sexos[posicao_sexo].codsexo;
        }

        private void cbRaca_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_raca = cbRaca.SelectedIndex;
            codraca = racas[posicao_raca].codraca;
        }

        private void cbTipoAnimal_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_tipoanimal = cbTipoAnimal.SelectedIndex;
            codtipoanimal = tipoanimais[posicao_tipoanimal].codtipoanimal;
        }

        private void cbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            posicao_cliente = cbCliente.SelectedIndex;
            codcliente = clientes[posicao_cliente].codcliente;
        }

        private void FrmAnimal_Load(object sender, EventArgs e)
        {

        }
    }
}
