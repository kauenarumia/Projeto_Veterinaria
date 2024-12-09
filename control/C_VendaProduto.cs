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
    internal class C_VendaProduto : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_vendaproduto;
        SqlDataAdapter da_vendaproduto;

        String sqlInsere = "insert into vendasprodutos (codvendafk, codprodutofk, quantv, valorv) values (@pcodvenda, @pcodproduto, @pquantv, @pvalorv)";
        String sqlApaga = "delete from vendasprodutos where codvendafk = @pcodvenda and codprodutofk = @pcodproduto";
        String sqlAtualiza = "update vendasprodutos set quantv = @pquantv, valorv = @pvalorv where codvendafk = @pcodvenda and codprodutofk = @pcodproduto";
        String sqlTodos = "select * from vendasprodutos";
        String sqlFiltro = "select * from vendasprodutos where codvendafk = @pcodvenda or codprodutofk = @pcodproduto";


        public List<VendaProduto> DadosVendaProduto()
        {
            List<VendaProduto> lista_vendaprod = new List<VendaProduto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_vendaprod;
            conn.Open();

            try
            {
                dr_vendaprod = cmd.ExecuteReader();
                while (dr_vendaprod.Read())
                {
                    VendaProduto aux = new VendaProduto();
                    aux.quantidade = dr_vendaprod["quantv"].ToString();
                    aux.valor = dr_vendaprod["valorv"].ToString();
                    lista_vendaprod.Add(aux);

                    Venda venda = new Venda();
                    venda.codvenda = Int32.Parse(dr_vendaprod["codvenda"].ToString());
                    aux.venda = venda;

                    Produto produto = new Produto();
                    produto.codproduto = Int32.Parse(dr_vendaprod["codproduto"].ToString());
                    aux.produto = produto;
                }
            }
            catch
            {

            }
            return lista_vendaprod;
        }

        public List<VendaProduto> DadosVendaProdutoFiltro(String parametro)
        {
            List<VendaProduto> lista_vendaprod = new List<VendaProduto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("pcodvenda", parametro + "%");

            SqlDataReader dr_vendaprod;
            conn.Open();

            try
            {
                dr_vendaprod = cmd.ExecuteReader();
                while (dr_vendaprod.Read())
                {
                    VendaProduto aux = new VendaProduto();
                    aux.quantidade = dr_vendaprod["quantv"].ToString();
                    aux.valor = dr_vendaprod["valorv"].ToString();
                    lista_vendaprod.Add(aux);

                    Venda venda = new Venda();
                    venda.codvenda = Int32.Parse(dr_vendaprod["codvenda"].ToString());
                    aux.venda = venda;

                    Produto produto = new Produto();
                    produto.codproduto = Int32.Parse(dr_vendaprod["codproduto"].ToString());
                    aux.produto = produto;
                }
            }
            catch
            {

            }
            return lista_vendaprod;
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
            VendaProduto dados = new VendaProduto();
            dados = (VendaProduto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodvenda", dados.venda);
            cmd.Parameters.AddWithValue("@pcodproduto", dados.produto);
            cmd.Parameters.AddWithValue("@pquantv", dados.quantidade);
            cmd.Parameters.AddWithValue("@pvalorv", dados.valor);
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

        public DataTable Buscar_Filtro(String pvendaproduto)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomevendaproduto", pvendaproduto);
            conn.Open();

            da_vendaproduto = new SqlDataAdapter(cmd);
            dt_vendaproduto = new DataTable();
            da_vendaproduto.Fill(dt_vendaproduto);

            return dt_vendaproduto;
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

            da_vendaproduto = new SqlDataAdapter(cmd);
            dt_vendaproduto = new DataTable();
            da_vendaproduto.Fill(dt_vendaproduto);

            return dt_vendaproduto;
        }

        public void Insere_Dados(object aux)
        {
            VendaProduto vendaproduto = new VendaProduto();
            vendaproduto = (VendaProduto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pcodvenda", vendaproduto.venda.codvenda);
            cmd.Parameters.AddWithValue("@pcodproduto", vendaproduto.produto.codproduto );
            cmd.Parameters.AddWithValue("@pquantv", vendaproduto.quantidade);
            cmd.Parameters.AddWithValue("@pvalorv", vendaproduto.valor);

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
