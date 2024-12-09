using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Cliente : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_cliente;
        SqlDataAdapter da_cliente;

        String sqlInsere = "insert into cliente (nomecliente, cpf, codbairrofk, codruafk, codcepfk, codcidadefk, codestadofk, codpaisfk, numerocasa) values (@pnome, @pcpf, @pcodbairro, @pcodrua, @pcodcep, @pcodcidade, @pcodestado, @pcodpais, @pnumeroCasa)";
        String sqlApaga = "delete from cliente where codcliente = @pcod";
        String sqlAtualiza = "update cliente set nomecliente = @pnome, cpf = @pcpf, codbairrofk = @pcodbairro, codruafk = @pcodrua, codcepfk = @pcodcep, codcidadefk = @pcodcidade, codestadofk = @pcodestado, codpaisfk = @pcodpais, numerocasa = @pnumeroCasa where codcliente = @pcod";
        String sqlTodos = "select * from cliente";
        String sqlFiltro = "select * from cliente where nomecliente like @pnomecliente";


        public List<Cliente> DadosCliente()
        {
            List<Cliente> lista_cliente = new List<Cliente>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_cliente;
            conn.Open();

            try
            {
                dr_cliente = cmd.ExecuteReader();
                while (dr_cliente.Read())
                {
                    Cliente aux = new Cliente();
                    aux.codcliente = Int32.Parse(dr_cliente["codcliente"].ToString());
                    aux.nomecliente = dr_cliente["nomecliente"].ToString();
                    aux.cpf = dr_cliente["cpf"].ToString();
                    lista_cliente.Add(aux);

                    Rua rua = new Rua();
                    rua.codrua = Int32.Parse(dr_cliente["codrua"].ToString());
                    aux.rua = rua;

                    Bairro bairro = new Bairro();
                    bairro.codbairro = Int32.Parse(dr_cliente["codbairro"].ToString());
                    aux.bairro = bairro;

                    Cidade cidade = new Cidade();
                    cidade.codcidade = Int32.Parse(dr_cliente["codcidade"].ToString());
                    aux.cidade = cidade;

                    Pais pais = new Pais();
                    pais.codpais = Int32.Parse(dr_cliente["codpais"].ToString());
                    aux.pais = pais;

                    Cep cep = new Cep();
                    cep.codcep = Int32.Parse(dr_cliente["codcep"].ToString());
                    aux.cep = cep;

                    Estado estado = new Estado();
                    estado.codestado = Int32.Parse(dr_cliente["codestado"].ToString());
                    aux.estado = estado;
                }
            }
            catch
            {

            }
            return lista_cliente;
        }

        public List<Cliente> DadosClienteFiltro(String parametro)
        {
            List<Cliente> lista_cliente = new List<Cliente>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomecliente", parametro + "%");

            SqlDataReader dr_cliente;
            conn.Open();

            try
            {
                dr_cliente = cmd.ExecuteReader();
                while (dr_cliente.Read())
                {
                    Cliente aux = new Cliente();
                    aux.codcliente = Int32.Parse(dr_cliente["codcliente"].ToString());
                    aux.nomecliente = dr_cliente["nomecliente"].ToString();
                    lista_cliente.Add(aux);
                }
            }
            catch
            {

            }
            return lista_cliente;
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
            Cliente dados = new Cliente();
            dados = (Cliente)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codcliente);
            cmd.Parameters.AddWithValue("@pnome", dados.nomecliente);
            cmd.Parameters.AddWithValue("@pcpf", dados.cpf);
            cmd.Parameters.AddWithValue("@pbairro", dados.bairro);
            cmd.Parameters.AddWithValue("@prua", dados.rua);
            cmd.Parameters.AddWithValue("@pcep", dados.cep);
            cmd.Parameters.AddWithValue("@pcidade", dados.cidade);
            cmd.Parameters.AddWithValue("@pestado", dados.estado);
            cmd.Parameters.AddWithValue("@ppais", dados.pais);
            cmd.Parameters.AddWithValue("@pnumerocasa", dados.numerocasa);
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

        public DataTable Buscar_Filtro(String pcliente)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomecliente", pcliente);
            conn.Open();

            da_cliente = new SqlDataAdapter(cmd);
            dt_cliente = new DataTable();
            da_cliente.Fill(dt_cliente);

            return dt_cliente;
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

            da_cliente = new SqlDataAdapter(cmd);
            dt_cliente = new DataTable();
            da_cliente.Fill(dt_cliente);

            return dt_cliente;
        }

        public void Insere_Dados(object aux)
        {
            Cliente cliente = new Cliente();
            cliente = (Cliente)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
           
            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", cliente.nomecliente);
            cmd.Parameters.AddWithValue("@pcpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@pcodbairro", cliente.bairro.codbairro);
            cmd.Parameters.AddWithValue("@pcodrua", cliente.rua.codrua);
            cmd.Parameters.AddWithValue("@pcodcep", cliente.cep.codcep);
            cmd.Parameters.AddWithValue("@pcodcidade", cliente.cidade.codcidade);
            cmd.Parameters.AddWithValue("@pcodestado", cliente.estado.codestado);
            cmd.Parameters.AddWithValue("@pcodpais", cliente.pais.codpais);
            cmd.Parameters.AddWithValue("@pnumerocasa", cliente.numerocasa);

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
                MessageBox.Show("Erro"+ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
