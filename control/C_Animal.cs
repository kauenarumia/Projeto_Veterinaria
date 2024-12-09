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
    internal class C_Animal : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_animal;
        SqlDataAdapter da_animal;

        String sqlInsere = "insert into animal (nomeanimal, codsexofk, codracafk, codtipoanimalfk, codclientefk) values (@pnome, @pcodsexo, @pcodraca, @pcodtipoanimal, @pcodcliente)";
        String sqlApaga = "delete from animal where codanimal = @pcodanimal";
        String sqlAtualiza = "update animal set nomeanimal = @pnome, codsexofk = @pcodsexo, codracafk = @pcodraca, codtipoanimalfk = @pcodtipoanimal, codclientefk = @pcodcliente where codanimal = @pcodanimal";
        String sqlTodos = "select * from animal";
        String sqlFiltro = "select * from animal where nomeanimal like @pnomeanimal";


        public List<Animal> DadosAnimal()
        {
            List<Animal> lista_animal = new List<Animal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_animal;
            conn.Open();

            try
            {
                dr_animal = cmd.ExecuteReader();
                while (dr_animal.Read())
                {
                    Animal aux = new Animal();
                    aux.codanimal = Int32.Parse(dr_animal["codanimal"].ToString());
                    aux.nomeanimal = dr_animal["nomeanimal"].ToString();
                    lista_animal.Add(aux);

                    Sexo sexo = new Sexo();
                    sexo.codsexo = Int32.Parse(dr_animal["codsexofk"].ToString());
                    aux.sexo = sexo;

                    Raca raca = new Raca();
                    raca.codraca = Int32.Parse(dr_animal["codmarcafk"].ToString());
                    aux.raca = raca;

                    Tipoanimal tipoanimal = new Tipoanimal();
                    tipoanimal.codtipoanimal =Int32.Parse(dr_animal["codtipoanimalfk"].ToString());
                    aux.tipoanimal = tipoanimal;

                    Cliente cliente = new Cliente();
                    cliente.codcliente = Int32.Parse(dr_animal["codclientefk"].ToString());
                    aux.cliente = cliente;
                }
            }
            catch
            {

            }
            return lista_animal;
        }

        public List<Animal> DadosAnimalFiltro(String parametro)
        {
            List<Animal> lista_animal = new List<Animal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeanimal", parametro + "%");

            SqlDataReader dr_animal;
            conn.Open();

            try
            {
                dr_animal = cmd.ExecuteReader();
                while (dr_animal.Read())
                {
                    Animal aux = new Animal();
                    aux.codanimal = Int32.Parse(dr_animal["codanimal"].ToString());
                    aux.nomeanimal = dr_animal["nomeanimal"].ToString();
                    lista_animal.Add(aux);
                }
            }
            catch
            {

            }
            return lista_animal;
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
            Animal dados = new Animal();
            dados = (Animal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codanimal);
            cmd.Parameters.AddWithValue("@pnome", dados.nomeanimal);
            cmd.Parameters.AddWithValue("@pcodsexo", dados.sexo);
            cmd.Parameters.AddWithValue("@pcodraca", dados.raca);
            cmd.Parameters.AddWithValue("@pcodtipoanimal", dados.tipoanimal);
            cmd.Parameters.AddWithValue("@pcodcliente", dados.cliente);
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

        public DataTable Buscar_Filtro(String panimal)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("pnomeanimal", panimal);
            conn.Open();

            da_animal = new SqlDataAdapter(cmd);
            dt_animal = new DataTable();
            da_animal.Fill(dt_animal);

            return dt_animal;
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

            da_animal = new SqlDataAdapter(cmd);
            dt_animal = new DataTable();
            da_animal.Fill(dt_animal);

            return dt_animal;
        }

        public void Insere_Dados(object aux)
        {
            Animal animal = new Animal();
            animal = (Animal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", animal.nomeanimal);
            cmd.Parameters.AddWithValue("@pcodsexo", animal.sexo.codsexo);
            cmd.Parameters.AddWithValue("@pcodraca", animal.raca.codraca);
            cmd.Parameters.AddWithValue("@pcodtipoanimal", animal.tipoanimal.codtipoanimal);
            cmd.Parameters.AddWithValue("@pcodcliente", animal.cliente.codcliente);


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
