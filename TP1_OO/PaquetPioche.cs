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

        public int GetNbCartes()
        {
            int count = 0;
            for(int i =0; i < 52; i++)
            {
                if(paquetPioche[i] == null)
                {
                    break;
                    //count++;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        new public Carte GetCarte()
        { 
            if(top == -1)
            {
                return null;
            }
            Carte carte = paquetPioche[top];
            paquetPioche[top] = null;
            top--;
            return carte;
        }

        public void TransfererPaquet(Carte[] cartes, int top1)
        {
            for (int i = 0; i < top1; i++)
            {
                paquetPioche[i] = cartes[i];
                top++;
            }
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
