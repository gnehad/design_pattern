using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProjetDP.Model
{
    public class ConnectionFactory
    {
        private static MySqlConnection connection = null;
        private static string connexionString = @"server=localhost;userid=root;database=bd_etudiants"; 
        public static MySqlConnection getConnection()
        {
            try
            {
                connection = new MySqlConnection(connexionString);
            }catch(MySqlException e)
            {
               // throw new Exception(e.Message);
               MessageBox.Show("COnnexionFactory : " + e.Message);
            }
            return connection; 
        }
        public void closeConnection(){
            if(connection != null)
            {
                connection.Close();
            }
        }
    }
}
