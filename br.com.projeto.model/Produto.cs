using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Controle_de_Vendas.br.com.projeto.model
{
    public class Produto
    {
        public int codigo { get; set; }

        public string descricao { get; set; }

        public decimal preco { get; set; }

        public int qtd_estoque { get; set; }

        //Associação apenas pegando o valor 
        public int for_id { get; set; }

        //Associação com classe (java)

        //public Fornecedor id_fornecedor { get; set; }
    }
}
