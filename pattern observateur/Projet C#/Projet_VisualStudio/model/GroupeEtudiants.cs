using System.Collections.Generic;

namespace GestionEtudiants.model
{
    public class GroupeEtudiants : IObservable
    {
        List<IObserver> listeObservateur;
        /* 
         Objet observé : doit notifier les observateur à chaque changement survenu dans sa 
        liste d'étudiants (ajout, suppression, modification) 
         */

        private List<Etudiant> listeEtudiants = new List<Etudiant>()
        {
            new Etudiant(100, "Gandalf le gris", 98),
            new Etudiant(101, "Sauron", 90),
            new Etudiant(102, "James Moriarty", 100),
            new Etudiant(103, "Arsène Lupin", 80),
            new Etudiant(104, "Sherlock Holmes", 100), 
            new Etudiant(105, "John Watson", 83)
        };
        public List<Etudiant> ListeEtudiants
        {
            set { listeEtudiants = value; }
            get { return listeEtudiants; }
        }

        public GroupeEtudiants()
        {
            listeObservateur = new List<IObserver>();
        }

        public bool ajouter(Etudiant etudiant)
        {
            if (indexOf(etudiant) == -1)
            {
                listeEtudiants.Add(etudiant);
                notifyObservers();
                return true;
            }
            return false;
        }

        public void supprimer(Etudiant etudiant)
        {
            int index = indexOf(etudiant);
            if (indexOf(etudiant) != -1)
            {
                listeEtudiants.RemoveAt(index);
                notifyObservers();
            }

        }

        public void modifier(Etudiant etudiant)
        {
            int index = indexOf(etudiant);
            if (indexOf(etudiant) != -1)
            {
                listeEtudiants[index] = etudiant;
                notifyObservers();
            }
        }

        /* Cette méthode renvoie la position d'un étudiant existe dans la liste des étudiants, 
         * ou -1 en si la liste ne contient pas l'étudiant en question.
         * la comparaison utilise l'identifiant de l'étudiant comme seul critère 
         * de comparaison
         */
        private int indexOf(Etudiant etudiant)
        {
            /*
             * La liste est parcouru en utilisant un itérateur : il s'agit d'un objet IEnumerator,
             * qui s'obtient via la méthode GetEnumerator() de la classe List
             * 
             * La méthode MoveNext() de cet objet fait avancer l'itérateur vers le prochain élément.
             * Elle renvoie false s'il n'y aucun élément dans l'énumérateur
             * 
             * Sa propriété Current contient une référence vers l'élément courant de l'énumérateur
             */
            int index = 0;
            using (IEnumerator<Etudiant> enumerator = listeEtudiants.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Etudiant etudiantCourant = enumerator.Current;
                    if(etudiantCourant.IdEtudiant == etudiant.IdEtudiant)
                    {
                        return index;
                    }
                    index++;
                }
            }
            return -1;
        }
        public void addObserver(IObserver observateur) 
        {
            listeObservateur.Add(observateur);
        }
        public void removeObserver(IObserver observateur)
        {
            listeObservateur.Remove(observateur);
        }
        public void notifyObservers()
        {
            using (IEnumerator<IObserver> enumerator = listeObservateur.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.update();
                }
            }
        }
    }
}
