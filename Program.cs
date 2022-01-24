using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moja_gra;
namespace Projekt_zaliczeniowy_parydygmaty
{
    class Program
    {
        static void Main(string[] args)
        {
            Gra gra = new Gra();
            Knight zycie = new Knight();
            List<Baza_klientow> klienci = new List<Baza_klientow>();
            Baza_klientow_form form = new Baza_klientow_form();
            klienci.Add(new Baza_klientow() { imie = "Jan", nazwisko = "Kowalski", Pesel = "12345628912", IBAN = "18105000997574020184966757", NIP = "6110202860", kwota_zadluzen = 55764 });
            klienci.Add(new Baza_klientow() { imie = "Michal", nazwisko = "Papolski", Pesel = "12345658912", IBAN = "83109018540000000113851228", NIP = "9721207776", kwota_zadluzen = 550000 });
            klienci.Add(new Baza_klientow() { imie = "Agata", nazwisko = "Sosna", Pesel = "12345998912", IBAN = "18105000997574020184966757", NIP = "8960005673", kwota_zadluzen = 635000 });

            Pracownik pracownik = new Pracownik();
            Menu menuGlowne = new Menu(new string[] { "--------------Baza Klientow---------------","------------------Edytuj------------------", "----------------Dodaj klienta-------------",
                "------------------Zapisz------------------","---------Pograj w wolnej chwili ----------", "-----------------Zamknij------------------" });
            Console.WriteLine("Prosze o podanie kodu dostepu");

            Menu testMenu = new Menu(null);
            string kod = Console.ReadLine();
            if (kod == pracownik.kod_dostepu)
            {
                Console.WriteLine($"Witam { pracownik.Imie} {pracownik.Nazwisko}");

                Console.WriteLine("Prosze o wcisniecie Enter ,aby przejsc do menu");
                Console.ReadKey();
                Console.Clear();

                int wybor = 0;
                while (wybor != 5)
                {

                    Console.Clear();

                    wybor = menuGlowne.ShowMenu(); // tu wywołujemy metodę obiektu menuGlowne.ShowMenu()
                    Console.Clear();
                    //Baza klientów
                    if (wybor == 0)
                    {

                        Console.WriteLine("Lista pracowników");
                        form.Lista(klienci);


                    }
                    //Edycja bazy klientów
                    else if (wybor == 1)
                    {

                        Console.WriteLine("Wybierz pracownika do edycji i wcisnij ENTER");

                        int wybrany = form.Lista(klienci);
                        if (wybrany != -1)
                        {
                            form.Edytuj(klienci[wybrany]);
                        }

                    }
                    // Dodanie nowego klienta do bazy
                    else if (wybor == 2)
                    {
                        Console.WriteLine("Prosze o wprowadzenie informacji o kliencie wedlug ponizszego schematu : ");
                        Console.WriteLine("Imie klienta");
                        Console.WriteLine("Nazwisko klienta");
                        Console.WriteLine("Pesel klienta");
                        Console.WriteLine("IBAN klienta");
                        Console.WriteLine("NIP klienta");
                        Console.WriteLine("kwota_zadluzen klienta");
                        klienci.Add(new Baza_klientow()
                        {
                            imie = Console.ReadLine(),
                            nazwisko = Console.ReadLine(),
                            Pesel = Console.ReadLine(),
                            IBAN = Console.ReadLine(),
                            NIP = Console.ReadLine(),
                            kwota_zadluzen = Decimal.Parse(Console.ReadLine())
                        });
                        Console.Clear();


                    }
                    //Zapisanie listy klientów do pliku .txt
                    else if (wybor == 3)
                    {


                        int wybrany = form.Lista(klienci);


                        Baza_klientow wybr = klienci[wybrany];
                        wybr.Zapis();
                    }
                    //Pograj w gre
                    else if (wybor == 4)
                    {
                        int wybor_gry = 0;
                        string g;
                        while (wybor_gry != 2)
                        {

                            Console.WriteLine("Wybierz swojego wojownika");
                            Console.WriteLine("1. Knight");
                            Console.WriteLine("2. Kusznik");
                            Console.WriteLine("3. Mag");
                            gra.Dodaj(new Knight());
                            g = Console.ReadLine();
                            wybor_gry = int.Parse(g);
                            if (wybor_gry == 1)
                            {

                                gra.Gracz = new Knight();


                            }
                            else if (wybor_gry == 2)
                            {

                                gra.Gracz = new Kusznik();
                            }
                            else if (wybor_gry == 3)
                            {
                                gra.Gracz = new Mag();
                            }


                            gra.Dodaj(gra.Gracz);


                            gra.Start();

                        }
                        


                    }
                   
                }

            }
            else
            {

                Console.WriteLine("Przepraszamy , ale nie masz dostepu do  bazy");
                Console.WriteLine("Polecamy pogranie w gre");

                Console.WriteLine("Nacisnij enter ,aby przejsc do gry");
                Console.ReadKey();
                Console.Clear();

                int wybor_gry = 0;
                string g;
                while (wybor_gry != 3)
                {

                    Console.WriteLine("Wybierz swojego wojownika");
                    Console.WriteLine("1. Knight");
                    Console.WriteLine("2. Kusznik");
                    Console.WriteLine("3. Mag");
                    gra.Dodaj(new Knight());
                    g = Console.ReadLine();
                    wybor_gry = int.Parse(g);
                    if (wybor_gry == 1)
                    {

                        gra.Gracz = new Knight();


                    }
                    else if (wybor_gry == 2)
                    {

                        gra.Gracz = new Kusznik();
                    }
                    else if(wybor_gry == 3)
                    {
                        gra.Gracz = new Mag();
                    }
                        
                    
                    gra.Dodaj(gra.Gracz);
                    
                    
                    gra.Start();

                }

                Console.ReadKey();
            }
        }
        class Baza_klientow_form
        {

            public int Lista(List<Baza_klientow> klienci)
            {
                string[] elementy = new string[klienci.Count];

                for (int i = 0; i < klienci.Count; i++)
                {
                    elementy[i] = $" {klienci[i].imie} {klienci[i].nazwisko} {klienci[i].Pesel} {klienci[i].IBAN} {klienci[i].NIP}  {klienci[i].kwota_zadluzen} ";
                }


                Menu lista = new Menu(elementy);

                return lista.ShowMenu();


            }

            public void Edytuj(Baza_klientow pracownik)
            {
                int wybor = 0;
                string a;
                while (wybor != 4)
                {

                    Console.Clear();
                    Console.WriteLine("Podaj co chcesz edytować : ");
                    Console.WriteLine("1 Imie : ");
                    Console.WriteLine("2 Nazwisko: ");
                    Console.WriteLine("3 Pesel : ");
                    Console.WriteLine("4 IBAN : ");
                    Console.WriteLine("5 NIP : ");
                    Console.WriteLine("6 Kwote zadluzenia : ");
                    a = Console.ReadLine();
                    wybor = int.Parse(a);
                    if (wybor == 1)
                    {

                        Console.Write("Podaj imię:");
                        pracownik.imie = Console.ReadLine();
                        break;

                    }
                    else if (wybor == 2)
                    {

                        Console.Write("Podaj Nazwisko :");
                        pracownik.nazwisko = Console.ReadLine();
                        break;
                    }
                    else if (wybor == 3)
                    {
                        pracownik.Pesel = Console.ReadLine();

                        break;
                    }
                    else if (wybor == 4)
                    {
                        pracownik.IBAN = Console.ReadLine();
                    }
                    else if (wybor == 5)
                    {
                        pracownik.NIP = Console.ReadLine();
                    }
                    else if (wybor == 6)
                    {

                        Console.Write("Podaj Kwote zadluzenia :");
                        pracownik.kwota_zadluzen = Decimal.Parse(Console.ReadLine());
                        break;
                    }

                    Console.Clear();
                }


            }
        }





    }
}
