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

        public void SetNom(string s)
        {
            nom = s;
        }

        public void SetPnom(string s)
        {
            pnom = s;
        }

        public bool Gagnant()
        {
            if(main.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void JouerCarte(Carte carte)
        {
            for(int i = 0; i < main.Count; i++)
            {
                if(carte == main.ElementAt(i))
                {
                    main.RemoveAt(i);
                }
            }
            paquetD.DeposerCarte(carte);
        }

        public Carte GetCarte(int index)
        {
            Carte carte = main.ElementAt(index);
            return carte;
        }
        public void Pige(Carte carte)
        {
            main.Add(carte);
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
