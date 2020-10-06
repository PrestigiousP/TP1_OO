using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TP1_OO
{
    public class Paquet
    { 
        //Attributs
        protected Carte[] paquet = new Carte[52];
        protected int top;    //Pointe sur le dessus de la pile.

        //Constructeurs
        public Paquet()
        {
            Carte[] paquet = new Carte[52];
            top = -1;
        }

        //Accesseurs
        public Carte getCarte()
        {
            if (top == -1)
            {
                return null;
            }
            Carte carte = paquet[top];
            paquet[top] = null;
            top--;
            return carte;
        }

        public Carte[] getPaquet()
        {
            return paquet;
        }
        public int getTop()
        {
            return top;
        }

        //Remplir/Vider un paquet
        public void remplir()
        {
            for (int i = 0; i < 52; i++)
            {
                if (i < 13)
                    paquet[i] = new Carte((i + 1) % 13, Carte.Couleur.Coeur);
                else if (i < 26)
                    paquet[i] = new Carte((i + 1) % 13, Carte.Couleur.Carreau);
                else if (i < 39)
                    paquet[i] = new Carte((i + 1) % 13, Carte.Couleur.Trefle);
                else
                    paquet[i] = new Carte((i + 1) % 13, Carte.Couleur.Pique);
            }
            top = 51;
        }
        public void vider()
        {
            for (int i = 0; i < 51; i++)
            {
                paquet[i] = null;
                top = -1;
            }
        }


        //Brasser les cartes
        public void brasser(int _nbFois)
        {
            int nbFois = _nbFois;

            Random random = new Random();
            Random random2 = new Random();
            Carte[] paquetTemp = new Carte[1];
            Carte[] paquetTemp2 = new Carte[1];

            //SWAP deux cartes
            for (int i = 0; i < nbFois; i++)
            {
                int randNum = random.Next(0, 52); // retourne un int random entre 0 et 52
                int randNum2 = random.Next(0, 52);

                paquetTemp[0] = paquet[randNum]; // sauvegarde les cartes dans un temp
                paquetTemp2[0] = paquet[randNum2];

                paquet[randNum2] = paquetTemp[0]; // swap les feux valeurs originales
                paquet[randNum] = paquetTemp2[0];
            }
        }
      
    }
}
