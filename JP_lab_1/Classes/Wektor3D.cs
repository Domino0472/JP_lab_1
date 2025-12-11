using System;

namespace JP_lab_1.Classes
{
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

        
        public Wektor3D(Punkt3D start, Punkt3D end)
        {
            if (start == null || end == null) throw new ArgumentNullException("Punkty nie mogą być null");
            _x = end.X - start.X;
            _y = end.Y - start.Y;
            _z = end.Z - start.Z;
        }

        public static Wektor3D Sum(Wektor3D w1, Wektor3D w2)
        {
            return new Wektor3D(w1.X + w2.X, w1.Y + w2.Y, w1.Z + w2.Z);
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
            double x = w1.Y * w2.Z - w1.Z * w2.Y;
            double y = w1.Z * w2.X - w1.X * w2.Z;
            double z = w1.X * w2.Y - w1.Y * w2.X;
            return new Wektor3D(x, y, z);
        }

        // Iloczyn mieszany: (u x v) . w
        public static double IloczynMieszany(Wektor3D u, Wektor3D v, Wektor3D w)
        {
            Wektor3D cross = IloczynWek(u, v);
            return IloczynSkal(cross, w);
        }
    }
}