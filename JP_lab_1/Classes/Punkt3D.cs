using System;

namespace JP_lab_1.Classes
{
    public class Punkt3D
    {
        private double _x;
        private double _y;
        private double _z;

        public double X => _x;
        public double Y => _y;
        public double Z => _z;

        public Punkt3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        // Wymagane: Przesunięcie punktu o wektor
        public void Przesun(Wektor3D v)
        {
            if (v == null) throw new ArgumentNullException("Wektor nie może być null.");
            _x += v.X;
            _y += v.Y;
            _z += v.Z;
        }

        
        public Punkt2D Rzutowanie(double z0, double d)
        {
            double mianownik = z0 - _z;

            // Sensowny wyjątek
            if (Math.Abs(mianownik) < 1e-9) // Porównanie double z tolerancją
                throw new DivideByZeroException("Punkt leży na płaszczyźnie rzutowania (z1 == z0), dzielenie przez zero.");

            // Wzory z obrazka:
            // x2 = (z0*x1 - z1*d) / (z0 - z1)
            // y2 = (z0*y1) / (z0 - z1)
            
            double x2 = (z0 * _x - _z * d) / mianownik;
            double y2 = (z0 * _y) / mianownik; 

            return new Punkt2D(x2, y2);
        }

        // Equals i GetHashCode jest KONIECZNE dla ZbiorPunktow3d (HashSet)
        // aby poprawnie wykrywać duplikaty
        public override bool Equals(object? obj)
        {
            if (obj is not Punkt3D p) return false;
            return Math.Abs(_x - p.X) < 1e-9 && 
                   Math.Abs(_y - p.Y) < 1e-9 && 
                   Math.Abs(_z - p.Z) < 1e-9;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y, _z);
        }

        public override string ToString()
        {
            return $"[{_x}, {_y}, {_z}]";
        }
    }
}