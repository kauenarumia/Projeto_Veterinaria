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
    internal class C_Telefone : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_telefone;
        SqlDataAdapter da_telefone;

        String sqlInsere = "insert into telefone(numerotelefone) values (@pnumero)";
        String sqlApaga = "delete from telefone where codtelefone = @pcod";
        String sqlAtualiza = "update numero set numerotelefone = @pnumero where codtelefone = @pcod";
        String sqlTodos = "select * from telefone";
        String sqlFiltro = "select * from telefone where numerotelefone like @pnumerotelefone";

        public List<Telefone> DadosTelefone()
        {
            List<Telefone> lista_telefone = new List<Telefone>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_telefone;
            conn.Open();

            try
            {
                dr_telefone = cmd.ExecuteReader();
                while (dr_telefone.Read())
                {
                    Telefone aux = new Telefone();
                    aux.codtelefone = Int32.Parse(dr_telefone["codtelefone"].ToString());
                    aux.numerotelefone = dr_telefone["numerotelefone"].ToString();
                    lista_telefone.Add(aux);
                }
            }
            catch
            {

            }
            return lista_telefone;
        }

        public List<Telefone> DadosTelefoneFiltro(String parametro)
        {
            List<Telefone> lista_telefone = new List<Telefone>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("pnumerotelefone", parametro + "%");

            SqlDataReader dr_telefone;
            conn.Open();

            try
            {
                dr_telefone = cmd.ExecuteReader();
                while (dr_telefone.Read())
                {
                    Telefone aux = new Telefone();
                    aux.codtelefone = Int32.Parse(dr_telefone["codtelefone"].ToString());
                    aux.numerotelefone = dr_telefone["numerotelefone"].ToString();
                    lista_telefone.Add(aux);
                }
            }
            catch
            {

            }
            return lista_telefone;
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
            Telefone dados = new Telefone();
            dados = (Telefone)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codtelefone);
            cmd.Parameters.AddWithValue("@pnome", dados.numerotelefone);
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

        public DataTable Buscar_Filtro(String ptelefone)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnumerotelefone", ptelefone);
            conn.Open();

            da_telefone = new SqlDataAdapter(cmd);
            dt_telefone = new DataTable();
            da_telefone.Fill(dt_telefone);

            return dt_telefone;
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

            da_telefone = new SqlDataAdapter(cmd);
            dt_telefone = new DataTable();
            da_telefone.Fill(dt_telefone);

            return dt_telefone;
        }

        public void Insere_Dados(object aux)
        {
            Telefone telefone = new Telefone();
            telefone = (Telefone)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnumero", telefone.numerotelefone);

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