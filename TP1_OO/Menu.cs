using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

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
                                //aller au deuxieme menu
                                MenuSecondaire();
                                break;
                            case 2:
                                on = false;
                                break;
                            default:
                                Console.WriteLine("Vous devez entrer 1 ou 2");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        //incomplet
                        Console.WriteLine(e);
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
                                //ajouter deux joueurs.

                                break;
                            case 2:
                                //ajouter trois joueurs.
                                break;
                            case 3:
                                //ajouter quatre joueurs.
                                break;
                            case 4:
                                on = false;
                                break;
                            default:
                                Console.WriteLine("Vous devez entrer un chiffre entre 1 et 4");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        //incomplet
                        Console.WriteLine(e);
                    }
                }

            }
        }
    }
}