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

namespace Veterinaria.control
{
    internal class C_TipoServico : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_tiposerv;
        SqlDataAdapter da_tiposerv;

        String sqlInsere = "insert into tiposervico(nometiposervico, valortiposervico) values (@pnome, @pvalor)";
        String sqlApaga = "delete from tiposervico where codtiposervico = @pcod";
        String sqlAtualiza = "update tiposervico set nometiposervico = @pnome, valortiposervico = @pvalor where codtiposervico = @pcod";
        String sqlTodos = "select * from tiposervico";
        String sqlFiltro = "select * from tiposervico where nometiposervico like @pnometiposervico";

        public List<Tiposervico> DadosTipoServ()
        {
            List<Tiposervico> lista_tiposerv = new List<Tiposervico>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_tiposerv;
            conn.Open();

            try
            {
                dr_tiposerv = cmd.ExecuteReader();
                while (dr_tiposerv.Read())
                {
                    Tiposervico aux = new Tiposervico();
                    aux.codtiposervico = Int32.Parse(dr_tiposerv["codtiposervico"].ToString());
                    aux.nometiposervico = dr_tiposerv["nometiposervico"].ToString();
                    aux.valortiposervico = dr_tiposerv["valortiposervico"].ToString();
                    lista_tiposerv.Add(aux);
                }
            }
            catch
            {

            }
            return lista_tiposerv;
        }

        public List<Tiposervico> DadosTipoServFiltro(String parametro)
        {
            List<Tiposervico> lista_tiposerv = new List<Tiposervico>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("pnomeservico", parametro + "%");

            SqlDataReader dr_tiposerv;
            conn.Open();

            try
            {
                dr_tiposerv = cmd.ExecuteReader();
                while (dr_tiposerv.Read())
                {
                    Tiposervico aux = new Tiposervico();
                    aux.codtiposervico = Int32.Parse(dr_tiposerv["codtiposervico"].ToString());
                    aux.nometiposervico = dr_tiposerv["nometiposervico"].ToString();
                    aux.valortiposervico = dr_tiposerv["valortiposervico"].ToString();
                    lista_tiposerv.Add(aux);
                }
            }
            catch
            {

            }
            return lista_tiposerv;
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
            Tiposervico dados = new Tiposervico();
            dados = (Tiposervico)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codtiposervico);
            cmd.Parameters.AddWithValue("@pnome", dados.nometiposervico);
            cmd.Parameters.AddWithValue("@pvalor", dados.valortiposervico);
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

        public DataTable Buscar_Filtro(String ptiposervico)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnometiposervico", ptiposervico);
            conn.Open();

            da_tiposerv = new SqlDataAdapter(cmd);
            dt_tiposerv = new DataTable();
            da_tiposerv.Fill(dt_tiposerv);

            return dt_tiposerv;
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

            da_tiposerv = new SqlDataAdapter(cmd);
            dt_tiposerv = new DataTable();
            da_tiposerv.Fill(dt_tiposerv);

            return dt_tiposerv;
        }

        public void Insere_Dados(object aux)
        {
            Tiposervico tiposervico = new Tiposervico();
            tiposervico = (Tiposervico)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", tiposervico.nometiposervico);
            cmd.Parameters.AddWithValue("@pvalor", tiposervico.valortiposervico);

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
