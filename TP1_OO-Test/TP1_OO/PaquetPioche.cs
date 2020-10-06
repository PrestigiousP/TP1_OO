using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_OO
{
    public class PaquetPioche : Paquet
    {

        //Constructeur
        public PaquetPioche() : base()
        {
            this.remplir();
            this.brasser(1000);
        }

        //Accesseurs
        public int getNbCartes()
        {
            return (top + 1);
        }

        public void transfertPaquet(Carte[] cartes, int top1)
        {
            for (int i = 0; i < top1; i++)
            {
                paquet[i] = cartes[i];
                top++;
            }
            int test = top;
        }

        //Distribution de 8 cartes de la pioche aux joueurs
        public void distribuerCartes(List<Joueur> listeJoueurs)
        {
            int nbJoueurs;
            int index = 0;
            nbJoueurs = listeJoueurs.Count;
            while (index != nbJoueurs)
            {
                for (int i = 0; i < 8; i++)
                    listeJoueurs[index].pige(this.getCarte());
                index++;
            }
        }
    }
}
