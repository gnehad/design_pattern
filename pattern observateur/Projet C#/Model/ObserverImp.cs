using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDP.View;

namespace ProjetDP.Model
{
    class ObserverImp : Observer
    {
        EtudiantUI etudiantUI;
        public ObserverImp(EtudiantUI etudiantUI)
        {
            this.etudiantUI = etudiantUI;
        }

        public void update()
        {
            etudiantUI.txbMoyenne.Text = calculerMoyenneGroupe(etudiantUI.ListeEtudiants).ToString("F2");
            etudiantUI.txbPremierEtudiant.Text = getPremierEtudiant(etudiantUI.ListeEtudiants).Nom + 
                " " + getPremierEtudiant(etudiantUI.ListeEtudiants).Prenom;
            etudiantUI.txbDernierEtudiant.Text = getDernierEtudiant(etudiantUI.ListeEtudiants).Nom +
                " " + getDernierEtudiant(etudiantUI.ListeEtudiants).Prenom;
            etudiantUI.afficherStats();
        }
        private double calculerMoyenneGroupe(List<Etudiant> listeEtudiants)
        {
            double somme = 0;
            foreach(Etudiant etudiant in listeEtudiants)
            {
                somme += etudiant.Moyenne;
            }
            return somme / listeEtudiants.Count;
        }

        private Etudiant getPremierEtudiant(List<Etudiant> listeEtudiants)
        {
            Etudiant meilleurEtudiant = listeEtudiants[0];
            for(int i = 0; i < listeEtudiants.Count; i++)
            {
                if (listeEtudiants[i].Moyenne > meilleurEtudiant.Moyenne)
                {
                    meilleurEtudiant = listeEtudiants[i];
                }
            }
            return meilleurEtudiant;
        }
        private Etudiant getDernierEtudiant(List<Etudiant> listeEtudiants)
        {
            Etudiant dernierEtudiant = listeEtudiants[0];
            for (int i = 0; i < listeEtudiants.Count; i++)
            {
                if (listeEtudiants[i].Moyenne < dernierEtudiant.Moyenne)
                {
                    dernierEtudiant = listeEtudiants[i];
                }
            }
            return dernierEtudiant;
        }
    }
    
}
