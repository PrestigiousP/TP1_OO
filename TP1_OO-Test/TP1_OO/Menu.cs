using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace TP1_OO
{
    public class Menu
    {
        static void Main(string[] args)
        {
            MenuPrincipal();


            //Menu principal.
            static void MenuPrincipal()
            {
                int choix;
                bool on = true;
                while (on)
                {
                    Console.WriteLine("-------------Jeu de pêche et pioche-------------");
                    Console.WriteLine("Veuillez entrer un nombre pour choisir: ");
                    Console.WriteLine("1 - Démarrer une partie");
                    Console.WriteLine("2 - Quitter");
                    try
                    {
                        choix = Int32.Parse(Console.ReadLine());
                        switch (choix)
                        {
                            case 1:
                                MenuSecondaire();                
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Vous devez entrer 1 ou 2");
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Entrée invalide.");
                    }
                }
            }

            //Menu secondaire. On choisi le nombre de personnes dans la partie.
            static void MenuSecondaire()
            {
                int choix;
                bool on = true;
                while (on)
                {
                    PaquetPioche paquetP = new PaquetPioche();
                    PaquetDepot paquetD = new PaquetDepot();

                    Joueur joueur1 = new Joueur("", "", paquetD, paquetP);
                    Joueur joueur2 = new Joueur("", "", paquetD, paquetP);
                    Joueur joueur3 = new Joueur("", "", paquetD, paquetP);
                    Joueur joueur4 = new Joueur("", "", paquetD, paquetP);

                    List<Joueur> listeJoueurs = new List<Joueur>();
                    listeJoueurs.Clear();

                    Console.WriteLine("Entrez le nombre de joueurs: ");
                    Console.WriteLine("1 - Deux joueurs");
                    Console.WriteLine("2 - Trois Joueurs");
                    Console.WriteLine("3 - Quatre Joueurs");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        choix = Int32.Parse(Console.ReadLine());
                        switch (choix)
                        {
                            case 1:
                                listeJoueurs.Add(joueur1);
                                listeJoueurs.Add(joueur2);
                                
                                entrerJoueur(listeJoueurs);
                                
                                break;
                            case 2:
                                listeJoueurs.Add(joueur1);
                                listeJoueurs.Add(joueur2);
                                listeJoueurs.Add(joueur3);
                                
                                entrerJoueur(listeJoueurs);
                              
                                break;
                            case 3:
                                listeJoueurs.Add(joueur1);
                                listeJoueurs.Add(joueur2);
                                listeJoueurs.Add(joueur3);
                                listeJoueurs.Add(joueur4);

                                entrerJoueur(listeJoueurs);
                                
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Vous devez entrer un chiffre entre 1 et 4");
                                break;
                        }
                        
                    }
                    catch 
                    {
                        Console.WriteLine("Entrée invalide.");
                    }
                    Partie partie = new Partie(listeJoueurs, paquetD, paquetP);
                    partie.startPartie();
                }

            }

            static void entrerJoueur(List<Joueur> listJoueur)
            {
                for (int ctr = 0; ctr < listJoueur.Count; ctr++)
                {
                    Console.WriteLine("Joueur #" + ctr);
                    Console.WriteLine("Quel est votre nom?");
                    listJoueur[ctr].setNom(Console.ReadLine());
                    Console.WriteLine("Quel est votre prénom?");
                    listJoueur[ctr].setPnom(Console.ReadLine());
                }
                
            }
        }
    }
}