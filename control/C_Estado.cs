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
    internal class C_Estado : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_estado;
        SqlDataAdapter da_estado;

        String sqlInsere = "insert into estado(nomeestado) values (@pnome)";
        String sqlApaga = "delete from estado where codestado = @pcod";
        String sqlAtualiza = "update estado set nomeestado = @pnome where codestado = @pcod";
        String sqlTodos = "select * from estado";
        String sqlFiltro = "select * from estado where nomeestado like @pnomeestado";

        public List<Estado> DadosEstado()
        {
            List<Estado> lista_estado = new List<Estado>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_estado;
            conn.Open();

            try
            {
                dr_estado = cmd.ExecuteReader();
                while (dr_estado.Read())
                {
                    Estado aux = new Estado();
                    aux.codestado = Int32.Parse(dr_estado["codestado"].ToString());
                    aux.nomeestado = dr_estado["nomeestado"].ToString();
                    lista_estado.Add(aux);
                }
            }
            catch
            {

            }
            return lista_estado;
        }

        public List<Estado> DadosEstadoFiltro(String parametro)
        {
            List<Estado> lista_estado = new List<Estado>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeestado", parametro + "%");

            SqlDataReader dr_estado;
            conn.Open();

            try
            {
                dr_estado = cmd.ExecuteReader();
                while (dr_estado.Read())
                {
                    Estado aux = new Estado();
                    aux.codestado = Int32.Parse(dr_estado["codestado"].ToString());
                    aux.nomeestado = dr_estado["nomeestado"].ToString();
                    lista_estado.Add(aux);
                }
            }
            catch
            {

            }
            return lista_estado;
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
            Estado dados = new Estado();
            dados = (Estado)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codestado);
            cmd.Parameters.AddWithValue("@pnome", dados.nomeestado);
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

        public DataTable Buscar_Filtro(String pestado)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeestado", pestado);
            conn.Open();

            da_estado = new SqlDataAdapter(cmd);
            dt_estado = new DataTable();
            da_estado.Fill(dt_estado);

            return dt_estado;
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

            da_estado = new SqlDataAdapter(cmd);
            dt_estado = new DataTable();
            da_estado.Fill(dt_estado);

            return dt_estado;
        }

        public void Insere_Dados(object aux)
        {
            Estado estado = new Estado();
            estado = (Estado)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", estado.nomeestado);

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
