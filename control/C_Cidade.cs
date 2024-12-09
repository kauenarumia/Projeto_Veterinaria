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
    internal class C_Cidade : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_cidade;
        SqlDataAdapter da_cidade;

        String sqlInsere = "insert into cidade(nomecidade) values (@pnome)";
        String sqlApaga = "delete from cidade where codcidade = @pcod";
        String sqlAtualiza = "update cidade set nomecidade = @pnome where codcidade = @pcod";
        String sqlTodos = "select * from cidade";
        String sqlFiltro = "select * from cidade where nomecidade like @pnomecidade";

        public List<Cidade> DadosCidade()
        {
            List<Cidade> lista_cidade = new List<Cidade>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_cidade;
            conn.Open();

            try
            {
                dr_cidade = cmd.ExecuteReader();
                while (dr_cidade.Read())
                {
                    Cidade aux = new Cidade();
                    aux.codcidade = Int32.Parse(dr_cidade["codcidade"].ToString());
                    aux.nomecidade = dr_cidade["nomecidade"].ToString();
                    lista_cidade.Add(aux);
                }
            }
            catch
            {

            }
            return lista_cidade;
        }

        public List<Cidade> DadosCidadeFiltro(String parametro)
        {
            List<Cidade> lista_cidade = new List<Cidade>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomecidade", parametro + "%");

            SqlDataReader dr_cidade;
            conn.Open();

            try
            {
                dr_cidade = cmd.ExecuteReader();
                while (dr_cidade.Read())
                {
                    Cidade aux = new Cidade();
                    aux.codcidade = Int32.Parse(dr_cidade["codcidade"].ToString());
                    aux.nomecidade = dr_cidade["nomecidade"].ToString();
                    lista_cidade.Add(aux);
                }
            }
            catch
            {

            }
            return lista_cidade;
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
            Cidade dados = new Cidade();
            dados = (Cidade)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codcidade);
            cmd.Parameters.AddWithValue("@pnome", dados.nomecidade);
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

        public DataTable Buscar_Filtro(String pcidade)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomecidade", pcidade);
            conn.Open();

            da_cidade = new SqlDataAdapter(cmd);
            dt_cidade = new DataTable();
            da_cidade.Fill(dt_cidade);

            return dt_cidade;
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

            da_cidade = new SqlDataAdapter(cmd);
            dt_cidade = new DataTable();
            da_cidade.Fill(dt_cidade);

            return dt_cidade;
        }

        public void Insere_Dados(object aux)
        {
            Cidade cidade = new Cidade();
            cidade = (Cidade)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", cidade.nomecidade);

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
