using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.control;

namespace Veterinaria.model
{
    internal class C_Venda : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_venda;
        SqlDataAdapter da_venda;


        String sqlInsere = "insert into venda(datavenda, codclientefk, codfuncionariofk, codlojafk) values(@pdatavenda, @pcodcliente, @pcodfuncionario, @pcodloja)";
        String sqlApaga = "delete from venda where codvenda = @pcodvenda";
        String sqlAtualiza = "update venda set datavenda = @pdatavenda, codclientefk = @pcodclientefk, codfuncionariofk = @pcodfuncionariofk, codlojafk = @pcodlojafk where codvenda = @pcodvenda";
        String sqlTodos = "select * from venda";
        String sqlFiltro = "select * from venda where codvenda = @pcodvenda or codclientefk = @pcodclientefk or codfuncionariofk = @pcodfuncionariofk or codlojafk = @pcodlojafk";


        public List<Venda> DadosVenda()
        {
            List<Venda> lista_venda = new List<Venda>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_venda;
            conn.Open();

            try
            {
                dr_venda = cmd.ExecuteReader();
                while (dr_venda.Read())
                {
                    Venda aux = new Venda();
                    aux.codvenda = Int32.Parse(dr_venda["codvenda"].ToString());
                    aux.datavenda = dr_venda["datavenda"].ToString();
                    lista_venda.Add(aux);

                    Cliente cliente = new Cliente();
                    cliente.codcliente = Int32.Parse(dr_venda["codcliente"].ToString());
                    aux.cliente = cliente;

                    Funcionario funcionario = new Funcionario();
                    funcionario.codfuncionario = Int32.Parse(dr_venda["codfuncionario"].ToString());
                    aux.funcionario = funcionario;

                    Loja loja = new Loja();
                    loja.codloja = Int32.Parse(dr_venda["codloja"].ToString());
                    aux.loja = loja;

                }
            }
            catch
            {

            }
            return lista_venda;
        }


        public List<Venda> DadosVendaFiltro(String parametro)
        {
            List<Venda> lista_venda = new List<Venda>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pdatavenda", parametro + "%");

            SqlDataReader dr_venda;
            conn.Open();

            try
            {
                dr_venda = cmd.ExecuteReader();
                while (dr_venda.Read())
                {
                    Venda aux = new Venda();
                    aux.codvenda = Int32.Parse(dr_venda["codvenda"].ToString());
                    aux.datavenda = dr_venda["datavenda"].ToString();
                    lista_venda.Add(aux);

                    Cliente cliente = new Cliente();
                    cliente.codcliente = Int32.Parse(dr_venda["codcliente"].ToString());
                    aux.cliente = cliente;

                    Funcionario funcionario = new Funcionario();
                    funcionario.codfuncionario = Int32.Parse(dr_venda["codfuncionario"].ToString());
                    aux.funcionario = funcionario;

                    Loja loja = new Loja();
                    loja.codloja = Int32.Parse(dr_venda["codloja"].ToString());
                    aux.loja = loja;

                }
            }
            catch
            {

            }
            return lista_venda;
        }
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcod", aux);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Apagado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }
        }

        public void Atualizar_Dados(object aux)
        {
            Venda dados = new Venda();
            dados = (Venda)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pdatavenda" +
                "" +
                "", dados.datavenda);
            cmd.Parameters.AddWithValue("@pcliente", dados.cliente);
            cmd.Parameters.AddWithValue("@pfuncionario", dados.funcionario);
            cmd.Parameters.AddWithValue("@ploja", dados.loja);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Atualizado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Buscar_Filtro(String pvenda)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pdatavenda", pvenda);
            conn.Open();

            da_venda = new SqlDataAdapter(cmd);
            dt_venda = new DataTable();
            da_venda.Fill(dt_venda);

            return dt_venda;
        }

        public object Buscar_Id(int valor)
        {
            throw new NotImplementedException();
        }

        public DataTable Buscar_Todos()
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            conn.Open();

            da_venda = new SqlDataAdapter(cmd);
            dt_venda = new DataTable();
            da_venda.Fill(dt_venda);

            return dt_venda;
        }

        public void Insere_Dados(object aux)
        {
            Venda venda = new Venda();
            venda = (Venda)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pdatavenda", venda.datavenda);
            cmd.Parameters.AddWithValue("@pcodcliente", venda.cliente.codcliente);
            cmd.Parameters.AddWithValue("@pcodfuncionario", venda.funcionario.codfuncionario);
            cmd.Parameters.AddWithValue("@pcodloja", venda.loja.codloja);


            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Inseriu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
