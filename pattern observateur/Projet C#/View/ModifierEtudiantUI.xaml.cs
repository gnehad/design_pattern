using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjetDP.Controller;
using ProjetDP.Model;

namespace ProjetDP.View
{
    /// <summary>
    /// Logique d'interaction pour ModifierEtudiantUI.xaml
    /// </summary>
    public partial class ModifierEtudiantUI : Window
    {
        private Etudiant etudiant;
        private EtudiantController etudiantController;
        public ModifierEtudiantUI(EtudiantController etudiantController, Etudiant etudiant)
        {
            InitializeComponent();
            this.etudiant = etudiant;
            this.etudiantController = etudiantController;
        }

        private void btnModfiierClic(object sender, RoutedEventArgs e)
        {
            double moyenne;
            if (string.IsNullOrEmpty(txtMoyenne.Text))
            {
                MessageBox.Show("La saisie de la nouvelle moyenne est obligatoire", 
                    "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }else if(!Double.TryParse(txtMoyenne.Text.Trim(), out moyenne))
            {
                MessageBox.Show("La nouvelle moyenne doit être une valeur numérique",
                    "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Etudiant etudiantModifie = new Etudiant()
                {
                    IdEtudiant = etudiant.IdEtudiant,
                    Nom = etudiant.Nom,
                    Prenom = etudiant.Prenom,
                    Moyenne = moyenne
                };
                etudiantController.updateEtudiant(etudiantModifie);
                MessageBox.Show("Moyenne modifiée avec succès", "Confirmation",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void btnAnnulerClic(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void initUI(object sender, RoutedEventArgs e)
        {
            txtIdEtudiant.Text = etudiant.IdEtudiant.ToString();
            txtNom.Text = etudiant.Nom;
            txtPrenom.Text = etudiant.Prenom;
            txtMoyenne.Text = etudiant.Moyenne.ToString();
            /*
             * On désactive la modification du nom, du prénom et l'identifiant de 
             * l'étudiant
             */
            txtIdEtudiant.IsEnabled = false;
            txtNom.IsEnabled = false;
            txtPrenom.IsEnabled = false;
        }
    }
}
