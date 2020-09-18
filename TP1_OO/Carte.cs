using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace TP1_OO
{
   
    class Carte
    {
        //Valeurs que prend une carte.
        private int valeur;
        private Couleur couleur;

        //Liste des couleurs des cartes.
        public enum Couleur
        {
            Coeur,
            Carreau,
            Trefle,
            Pique
        }

        public Carte(int valeur, Couleur couleur)
        {
            this.valeur = valeur;
            this.couleur = couleur;
        }
        
       public int getValeur()
        {
            return valeur;
        }

       public Couleur getCouleur()
        {
            return couleur;
        }

        
       override public string ToString()
        {
            string val = "";
            string coul = "";
            string name = "";
            switch (valeur)
            {
                case 1:
                    val = "as";
                    break;
                case 2:
                    val = "deux";
                    break;
                case 3:
                    val = "trois";
                    break;
                case 4:
                    val = "quatre";
                    break;
                case 5:
                    val = "cinq";
                    break;
                case 6:
                    val = "six";
                    break;
                case 7:
                    val = "sept";
                    break;
                case 8:
                    val = "huit";
                    break;
                case 9:
                    val = "neuf";
                    break;
                case 10:
                    val = "dix";
                    break;
                case 11:
                    val = "valet";
                    break;
                case 12:
                    val = "dame";
                    break;
                case 13:
                    val = "roi";
                    break;
            }

            switch (couleur)
            {
                case Couleur.Coeur:
                    coul = "coeur";
                    break;
                case Couleur.Carreau:
                    coul = "carreau";
                    break;
                case Couleur.Trefle:
                    coul = "trefle";
                    break;
                case Couleur.Pique:
                    coul = "pique";
                    break;
            }
            name = val + " de " + coul;
            return name;
            //Console.WriteLine()

        }

    }
}
