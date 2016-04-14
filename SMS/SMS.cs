using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net.Configuration;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;

namespace SMS
{
    public class SMS
    {
            API.SMS sms;
        public SMS(){
            this.sms = new API.SMS(ConfigurationManager.AppSettings["Chave"].ToString());
            if(ConfigurationManager.AppSettings["Proxy"].ToString()=="True")
            {
                this.sms.Proxy(ConfigurationManager.AppSettings["URIProxy"].ToString());
            }
        }

        public int Saldo()
        {
           int qtd = Convert.ToInt16(sms.saldo());
            int i = 0;
            if(qtd <= 1000)
            { if (i == 0)
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("admin@hospitalinfantilsaocamilo.com.br");
                    mail.To.Add("informatica@hospitalinfantilsaocamilo.com.br");
                    mail.To.Add("info@hospitalinfantilsaocamilo.com.br");
                   // mail.To.Add("gerencia@hospitalinfantilsaocamilo.com.br");
                    mail.Subject = "Quantidade de sms ao fim";
                    mail.Body = "Estamos com um total de " + qtd.ToString() + " sms, favor avaliar a possibilidade de compra.";
                    SmtpClient smtp = new SmtpClient("192.168.0.201", 25);
                    smtp.EnableSsl = false;
                    NetworkCredential cred = new NetworkCredential("admin", "weshisc");
                    smtp.Credentials = cred;
                    smtp.UseDefaultCredentials = true;
                    smtp.Send(mail);
                    i++;
                }

            }
            return Convert.ToInt16(sms.saldo());
        }

        public Boolean envio(string destinatario, string mensagem)
        {
            return sms.EnviarMensagem("API", destinatario, mensagem);
        }
    }
}