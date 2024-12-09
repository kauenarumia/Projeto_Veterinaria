using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Produto : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_produto;
        SqlDataAdapter da_produto;

        String sqlInsere = "INSERT INTO produto (nomeproduto, codmarcafk, quantidade, valor, " +
            "codtipoprodutofk) VALUES " +
            "(@pnomeproduto, @pcodmarca, @pquantidade, @pvalor, @pcodtipoproduto)";
        String sqlApaga = "DELETE FROM produto WHERE codproduto = @pcodproduto";
        String sqlAtualiza = "UPDATE produto SET nomeproduto = @pnomeproduto, codmarcafk = @pcodmarca, quantidade = @pquantidade, valor = @pvalor, codtipoprodutofk = @pcodtipoproduto WHERE codproduto = @pcodproduto";
        String sqlTodos = "SELECT * FROM produto";
        String sqlFiltro = "SELECT * FROM produto WHERE nomeproduto LIKE @pnomeproduto";


        public List<Produto> DadosProduto()
        {
            List<Produto> lista_produto = new List<Produto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_produto;
            conn.Open();

            try
            {
                dr_produto = cmd.ExecuteReader();
                while (dr_produto.Read())
                {
                    Produto aux = new Produto();
                    aux.codproduto = Int32.Parse(dr_produto["codproduto"].ToString());
                    aux.nomeproduto = dr_produto["nomeproduto"].ToString();

                    Marca marca = new Marca();
                    marca.codmarca = Int32.Parse(dr_produto["codmarcafk"].ToString());
                    aux.marca = marca;
                    lista_produto.Add(aux);

                    Tipoproduto tipoproduto = new Tipoproduto();
                    tipoproduto.codtipoproduto = Int32.Parse(dr_produto["codpaisfk"].ToString());
                    aux.tipoproduto = tipoproduto;
                }
            }
            catch
            {

            }
            return lista_produto;
        }

        public List<Produto> DadosProdutoFiltro(String parametro)
        {
            List<Produto> lista_produto = new List<Produto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeproduto", parametro + "%");

            SqlDataReader dr_produto;
            conn.Open();

            try
            {
                dr_produto = cmd.ExecuteReader();
                while (dr_produto.Read())
                {
                    Produto aux = new Produto();
                    aux.codproduto = Int32.Parse(dr_produto["codproduto"].ToString());
                    aux.nomeproduto = dr_produto["nomeproduto"].ToString();
                    lista_produto.Add(aux);
                }
            }
            catch
            {

            }
            return lista_produto;
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
            Produto dados = new Produto();
            dados = (Produto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnomeproduto", dados.nomeproduto);
            cmd.Parameters.AddWithValue("@pcodmarca", dados.marca);
            cmd.Parameters.AddWithValue("@pquantidade", dados.quantidade);
            cmd.Parameters.AddWithValue("@pvalor", dados.valor);
            cmd.Parameters.AddWithValue("@pcodtipoproduto", dados.tipoproduto);
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

        public DataTable Buscar_Filtro(String pproduto)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeproduto", pproduto);
            conn.Open();

            da_produto = new SqlDataAdapter(cmd);
            dt_produto = new DataTable();
            da_produto.Fill(dt_produto);

            return dt_produto;
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

            da_produto = new SqlDataAdapter(cmd);
            dt_produto = new DataTable();
            da_produto.Fill(dt_produto);

            return dt_produto;
        }

        public void Insere_Dados(object aux)
        {
            Produto produto = new Produto();
            produto = (Produto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();


            //"INSERT INTO produto (nomeproduto, codmarcafk, quantidade, valor, " +
            //"codtipoprodutofk) VALUES " +
            //"(@pnomeproduto, @pcodmarca, @pquantidade, @pvalor, @pcodtipoproduto)";
            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomeproduto", produto.nomeproduto);
            cmd.Parameters.AddWithValue("@pcodmarca", produto.marca.codmarca);
            cmd.Parameters.AddWithValue("@pquantidade", produto.quantidade);
            cmd.Parameters.AddWithValue("@pvalor", produto.valor);
            cmd.Parameters.AddWithValue("@pcodtipoproduto", produto.tipoproduto.codtipoproduto);

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
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
