using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS
{
    public class select
    {
        Banco.Banco banco = new Banco.Banco();
        public string setor(string id)
        {   
            string sql = "SELECT * FROM tb_contagem WHERE id_user=" + id.ToString();
            this.banco.lista(sql);
            return "ola";
        }


    }
}