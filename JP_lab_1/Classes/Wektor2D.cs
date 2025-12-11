using System;

namespace JP_lab_1.Classes
{
    public class Wektor2D
    {
        private double _x;
        private double _y;

        public double X => _x;
        public double Y => _y;

        public Wektor2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // Tworzenie z punktów
        public static Wektor2D CreatePointer(Punkt2D start, Punkt2D end)
        {
            if (start == null || end == null) throw new ArgumentNullException("Punkty nie mogą być null.");
            return new Wektor2D(end.X - start.X, end.Y - start.Y);
        }

        public static Wektor2D Sum(Wektor2D w1, Wektor2D w2)
        {
            if (w1 == null || w2 == null) throw new ArgumentNullException("Wektory nie mogą być null.");
            return new Wektor2D(w1.X + w2.X, w1.Y + w2.Y);
        }

        public static Wektor2D Odejmij(Wektor2D w1, Wektor2D w2)
        {
            if (w1 == null || w2 == null) throw new ArgumentNullException("Wektory nie mogą być null.");
            return new Wektor2D(w1.X - w2.X, w1.Y - w2.Y);
        }

        public double Dlugosc()
        {
            return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
        }

        // Wyznaczanie kąta między wektorami (w stopniach)
        public static double Kat(Wektor2D w1, Wektor2D w2)
        {
            if (w1 == null || w2 == null) throw new ArgumentNullException("Wektory nie mogą być null.");
            
            double iloczynSkalarny = (w1.X * w2.X) + (w1.Y * w2.Y);
            double iloczynDlugosci = w1.Dlugosc() * w2.Dlugosc();

            if (iloczynDlugosci == 0) throw new ArithmeticException("Nie można obliczyć kąta dla wektora zerowego.");

            double cosKat = iloczynSkalarny / iloczynDlugosci;
            // Zabezpieczenie przed błędami zaokrągleń (np. 1.0000000002)
            cosKat = Math.Max(-1, Math.Min(1, cosKat)); 

            return Math.Acos(cosKat) * (180.0 / Math.PI); // Wynik w stopniach
        }
    }
}