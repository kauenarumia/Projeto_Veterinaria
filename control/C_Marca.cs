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
    internal class C_Marca : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_marca;
        SqlDataAdapter da_marca;

        String sqlInsere = "insert into marca(nomemarca) values (@pnome)";
        String sqlApaga = "delete from marca where codmarca = @pcod";
        String sqlAtualiza = "update marca set nomemarca = @pnome where codmarca = @pcod";
        String sqlTodos = "select * from marca";
        String sqlFiltro = "select * from marca where nomemarca like @pnomemarca";
        public List<Marca> DadosMarca()
        {
            List<Marca> lista_marca = new List<Marca>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_marca;
            conn.Open();

            try
            {
                dr_marca = cmd.ExecuteReader();
                while (dr_marca.Read())
                {
                    Marca aux = new Marca();
                    aux.codmarca = Int32.Parse(dr_marca["codmarca"].ToString());
                    aux.nomemarca = dr_marca["nomemarca"].ToString();
                    lista_marca.Add(aux);
                }
            }
            catch
            {

            }

            return lista_marca;
        }

        public List<Marca> DadosMarcaFiltro(String parametro)
        {
            List<Marca> lista_marca = new List<Marca>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("pnomemarca", parametro + "%");

            SqlDataReader dr_marca;
            conn.Open();

            try
            {
                dr_marca = cmd.ExecuteReader();
                while (dr_marca.Read())
                {
                    Marca aux = new Marca();
                    aux.codmarca = Int32.Parse(dr_marca["codmarca"].ToString());
                    aux.nomemarca = dr_marca["nomemarca"].ToString();
                    lista_marca.Add(aux);
                }
            }
            catch
            {

            }

            return lista_marca;
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
            Marca dados = new Marca();
            dados = (Marca)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codmarca);
            cmd.Parameters.AddWithValue("@pnome",dados.nomemarca);
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

        public DataTable Buscar_Filtro(String pmarca)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomerua", pmarca);
            conn.Open();

            da_marca = new SqlDataAdapter(cmd);
            dt_marca = new DataTable();
            da_marca.Fill(dt_marca);

            return dt_marca;
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

            da_marca = new SqlDataAdapter(cmd);
            dt_marca = new DataTable();
            da_marca.Fill(dt_marca);

            return dt_marca;
        }

        public void Insere_Dados(object aux)
        {
            Marca marca = new Marca();
            marca = (Marca)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", marca.nomemarca);

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
