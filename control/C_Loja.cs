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
    internal class C_Loja : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_loja;
        SqlDataAdapter da_loja;

        String sqlInsere = "insert into loja (nomeloja, codbairrofk, codruafk, codcepfk, codcidadefk, codestadofk, codpaisfk, numeroloja, cnpj) values (@pnome, @pcodbairro, @pcodrua, @pcodcep, @pcodcidade, @pcodestado, @pcodpais, @pnumero, @pcnpj)";
        String sqlApaga = "delete from loja where codloja = @pcod";
        String sqlAtualiza = "update loja set nomeloja = @pnome, codbairrofk = @pcodbairro, codruafk = @pcodrua, codcepfk = @pcodcep, codcidadefk = @pcodcidade, codestadofk = @pcodestado, codpaisfk = @pcodpais, numeroloja = @pnumero, cnpj = @pcnpj  where codloja = @pcod";
        String sqlTodos = "select * from loja";
        String sqlFiltro = "select * from loja where nomeloja like @pnomeloja";


        public List<Loja> DadosLoja()
        {
            List<Loja> lista_loja = new List<Loja>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_loja;
            conn.Open();

            try
            {
                dr_loja = cmd.ExecuteReader();
                while (dr_loja.Read())
                {
                    Loja aux = new Loja();
                    aux.codloja = Int32.Parse(dr_loja["codloja"].ToString());
                    aux.nomeloja = dr_loja["nomeloja"].ToString();
                    aux.numeroloja = dr_loja["numeroloja"].ToString();
                    aux.cnpj = dr_loja["cnpj"].ToString();

                    Pais pais = new Pais();
                    pais.codpais = Int32.Parse(dr_loja["codpaisfk"].ToString());
                    aux.pais = pais;

                    Bairro bairro = new Bairro();
                    bairro.codbairro = Int32.Parse(dr_loja["codbairrofk"].ToString());
                    aux.bairro = bairro; 

                    Cep cep = new Cep();
                    cep.codcep = Int32.Parse(dr_loja["codcepfk"].ToString());
                    aux.cep = cep;

                    Cidade cidade = new Cidade();
                    cidade.codcidade = Int32.Parse(dr_loja["codcidadefk"].ToString());
                    aux.cidade = cidade;

                    Rua rua = new Rua();
                    rua.codrua = Int32.Parse(dr_loja["codruafk"].ToString());
                    aux.rua = rua;

                    Estado estado = new Estado();
                    estado.codestado = Int32.Parse(dr_loja["codestadofk"].ToString());
                    aux.estado = estado;

                    lista_loja.Add(aux);
                }
            }
            catch
            {

            }
            return lista_loja;
        }

        public List<Loja> DadosLojaFiltro(String parametro)
        {
            List<Loja> lista_loja = new List<Loja>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeloja", parametro + "%");

            SqlDataReader dr_loja;
            conn.Open();

            try
            {
                dr_loja = cmd.ExecuteReader();
                while (dr_loja.Read())
                {
                    Loja aux = new Loja();
                    aux.codloja = Int32.Parse(dr_loja["codloja"].ToString());
                    aux.nomeloja = dr_loja["nomeloja"].ToString();
                    lista_loja.Add(aux);
                }
            }
            catch
            {

            }
            return lista_loja;
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
            Loja dados = new Loja();
            dados = (Loja)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codloja);
            cmd.Parameters.AddWithValue("@pnome", dados.nomeloja);
            cmd.Parameters.AddWithValue("@pbairro", dados.bairro);
            cmd.Parameters.AddWithValue("@prua", dados.rua);
            cmd.Parameters.AddWithValue("@pcep", dados.cep);
            cmd.Parameters.AddWithValue("@pcidade", dados.cidade);
            cmd.Parameters.AddWithValue("@pestado", dados.estado);
            cmd.Parameters.AddWithValue("@ppais", dados.pais);
            cmd.Parameters.AddWithValue("@pnumero", dados.numeroloja);
            cmd.Parameters.AddWithValue("@pcnpj", dados.cnpj);
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

        public DataTable Buscar_Filtro(String ploja)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeloja", ploja);
            conn.Open();

            da_loja = new SqlDataAdapter(cmd);
            dt_loja = new DataTable();
            da_loja.Fill(dt_loja);

            return dt_loja;
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

            da_loja = new SqlDataAdapter(cmd);
            dt_loja = new DataTable();
            da_loja.Fill(dt_loja);

            return dt_loja;
        }

        public void Insere_Dados(object aux)
        {
            Loja loja = new Loja();
            loja = (Loja)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pcod", loja.codloja);
            cmd.Parameters.AddWithValue("@pnome", loja.nomeloja);
            cmd.Parameters.AddWithValue("@pcodbairro", loja.bairro.codbairro);
            cmd.Parameters.AddWithValue("@pcodrua", loja.rua.codrua);
            cmd.Parameters.AddWithValue("@pcodcep", loja.cep.codcep);
            cmd.Parameters.AddWithValue("@pcodcidade", loja.cidade.codcidade);
            cmd.Parameters.AddWithValue("@pcodestado", loja.estado.codestado);
            cmd.Parameters.AddWithValue("@pcodpais", loja.pais.codpais);
            cmd.Parameters.AddWithValue("@pnumero", loja.numeroloja);
            cmd.Parameters.AddWithValue("@pcnpj", loja.cnpj);

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
                MessageBox.Show("Erro: "+ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
