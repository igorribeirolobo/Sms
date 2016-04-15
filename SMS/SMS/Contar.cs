using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS
{
    public class Contar
    {
        Banco.Banco banco;
        private int contar;


    public void Contagem(int Contar, int usuario)
        {
            this.banco = new Banco.Banco();
            DateTime atual = DateTime.Now;
        
            banco.sql("INSERT INTO `tb_contagem` (`id` ,`id_user` ,`cont` ,`data`) VALUES ( NULL,'" + usuario + "','" + Contar + "','"+atual.Year+"-"+atual.Month+"-"+atual.Day+"')");


        }


    }
}