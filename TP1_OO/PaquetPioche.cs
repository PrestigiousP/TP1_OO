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
            top = 0;
        }

        //Ceci va devoir etre teste.
        public void RemplirPioche(Carte[] cartes)
        {
            /*Carte[] paquetCartes = new Carte[52];
            for (int i = 0; i < 51; i++)
            {
                paquetCartes = paquet.GetPaquet();
            }   */
           // int j = 0;
            for (int i = 0; i < 52; i++)
            {
                paquetPioche[i] = cartes[i];
                //j++;
                top++;
            }
        }

        //Retourne la valeur D'UNE carte dans le paquet.
       new public Carte GetCarte(int i)
       {
            return paquetPioche[i];
       }

        public Carte Pop()
        {
           Carte carteTemp;
           carteTemp = paquetPioche[top];
           paquetPioche[top] = null;
           top--;
            return carteTemp;
        }

    }
}
