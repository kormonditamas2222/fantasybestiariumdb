namespace fantasybestiariumdb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SzornyAdatbazis db = new();
            List<Szorny> szornyek = db.Feltolt();
            SzornyElemzo elemzo = new(szornyek);
            Console.WriteLine($"A listában {elemzo.OsszesSzornySzama()} szörny található.");
            Console.Write("A veszélyes szörnyek nevei: ");
            foreach (string nev in elemzo.VeszelyesSzornyekNevei())
            {
                Console.Write(nev + ", ");
            }
            Console.WriteLine();
            Console.Write("Egyedi élőhelyek: ");
            foreach (string elohely in elemzo.EgyediElohelyek())
            {
                Console.Write(elohely + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"A szörnyek átlagos veszélyességi szintje: {elemzo.AtlagosVeszelyessegiSzint()}");
            Console.Write("A legveszélyesebb szörnyek: ");
            foreach (Szorny szorny in elemzo.LegVeszelyesebbSzornyek())
            {
                Console.Write(szorny.ToString() + " | ");
            }
            Console.WriteLine();
            Console.Write("A mocsári, veszélyes szörnyek: ");
            foreach (Szorny szorny in elemzo.MocsariVeszelyesSzornyek())
            {
                Console.Write(szorny.ToString() + " | ");
            }
            Console.WriteLine();
            Console.WriteLine(elemzo.VanExtremTuzGyengeSzorny() ? "Van olyan szörny amelynek fő gyengesége a Tűz és veszélyessége eléri vagy meghaladja a 9-et" 
                : "Nincs olyan szörny amelynek fő gyengesége a Tűz és veszélyessége eléri vagy meghaladja a 9-et");
            Console.Write("Élőhelyenként ott élő szörnyek száma: ");
            foreach (string elohelySzam in elemzo.SzornyekSzamaElohelyenkent())
            {
                Console.Write(elohelySzam + ", ");
            }
        }
    }
}
