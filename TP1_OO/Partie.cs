using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Text;

namespace TP1_OO
{

    class Partie
    {
        //regroupement des methodes pour initialiser une partie
        public void startPartie(List<Joueur> listeJoueurs, PaquetDepot paquetD, PaquetPioche paquetP, Paquet paquet)
        {
            //Instanciation pour les tests, a enlever apres.
            Joueur joueur;
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
            joueur = JoueurDepart(listeJoueurs, nbJoueurs);

            //Creer une methode tour qui entre en argument le premier joueur.
            Jouer(joueur, listeJoueurs, paquetD, paquetP);

      

        }

        public void Jouer(Joueur joueur, List<Joueur> listeJoueurs, PaquetDepot paquetD, PaquetPioche paquetP)
        {
            int index = listeJoueurs.IndexOf(joueur);
            //Joueur joueur;
            int carteChoisi = 0;
            int sens = 1;
            int saut = 0;
            bool verification;
            bool gameover = false;
            while (!gameover)
            {
                try
                {

                    verification = true;
                    joueur = listeJoueurs.ElementAt(index);
                    Console.WriteLine("\nC'est le tour à " + joueur.ToString() + "\n");
                    Console.WriteLine("La dernière carte jouée est: " + paquetD.VoirCarte().ToString());
                    Console.WriteLine("Voici votre paquet: \n" + joueur.GetMain());
                    Console.WriteLine("Entrez " + joueur.NbCartes() + " pour piger.");
                    Console.WriteLine("Entrez un chiffre pour jouer.");
                    while (verification) 
                    {
                        carteChoisi = Int32.Parse(Console.ReadLine());
                        if (carteChoisi == joueur.NbCartes())
                        {
                            joueur.PushCard(paquetP.GetCarte());
                            verification = false;
                        }
                        else
                        {
                            verification = VerifierCarte(joueur, carteChoisi, paquetD, paquetP);
                        }
                    }
                    if (!(carteChoisi == joueur.NbCartes()-1))
                    {

                        int val = joueur.GetCarte(carteChoisi).GetValeur();
                        joueur.JouerCarte(carteChoisi);

                        switch (val)
                        {
                            case 1:
                                Console.WriteLine("Le prochain joueur passe son tour.");
                                saut = 1;
                                index = Tour(listeJoueurs, sens, saut, index);
                                break;
                            case 7:
                                Console.WriteLine("Le prochain joueur pige deux cartes. ");
                                index = Tour(listeJoueurs, sens, saut, index);
                                Joueur joueur2 = listeJoueurs.ElementAt(index);
                                joueur2.PushCard(paquetP.GetCarte());
                                joueur2.PushCard(paquetP.GetCarte());
                                break; 
                            case 10:
                                Console.WriteLine("Inversement de sens.");
                                sens = -1;
                                index = Tour(listeJoueurs, sens, saut, index);
                                break;
                            default:
                                index = Tour(listeJoueurs, sens, saut, index);
                                break;
                        }
                        //index = Tour(listeJoueurs, sens, saut, index);
                    }
                    else
                    {
                        index = Tour(listeJoueurs, sens, saut, index);
                    }

                    //Tour(listeJoueurs, sens, saut);
                    gameover = VerifierGagnant(listeJoueurs);
                }
                catch (Exception e)
                {
                    Console.WriteLine("J'ai attrapé l'erreur ici");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static int OutOfBound(List<Joueur> listeJoueurs, int index)
        {
            if (index < 0)
            {
                index = listeJoueurs.Count - 1;
                //return index;
            }
            else if (index >= listeJoueurs.Count)
            {
                index = 0;
                //return index;
            }
            return index;
        }

        public static int Tour(List<Joueur> listeJoueurs, int sens, int saut, int index)
        {
            try
            {
                //Joueur joueur = null;
                if(sens == 1 && saut == 0)
                {
                    index++;
                }
                else if (sens == -1 && saut == 0)
                {
                    index--;
                }
                else if(sens == 1 && saut == 1)
                {
                    index += 2;
                }
                else if(sens == -1 && saut == 1)
                {
                    index -= 2;
                }
                index = OutOfBound(listeJoueurs, index);

                return index;
            }
            catch
            {
                Console.WriteLine("erreur attrapé dans la méthode tour");
            }
            return index;
        }

        public static bool VerifierCarte(Joueur joueur, int carteChoisi, PaquetDepot paquetD, PaquetPioche paquetP)
        {
            if (joueur.GetCarte(carteChoisi).GetCouleur() == paquetD.VoirCarte().GetCouleur() ||
                joueur.GetCarte(carteChoisi).GetValeur() == paquetD.VoirCarte().GetValeur())
            {
                return false;
            }
            else
            {
                Console.WriteLine("Vous ne pouvez pas jouer cette carte.");
                return true;
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