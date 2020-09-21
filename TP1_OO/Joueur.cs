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

        public Joueur(string nom, string pnom)
        {
            this.nom = nom;
            this.pnom = pnom;
            //this.main = main;
        }

        public void PushCard(Carte carte)
        {
            main.Add(carte);
        }
      /*  public Carte pushCard(int index)
        {
            Carte carte = this.main[index];
            this.main.RemoveAt(index);
            return carte;
        }*/

        public void pullCard(Carte carte)
        {
            this.main.Add(carte);
        }

        public String GetMain()
        {
            String strMain = "";
            for (int i = 0; i < main.Capacity; i++)
            {
                strMain += this.main[i].ToString() + " en position " + i + "\n";
            }

            return strMain;
        }
    }
}
