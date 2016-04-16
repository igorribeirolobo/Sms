using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Obijeto
{
    public class Usuario
    {
        Banco.Usuario ban = new Banco.Usuario();

        public int idLogin{get;set;}
        public string Nome{get;set;}
        public string Setor{get;set;}
        public string Login{get;set;}
        public string Senha { get; set; }

        public Boolean valida()
        {
            return ban.valida(this);
        }

    }
}