using System.Collections.Generic;
using System;
using GestionEtudiants.model;
using System.Windows;

namespace GestionEtudiants.Utils
{
    public class Statistiques
    {
        public static double calculerMoyenne(List<Etudiant> listeEtudiants)
        {
            double somme = 0;
            foreach(Etudiant etudiant in listeEtudiants)
            {
                somme += etudiant.Moyenne;
            }
            return somme / listeEtudiants.Count;
        }
        public static double determinerMediane(List<Etudiant> listeEtudiants)
        {
            double mediane;
            int n = listeEtudiants.Count;
            if(n % 2 != 0)
            {
                mediane = listeEtudiants[n / 2].Moyenne;
            }
            else
            {
                mediane = (listeEtudiants[n / 2].Moyenne + listeEtudiants[(n / 2) - 1].Moyenne) / 2;
            }
            return mediane;
        }

        public static double calculerEcartType(List<Etudiant> listeEtudiants)
        {
            int n = listeEtudiants.Count;
            double moyenne = calculerMoyenne(listeEtudiants);
            double somme = 0.0;
            foreach(Etudiant etudiant in listeEtudiants)
            {
                somme += Math.Pow(etudiant.Moyenne, 2);
            }
            return  Math.Sqrt(Math.Abs((somme / n) - Math.Pow(moyenne, 2)));
        }
    }
}
