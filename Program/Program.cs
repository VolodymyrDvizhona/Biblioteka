using BazaZstudentami;
using System;
using System.Collections.Generic;
using System.IO;
using static BazaZstudentami.Baza;

namespace SterowaniaBaza
{
    class Program
    {
        static List<Baza.Grupa> bazaGrup = new List<Baza.Grupa>();
        static List<Baza.Kierunek> bazaKierunkow = new List<Baza.Kierunek>();
        static void Main(string[] args)
        {
            char c;
            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        DodajGrupe();
                        break;
                    case 'b':
                    case 'B':
                        WypiszNumeryGrup();
                        break;
                    case 'c':
                    case 'C':
                        WyswietlSzczegolyGrupy();
                        break;
                    case 'd':
                    case 'D':
                        ZapiszBazeDoPliku();
                        break;
                    case 'k':
                    case 'K':
                        Console.Write("oniec programu :)\n\n");
                        Environment.Exit(0);
                        break;
                }
            }
            while (!(c == 'k' || c == 'K'));
        }

        static char Menu()
        {
            Console.Clear();
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║           Wybierz opcję:            ║");
            Console.WriteLine("╠═════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine("║ A. Dodaj grupę                      ║");
            Console.WriteLine("║ B. Wypisz wszystkie grupy           ║");
            Console.WriteLine("║ C. Wyświetl informacje o grupie     ║");
            Console.WriteLine("║ D. Zapisz bazę do pliku             ║");
            Console.WriteLine("║ K. Wyjdź z programu                 ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            return Console.ReadKey().KeyChar;
        }

        static void DodajGrupe()
        {
            Console.Clear();
            Baza.Grupa grupa = new Baza.Grupa();
            grupa.WprowadzGrupe();
            bazaGrup.Add(grupa);
 
        }

        static void WypiszNumeryGrup()
        {
            Console.Clear();
            Console.WriteLine("Lista grup:");
            int i = 1;
           
                foreach (var grupa in bazaGrup)
                {

                    Console.WriteLine(i + ". " + grupa.Numer);
                    i++;
                }
                
            
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        }

        static void WyswietlSzczegolyGrupy()
        {
            Console.Clear();
            Console.WriteLine("Lista grup:");
            int i = 1;
            foreach (var grupa in bazaGrup)
            {
                Console.WriteLine(i + ". " + grupa.Numer);
                i++;
            }

            Console.WriteLine("Podaj ID grupy do wyświetlenia informacji:");
            int numerGrupy;

            if (int.TryParse(Console.ReadLine(), out numerGrupy) && numerGrupy > 0 && numerGrupy <= bazaGrup.Count)
            {
                var grupa = bazaGrup [numerGrupy - 1];
                Console.WriteLine($"Szczegóły płyty {grupa.Numer}:");
                grupa.WypiszSzczegolyGrupy();

                Console.Write("Chcesz wyswietlic informacje o konkretnym studencie(-tce)?(T/N): ");
                char tn;
                tn = Console.ReadKey().KeyChar;
                if (tn == 'T' || tn == 't')
                {
                    var szczeg = bazaGrup[numerGrupy - 1];
                    szczeg.WypiszSzczegolyStudenta();
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny ID grupy.");
                
            }
            

            Console.WriteLine("\nNaciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        }

        static void ZapiszBazeDoPliku()
        {
            Console.Clear();
            if (bazaGrup.Count != 0)
            {
                using (StreamWriter sw = new StreamWriter("baza.txt"))
                {
                    foreach (var grupa in bazaGrup)
                    {

                        sw.WriteLine("Numer grupy: " + grupa.Numer);
                        sw.WriteLine("Ilość studentów: " + grupa.IloscStudentow);
                        sw.WriteLine($"Kierunek: {grupa.KierunekGrupy.Nazwa}");
                        sw.WriteLine($"Rok studiów: {grupa.KierunekGrupy.CzasStudiow}");
                        sw.Write("\n");
                        foreach (var student in grupa.Studenci)
                        {
                            sw.WriteLine($"Imię:{student.Imie}  Nazwisko:{student.Nazwisko}");
                            sw.WriteLine("ID: " + student.NumerAlb);
                            if (student.Przedmioty.Count != 0)
                            {
                                sw.WriteLine($"Ulubione przedmioty: ");
                                sw.WriteLine(string.Join(", ", student.Przedmioty));
                            }
                            else { Console.WriteLine("Brak ulubionych przedmiotów"); }
                            sw.Write("\n");
                        }
                    }
                }
                Console.WriteLine("Baza została zapisana do pliku.");
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Brak danych w bazie.");
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
            }
        }


    }
}