using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;
using Veterinaria.view;

namespace Veterinaria.control
{
    internal class C_TipoFunc : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_tipofunc;
        SqlDataAdapter da_tipofunc;

        String sqlInsere = "insert into tipofuncionario(nometipofuncionario) values (@pnome)";
        String sqlApaga = "delete from tipofuncionario where codtipofuncionario = @pcod";
        String sqlAtualiza = "update tipofuncionario set nometipofuncionario = @pnome where codtipofuncionario = @pcod";
        String sqlTodos = "select * from tipofuncionario";
        String sqlFiltro = "select * from tipofuncionario where nometipofuncionario like @pnometipofuncionario";

        public List<Tipofuncionario> DadosTipoFunc()
        {
            List<Tipofuncionario> lista_tipofunc = new List<Tipofuncionario>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_tipofunc;
            conn.Open();

            try
            {
                dr_tipofunc = cmd.ExecuteReader();
                while (dr_tipofunc.Read())
                {
                    Tipofuncionario aux = new Tipofuncionario();
                    aux.codtipofuncionario = Int32.Parse(dr_tipofunc["codtipofuncionario"].ToString());
                    aux.nometipofuncionario = dr_tipofunc["nometipofuncionario"].ToString();
                    lista_tipofunc.Add(aux);
                }
            }
            catch
            {

            }
            return lista_tipofunc;
        }

        public List<Tipofuncionario> DadosTipoFuncFiltro(String parametro)
        {
            List<Tipofuncionario> lista__tipofunc = new List<Tipofuncionario>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnometipofuncionario", parametro + "%");

            SqlDataReader dr_tipofunc;
            conn.Open();

            try
            {
                dr_tipofunc = cmd.ExecuteReader();
                while (dr_tipofunc.Read())
                {
                    Tipofuncionario aux = new Tipofuncionario();
                    aux.codtipofuncionario = Int32.Parse(dr_tipofunc["codrua"].ToString());
                    aux.nometipofuncionario = dr_tipofunc["nomerua"].ToString();
                    lista__tipofunc.Add(aux);
                }
            }
            catch
            {

            }
            return lista__tipofunc;
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
            Tipofuncionario dados = new Tipofuncionario();
            dados = (Tipofuncionario)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codtipofuncionario);
            cmd.Parameters.AddWithValue("@pnome", dados.nometipofuncionario);
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

        public DataTable Buscar_Filtro(String ptipofuncionario)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnometipofuncionario", ptipofuncionario);
            conn.Open();

            da_tipofunc = new SqlDataAdapter(cmd);
            dt_tipofunc = new DataTable();
            da_tipofunc.Fill(dt_tipofunc);

            return dt_tipofunc;
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

            da_tipofunc = new SqlDataAdapter(cmd);
            dt_tipofunc = new DataTable();
            da_tipofunc.Fill(dt_tipofunc);

            return dt_tipofunc;
        }

        public void Insere_Dados(object aux)
        {
            Tipofuncionario tipofuncionario = new Tipofuncionario();
            tipofuncionario = (Tipofuncionario)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", tipofuncionario.nometipofuncionario);

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
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
