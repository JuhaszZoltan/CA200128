using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CA200128
{
    struct Hotel
    {
        public string Nev;
        public int FelPanzioAr;
        public int TeljesellatasAr;
        public int Ferohely;
    }
    class Program
    {
        static List<Hotel> hotelek = new List<Hotel>();

        static void Main(string[] args)
        {
            Felaldat02();
            //Teszt01();
            Feladat03();
            Feladat04();
            Feladat05();
            Feladat06();
            Console.ReadKey();
        }

        private static void Feladat06()
        {
            Console.Write("keresett hotel neve: ");
            string nev = Console.ReadLine();

            int i = 0;
            while (i < hotelek.Count && nev != hotelek[i].Nev)
            {
                i++;
            }

            if(i < hotelek.Count)
            {
                Console.WriteLine($"{hotelek[i].Nev} félpanzió: {hotelek[i].FelPanzioAr}Ft, teljes ellátás: {hotelek[i].TeljesellatasAr}Ft");
                Console.WriteLine($"férőhely: {hotelek[i].Ferohely} fő");
            }
            else
            {
                Console.WriteLine("nincs ilyen hotel");
            }

        }

        static void Feladat05()
        {
            int osszeg = 0;
            int SzazAlatti = 0;
            int felOsszeg = 0;
            foreach (var h in hotelek)
            {
                osszeg += h.TeljesellatasAr;
                felOsszeg += h.FelPanzioAr;
                if(h.Ferohely < 100)
                {
                    SzazAlatti++;
                }
            }
            Console.WriteLine($"\nHa mindehol lennék 1x az {osszeg}Ft-ba kerülne");
            Console.WriteLine($"{SzazAlatti} db hotel férőhelyeinek száma van 100 alatt");
            Console.WriteLine($"Átlagos félpanziós ár: {felOsszeg / (float)hotelek.Count}Ft");
        }
        private static void Feladat04()
        {
            Console.WriteLine("NAGY BEFOGADÓ KÉPESSÉGŰEK");
            foreach (var h in hotelek)
            {
                if(h.Ferohely > 300)
                {
                    Console.WriteLine($"{h.Nev}: {h.Ferohely} fő");
                }
            }
        }
        static void Feladat03()
        {
            foreach(var h in hotelek)
            {
                Console.WriteLine($"{h.Nev} félpanzió: {h.FelPanzioAr}Ft, teljes ellátás: {h.TeljesellatasAr}Ft");
                Console.WriteLine($"férőhely: {h.Ferohely} fő\n");
            }
        }
        private static void Teszt01()
        {
            foreach (var h in hotelek)
            {
                Console.WriteLine(h.Nev);
            }
        }
        private static void Felaldat02()
        {
            var sr = new StreamReader(@"hotel.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string[] t = sr.ReadLine().Split(';');
                var h = new Hotel()
                {
                    Nev = t[0],
                    FelPanzioAr = int.Parse(t[1]),
                    TeljesellatasAr = int.Parse(t[2]),
                    Ferohely = int.Parse(t[3]),
                };
                hotelek.Add(h);
            }
            sr.Close();
        }
    }
}