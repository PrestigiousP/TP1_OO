using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;

namespace TP1_OO
{

    class Partie
    {
        private Stack<Carte> pile = new Stack<Carte>();
        private Paquet paquet = new Paquet();


        private List<Joueur> listeJoueurs = new List<Joueur>();
        private int nbPersonnes;

        //regroupement des methodes pour initialiser une partie
        public void startPartie(List<Joueur> listeJoueurs)
        {
            //Instanciation pour les tests, a enlever apres.
            Joueur premierJoueur;
            int nbJoueurs = listeJoueurs.Count;
            PaquetPioche paquetP = new PaquetPioche();
            PaquetDepot paquetD = new PaquetDepot();
            Paquet paquet = new Paquet();
            //Rempli le paquet de cartes de toutes les cartes du jeu. 
            paquet.Remplir();
      
            //Brasse les cartes.
            paquet.Brasser(1000);
         
            //Distribue les cartes aux joueurs.
            paquet.DistribuerCartes(listeJoueurs);

            //Retourne une carte de départ sur de paquet de Dépot.
            paquetD.DeposerCarte(paquet.GetCarte());

            //Envoi les cartes a la fonction RemplirPioche qui remplit le paquetP.
            paquetP.RemplirPioche(paquet.GetPaquet());

            //Vide le paquet. 
            paquet.Vider();
            
            //Choisi le premier joueur à jouer.
            premierJoueur = JoueurDepart(listeJoueurs, nbJoueurs);

            //Creer une methode tour qui entre en argument le premier joueur.
            Jouer(premierJoueur, listeJoueurs, paquetD, paquetP);

        }

        public void Jouer(Joueur premierJoueur, List<Joueur> listeJoueurs, PaquetDepot paquetD, PaquetPioche paquetP)
        {
            int index = listeJoueurs.IndexOf(premierJoueur);
            Joueur joueur;
            int carteChoisi;
            bool gameover = false;
            while (!gameover)
            {
                joueur = listeJoueurs.ElementAt(index);
                Console.WriteLine("C'est le tour a " + joueur.ToString());
                Console.WriteLine("La dernière carte jouée est: " + paquetD.VoirCarte());      
                Console.WriteLine("Voici votre paquet: \n" + joueur.GetMain());
                Console.WriteLine("Entrez le numéro de carte que vous voulez jouer.");
                try
                {
                   carteChoisi = Int32.Parse(Console.ReadLine());
                   joueur.JouerCarte(carteChoisi);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Joueur JoueurDepart(List<Joueur> listeJoueurs, int nbJoueurs)
        {

            Random rand = new Random();
            int randNum = rand.Next(0, nbJoueurs);
            return listeJoueurs.ElementAt(randNum);
        }
    }
}