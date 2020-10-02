using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TP1_OO
{//
    class PaquetDepot : Paquet
    {
        private Carte[] paquetDepot = new Carte[52];
        private int top;
        public PaquetDepot() : base()
        {
            Carte[] paquetDepot = new Carte[52];
            top = -1;
        }
      
        new public Carte[] GetPaquet()
        {
            return paquetDepot;
        }
        /*public void RebrasserCartes()
        {
            for(int i = top-1; i > -1; i--)
            {
                paquetDepot[i] = 
            }
        }*/

        public int GetTop()
        {
            return top;
        }

        public Carte VoirCarte()
        {
            Carte carte = paquetDepot[top];
            return carte;
        }

        public void DeposerCarte(Carte carte)
        {
            paquetDepot[++top] = carte;
        }

    }
}
