namespace JP_lab_1.Classes;

public class Wektor3D
{
    private double _x;
    private double _y;
    private double _z;
    
    public double X => _x;
    public double Y => _y;
    public double Z => _z;
    
    public Wektor3D(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public Wektor3D CreatePoint(Punkt3D start, Punkt3D end)
    {
        return new Wektor3D(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
    }

    public static Wektor3D Sum(Wektor3D w1, Wektor3D w2)
    {
        return new Wektor3D (w1.X + w2.X, w1.Y + w2.Y, w1.Z + w2.Z);
        
    }

    public static Wektor3D Odejmij(Wektor3D w1, Wektor3D w2)
    {
        return new Wektor3D(w1.X - w2.X, w1.Y - w2.Y, w1.Z - w2.Z);
    }

    public static double IloczynSkal(Wektor3D w1, Wektor3D w2)
    {
        return (w1.X * w2.X) + (w1.Y * w2.Y) + (w1.Z * w2.Z);
    }
    public static Wektor3D IloczynWek(Wektor3D w1, Wektor3D w2)
    {
        // w1 x w2 = (y1*z2 - z1*y2, z1*x2 - x1*z2, x1*y2 - y1*x2)
        double x = w1.Y * w2.Z - w1.Z * w2.Y;
        double y = w1.Z * w2.X - w1.X * w2.Z;
        double z = w1.X * w2.Y - w1.Y * w2.X;
        return new Wektor3D(x, y, z);
    }
}