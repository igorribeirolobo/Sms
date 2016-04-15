using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Padrao : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SMS sms = new SMS();
            lb_saldo.Text = sms.Saldo().ToString();

            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}