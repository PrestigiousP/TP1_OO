using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace TP1_OO
{
    class Menu
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
                    Paquet paquet = new Paquet();

                    Joueur joueur1 = new Joueur("", "", paquetD, paquetP);
                    Joueur joueur2 = new Joueur("", "", paquetD, paquetP);
                    Joueur joueur3 = new Joueur("", "", paquetD, paquetP);
                    Joueur joueur4 = new Joueur("", "", paquetD, paquetP);

                    List<Joueur> listeJoueurs = new List<Joueur>();
                    listeJoueurs.Clear();

                    Partie partie = new Partie();

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
                                for (int i = 1; i <= 2; i++)
                                {
                                    Console.WriteLine("Joueur #" + i);

                                    if (i == 1)
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur1.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur1.SetPnom(Console.ReadLine());
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur2.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur2.SetPnom(Console.ReadLine());
                                    }

                                }

                                listeJoueurs.Add(joueur1);
                                listeJoueurs.Add(joueur2);

                                break;
                            case 2:
                                for (int i = 1; i <= 3; i++)
                                {
                                    Console.WriteLine("Joueur #" + i);

                                    if (i == 1)
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur1.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur1.SetPnom(Console.ReadLine());
                                    }
                                    else if (i == 2)
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur2.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur2.SetPnom(Console.ReadLine());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur3.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur3.SetPnom(Console.ReadLine());
                                    }

                                }
                               
                                listeJoueurs.Add(joueur1);
                                listeJoueurs.Add(joueur2);
                                listeJoueurs.Add(joueur3);
                                //ajouter trois joueurs.
                                break;
                            case 3:
                                for (int i = 1; i <= 4; i++)
                                {
                                    Console.WriteLine("Joueur #" + i);

                                    if (i == 1)
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur1.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur1.SetPnom(Console.ReadLine());
                                    }
                                    else if (i == 2)
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur2.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur2.SetPnom(Console.ReadLine());
                                    }
                                    else if (i == 3)
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur3.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur3.SetPnom(Console.ReadLine());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quel est votre nom?");
                                        joueur4.SetNom(Console.ReadLine());
                                        Console.WriteLine("Quel est votre prénom?");
                                        joueur4.SetPnom(Console.ReadLine());
                                    }

                                }

                                listeJoueurs.Add(joueur1);
                                listeJoueurs.Add(joueur2);
                                listeJoueurs.Add(joueur3);
                                listeJoueurs.Add(joueur4);
                                //ajouter quatre joueurs.
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
                    partie.startPartie(listeJoueurs, paquetD, paquetP, paquet);
                }

            }

            static void EntrerJoueur(Joueur joueur)
            {
                Console.WriteLine("Quel est votre nom?");
                joueur.SetNom(Console.ReadLine());
                Console.WriteLine("Quel est votre prénom?");
                joueur.SetPnom(Console.ReadLine());
            }
        }
    }
}