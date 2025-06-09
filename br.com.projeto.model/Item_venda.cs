using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Controle_de_Vendas.br.com.projeto.model
{
    public class Item_venda
    {
        public int id { get; set; }
        public int id_venda { get; set; }
        public int id_produto { get; set; }
        public int quantidade { get; set; }
        public decimal subtotal { get; set; }
    }
}
