using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP1_OO
{

    class Partie
    {
        //regroupement des methodes pour initialiser une partie
        public async Task startPartie(List<Joueur> listeJoueurs, PaquetDepot paquetD, PaquetPioche paquetP, Paquet paquet)
        {
            //Instanciation pour les tests, a enlever apres.
            Joueur joueur;
            int nbJoueurs = listeJoueurs.Count;

   
            //Rempli le paquet de cartes de toutes les cartes du jeu. 
            paquet.Remplir();
      
            //Brasse les cartes.
            paquet.Brasser(10000);
         
            //Distribue les cartes aux joueurs.
            paquet.DistribuerCartes(listeJoueurs);

            //Retourne une carte de départ sur le paquet de Dépot.
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
        //Joueur joueur, int carteChoisi, PaquetDepot paquetD, PaquetPioche paquetP, string couleur
        public static Carte BotChoisiCarte(Joueur joueur, PaquetDepot paquetD)
        {
           bool ok;
           for(int i = 0; i < joueur.NbCartes(); i++)
            {
                ok = VerifierCarte(joueur, i, paquetD);
                if (ok == true)
                {
                    return joueur.GetCarte(i);
                }
            }
            return null;
        }

        public static void Jouer(Joueur joueur, List<Joueur> listeJoueurs, PaquetDepot paquetD, PaquetPioche paquetP)
        {
            Carte carte;
            int index = listeJoueurs.IndexOf(joueur);
            bool gameover = false;
            while (!gameover)
            {
                try
                {
                   
                    joueur = listeJoueurs.ElementAt(index);
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("\nC'est le tour à " + joueur.ToString() + "\n");
                    Console.WriteLine("La dernière carte jouée est: " + paquetD.VoirCarte().ToString());
                    Console.WriteLine("Voici votre paquet: \n" + joueur.GetMain());
                    //await Task.Delay(3000);

                    //Le bot choisi sa carte à jouer.
                    carte = BotChoisiCarte(joueur, paquetD);

                        if(carte == null)
                        {
                            GererPige(paquetP, paquetD, joueur);
                        }
                        else
                        {
                            joueur.JouerCarte(carte);
                        }

                    index = Tour(listeJoueurs, index);
                    
                    
                    gameover = joueur.Gagnant();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Le gagnant est: {0}!\n", joueur.ToString());
        }

        //Determine s'il faut rebrasser le paquet. 
        public static void GererPige(PaquetPioche paquetP, PaquetDepot paquetD, Joueur joueur)
        {
            Carte carte;
            if(paquetD.GetTop() > 0 && paquetP.GetNbCartes() == 0)
            {
                Console.WriteLine("Le paquet est vide. Il va donc être rebrassé.");
                Carte[] cartes = paquetD.GetPaquet();
                int top = paquetD.GetTop();
                paquetP.TransfererPaquet(cartes, top);
                paquetD.Vider();
                paquetP.Brasser(10000);
                joueur.Pige(paquetP.GetCarte());

            }
            else if(paquetD.GetTop() == 0 && paquetP.GetNbCartes() == 0)
            {
                Console.WriteLine("Vous ne pouvez pas piger de carte.");
            }
            else if(paquetP.GetNbCartes() > 0)
            {
                carte = paquetP.GetCarte();
                if (carte == null)
                    Console.WriteLine("Erreur. Le joueur ne peut pas piger");
                else
                {
                    Console.WriteLine("Le joueur a pigé.");
                    joueur.Pige(carte);
                }
            }
        }

        //Determine si l'index qui pointe les joueurs sont out of bound.
        public static int OutOfBound(List<Joueur> listeJoueurs, int index)
        {
            if (index < 0)
            {
                index = listeJoueurs.Count - 1;
            }
            else if (index >= listeJoueurs.Count)
            {
                index = 0;
            }
            return index;
        }

        //Gere les tours et decide qui doit jouer.
        public static int Tour(List<Joueur> listeJoueurs, int index)
        {
            index++;
            if (index >= listeJoueurs.Count)
                index = 0;

            return index;
        }

        public static bool VerifierCarte(Joueur joueur, int carteChoisi, PaquetDepot paquetD)
        {
            int valet = joueur.GetCarte(carteChoisi).GetValeur();
            if(valet == 11)
            {
                return true;
            }
            else if (joueur.GetCarte(carteChoisi).GetCouleur() == paquetD.VoirCarte().GetCouleur() ||
                    joueur.GetCarte(carteChoisi).GetValeur() == paquetD.VoirCarte().GetValeur())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Joueur JoueurDepart(List<Joueur> listeJoueurs, int nbJoueurs)
        {
            Random rand = new Random();
            int randNum = rand.Next(0, nbJoueurs);
            return listeJoueurs.ElementAt(randNum);
        }

        public static Carte.Couleur RandomCouleur()
        {
            Random rand = new Random();
            int randNum = rand.Next(0, 3);
            switch (randNum)
            {
                case 0:
                    return Carte.Couleur.Carreau;
                case 1:
                    return Carte.Couleur.Coeur;
                case 2:
                    return Carte.Couleur.Pique;
                case 3:
                    return Carte.Couleur.Trefle;
            }
            return Carte.Couleur.Carreau;
        }
    }
}