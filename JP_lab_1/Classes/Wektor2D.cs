using System;

namespace JP_lab_1.Classes;

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

    public static Wektor2D CreatePointer(Punkt2D start, Punkt2D end)
    {
        return new Wektor2D(start.X-end.X, end.Y-start.Y);
    }

    public static Wektor2D Sum(Wektor2D w1, Wektor2D w2)
    {
        return new Wektor2D(w1.X + w2.X, w1.Y + w2.Y);
    }

    public static Wektor2D Odejmij(Wektor2D w1, Wektor2D w2)
    {
        return new Wektor2D(w1.X - w2.X, w1.Y - w2.Y);
    }

    public double Distance()
    {
        return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
    }
    
}