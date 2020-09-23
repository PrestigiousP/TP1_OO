using System;
using System.Collections.Generic;
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

        //Ceci va devoir etre teste.
        public void RemplirPioche(Carte[] cartes)
        {
            for (int i = 0; i < 52; i++)
            {
                paquetPioche[i] = cartes[i];
                top++;
            }
        }

        /*public Carte GetCarte()
        {
           Carte carteTemp;
           carteTemp = paquetPioche[top];
           paquetPioche[top] = null;
           top--;
            return carteTemp;
        }*/

    }
}
