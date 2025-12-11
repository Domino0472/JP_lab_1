using System;
using System.Collections.Generic;

namespace JP_lab_1.Classes
{
    public class CiagPunktow3d
    {
        
        private List<Punkt3D> _lista;

        public CiagPunktow3d()
        {
            _lista = new List<Punkt3D>();
        }

        public void DodajPunkt(Punkt3D p)
        {
            if (p == null) throw new ArgumentNullException("Punkt nie może być null");
            _lista.Add(p); // Dodaje zawsze na końcu
        }

        public void UsunPunkt(Punkt3D p)
        {
            // Usuwa pierwsze wystąpienie identyczne z podanym
            _lista.Remove(p); 
        }

        public bool CzyPunktJestWCiagu(Punkt3D p)
        {
            return _lista.Contains(p);
        }

        public Punkt3D PodajPunkt(int i)
        {
            if (i < 0 || i >= _lista.Count) throw new IndexOutOfRangeException("Indeks poza zakresem ciągu.");
            return _lista[i];
        }

        public int DlugoscCiagu()
        {
            return _lista.Count;
        }
    }
}