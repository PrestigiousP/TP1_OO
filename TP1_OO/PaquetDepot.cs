using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TP1_OO
{
    class PaquetDepot : Paquet
    {
        public delegate Carte DelegateCarte();


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

        public int GetTop()
        {
            return top;
        }

        new public void Vider()
        {
            paquetDepot[0] = paquetDepot[top];

            int borne = top;
            for (int i = borne; i > 1; i--)
            {
                paquetDepot[i] = null;
                top--;
            }
        }

        public Carte VoirCarte()
        {
            int test = top;
            Carte carte = paquetDepot[top];
            return carte;
        }

        public void DeposerCarte(Carte carte)
        {
            paquetDepot[++top] = carte;
        }

    }
}
