using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_OO
{
    class Paquet
    {

        //Cartes de coeur.
        Carte asCoeur = new Carte(1, Carte.Couleur.Coeur);
        Carte deuxCoeur = new Carte(2, Carte.Couleur.Coeur);
        Carte troisCoeur = new Carte(3, Carte.Couleur.Coeur);
        Carte quatreCoeur = new Carte(4, Carte.Couleur.Coeur);
        Carte cinqCoeur = new Carte(5, Carte.Couleur.Coeur);
        Carte sixCoeur = new Carte(6, Carte.Couleur.Coeur);
        Carte septCoeur = new Carte(7, Carte.Couleur.Coeur);
        Carte huitCoeur = new Carte(8, Carte.Couleur.Coeur);
        Carte neufCoeur = new Carte(9, Carte.Couleur.Coeur);
        Carte dixCoeur = new Carte(10, Carte.Couleur.Coeur);
        Carte valetCoeur = new Carte(11, Carte.Couleur.Coeur);
        Carte dameCoeur = new Carte(12, Carte.Couleur.Coeur);
        Carte roiCoeur = new Carte(13, Carte.Couleur.Coeur);
        //Cartes de carreau.
        Carte asCarreau = new Carte(1, Carte.Couleur.Carreau);
        Carte deuxCarreau = new Carte(2, Carte.Couleur.Carreau);
        Carte troisCarreau = new Carte(3, Carte.Couleur.Carreau);
        Carte quatreCarreau = new Carte(4, Carte.Couleur.Carreau);
        Carte cinqCarreau = new Carte(5, Carte.Couleur.Carreau);
        Carte sixCarreau = new Carte(6, Carte.Couleur.Carreau);
        Carte septCarreau = new Carte(7, Carte.Couleur.Carreau);
        Carte huitCarreau = new Carte(8, Carte.Couleur.Carreau);
        Carte neufCarreau = new Carte(9, Carte.Couleur.Carreau);
        Carte dixCarreau = new Carte(10, Carte.Couleur.Carreau);
        Carte valetCarreau = new Carte(11, Carte.Couleur.Carreau);
        Carte dameCarreau = new Carte(12, Carte.Couleur.Carreau);
        Carte roiCarreau = new Carte(13, Carte.Couleur.Carreau);
        //Cartes de trefle.
        Carte asTrefle = new Carte(1, Carte.Couleur.Trefle);
        Carte deuxTrefle = new Carte(2, Carte.Couleur.Trefle);
        Carte troisTrefle = new Carte(3, Carte.Couleur.Trefle);
        Carte quatreTrefle = new Carte(4, Carte.Couleur.Trefle);
        Carte cinqTrefle = new Carte(5, Carte.Couleur.Trefle);
        Carte sixTrefle = new Carte(6, Carte.Couleur.Trefle);
        Carte septTrefle = new Carte(7, Carte.Couleur.Trefle);
        Carte huitTrefle = new Carte(8, Carte.Couleur.Trefle);
        Carte neufTrefle = new Carte(9, Carte.Couleur.Trefle);
        Carte dixTrefle = new Carte(10, Carte.Couleur.Trefle);
        Carte valetTrefle = new Carte(11, Carte.Couleur.Trefle);
        Carte dameTrefle = new Carte(12, Carte.Couleur.Trefle);
        Carte roiTrefle = new Carte(13, Carte.Couleur.Trefle);
        //Cartes de pique.
        Carte asPique = new Carte(1, Carte.Couleur.Pique);
        Carte deuxPique = new Carte(2, Carte.Couleur.Pique);
        Carte troisPique = new Carte(3, Carte.Couleur.Pique);
        Carte quatrePique = new Carte(4, Carte.Couleur.Pique);
        Carte cinqPique = new Carte(5, Carte.Couleur.Pique);
        Carte sixPique = new Carte(6, Carte.Couleur.Pique);
        Carte septPique = new Carte(7, Carte.Couleur.Pique);
        Carte huitPique = new Carte(8, Carte.Couleur.Pique);
        Carte neufPique = new Carte(9, Carte.Couleur.Pique);
        Carte dixPique = new Carte(10, Carte.Couleur.Pique);
        Carte valetPique = new Carte(11, Carte.Couleur.Pique);
        Carte damePique = new Carte(12, Carte.Couleur.Pique);
        Carte roiPique = new Carte(13, Carte.Couleur.Pique);
        //-----------------------------------------------------------------
        //Paquet de cartes.
        private Carte[] paquet = new Carte[52];
        private Carte[] paquetTemp = new Carte[1];
        private Carte[] paquetTemp2 = new Carte[1];

        public Carte getCarte(int i)
        {
            return paquet[i];
        }
        public Paquet()
        {
            paquet[0] = asCoeur;
            paquet[1] = deuxCoeur;
            paquet[2] = troisCoeur;
            paquet[3] = quatreCoeur;
            paquet[4] = cinqCoeur;
            paquet[5] = sixCoeur;
            paquet[6] = septCoeur;
            paquet[7] = huitCoeur;
            paquet[8] = neufCoeur;
            paquet[9] = dixCoeur;
            paquet[10] = valetCoeur;
            paquet[11] = dameCoeur;
            paquet[12] = roiCoeur;
            paquet[13] = asCarreau;
            paquet[14] = deuxCarreau;
            paquet[15] = troisCarreau;
            paquet[16] = quatreCarreau;
            paquet[17] = cinqCarreau;
            paquet[18] = sixCarreau;
            paquet[19] = septCarreau;
            paquet[20] = huitCarreau;
            paquet[21] = neufCarreau;
            paquet[22] = dixCarreau;
            paquet[23] = valetCarreau;
            paquet[24] = dameCarreau;
            paquet[25] = roiCarreau;
            paquet[26] = asTrefle;
            paquet[27] = deuxTrefle;
            paquet[28] = troisTrefle;
            paquet[29] = quatreTrefle;
            paquet[30] = cinqTrefle;
            paquet[31] = sixTrefle;
            paquet[32] = septTrefle;
            paquet[33] = huitTrefle;
            paquet[34] = neufTrefle;
            paquet[35] = dixTrefle;
            paquet[36] = valetTrefle;
            paquet[37] = dameTrefle;
            paquet[38] = roiTrefle;
            paquet[39] = asPique;
            paquet[40] = deuxPique;
            paquet[41] = troisPique;
            paquet[42] = quatrePique;
            paquet[43] = cinqPique;
            paquet[44] = sixPique;
            paquet[45] = septPique;
            paquet[46] = huitPique;
            paquet[47] = neufPique;
            paquet[48] = dixPique;
            paquet[49] = valetPique;
            paquet[50] = damePique;
            paquet[51] = roiPique;

        }


        //Brasser les cartes
        public void Brasser(int _nbFois)
        {
            int nbFois = _nbFois;

            Random random = new Random();
            Random random2 = new Random();



            // va swap entre deux cases aléatoire de l'array.
            for (int i = 0; i < nbFois; i++)
            {
                int randNum = random.Next(0, 53); // retourne un int random entre 0 et 52
                int randNum2 = random.Next(0, 53);

                paquetTemp[0] = paquet[randNum]; // sauvegarde les cartes dans un temp
                paquetTemp2[0] = paquet[randNum2];

                paquet[randNum2] = paquetTemp[0]; // swap les feux valeurs originales
                paquet[randNum] = paquetTemp2[0];
            }
        }
    }
}
