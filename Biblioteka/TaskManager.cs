using System;
using System.Collections;
using System.Collections.Generic;
using static BazaZstudentami.Baza;

namespace BazaZstudentami
{
    public class Baza
    {
        public class Student
        {
            public string Imie;
            public string Nazwisko;
            public int NumerAlb;
            public List<string> Przedmioty;
            public double Nr;

            public Student()
            {
                Przedmioty = new List<string>();
            }
        }

        public class Kierunek
        {
            public string Nazwa;
            public int CzasStudiow;
        }

        public class Grupa
        {
            public int Numer;
            public double IloscStudentow;
            public List<Student> Studenci;
            public Kierunek KierunekGrupy;

            public Grupa()
            {
                Studenci = new List<Student>();
            }

            public void WprowadzGrupe()
            {
                bool l = true;
                while (l == true)
                {
                    try
                    {
                        Console.Write("Podaj numer grupy: ");
                        Numer = Convert.ToInt32(Console.ReadLine());
                        l = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                l = true;
                while (l == true)
                {
                    try
                    {
                        KierunekGrupy = new Kierunek();
                        Console.Write("Podaj nazwę kierunku: ");
                        KierunekGrupy.Nazwa = Console.ReadLine();
                        Console.Write($"Podaj na którym roku jest grupa {Numer}: ");
                        KierunekGrupy.CzasStudiow = Convert.ToInt32(Console.ReadLine());
                        l = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                for (int i = 0; i < 30; i++)
                {
                    l = true;
                    while (l == true)
                    {
                        try
                        {
                            Console.WriteLine($"\nWprowadzanie studenta {i + 1}:");
                            Student student = new Student();
                            student.Nr = i + 1;

                            Console.Write("Podaj imię studenta: ");
                            student.Imie = Console.ReadLine();

                            Console.Write("Podaj nazwisko studenta: ");
                            student.Nazwisko = Console.ReadLine();

                            Console.Write("Podaj numer albumu studenta: ");
                            student.NumerAlb = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Podaj liczbę ulubionych przedmiotów: ");
                            int liczbaPrzedmiotow = Convert.ToInt32(Console.ReadLine());
                            for (int j = 0; j < liczbaPrzedmiotow; j++)
                            {
                                Console.Write($"Podaj przedmiot {j + 1}: ");
                                string lokalna = Console.ReadLine();
                                student.Przedmioty.Add(lokalna);
                            }

                            Studenci.Add(student);
                            IloscStudentow = Studenci.Count;
                            l = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Console.Write("\nCzy chcesz dodać kolejnego studenta(-tke)? (T/N): ");
                    string odpowiedz = Console.ReadLine();
                    if (odpowiedz.ToLower() != "t")
                    {
                        break;
                    }
                    l = true;
                }
            }

            public void WypiszSzczegolyStudenta()
            {
                while (true)
                {
                    Console.Write("\nPodaj numer studenta: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    index--;
                    Student student = Studenci[index];
                    Console.WriteLine($"\nInformacja o studencie(-tce) (nr.{student.NumerAlb}):");
                    Console.WriteLine($"Imię:{student.Imie}, Nazwisko: {student.Nazwisko}");
                    if (student.Przedmioty.Count != 0)
                    {
                        Console.WriteLine("Ulubione przedmioty:");
                        foreach (var przedmiot in student.Przedmioty)
                        {
                            Console.WriteLine($"{przedmiot}");
                        }
                    }
                    else { Console.WriteLine("Brak ulubionych przedmiotów"); }
                    break;
                }
            }

            public void WypiszSzczegolyGrupy()
            {
                Console.Clear();
                Console.WriteLine($"Numer grupy: {Numer}");
                Console.WriteLine($"Ilość studentów: {IloscStudentow}");
                Console.WriteLine($"Kierunek: {KierunekGrupy.Nazwa}");
                Console.WriteLine($"Rok studiów: {KierunekGrupy.CzasStudiow}");
                Console.WriteLine("\nLista studentów:");
                foreach (var student in Studenci)
                {
                    Console.WriteLine($"{student.Nr}. {student.Imie} {student.Nazwisko}, Numer albumu: {student.NumerAlb}, Ilość ulubionych przedmiotów: {student.Przedmioty.Count}");
                    Console.Write("\n");
                }
            }
        }
    }
}


