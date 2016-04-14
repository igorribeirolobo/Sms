using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Obijeto
{
    public class Mensagem
    {
        public int idSMS {get; set;}
        public int Destinatario {get; set;}
        public String Menssagem {get; set;}
        public int Login_idLogin {get; set;}
    }
}