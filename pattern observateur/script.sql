DROP TABLE IF EXISTS Etudiant;
CREATE TABLE Etudiant(
 idEtudiant INTEGER NOT NULL,
 nom VARCHAR(25) NOT NULL, 
 prenom VARCHAR(25) NOT NULL,
 moyenne DECIMAL(5, 2) NOT NULL, 
 CONSTRAINT Pk_Etudiant PRIMARY KEY(idEtudiant)
 );
 
 
 
 
 INSERT INTO Etudiant(idEtudiant, nom, prenom, moyenne) 
 VALUES
	(100, 'Le gris', 'Gandalf', 98),
	(101, 'Le grand', 'Sauron', 90),
	(102, 'Moriaty', 'James', 100),
	(103, 'Watson', 'John', 77),
	(104, 'Lupin', 'Arsène', 98),
	(105, 'Holmes', 'Sherlock', 98);