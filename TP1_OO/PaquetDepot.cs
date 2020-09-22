using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_OO
{
    class PaquetDepot : Paquet
    {
        private Carte[] paquetDepot = new Carte[52];
        private int top;
        public PaquetDepot() : base()
        {
            Carte[] paquetDepot = new Carte[52];
            top = -1;
        }

        public string VoirCarte()
        {
            string nomCarte;
            Carte carte = paquetDepot[top];
            nomCarte = carte.ToString();
            return nomCarte;
        }

        public void DeposerCarte(Carte carte)
        {
            paquetDepot[++top] = carte;
            //top++;
        }

    }
}
