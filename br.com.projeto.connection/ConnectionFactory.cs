using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Controle_de_Vendas.br.com.projeto.connection
{
    public class ConnectionFactory
    {
        //Método de conexão ao banco de dados 

        public MySqlConnection getconnection()
        {
            //ConfigManager é quem acessa o App.config
            //Passa os parametros e o nome da classe do AppConfig. necessário o
            //using System.configuration
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].
                ConnectionString;

            //Retorno do tipo connection 
            return new MySqlConnection(conexao);
        }
    }
}
