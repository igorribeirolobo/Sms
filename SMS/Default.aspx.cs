using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int Contar = 0;
            if ((tx_numero.Text == "") || (tx_mensagem.Text == ""))
            {
                Lb_erro.Text = "<div class='alert alert-danger'>Você deve prencher todos os campos.</div>";
            }
            else
            {
                Lb_erro.Text = "";
            SMS sms = new SMS();
            string mensegamretorno = "";
            string[] valores = tx_numero.Text.Split(new char[] { ':' });
            for (int c = 0; c < valores.Count(); c++)
            {
                    Contar += 1;
                
                if (sms.envio(valores[c], tx_mensagem.Text))
                {
                    mensegamretorno += "<tr class='success'><td>" + valores[c] + "</td><td><span class='glyphicon glyphicon-ok'></span></td></tr>";
                }
                else
                {
                    mensegamretorno += "<tr class='danger'><td>" + valores[c] + "</td><td><span class='glyphicon glyphicon-remove'></span></td></tr>";
                }
                Label1.Text = mensegamretorno;
            }
                Contar calculo = new Contar();
                calculo.Contagem(Contar, int.Parse(Session["id"].ToString()));

            }
        }
    }
}