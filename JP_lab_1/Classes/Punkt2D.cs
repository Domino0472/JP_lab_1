using System;

namespace JP_lab_1.Classes
{
    public class Punkt2D
    {
        
        private double _x;
        private double _y;

        public double X => _x;
        public double Y => _y;

        public Punkt2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // Metoda do wypisywania punktu 
        public void Wypisz()
        {
            Console.WriteLine($"Punkt2D({_x:F4}, {_y:F4})");
        }
    }
}