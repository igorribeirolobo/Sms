using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Banco
{
    public class Usuario
    {
        Banco con=new Banco();
        public Boolean valida(Obijeto.Usuario usuario)
        {
            if (this.con.lista("SELECT * FROM sms.login where login='" + usuario.Login + "' and Senha='" + usuario.Senha + "'").Rows.Count > 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}