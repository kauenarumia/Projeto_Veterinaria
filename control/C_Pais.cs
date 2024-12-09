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
    internal class C_Pais : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_pais;
        SqlDataAdapter da_pais;

        String sqlInsere = "insert into pais(nomepais) values (@pnome)";
        String sqlApaga = "delete from pais where codpais = @pcod";
        String sqlAtualiza = "update pais set nomepais = @pnome where codpais = @pcod";
        String sqlTodos = "select * from pais";
        String sqlFiltro = "select * from pais where nomepais like @pnomepais";

        public List<Pais> DadosPais()
        {
            List<Pais> lista_pais = new List<Pais>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_pais;
            conn.Open();

            try
            {
                dr_pais = cmd.ExecuteReader();
                while (dr_pais.Read())
                {
                    Pais aux = new Pais();
                    aux.codpais = Int32.Parse(dr_pais["codpais"].ToString());
                    aux.nomepais = dr_pais["nomepais"].ToString();
                    lista_pais.Add(aux);
                }
            }
            catch
            {

            }
            return lista_pais;
        }

        public List<Pais> DadosPaisFiltro(String parametro)
        {
            List<Pais> lista_pais = new List<Pais>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand (sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomepais", parametro + "%");

            SqlDataReader dr_pais;
            conn.Open();

            try
            {
                dr_pais = cmd.ExecuteReader();
                while (dr_pais.Read())
                {
                    Pais aux = new Pais();
                    aux.codpais = Int32.Parse(dr_pais["codpais"].ToString());
                    aux.nomepais = dr_pais["nomepais"].ToString();
                    lista_pais.Add(aux);
                }
            }
            catch
            {

            }
            return lista_pais;
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
            Pais dados = new Pais();
            dados = (Pais)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codpais);
            cmd.Parameters.AddWithValue("@pnome", dados.nomepais);
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

        public DataTable Buscar_Filtro(String ppais)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomepais", ppais);
            conn.Open();

            da_pais = new SqlDataAdapter(cmd);
            dt_pais = new DataTable();
            da_pais.Fill(dt_pais);

            return dt_pais;
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

            da_pais = new SqlDataAdapter(cmd);
            dt_pais = new DataTable();
            da_pais.Fill(dt_pais);

            return dt_pais;
        }

        public void Insere_Dados(object aux)
        {
            Pais pais = new Pais();
            pais = (Pais)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", pais.nomepais);

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
                MessageBox.Show("Erro" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
