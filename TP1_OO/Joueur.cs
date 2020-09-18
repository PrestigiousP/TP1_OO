using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_OO
{
    class Joueur 
    {
        private string nom;
        private string pnom;
        private List<Carte> main = new List<Carte>();

        public Joueur(string nom, string pnom, List<Carte> main)
        {
            this.nom = nom;
            this.pnom = pnom;
            this.main = main;
        }

        
    }
}
