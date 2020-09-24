using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_OO
{
    class PaquetPioche : Paquet
    {
        private Carte[] paquetPioche = new Carte[52];
        private int top;
        public PaquetPioche() : base()
        {
            Carte[] paquetPioche = new Carte[52];
            top = -1;
        }

        new public Carte GetCarte()
        {
            int test = top;
            Carte carte = paquetPioche[top];
            paquetPioche[top] = null;
            top--;
            return carte;

        }

        //Ceci va devoir etre teste.
        public void RemplirPioche(Carte[] cartes)
        {
            for (int i = 0; i < 52; i++)
            {
                if (cartes[i] == null)
                {
                    return;
                }
                else
                {
                    paquetPioche[i] = cartes[i];
                    top++;
                }
            }
        }

    }
}
