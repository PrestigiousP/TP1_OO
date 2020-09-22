using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_OO
{
    class Joueur
    {
        private string nom;
        private string pnom;
        private List<Carte> main = new List<Carte>();
        PaquetDepot paquetDepot = new PaquetDepot();

        public Joueur(string nom, string pnom)
        {
            this.nom = nom;
            this.pnom = pnom;
        }

        public void JouerCarte(int index)
        {
            Carte carte = main.ElementAt(index);
            main.RemoveAt(index);
            Console.WriteLine(carte.ToString());
            //A voir pourquoi il y a une erreur.
            paquetDepot.DeposerCarte(carte);
        }
        public void PushCard(Carte carte)
        {
            main.Add(carte);
        }

        public void pullCard(Carte carte)
        {
            this.main.Add(carte);
        }

        public int NbCartes()
        {
            return main.Count;
        }

        override public string ToString()
        {
            string nomComplet = nom + " " + pnom;
            return nomComplet;
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
