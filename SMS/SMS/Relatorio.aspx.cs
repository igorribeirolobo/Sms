using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace SMS
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        Banco.Banco banco = new Banco.Banco();

        protected void Page_Load(object sender, EventArgs e)
        {

            

        }

        protected void Total_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void RbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
                tblrelatorio.Visible = true;
            if (tblrelatorio1.Visible == true)
            {
                tblrelatorio1.Visible = false;
            }
            TableRow tb = new TableRow();
                tblrelatorio.Rows.Add(tb);
                TableCell cell = new TableCell();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell.Text = "Usuário";
                cell1.Text = "Quantidade de Sms";
                cell2.Text = "Data";
                tb.Cells.Add(cell);
                tb.Cells.Add(cell1);
                tb.Cells.Add(cell2);
                string sql = "SELECT * FROM tb_contagem WHERE id_user=" + ddSetor.SelectedValue;
                string sql1 = "SELECT * FROM login WHERE idLogin=" + ddSetor.SelectedValue;
                MySqlDataReader reader = this.banco.leitor(sql);
                MySqlDataReader ler = this.banco.leitor(sql1);
            int soma= 0;
                while (ler.Read())
                {
                    while (reader.Read())
                    {

                        TableRow tb1 = new TableRow();
                        tblrelatorio.Rows.Add(tb1);
                        TableCell coluna = new TableCell();
                        TableCell coluna1 = new TableCell();
                        TableCell coluna2 = new TableCell();
                        soma += Convert.ToInt16(reader["cont"].ToString());
                        coluna.Text = ler["Nome"].ToString();
                        coluna1.Text = reader["cont"].ToString();
                        coluna2.Text = reader["data"].ToString();
                        tb1.Cells.Add(coluna);
                        tb1.Cells.Add(coluna1);
                        tb1.Cells.Add(coluna2);


                    }
                }
            TableRow tb2 = new TableRow();
            tblrelatorio.Rows.Add(tb2);
            TableCell total = new TableCell();
            TableCell total1 = new TableCell();
            total.Text = "Total.:";
            total1.Text = soma.ToString();
            tb2.Cells.Add(total);
            tb2.Cells.Add(total1);


        }
   

        protected void ddSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void btnSetor_Click(object sender, EventArgs e)
        {
            ddSetor.DataSource = this.banco.lista("select * from login");
            ddSetor.DataTextField = "Nome";
            ddSetor.DataValueField = "idLogin";
            ddSetor.DataBind();
            ddSetor.Visible = true;
            btnGerar.Visible = true;
            lbldataini.Visible = false;
            lbldatafim.Visible = false;
            btnGerar1.Visible = false;
            cdini.Visible = false;
            cdfim.Visible = false;
            btnGerar2.Visible = false;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            lbldataini.Visible = true;
            lbldatafim.Visible = true;
            cdini.Visible = true;
            cdfim.Visible = true;
            btnGerar1.Visible = true;
            ddSetor.Visible = false;
            btnGerar.Visible = false;
            btnGerar2.Visible = false;
        }

        protected void btnGerar1_Click(object sender, EventArgs e)
        {
            tblrelatorio1.Visible = true;
            if(tblrelatorio.Visible == true)
            {
                tblrelatorio.Visible = false;
            }
            TableRow tb = new TableRow();
            tblrelatorio1.Rows.Add(tb);
            TableCell cell = new TableCell();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            cell.Text = "Usuário";
            cell1.Text = "Quantidade de Sms";
            cell2.Text = "Data";
            tb.Cells.Add(cell);
            tb.Cells.Add(cell1);
            tb.Cells.Add(cell2);
            string dataini = cdini.SelectedDate.ToString();
            string[] inicio = dataini.Split(" ".ToCharArray());
            string[] inidata = inicio[0].Split("/".ToCharArray());
            string nova_dataini = inidata[2] + "/" + inidata[1] + "/" + inidata[0] + " " + inicio[1];
            string datafim = cdfim.SelectedDate.ToString();
            string[] fim = datafim.Split(" ".ToCharArray());
            string[] fimdata = fim[0].Split("/".ToCharArray());
            string nova_datafim = fimdata[2] + "/" + fimdata[1] + "/" + fimdata[0] + " " + fim[1];
            string sql = "SELECT * FROM tb_contagem WHERE data >='" + nova_dataini + "' AND data <='" + nova_datafim+"'";
            MySqlDataReader reader = this.banco.leitor(sql);
            int soma = 0;
            
                while (reader.Read())
                {   
                    TableRow tb1 = new TableRow();
                    tblrelatorio1.Rows.Add(tb1);
                    TableCell coluna = new TableCell();
                    TableCell coluna1 = new TableCell();
                    TableCell coluna2 = new TableCell();
                    soma += Convert.ToInt16(reader["cont"].ToString());
                string sql1 = "select * from login where idLogin=" + reader["id_user"].ToString();
                MySqlDataReader ler = this.banco.leitor(sql1);
                while(ler.Read())
                {
                    coluna.Text = ler["Nome"].ToString();
                }   
                    coluna1.Text = reader["cont"].ToString();
                    coluna2.Text = reader["data"].ToString();
                    tb1.Cells.Add(coluna);
                    tb1.Cells.Add(coluna1);
                    tb1.Cells.Add(coluna2);
                }
            
            TableRow tb2 = new TableRow();
            tblrelatorio1.Rows.Add(tb2);
            TableCell total = new TableCell();
            TableCell total1 = new TableCell();
            total.Text = "Total.:";
            total1.Text = soma.ToString();
            tb2.Cells.Add(total);
            tb2.Cells.Add(total1);
        }

        protected void btnds_Click(object sender, EventArgs e)
        {
            ddSetor.DataSource = this.banco.lista("select * from login");
            ddSetor.DataTextField = "Nome";
            ddSetor.DataValueField = "idLogin";
            ddSetor.DataBind();
            lbldataini.Visible = true;
            lbldatafim.Visible = true;
            cdini.Visible = true;
            cdfim.Visible = true;
            btnGerar1.Visible = false;
            ddSetor.Visible = true;
            btnGerar.Visible = false;
            btnGerar2.Visible = true;

        }

        protected void btnGerar2_Click(object sender, EventArgs e)
        {
            tblrelatorio1.Visible = true;
            if (tblrelatorio.Visible == true)
            {
                tblrelatorio.Visible = false;
            }
            TableRow tb = new TableRow();
            tblrelatorio1.Rows.Add(tb);
            TableCell cell = new TableCell();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            cell.Text = "Usuário";
            cell1.Text = "Quantidade de Sms";
            cell2.Text = "Data";
            tb.Cells.Add(cell);
            tb.Cells.Add(cell1);
            tb.Cells.Add(cell2);
            string dataini = cdini.SelectedDate.ToString();
            string[] inicio = dataini.Split(" ".ToCharArray());
            string[] inidata = inicio[0].Split("/".ToCharArray());
            string nova_dataini = inidata[2] + "/" + inidata[1] + "/" + inidata[0] + " " + inicio[1];
            string datafim = cdfim.SelectedDate.ToString();
            string[] fim = datafim.Split(" ".ToCharArray());
            string[] fimdata = fim[0].Split("/".ToCharArray());
            string nova_datafim = fimdata[2] + "/" + fimdata[1] + "/" + fimdata[0] + " " + fim[1];
            string sql = "SELECT * FROM login WHERE idLogin=" + ddSetor.SelectedValue;
            string sql1 = "SELECT * FROM tb_contagem WHERE id_user=" + ddSetor.SelectedValue + " AND data >=" + dataini + " AND data <=" + datafim;
            MySqlDataReader reader = this.banco.leitor(sql);
            MySqlDataReader ler = this.banco.leitor(sql1);
            int soma = 0;
            while(reader.Read())
            {  
                while(ler.Read())
                {
                    TableRow tb1 = new TableRow();
                    tblrelatorio.Rows.Add(tb1);
                    TableCell coluna = new TableCell();
                    TableCell coluna1 = new TableCell();
                    TableCell coluna2 = new TableCell();
                    soma += Convert.ToInt16(reader["cont"].ToString());
                    coluna.Text = ler["Nome"].ToString();
                    coluna1.Text = reader["cont"].ToString();
                    coluna2.Text = reader["data"].ToString();
                    tb1.Cells.Add(coluna);
                    tb1.Cells.Add(coluna1);
                    tb1.Cells.Add(coluna2);
                }
                
            }

        }
    }
}