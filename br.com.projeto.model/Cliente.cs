using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Controle_de_Vendas.br.com.projeto.model
{
    public class Cliente
    {
        //Atributos 

        public string nome; //Criação do atributo


        //Getter e setter (Padrão Java)

        public String getName()
        {
            return nome;
        }

        public void setName(String nome)
        {
            this.nome = nome; 
        }

        //Padrão Windows

        public int codigo { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string email { get; set; } 
        public string telefone { get; set; }
        public string celular { get; set; }
        public string cep { get; set; }
        public string endereço { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }


    }
}
