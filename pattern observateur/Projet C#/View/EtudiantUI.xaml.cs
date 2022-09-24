using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Org.BouncyCastle.Bcpg;
using ProjetDP.Controller;
using ProjetDP.Model;

namespace ProjetDP.View
{
    /// <summary>
    /// Interaction logic for EtudiantUI.xaml
    /// </summary>
    public partial class EtudiantUI : Window, Observable
    {
        private List<Etudiant> listeEtudiants;
        public List<Etudiant> ListeEtudiants
        {
            get 
            { 
                return listeEtudiants; 
            }
        }
        private EtudiantController etudiantController;
        private List<Observer> observers;
        public EtudiantUI()
        {
            observers = new List<Observer>();
            etudiantController = new EtudiantController();
            listeEtudiants = etudiantController.getEtudiantList();
            InitializeComponent();
        }

        private void initUI(object sender, RoutedEventArgs e)
        {
            ObserverImp observerImp = new ObserverImp(this);
            addObserver(observerImp);
            lsvEtudiant.ItemsSource = listeEtudiants;
        }

        private void btnAjouterClic(object sender, RoutedEventArgs e)
        {

            /*On met à jour la ListView des contacts.
             * Cela peut être évité en implémentant INotifyPropertyChanged au niveau de la classe
             * Contact
            */
            /*
             * Réaliser des controles de validation sur la saisie de l'utilisateur
             */
            int idEtudiant = Int32.Parse(txtIdEtudiant.Text);
            double moyenne = Double.Parse(txtMoyenne.Text);
            Etudiant etudiant = new Etudiant(idEtudiant, txtNom.Text, txtPrenom.Text, moyenne);
            etudiantController.createEtudiant(etudiant);
            updateView();
            notifyObservers();
        }

        private void btnModfiierClic(object sender, RoutedEventArgs e)
        {
            Etudiant etudiantSelectionne = (Etudiant)lsvEtudiant.SelectedItem;
            if (etudiantSelectionne == null)
            {
                MessageBox.Show("Vous devez sélectionner l'étudiant à modifier", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ModifierEtudiantUI modifierEtudiantUI = new ModifierEtudiantUI(etudiantController, etudiantSelectionne);
                modifierEtudiantUI.ShowDialog();
                updateView();
                notifyObservers();
            }
        }

        private void btnSupprimerClic(object sender, RoutedEventArgs e)
        {
            Etudiant etudiantSelectionne = (Etudiant)lsvEtudiant.SelectedItem;
            if (etudiantSelectionne == null)
            {
                MessageBox.Show("Vous devez sélectionner le etudiant à supprimer", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                /*
                 * On supprime de la BD l'étudiant qui correpond au contactId du etudiant sélectionné
                 * dans la ListView
                 */
                etudiantController.deleteEtudiant(etudiantSelectionne.IdEtudiant);
                updateView();
                notifyObservers();
            }
        }
        private void updateView()
        {
            listeEtudiants = etudiantController.getEtudiantList();
            lsvEtudiant.ItemsSource = listeEtudiants;
        }
        public void addObserver(Observer observer) 
        {
            observers.Add(observer);
        }
        public void removeObserver(Observer observer) 
        {
            observers.Remove(observer);
        }
        public void notifyObservers() 
        {
            /*
             * On récupère un objet IEnumerator pour itérer la liste des observateurs
             * La méthode MoveNext() fait avancer l'itérateur vers le prochain élément.
             * Elle renvoie false s'il n'y aucun élément dans l'énumérateur
             * 
             * La propriété Current contient une référence vers l'élément courant de 
             * l'énumérateur
             */
            using(IEnumerator<Observer> enumerator = observers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Observer observer = enumerator.Current;
                    observer.update();
                }
            } 
        }
        public void afficherStats()
        {
            lblStats.Visibility = Visibility.Visible;
            lblMoyenne.Visibility = Visibility.Visible;
            txbMoyenne.Visibility = Visibility.Visible;
            lblPremier.Visibility = Visibility.Visible;
            txbPremierEtudiant.Visibility = Visibility.Visible;
            lblDernier.Visibility = Visibility.Visible;
            txbDernierEtudiant.Visibility = Visibility.Visible;
        }
    }
}
