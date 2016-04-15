using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SMS.Obijeto
{
    public class grupo
    {
        Banco.grupo dados = new Banco.grupo();
        public int idGrupo { get; set; }
        public string Nome { get; set; }

        public grupo()
        {

        }

        public grupo(int id)
        {
            DataTable dado = dados.getid(id);
            this.idGrupo = Convert.ToInt32(dado.Rows[0][0].ToString());
            this.Nome = dado.Rows[0][1].ToString();
        }

        public void salva()
        {
            if (this.idGrupo != 0)
            {
                dados.update(this);
            }
            else
            {
                dados.salvar(this);
            }
        }

        public DataSet lista()
        {
            return dados.lista();
        }
    }
}