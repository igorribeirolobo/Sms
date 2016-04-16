using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Obijeto.Usuario usu = new Obijeto.Usuario();
            Banco.Banco ban = new Banco.Banco();
            usu.Login = TextBox1.Text;
            usu.Senha = TextBox2.Text;
            if (usu.valida())
            {   //quero colocar o id do usuario aqui.
                usu.idLogin = int.Parse(ban.lista("SELECT * FROM sms.login where login='" + TextBox1.Text + "' and Senha='" + TextBox2.Text + "'").Rows[0][0].ToString());
                usu.Nome = (ban.lista("SELECT * FROM sms.login where login='" + TextBox1.Text + "' and Senha='" + TextBox2.Text + "'").Rows[0][1].ToString());
                Session["id"] = usu.idLogin.ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = "<div class='alert alert-danger'>Login ou senha incoreto.</div>";
            }
        }
    }
}