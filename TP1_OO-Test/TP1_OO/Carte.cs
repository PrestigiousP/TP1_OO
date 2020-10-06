using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace TP1_OO
{
    public class CardEventArgs : EventArgs
    {
        public Carte Carte { get; set; }
    }
    public class Carte
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
        
       public int GetValeur()
        {
            return valeur;
        }

       public Couleur GetCouleur()
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
                    val = "As";
                    break;
                case 2:
                    val = "Deux";
                    break;
                case 3:
                    val = "Trois";
                    break;
                case 4:
                    val = "Quatre";
                    break;
                case 5:
                    val = "Cinq";
                    break;
                case 6:
                    val = "Six";
                    break;
                case 7:
                    val = "Sept";
                    break;
                case 8:
                    val = "Huit";
                    break;
                case 9:
                    val = "Neuf";
                    break;
                case 10:
                    val = "Dix";
                    break;
                case 11:
                    val = "Valet";
                    break;
                case 12:
                    val = "Dame";
                    break;
                case 13:
                    val = "Roi";
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

        }

    }
}
