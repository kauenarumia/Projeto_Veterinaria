using System;
using System.CodeDom;
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
    internal class C_TpAnimal : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_tpanimal;
        SqlDataAdapter da_tpanimal;

        String sqlInsere = "insert into tipoanimal(nometipoanimal) values (@pnome)";
        String sqlApaga = "delete from tipoanimal where codtipoanimal = @pcod";
        String sqlAtualiza = "update tipoanimal set nometipoanimal = @pnome where codtipoanimal = @pcod";
        String sqlTodos = "select * from tipoanimal";
        String sqlFiltro = "select * from tipoanimal where nometipoanimal like @pnometipoanimal";

        public List<Tipoanimal> DadosTipoAnimal()
        {
            List<Tipoanimal> lista_tipoanimal = new List<Tipoanimal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_tipoanimal;
            conn.Open();
            try
            {
                dr_tipoanimal= cmd.ExecuteReader();
                while (dr_tipoanimal.Read())
                {
                    Tipoanimal aux = new Tipoanimal();
                    aux.codtipoanimal = Int32.Parse(dr_tipoanimal["codtipoanimal"].ToString());
                    aux.nometipoanimal = dr_tipoanimal["nometipoanimal"].ToString();

                    lista_tipoanimal.Add(aux);
                }
            }
            catch
            {

            }

            return lista_tipoanimal;
        }

        public List<Tipoanimal> DadosTpAnimalFiltro(String parametro)
        {
            List<Tipoanimal> lista_tipoanimal = new List<Tipoanimal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnometipoanimal", parametro + "%");

            SqlDataReader dr_tipoanimal;
            conn.Open();

            try
            {
                dr_tipoanimal = cmd.ExecuteReader();
                while (dr_tipoanimal.Read())
                {
                    Tipoanimal aux = new Tipoanimal();
                    aux.codtipoanimal = Int32.Parse(dr_tipoanimal["codtipoanimal"].ToString());
                    aux.nometipoanimal = dr_tipoanimal["nometipoanimal"].ToString();

                    lista_tipoanimal.Add(aux);
                }
            }
            catch
            {

            }

            return lista_tipoanimal;
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
            Tipoanimal dados = new Tipoanimal();
            dados = (Tipoanimal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codtipoanimal);
            cmd.Parameters.AddWithValue("@pnome", dados.nometipoanimal);
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

        public DataTable Buscar_Filtro(String ptipoanimal)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnometipoanimal", ptipoanimal);

            conn.Open();

            da_tpanimal = new SqlDataAdapter(cmd);
            dt_tpanimal = new DataTable();
            da_tpanimal.Fill(dt_tpanimal);

            return dt_tpanimal;
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

            da_tpanimal = new SqlDataAdapter(cmd);
            dt_tpanimal = new DataTable();
            da_tpanimal.Fill(dt_tpanimal);

            return dt_tpanimal;
        }

        public void Insere_Dados(object aux)
        {
            Tipoanimal tipoanimal = new Tipoanimal();
            tipoanimal = (Tipoanimal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", tipoanimal.nometipoanimal);
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
