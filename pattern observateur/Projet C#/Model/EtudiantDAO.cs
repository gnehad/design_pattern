using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace ProjetDP.Model
{
    public class EtudiantDAO
    {
        private MySqlConnection connection = ConnectionFactory.getConnection();
        public EtudiantDAO()
        {}
        public void create(Etudiant etudiant)
        {
            try
            {

                connection.Open();
                string query = "INSERT INTO Etudiant(idEtudiant, nom, prenom, moyenne) VALUES(@idEtudiant, @nom, @prenom, @moyenne)";
                MySqlCommand comnand = connection.CreateCommand();
                comnand.CommandText = query;
                comnand.Parameters.AddWithValue("@idEtudiant", etudiant.IdEtudiant);
                comnand.Parameters.AddWithValue("@nom", etudiant.Nom);
                comnand.Parameters.AddWithValue("@prenom", etudiant.Prenom);
                comnand.Parameters.AddWithValue("@moyenne", etudiant.Moyenne);
                comnand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw new Exception(e.Message);
            }
        }
        public Etudiant findById(int idEtudiant)
        {
            Etudiant etudiant = null;
            try
            {
                connection.Open();
                string query = "SELECT idEtudiant, nom, prenom, moyenne FROM Etudiant" +
                               " WHERE idEtudiant = @idEtudiant";
                MySqlCommand comnand = connection.CreateCommand();
                comnand.CommandText = query;
                comnand.Parameters.AddWithValue("@idEtudiant", idEtudiant);
                MySqlDataReader cursor = comnand.ExecuteReader();
                if(cursor.Read())
                {
                    etudiant = new Etudiant()
                    {
                        IdEtudiant = cursor.GetInt32(0),
                        Nom = cursor.GetString(1),
                        Prenom = cursor.GetString(2), 
                        Moyenne = cursor.GetDouble(3)
                    };
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                MessageBox.Show("DAO findById : " + e.Message);
                // new Exception(e.Message);
            }
            return etudiant;
        }

        public List<Etudiant> findAll()
        {
            List<Etudiant> listEtudiant = new List<Etudiant>();
            try
            {
                connection.Open();
                string query = "SELECT idEtudiant, nom, prenom, moyenne FROM Etudiant";
                MySqlCommand comnand = connection.CreateCommand();
                comnand.CommandText = query;
                MySqlDataReader cursor = comnand.ExecuteReader();
                while(cursor.Read())
                {
                    Etudiant etudiant = new Etudiant()
                    {
                        IdEtudiant = cursor.GetInt32(0),
                        Nom = cursor.GetString(1),
                        Prenom = cursor.GetString(2),
                        Moyenne = cursor.GetDouble(3)
                    };
                    listEtudiant.Add(etudiant);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                if(connection == null)
                {
                    MessageBox.Show("nnull");
                }
                else {
                    connection.Close();
                    MessageBox.Show(listEtudiant.Count.ToString());
                    MessageBox.Show(connection.ToString());
                    MessageBox.Show("DAO findAll : " + e.Message);
                }
                    
                
            }
            return listEtudiant;
        }

        public void update(Etudiant etudiant)
        {
            try
            {
                connection.Open();
                string query = "UPDATE Etudiant SET nom = @nom , prenom = @prenom, moyenne = @moyenne" +
                               " WHERE idEtudiant = @idEtudiant";
                MySqlCommand comnand = connection.CreateCommand();
                comnand.CommandText = query;
                comnand.Parameters.AddWithValue("@idEtudiant", etudiant.IdEtudiant);
                comnand.Parameters.AddWithValue("@nom", etudiant.Nom);
                comnand.Parameters.AddWithValue("@prenom", etudiant.Prenom);
                comnand.Parameters.AddWithValue("@moyenne", etudiant.Moyenne);
                comnand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                if (connection == null)
                {
                    MessageBox.Show("Connexion null");
                }
                else
                {
                    connection.Close();
                    MessageBox.Show("update : " + e.Message);
                }
                // throw new Exception(e.Message);

            }
        }

        public void delete(int idEtudiant)
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM Etudiant WHERE idEtudiant = @idEtudiant";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@idEtudiant", idEtudiant);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
