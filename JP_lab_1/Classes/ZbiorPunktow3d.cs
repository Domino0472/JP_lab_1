using System;
using System.Collections.Generic;

namespace JP_lab_1.Classes
{
    public class ZbiorPunktow3d
    {
        // Wykorzystujemy HashSet<T> jako "odpowiednią strukturę" (zbiór bez duplikatów)
        private HashSet<Punkt3D> _zbior;

        public ZbiorPunktow3d()
        {
            _zbior = new HashSet<Punkt3D>();
        }

        public void DodajPunkt(Punkt3D p)
        {
            if (p == null) throw new ArgumentNullException("Punkt nie może być null");
            // HashSet automatycznie ignoruje duplikaty (wymaga Equals w Punkt3D)
            _zbior.Add(p);
        }

        public void UsunPunkt(Punkt3D p)
        {
            _zbior.Remove(p);
        }

        public bool CzyPunktJestWZbiorze(Punkt3D p)
        {
            return _zbior.Contains(p);
        }

        public int MocZbioru()
        {
            return _zbior.Count;
        }
    }
}