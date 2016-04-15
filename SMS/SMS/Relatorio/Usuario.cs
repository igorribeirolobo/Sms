using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Relatorio
{
    public class Usuario
    {
        Banco.Banco bd = new Banco.Banco();
        public String Total(string usuario)
        {
            int qtd = 0;
            string retorno = null;
            int cont = bd.lista("SELECT * FROM tb_contagem WHERE id_user='"+usuario+"'").Rows.Count;
            if (bd.lista("SELECT * FROM tb_contagem WHERE id_user='" + usuario + "'").Rows.Count != 0)
            {
                for (int i = 0; i <= cont; i++)
                {
                    for (int v = 0; v<= 4; v++)
                    {
                        qtd += int.Parse(bd.lista("SELECT * FROM tb_contagem WHERE id_user='" + usuario + "'").Rows[i][v].ToString());
                        retorno = qtd.ToString();
                    }
                }
            }
            else
            {
                retorno = "error!";
            }
            return retorno;

        }

    }
}