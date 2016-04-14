using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SMS.Banco
{
    public class Banco
    {
        private String SqlConection = ConfigurationManager.AppSettings["StringDeConexao"].ToString();
        public void sql(string strQuery)
        {
            DataTable dtcliente = new DataTable();
            MySqlConnection objcon = new MySqlConnection(SqlConection);
            MySqlDataAdapter objAdp = new MySqlDataAdapter(strQuery, objcon);
            objAdp.Fill(dtcliente);
            objcon.Close();
        }
        public DataSet grid(string strQuery)
        {
            DataSet grid_var = new DataSet();
            MySqlConnection objcon = new MySqlConnection(SqlConection);
            MySqlDataAdapter objAdp = new MySqlDataAdapter(strQuery, objcon);
            objAdp.Fill(grid_var);
            objcon.Close();
            return grid_var;
        }
        public DataTable lista(string strQuery)
        {
            DataTable grid_var = new DataTable();
            MySqlConnection objcon = new MySqlConnection(SqlConection);
            MySqlDataAdapter objAdp = new MySqlDataAdapter(strQuery, objcon);
            objAdp.Fill(grid_var);
            objcon.Close();
            return grid_var;
        }
        public MySqlDataReader leitor(string strQuery)
        {
            MySqlConnection objcon = new MySqlConnection(SqlConection);
            objcon.Open();
            MySqlCommand cmd = new MySqlCommand(strQuery,objcon);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
            
        }
    }
}