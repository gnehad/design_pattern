using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDP.Model
{
    public class Etudiant
    {
        public int IdEtudiant
        {
            set;get;
        }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public double Moyenne { get; set; }

        public Etudiant()
        {

        }

        public Etudiant(int idEtudiant, string nom, string prenom, double moyenne)
        {
            IdEtudiant = idEtudiant;
            Nom = nom; 
            Prenom = prenom; 
            Moyenne = moyenne; 
        }

        public override string ToString()
        {
            return "id : " + IdEtudiant + "\nNom : " + Nom + 
                "\nPrénom : " + Prenom +"\nMoyenne : " + Moyenne + "\n";
        }

    }
}
