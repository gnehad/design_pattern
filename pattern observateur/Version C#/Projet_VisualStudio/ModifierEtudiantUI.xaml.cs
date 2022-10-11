using System;
using System.Windows;
using GestionEtudiants.model;
namespace GestionEtudiants
{
    public partial class UpdateEtudiantUI : Window
    {
        private EtudiantUI parent;
        private Etudiant etudiantCourant;
        private  GroupeEtudiants groupeEtudiants;
        public UpdateEtudiantUI(EtudiantUI parent, Etudiant etudiant, GroupeEtudiants groupeEtudiants)
        {   
            InitializeComponent();
            this.parent = parent;
            etudiantCourant = etudiant;
            this.groupeEtudiants = groupeEtudiants;
        }

        private void btnModfiierClic(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtMoyenne.Text))
            {
                MessageBox.Show("La moyenne n'a pas été saisie. Modification annulée",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                retourAuParent();
            }
            else
            {
                double nouvelleMoyenne;
                if(Double.TryParse(txtMoyenne.Text, out nouvelleMoyenne))
                {
                    etudiantCourant.Moyenne = Double.Parse(txtMoyenne.Text);
                    groupeEtudiants.modifier(etudiantCourant);
                    MessageBox.Show("Moyenne modifiée avec succès",
                    "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    retourAuParent();
                }
                else
                {
                    MessageBox.Show("La moyenne doit être une valeur numérique",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void btnAnnulerClic(object sender, RoutedEventArgs e)
        {
            retourAuParent();
        }

        private void retourAuParent()
        {
            this.Close();
            parent.Show();
        }
        private void initUI(object sender, RoutedEventArgs e)
        {
            txtIdEtudiant.Text = etudiantCourant.IdEtudiant.ToString();
            txtNom.Text = etudiantCourant.Nom;
            txtIdEtudiant.IsEnabled = false;
            txtNom.IsEnabled = false;
        }
    }
}
