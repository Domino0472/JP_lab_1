namespace JP_lab_1.Classes;

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

    public Punkt2D Rzutowanie(double z0, double d)
    {
        double mianownik = z0 - _z;

        if (mianownik == 0)
            throw new ("punkt lezy na plaszczyznie rzutowania z1 = z0");
        double x2 = (z0 * _x - d * _x) / mianownik;
        double y2 = (z0 * _y - d * _y) / mianownik;
        return new Punkt2D(x2, y2);
        
    }
}