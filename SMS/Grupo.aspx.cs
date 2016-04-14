using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Grupo : System.Web.UI.Page
    {
        Obijeto.grupo grupo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["id"] != null)
            {
                grupo = new Obijeto.grupo(Convert.ToInt16(Page.Request["id"]));
                if (HttpContext.Current.Request.Url.AbsoluteUri != Request.ServerVariables.Get("HTTP_REFERER"))
                {
                    tx_nome.Text = grupo.Nome;
                }
            }
            else
            {
                grupo = new Obijeto.grupo();
            }
            GridView1.DataSource = grupo.lista();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            grupo.Nome = tx_nome.Text;
            grupo.salva();
            Response.Redirect("Grupo.aspx");
        }

        protected void edita(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(GridView1.DataKeys[index]["idGrupo"].ToString());
            Response.Redirect("Grupo.aspx?id=" + id);
        }

    }
}