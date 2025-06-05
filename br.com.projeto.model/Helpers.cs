using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.model
{
    //Métodos de ajuda 
    public class Helpers
    {

        //Método para limpar as informações 
        public void limpar_tela(Form tela)
        {
            //Controles são as páginas 
            foreach (Control control in tela.Controls)
            {
                foreach(Control control2 in control.Controls)
                {
                    if (control2 is TabPage)
                    {
                        foreach(Control control3 in control2.Controls)
                        {
                            if (control3 is TextBox)
                            {
                                (control3 as TextBox).Text = string.Empty;
                            }
                            else if (control3 is MaskedTextBox)
                            {
                                (control3 as MaskedTextBox).Text = string.Empty;
                            }
                            else if ( control3 is ComboBox)
                            {
                                (control3 as ComboBox).Text = string.Empty;
                            }
                        }
                    }
                }
            }

        }
    }
}
