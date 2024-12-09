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
    internal class C_TipoProduto : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_tipoprod;
        SqlDataAdapter da_tipoprod;

        String sqlInsere = "insert into tipoproduto(nometipoproduto) values (@pnome)";
        String sqlApaga = "delete from tipoproduto where codtipoproduto = @pcod";
        String sqlAtualiza = "update tipoproduto set nometipoproduto = @pnome where codtipoproduto = @pcod";
        String sqlTodos = "select * from tipoproduto";
        String sqlFiltro = "select * from tipoproduto where nometipoproduto like @pnometipoproduto";

        public List<Tipoproduto> DadosTipoProduto()
        {
            List<Tipoproduto> lista_tipoprod = new List<Tipoproduto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_tipoprod;
            conn.Open();

            try
            {
                dr_tipoprod = cmd.ExecuteReader();
                while (dr_tipoprod.Read())
                {
                    Tipoproduto aux = new Tipoproduto();
                    aux.codtipoproduto = Int32.Parse(dr_tipoprod["codtipoproduto"].ToString());
                    aux.nometipoproduto = dr_tipoprod["nometipoproduto"].ToString();
                    lista_tipoprod.Add(aux);
                }
            }
            catch
            {

            }
            return lista_tipoprod;
        }

        public List<Tipoproduto> DadosTipoProdutoFiltro(String parametro)
        {
            List<Tipoproduto> lista_tipoprod = new List<Tipoproduto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("pnometipoproduto", parametro + "%");

            SqlDataReader dr_tipoprod;
            conn.Open();

            try
            {
                dr_tipoprod = cmd.ExecuteReader();
                while (dr_tipoprod.Read())
                {
                    Tipoproduto aux = new Tipoproduto();
                    aux.codtipoproduto = Int32.Parse(dr_tipoprod["codtipoproduto"].ToString());
                    aux.nometipoproduto = dr_tipoprod["nometipoproduto"].ToString();
                    lista_tipoprod.Add(aux);
                }
            }
            catch
            {

            }
            return lista_tipoprod;
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
            Tipoproduto dados = new Tipoproduto();
            dados = (Tipoproduto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codtipoproduto);
            cmd.Parameters.AddWithValue("@pnome", dados.nometipoproduto);
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

        public DataTable Buscar_Filtro(String ptipoproduto)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnometipoproduto", ptipoproduto);
            conn.Open();

            da_tipoprod = new SqlDataAdapter(cmd);
            dt_tipoprod = new DataTable();
            da_tipoprod.Fill(dt_tipoprod);

            return dt_tipoprod;
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

            da_tipoprod = new SqlDataAdapter(cmd);
            dt_tipoprod = new DataTable();
            da_tipoprod.Fill(dt_tipoprod);

            return dt_tipoprod;
        }

        public void Insere_Dados(object aux)
        {
            Tipoproduto tipoproduto = new Tipoproduto();
            tipoproduto = (Tipoproduto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", tipoproduto.nometipoproduto);

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
