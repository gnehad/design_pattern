using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using GestionEtudiants.model;
using GestionEtudiants.Utils;

namespace GestionEtudiants
{

    public partial class EtudiantUI : Window, IObserver
    {
        private GroupeEtudiants groupeEtudiants; //Référence vers l'objet observé
        public EtudiantUI()
        {
            groupeEtudiants = new GroupeEtudiants();
            //Ajout de la fenêtre comme observateur 
            groupeEtudiants.addObserver(this);
            InitializeComponent();
        }
        public void update()
        {
            /*
             * Ici, la fenêtre a reçu une notification de la part de l'objet observé GroupeEtudiants.
             * Elle met alors à jour ses composants (mise à jour de la présentation)
             */
            lsvEtudiants.ItemsSource = null;
            updateView();
        }

        private void btnAjouterClic(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdEtudiant.Text) || string.IsNullOrEmpty(txtMoyenne.Text) ||
                string.IsNullOrEmpty(txtMoyenne.Text))
            {
                MessageBox.Show("L'identifiant, le nom et la moyenne sont obligatoires", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int idEtudiant;
                double moyenne;
                if(!Int32.TryParse(txtIdEtudiant.Text, out idEtudiant) || 
                    !Double.TryParse(txtMoyenne.Text, out moyenne))
                {
                    MessageBox.Show("Mauvais format pour l'identfiant ou la moyenne", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(moyenne < 0 || moyenne > 100)
                    {
                        MessageBox.Show("La moyenne doit être entre 0 (inclus) et 100 (inclus)", 
                            "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Etudiant nouvelEtudiant = new Etudiant()
                        {
                            IdEtudiant = Int32.Parse(txtIdEtudiant.Text),
                            Nom = txtNom.Text,
                            Moyenne = Double.Parse(txtMoyenne.Text)
                        };
                        if (!groupeEtudiants.ajouter(nouvelEtudiant))
                        {
                            MessageBox.Show("L'identifiant " + txtIdEtudiant.Text + " est déjà utilisé",
                                "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            effacerComposants();
                        }
                    }
                }
            }
        }
        private void btnModfiierClic(object sender, RoutedEventArgs e)
        {
            Etudiant etudiantSelectionne = (Etudiant)lsvEtudiants.SelectedItem;
            if (etudiantSelectionne == null)
            {
                MessageBox.Show("Aucun étudiant n'a été sélectionné", "Stop",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                UpdateEtudiantUI modifierEtudiantUI = new UpdateEtudiantUI(this, etudiantSelectionne,
                    groupeEtudiants);
                this.Hide();
                modifierEtudiantUI.ShowDialog();
            }

        }

        private void btnSupprimerClic(object sender, RoutedEventArgs e)
        {
            Etudiant etudiantSelectionne = (Etudiant)lsvEtudiants.SelectedItem;
            if (etudiantSelectionne == null)
            {
                MessageBox.Show("Aucun étudiant n'a été sélectionné", "Stop",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                MessageBoxResult reponse = MessageBox.Show("Vous êtes sûr de vouloir supprimer l'étudiant sélectionné ?", 
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(reponse == MessageBoxResult.Yes)
                {
                    groupeEtudiants.supprimer(etudiantSelectionne);
                }
            }
        }

        private void initUI(object sender, RoutedEventArgs e)
        {
            updateView();

        }
        private void updateView()
        {
            List<Etudiant> listeEtudiants = groupeEtudiants.ListeEtudiants;
            listeEtudiants.Sort(delegate (Etudiant e1, Etudiant e2)
            {
                return e1.Moyenne.CompareTo(e2.Moyenne);
            });
            lsvEtudiants.ItemsSource = listeEtudiants;
            if (listeEtudiants.Count != 0)
            {
                txbMoyenne.Text = Statistiques.calculerMoyenne(listeEtudiants).ToString("F2") + "%";
                txbMediane.Text = Statistiques.determinerMediane(listeEtudiants).ToString("F2") + "%";
                txbEcartType.Text = Statistiques.calculerEcartType(listeEtudiants).ToString("F2") + "%";
                panneauStats.Visibility = Visibility.Visible;
            }
            else
            {
                panneauStats.Visibility = Visibility.Hidden;
            }
        }
        private void btnQuitterClic(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void effacerComposants()
        {
            txtIdEtudiant.Text = "";
            txtNom.Text = "";
            txtMoyenne.Text = "";
        }
    }
}
