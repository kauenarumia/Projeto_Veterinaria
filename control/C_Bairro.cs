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
    internal class C_Bairro : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_bairro;
        SqlDataAdapter da_bairro;

        String sqlInsere = "insert into bairro(nomebairro) values (@pnome)";
        String sqlApaga = "delete from bairro where codbairro = @pcod";
        String sqlAtualiza = "update bairro set nomebairro = @pnome where codbairro = @pcod";
        String sqlTodos = "select * from bairro";
        String sqlFiltro = "select * from bairro where nomebairro like @pnomebairro";

        public List<Bairro> DadosBairro()
        {
            List<Bairro> lista_bairro = new List<Bairro>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_bairro;
            conn.Open();

            try
            {
                dr_bairro = cmd.ExecuteReader();
                while (dr_bairro.Read())
                {
                    Bairro aux = new Bairro();
                    aux.codbairro = Int32.Parse(dr_bairro["codbairro"].ToString());
                    aux.nomebairro = dr_bairro["nomebairro"].ToString();
                    lista_bairro.Add(aux);
                }
            }
            catch
            {

            }
            return lista_bairro;
        }

        public List<Bairro> DadosBairroFiltro(String parametro)
        {
            List<Bairro> lista_bairro = new List<Bairro>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomebairro", parametro + "%");

            SqlDataReader dr_bairro;
            conn.Open();

            try
            {
                dr_bairro = cmd.ExecuteReader();
                while (dr_bairro.Read())
                {
                    Bairro aux = new Bairro();
                    aux.codbairro = Int32.Parse(dr_bairro["codbairro"].ToString());
                    aux.nomebairro = dr_bairro["nomebairro"].ToString();
                    lista_bairro.Add(aux);
                }
            }
            catch
            {

            }
            return lista_bairro;
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
            Bairro dados = new Bairro();
            dados = (Bairro)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codbairro);
            cmd.Parameters.AddWithValue("@pnome", dados.nomebairro);
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

        public DataTable Buscar_Filtro(String pbairro)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomebairro", pbairro);
            conn.Open();

            da_bairro = new SqlDataAdapter(cmd);
            dt_bairro = new DataTable();
            da_bairro.Fill(dt_bairro);

            return dt_bairro;
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

            da_bairro = new SqlDataAdapter(cmd);
            dt_bairro = new DataTable();
            da_bairro.Fill(dt_bairro);

            return dt_bairro;
        }

        public void Insere_Dados(object aux)
        {
            Bairro bairro = new Bairro();
            bairro = (Bairro)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", bairro.nomebairro);

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
