using System;
using System.Collections.Generic;
using JP_lab_1.Classes;

public class App
{
    public static void Main(string[] args)
    {
        try
        {
            // --- ZADANIE 1 ---
            Console.WriteLine("=== ZADANIE 1: Rzutowanie Punktów 3D ===");
            TestRzutowania();
            
            Console.WriteLine("\n(Naciśnij dowolny klawisz, aby przejść do Zadania 2...)");
            Console.ReadKey(); // <--- ZATRZYMANIE 1
            Console.Clear();   

            // --- ZADANIE 2 ---
            Console.WriteLine("\n=== ZADANIE 2: Objętość Równoległościanu ===");
            TestObjetosci();

            Console.WriteLine("\n(Naciśnij dowolny klawisz, aby przejść do Zadania 3...)");
            Console.ReadKey(); // <--- ZATRZYMANIE 2
            Console.Clear();

            // --- ZADANIE 3 ---
            Console.WriteLine("\n=== ZADANIE 3: Test Kolekcji (Ciąg i Zbiór) ===");
            TestKolekcji();
            
            Console.WriteLine("\n=== KONIEC PROGRAMU ===");
            Console.WriteLine("Naciśnij dowolny klawisz, aby zamknąć okno...");
            Console.ReadKey(); // <--- ZATRZYMANIE KOŃCOWE 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nWystąpił nieoczekiwany błąd globalny: {ex.Message}");
            Console.WriteLine("Naciśnij klawisz, aby zamknąć...");
            Console.ReadKey(); 
        }
    }

    private static void TestRzutowania()
    {
        Console.Write("Podaj liczbę punktów do wczytania: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Nieprawidłowa liczba.");
            return;
        }

        List<Punkt3D> punkty = new List<Punkt3D>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Wprowadź współrzędne punktu " + (i + 1));
            double x = WczytajLiczbe("x: ");
            double y = WczytajLiczbe("y: ");
            double z = WczytajLiczbe("z: ");
            punkty.Add(new Punkt3D(x, y, z));
        }

        Console.WriteLine("\nPodaj parametry rzutowania:");
        double z0 = WczytajLiczbe("z0: ");
        double d = WczytajLiczbe("d: ");

        Console.WriteLine("\nWyniki rzutowania:");
        foreach (var p in punkty)
        {
            try
            {
                Punkt2D rzut = p.Rzutowanie(z0, d);
                Console.Write($"Punkt {p} -> ");
                rzut.Wypisz();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Błąd rzutowania dla punktu {p}: {e.Message}");
            }
        }
    }

    private static void TestObjetosci()
    {
        Console.WriteLine("Podaj 4 punkty rozpinające równoległościan:");
        Punkt3D[] p = new Punkt3D[4];
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Punkt {i + 1}:");
            p[i] = new Punkt3D(WczytajLiczbe("x: "), WczytajLiczbe("y: "), WczytajLiczbe("z: "));
        }

        // Tworzymy 3 wektory wychodzące z pierwszego punktu
        Wektor3D u = new Wektor3D(p[0], p[1]);
        Wektor3D v = new Wektor3D(p[0], p[2]);
        Wektor3D w = new Wektor3D(p[0], p[3]);

        // Objętość to wartość bezwzględna z iloczynu mieszanego
        double iloczyn = Wektor3D.IloczynMieszany(u, v, w);
        double objetosc = Math.Abs(iloczyn);

        Console.WriteLine($"Objętość równoległościanu wynosi: {objetosc:F4}");
    }

    private static void TestKolekcji()
    {
        Punkt3D p1 = new Punkt3D(1, 2, 3);
        Punkt3D p2 = new Punkt3D(1, 2, 3); // To samo co p1 matematycznie
        Punkt3D p3 = new Punkt3D(5, 5, 5);

        // Test Ciągu (List) - p1 i p2 będą traktowane jako dwa wpisy
        Console.WriteLine("\n--- Ciąg (List) ---");
        CiagPunktow3d ciag = new CiagPunktow3d();
        ciag.DodajPunkt(p1);
        ciag.DodajPunkt(p2);
        ciag.DodajPunkt(p3);
        Console.WriteLine($"Długość ciągu: {ciag.DlugoscCiagu()} (Oczekiwano: 3)");
        
        // Test Zbioru (Set) - p1 i p2 to ten sam punkt, więc powinien być 1 raz
        Console.WriteLine("\n--- Zbiór (Set) ---");
        ZbiorPunktow3d zbior = new ZbiorPunktow3d();
        zbior.DodajPunkt(p1);
        zbior.DodajPunkt(p2); // Duplikat
        zbior.DodajPunkt(p3);
        Console.WriteLine($"Moc zbioru: {zbior.MocZbioru()} (Oczekiwano: 2, bo p1==p2)");
    }

    private static double WczytajLiczbe(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;
            Console.Write("Błędna liczba, spróbuj ponownie: ");
        }
    }
}