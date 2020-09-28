using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace TP1_OO
{
    class Joueur
    {
       
        private string nom;
        private string pnom;
        private List<Carte> main = new List<Carte>();
        private PaquetDepot paquetD;
        private PaquetPioche paquetP;

        public Joueur(string nom, string pnom, PaquetDepot paquetD, PaquetPioche paquetP)
        {
            this.nom = nom;
            this.pnom = pnom;
            this.paquetD = paquetD;
            this.paquetP = paquetP;
        }

        public void JouerCarte(int index)
        {
            Carte carte = main.ElementAt(index);
            paquetD.DeposerCarte(carte);
            main.RemoveAt(index);
        }

        public Carte GetCarte(int index)
        {
            Carte carte = main.ElementAt(index);
            return carte;
        }
        public void PushCard(Carte carte)
        {
            main.Add(carte);
        }

        public void PushCard(PaquetPioche paquetP)
        {

            main.Add(paquetP.GetCarte());
        }
        /*public void pullCard(Carte carte)
        {
            main.Add(carte);
        }*/

        public int NbCartes()
        {
            return main.Count;
        }

        override public string ToString()
        {
            string nomComplet = nom + " " + pnom;
            return nomComplet;
        }

        public string GetMain()
        {
            string strMain = "";
            for (int i = 0;  i < main.Count; i++)
            {
                strMain += this.main[i].ToString() + ", position " + i + "\n";
            }
            return strMain;
        }
    }
}
