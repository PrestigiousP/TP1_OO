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
   

    
    public class Partie
    {
        //Attributs
        private List<Joueur> listeJoueur;
        private PaquetDepot depot;
        private PaquetPioche pioche;
        private int indexJoueur;
        private int nbJoueurs;

        //Constructeur d'une partie
        public Partie(List<Joueur> listeJoueur, PaquetDepot depot, PaquetPioche pioche)
        {
            this.listeJoueur = listeJoueur;
            this.depot = depot;
            this.pioche = pioche;
            Random rand = new Random();
            indexJoueur = rand.Next(0, nbJoueurs);
            nbJoueurs = listeJoueur.Count;

            //Inscrire les abonnées
            for (int i = 0; i < nbJoueurs; i++)
                this.CardPlayed += listeJoueur[i].OnCardPlayed;
        }
        

        //-----------------------------------EVENT HANDLER------------------------------------------------//
        //Delegate (Event handler)
        public delegate void CardPlayedEventHandler(object source, PlayerEventArgs e, CardEventArgs s);
        //Event basé sur le delegate
        public event CardPlayedEventHandler CardPlayed;

        //Notifier les abonnés
        protected virtual void OnCardPlayed(Joueur j, Carte c)
        {
            if (CardPlayed != null)
                CardPlayed(this, new PlayerEventArgs() { Joueur = j}, new CardEventArgs() {Carte = c});
        }

        
        //regroupement des methodes pour initialiser une partie
        public async void startPartieAsync()
        {
            //Distribue les cartes aux joueurs.
            pioche.distribuerCartes(listeJoueur);

            //Retourne une carte de départ sur le paquet de Dépot.
            depot.deposerCarte(pioche.getCarte());

            //Creer une methode tour qui entre en argument le premier joueur.
            jouer();
        }
       

        public void jouer()
        {
            bool gameover = false;
            while (!gameover)
            {
                try
                {
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("\nC'est le tour à " + listeJoueur[indexJoueur].ToString() + "\n");
                    Console.WriteLine("La dernière carte jouée est: " + depot.voirCarte().ToString());
                    Console.WriteLine("Voici votre paquet: \n" + listeJoueur[indexJoueur].getMain());

                    var t = Task.Factory.StartNew(() =>
                    {
                        //Notifier tous les abonnées
                        OnCardPlayed(listeJoueur[indexJoueur], depot.voirCarte());
                        Task.Delay(1000).Wait();

                        tour();
                        if (pioche.getNbCartes() == 0)
                        {
                            Carte[] cartes = depot.getPaquet();
                            int top = depot.getTop();
                            pioche.transfertPaquet(cartes, top);
                            depot.vider();
                            pioche.brasser(10000);
                        }
                        gameover = listeJoueur[indexJoueur].gagnant();
                    });

                    t.Wait();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Le gagnant est: {0}!\n", listeJoueur[indexJoueur].ToString());
        }

        //Gere les tours et decide qui doit jouer.
        public int tour()
        {
            indexJoueur++;
            if (indexJoueur >= listeJoueur.Count)
                indexJoueur = 0;

            return indexJoueur;
        }

    }
}