using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TP1_OO
{
    public class PaquetDepot : Paquet
    {
        public delegate Carte DelegateCarte();


        //Constructeur
        public PaquetDepot() : base()
        {
        }

        public Carte voirCarte()
        {
            int test = top;
            Carte carte = paquet[top];
            return carte;
        }

        public void deposerCarte(Carte carte)
        {
            paquet[++top] = carte;
        }

    }
}
