using System;
using System.Collections.Generic;
using System.Text;

namespace fantasybestiariumdb
{
    internal class SzornyElemzo
    {
        List<Szorny> szornyek;

        public SzornyElemzo(List<Szorny> szornyek)
        {
            this.szornyek = szornyek;
        }

        public int OsszesSzornySzama()
        {
            return szornyek.Count;
        }
        public IEnumerable<string> VeszelyesSzornyekNevei()
        {
            var eredmeny = szornyek.Where(sz => sz.VeszelyesE).Select(sz => sz.Nev);
            return eredmeny;
        }
        public IEnumerable<string> EgyediElohelyek()
        {
            var eredmeny = szornyek.Select(sz => sz.Elohely).Distinct().OrderBy(sz => sz);
            return eredmeny;
        }
        public double AtlagosVeszelyessegiSzint()
        {
            double atlag = szornyek.Average(sz => sz.VeszelyessegiSzint);
            return atlag;
        }
        public IEnumerable<Szorny> LegVeszelyesebbSzornyek()
        {
            int legmagasabbVeszelyessegiSzint = szornyek.Max(sz => sz.VeszelyessegiSzint);
            var eredmeny = szornyek.Where(sz => sz.VeszelyessegiSzint == legmagasabbVeszelyessegiSzint);
            return eredmeny;
        }
        public IEnumerable<Szorny> MocsariVeszelyesSzornyek()
        {
            var eredmeny = szornyek.Where(sz => sz.Elohely == "Fekete Mocsár" && sz.VeszelyessegiSzint >= 5).OrderByDescending(sz => sz.VeszelyessegiSzint);
            return eredmeny;
        }
        public bool VanExtremTuzGyengeSzorny()
        {
            var eredmeny = szornyek.Any(sz => sz.FoGyengeseg == "Tűz" && sz.VeszelyessegiSzint >= 9);
            return eredmeny;
        }
        public IEnumerable<string> SzornyekSzamaElohelyenkent()
        {
            var eredmeny = szornyek.GroupBy(sz => sz.Elohely).Select(csoport => $"{csoport.Key}: {csoport.Count()}");
            return eredmeny;
        }
    }
}
