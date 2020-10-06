using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP1_OO
{
    public class PlayerEventArgs : EventArgs
    {
        public Joueur Joueur { get; set; }
    }
    public class Joueur
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

        //Mutateurs
        public void setNom(string s)
        {
            nom = s;
        }

        public void setPnom(string s)
        {
            pnom = s;
        }

        //Accesseurs
        public string getMain()
        {
            string strMain = "";
            for (int i = 0; i < main.Count; i++)
            {
                strMain += "[" + i + "]" + this.main[i].ToString() + "\n";
            }
            return strMain;
        }

        public int nbCartes()
        {
            return main.Count;
        }

        public bool gagnant()
        {
            if(main.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void jouerCarte(Carte carte)
        {
            for(int i = 0; i < main.Count; i++)
            {
                if(carte == main.ElementAt(i))
                {
                    main.RemoveAt(i);
                }
            }
            paquetD.deposerCarte(carte);
        }

        public Carte getCarte(int index)
        {
            Carte carte = main.ElementAt(index);
            return carte;
        }
        public void pige(Carte carte)
        {
            main.Add(carte);
        }

        override public string ToString()
        {
            string nomComplet = pnom + " " + nom;
            return nomComplet;
        }

        public void OnCardPlayed(Object source, PlayerEventArgs e, CardEventArgs s)
        {

            if (e.Joueur == this)
            {
                

                for (int i = 0; i < this.nbCartes(); i++)
                {
                    try
                    {
                        //Valet peut être jouer à n'importe quel moment
                        if (this.getCarte(i).GetValeur() == 11)
                        {
                            var t = Task.Factory.StartNew(() =>
                            {
                                Task.Delay(1500).Wait();
                                Console.WriteLine(this.pnom + " " + this.nom + " a joué un  : " + this.getCarte(i));
                                this.jouerCarte(this.getCarte(i));
                            });
                            t.Wait();
                            break;
                        }
                        //Vérifie que la carte peut être jouer
                        else if (s.Carte.GetCouleur() == this.getCarte(i).GetCouleur() || s.Carte.GetValeur() == this.getCarte(i).GetValeur())
                        {
                            var t = Task.Factory.StartNew(() =>
                            {
                                Task.Delay(1500).Wait();
                                Console.WriteLine(this.pnom + " " + this.nom + " a joué un/une " + this.getCarte(i));
                                this.jouerCarte(this.getCarte(i));
                            });
                            t.Wait();
                            break;
                        }

                        else if (i == this.nbCartes() - 1)
                        {
                            var t = Task.Factory.StartNew(() =>
                            {
                                Task.Delay(1500).Wait();
                                this.pige(paquetP.getCarte());
                                Console.WriteLine("Vous avez pigé un/une " + this.getCarte(this.nbCartes() - 1));
                            });
                            t.Wait();
                            break;
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                
            }
            
        }
    }
}
