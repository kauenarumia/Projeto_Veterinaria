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
    internal class C_Rua : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_rua;
        SqlDataAdapter da_rua;

        String sqlInsere = "insert into rua(nomerua) values (@pnome)";
        String sqlApaga = "delete from rua where codrua = @pcod";
        String sqlAtualiza = "update rua set nomerua = @pnome where codrua = @pcod";
        String sqlTodos = "select * from rua";
        String sqlFiltro = "select * from rua where nomerua like @pnomerua";

        public List<Rua> DadosRua()
        {
            List<Rua> lista_rua = new List<Rua>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_rua;
            conn.Open();

            try
            {
                dr_rua = cmd.ExecuteReader();
                while (dr_rua.Read())
                {
                    Rua aux = new Rua();
                    aux.codrua = Int32.Parse(dr_rua["codrua"].ToString());
                    aux.nomerua = dr_rua["nomerua"].ToString();
                    lista_rua.Add(aux);
                }
            }
            catch
            {

            }
            return lista_rua;
        }

        public List<Rua> DadosRuaFiltro(String parametro)
        {
            List<Rua> lista_rua = new List<Rua>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomerua", parametro + "%");

            SqlDataReader dr_rua;
            conn.Open();

            try
            {
                dr_rua = cmd.ExecuteReader();
                while (dr_rua.Read())
                {
                    Rua aux = new Rua();
                    aux.codrua = Int32.Parse(dr_rua["codrua"].ToString());
                    aux.nomerua = dr_rua["nomerua"].ToString();
                    lista_rua.Add(aux);
                }
            }
            catch
            {

            }
            return lista_rua;
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
            Rua dados = new Rua();
            dados = (Rua)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codrua);
            cmd.Parameters.AddWithValue("@pnome", dados.nomerua);
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

        public DataTable Buscar_Filtro(String prua)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomerua", prua);
            conn.Open();

            da_rua = new SqlDataAdapter(cmd);
            dt_rua = new DataTable();
            da_rua.Fill(dt_rua);

            return dt_rua;
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

            da_rua = new SqlDataAdapter(cmd);
            dt_rua = new DataTable();
            da_rua.Fill(dt_rua);

            return dt_rua;
        }

        public void Insere_Dados(object aux)
        {
            Rua rua = new Rua();
            rua = (Rua)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", rua.nomerua);

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