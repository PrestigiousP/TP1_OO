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

        //regroupement des methodes pour initialiser une partie
        public void startPartie(List<Joueur> listeJoueurs, PaquetDepot paquetD, PaquetPioche paquetP, Paquet paquet)
        {
            //Instanciation pour les tests, a enlever apres.
            Joueur premierJoueur;
            int nbJoueurs = listeJoueurs.Count;
   
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
                if(index == listeJoueurs.Count)
                {
                    index = 0;
                }
                else
                {
                    try
                    {
                        joueur = listeJoueurs.ElementAt(index);
                        Console.WriteLine("\nC'est le tour a " + joueur.ToString() + "\n");
                        Console.WriteLine("La dernière carte jouée est: " + paquetD.VoirCarte().ToString());
                        Console.WriteLine("Voici votre paquet: \n" + joueur.GetMain());
                        Console.WriteLine("Entrez le numéro de carte que vous voulez jouer.");
                        carteChoisi = Int32.Parse(Console.ReadLine());

                        index = VerifierCarte(joueur, carteChoisi, index, paquetD);
                        gameover = VerifierGagnant(listeJoueurs);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("J'ai attrapé l'erreur ici");
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public static int VerifierCarte(Joueur joueur, int carteChoisi, int index, PaquetDepot paquetD)
        {
            if(joueur.GetCarte(carteChoisi).GetCouleur() == paquetD.VoirCarte().GetCouleur() || 
                joueur.GetCarte(carteChoisi).GetValeur() == paquetD.VoirCarte().GetValeur())
            {
                joueur.JouerCarte(carteChoisi);
                index++;
                return index;
            }
            else
            {
                Console.WriteLine("Vous ne pouvez pas jouer cette carte.");
                return index;
            }
        }

        public static bool VerifierGagnant(List<Joueur> listeJoueurs)
        {
            bool gameover = false;
            foreach(Joueur joueur in listeJoueurs)
            {
                if(joueur.NbCartes() == 0)
                {
                    gameover = true;
                    return gameover;
                }
                else
                {
                    return gameover;
                }
            }
            return gameover;
        }

        public Joueur JoueurDepart(List<Joueur> listeJoueurs, int nbJoueurs)
        {

            Random rand = new Random();
            int randNum = rand.Next(0, nbJoueurs);
            return listeJoueurs.ElementAt(randNum);
        }
    }
}