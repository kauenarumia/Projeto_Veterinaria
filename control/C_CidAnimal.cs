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
    internal class C_CidAnimal : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_cid;
        SqlDataAdapter da_cid;

        String sqlInsere = "insert into cidanimal(nomecidanimal, descricao) values (@pnome, @pdescricao)";
        String sqlApaga = "delete from cidanimal where codcidanimal = @pcod";
        String sqlAtualiza = "update cidanimal set nomecidanimal = @pnome, descricao = @pdescricao where codcidanimal = @pcod";
        String sqlTodos = "select * from cidanimal";
        String sqlFiltro = "select * from cidanimal where nomecidanimal like @pnomecidanimal";

        public List<Cidanimal> DadosCidAnimal()
        {
            List<Cidanimal> lista_cid = new List<Cidanimal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_cid;
            conn.Open();

            try
            {
                dr_cid = cmd.ExecuteReader();
                while (dr_cid.Read())
                {
                    Cidanimal aux = new Cidanimal();
                    aux.codcidanimal = Int32.Parse(dr_cid["codcidanimal"].ToString());
                    aux.nomecidanimal = dr_cid["nomecidanimal"].ToString();
                    aux.descricao = dr_cid["descricao"].ToString();
                    lista_cid.Add(aux);
                }
            }
            catch
            {

            }
            return lista_cid;
        }
        public List<Cidanimal> DadosCidAnimalFiltro(String parametro)
        {
            List<Cidanimal> lista_cid = new List<Cidanimal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("pnomecidanimal", parametro + "%");

            SqlDataReader dr_cid;
            conn.Open();

            try
            {
                dr_cid = cmd.ExecuteReader();
                while (dr_cid.Read())
                {
                    Cidanimal aux = new Cidanimal();
                    aux.codcidanimal = Int32.Parse(dr_cid["codcidanimal"].ToString());
                    aux.nomecidanimal = dr_cid["nomecidanimal"].ToString();
                    aux.descricao = dr_cid["descricao"].ToString();
                    lista_cid.Add(aux);
                }
            }
            catch
            {

            }
            return lista_cid;
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
            Cidanimal dados = new Cidanimal();
            dados = (Cidanimal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codcidanimal);
            cmd.Parameters.AddWithValue("@pnome", dados.nomecidanimal);
            cmd.Parameters.AddWithValue("@pdescricao", dados.descricao);
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

        public DataTable Buscar_Filtro(String pcidanimal)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomecidanimal", pcidanimal);
            conn.Open();

            da_cid = new SqlDataAdapter(cmd);
            dt_cid = new DataTable();
            da_cid.Fill(dt_cid);

            return dt_cid;
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

            da_cid = new SqlDataAdapter(cmd);
            dt_cid = new DataTable();
            da_cid.Fill(dt_cid);

            return dt_cid;
        }

        public void Insere_Dados(object aux)
        {
            Cidanimal cidanimal = new Cidanimal();
            cidanimal = (Cidanimal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", cidanimal.nomecidanimal);
            cmd.Parameters.AddWithValue("@pdescricao", cidanimal.descricao);

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
