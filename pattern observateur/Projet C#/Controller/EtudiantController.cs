using System.Collections.Generic;
using ProjetDP.Model;
namespace ProjetDP.Controller
{
    public class EtudiantController
    {
        EtudiantDAO contactDao = new EtudiantDAO();
        public List<Etudiant> getEtudiantList()
        {
            return contactDao.findAll();
        }

        public Etudiant getEtudiant(int idEtudiant)
        {
            return contactDao.findById(idEtudiant);
        }


        public void createEtudiant(Etudiant etudiant) 
        {
            contactDao.create(etudiant);
        }

        public void updateEtudiant(Etudiant etudiant)
        {
            contactDao.update(etudiant);
        }

        public void deleteEtudiant(int idEtudiant)
        {
            contactDao.delete(idEtudiant);
        }
    }
}
