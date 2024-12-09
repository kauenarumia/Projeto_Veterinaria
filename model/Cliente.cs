using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /*
     cliente = {codcliente, nomecliente, cpf, codbairrofk, codruafk, 
     codcepfk, codcidadefk, codestadofk, codpaisfk, numerocasa, fotocliente}
    */
    internal class Cliente
    {
        public int codcliente {  get; set; }
        public String nomecliente { get; set; }
        public String cpf {  get; set; }
        public Bairro bairro { get; set; }
        public Rua rua { get; set; }
        public Cep cep { get; set; }
        public Cidade cidade { get; set; }
        public Estado estado { get; set; }
        public Pais pais { get; set; }
        public String numerocasa {  get; set; }   
    }
}
