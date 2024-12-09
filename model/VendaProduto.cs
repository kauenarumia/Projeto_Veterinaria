using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class VendaProduto
    {
        public Venda venda { get; set; }
        public Produto produto { get; set; }
        public String quantidade { get; set; }
        public String valor {  get; set; }
    }
}
