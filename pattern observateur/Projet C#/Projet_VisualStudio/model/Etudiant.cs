namespace GestionEtudiants.model
{
    public class Etudiant
    {
        public int IdEtudiant
        {set; get;}
        public string Nom 
        {get; set;}
        public double Moyenne 
        {get; set;}

        public Etudiant()
        {
        }

        public Etudiant(int idEtudiant, string nom, double moyenne)
        {
            IdEtudiant = idEtudiant;
            Nom = nom;
            Moyenne = moyenne;
        }
    }
}
