using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SMS.Banco
{
    public class grupo
    {
        Banco con = new Banco();

        public void salvar(Obijeto.grupo grupo)
        {
            con.sql("INSERT INTO `grupo` (`idGrupo`,`Nome`) VALUES (NULL, '"+grupo.Nome+"')");
        }

        public void update(Obijeto.grupo grupo)
        {
            con.sql("UPDATE `grupo` SET `Nome` = '" + grupo.Nome + "' WHERE `idGrupo` = " + grupo.idGrupo);
        }

        public DataSet lista()
        {
            return con.grid("SELECT * FROM grupo");
        }

        public DataTable getid(int id)
        {
            return con.lista("SELECT * FROM grupo WHERE `idGrupo`=" + id);
        } 
    }
}