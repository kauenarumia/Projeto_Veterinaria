using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Funcionario : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_funcionario;
        SqlDataAdapter da_funcionario;

        String sqlInsere = "INSERT INTO funcionario (nomefuncionario, codtipofuncionariofk, codlojafk) VALUES (@pnome, @pcodtipofuncionario, @pcodloja)";
        String sqlApaga = "DELETE FROM funcionario WHERE codfuncionario = @pcodfuncionario";
        String sqlAtualiza = "UPDATE funcionario SET nomefuncionario = @pnomefuncionario, codtipofuncionariofk = @pcodtipofuncionario, codfuncionariofk = @pcodfuncionario WHERE codfuncionario = @pcodfuncionario";
        String sqlTodos = "SELECT * FROM funcionario";
        String sqlFiltro = "SELECT * FROM funcionario WHERE nomefuncionario LIKE @pnomefuncionario";


        public List<Funcionario> DadosFuncionario()
        {
            List<Funcionario> lista_funcionario = new List<Funcionario>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_funcionario;
            conn.Open();

            try
            {
                dr_funcionario = cmd.ExecuteReader();
                while (dr_funcionario.Read())
                {
                    Funcionario aux = new Funcionario();
                    aux.codfuncionario = Int32.Parse(dr_funcionario["codfuncionario"].ToString());
                    aux.nomefuncionario = dr_funcionario["nomefuncionario"].ToString();
                    lista_funcionario.Add(aux);

                    Tipofuncionario tipofuncionario = new Tipofuncionario();
                    tipofuncionario.codtipofuncionario = Int32.Parse(dr_funcionario["codtipofuncionario"].ToString());
                    aux.tipofuncionario = tipofuncionario;

                    Loja loja = new Loja();
                    loja.codloja = Int32.Parse(dr_funcionario["codloja"].ToString());
                    aux.loja = loja;
                }
            }
            catch
            {

            }
            return lista_funcionario;
        }

        public List<Funcionario> DadosFuncionarioFiltro(String parametro)
        {
            List<Funcionario> lista_funcionario = new List<Funcionario>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomefuncionario", parametro + "%");

            SqlDataReader dr_funcionario;
            conn.Open();

            try
            {
                dr_funcionario = cmd.ExecuteReader();
                while (dr_funcionario.Read())
                {
                    Funcionario aux = new Funcionario();
                    aux.codfuncionario = Int32.Parse(dr_funcionario["codfuncionario"].ToString());
                    aux.nomefuncionario = dr_funcionario["nomefuncionario"].ToString();
                    lista_funcionario.Add(aux);
                }
            }
            catch
            {

            }
            return lista_funcionario;
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
            Funcionario dados = new Funcionario();
            dados = (Funcionario) aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnomefuncionario", dados.nomefuncionario);
            cmd.Parameters.AddWithValue("@pcodtipofuncionario", dados.tipofuncionario);
            cmd.Parameters.AddWithValue("@pcodfuncionario", dados.codfuncionario);
            cmd.Parameters.AddWithValue("@pcodloja", dados.loja);
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

        public DataTable Buscar_Filtro(String pfuncionario)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomefuncionario", pfuncionario);
            conn.Open();

            da_funcionario = new SqlDataAdapter(cmd);
            dt_funcionario = new DataTable();
            da_funcionario.Fill(dt_funcionario);

            return dt_funcionario;
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

            da_funcionario = new SqlDataAdapter(cmd);
            dt_funcionario = new DataTable();
            da_funcionario.Fill(dt_funcionario);

            return dt_funcionario;
        }

        public void Insere_Dados(object aux)
        {
            Funcionario funcionario = new Funcionario();
            funcionario = (Funcionario)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", funcionario.nomefuncionario);
            cmd.Parameters.AddWithValue("@pcodtipofuncionario", funcionario.tipofuncionario.codtipofuncionario);
            cmd.Parameters.AddWithValue("@pcodloja", funcionario.loja.codloja);

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
