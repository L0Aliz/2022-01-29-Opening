using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpeningWeekend
{
    class Film
    {
        public string EredetiCím { get; set; }
        public string MagyarCím { get; set; }
        public string BemutatóDátuma { get; set; }
        public string Forgalmazó { get; set; }
        public int Bevétel { get; set; }
        public int Látogató { get; set; }

        public Film(string sor)
        {
            string[] x = sor.Split(';');
            this.EredetiCím = x[0];
            this.MagyarCím = x[1];
            this.BemutatóDátuma = x[2];
            this.Forgalmazó = x[3];
            this.Bevétel = int.Parse(x[4]);
            this.Látogató = int.Parse(x[5]);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Film> filmek = new List<Film>();
            foreach (var sor in File.ReadAllLines("nyitohetvege.txt").Skip(1))
            {
                filmek.Add(new Film(sor));
            }
            //3. feladat:
            Console.WriteLine($"3. feladat: Filmek száma az állományban: {filmek.Count} db");
            //4.feladat:
            int bevételszámoló = 0;
            foreach (var f in filmek)
            {
                if (f.Forgalmazó=="UIP")
                {
                    if (f.BemutatóDátuma=="2016.12.01")
                    {
                        bevételszámoló = bevételszámoló + f.Bevétel;
                    }
                }
            }
            Console.WriteLine($"4. feladat: UIP Duna Film 1. hetes bevételeinek összege: {bevételszámoló} Ft");
            //5. feladat:
            Console.WriteLine("5. feladat: Legtöbb látogató az 1. héten: ");
            int maxlátogató = 1;
            foreach (var i in filmek)
            {
                if (i.Látogató>maxlátogató)
                {
                    maxlátogató = i.Látogató;
                }
            }
            foreach (var l in filmek)
            {
                if (l.Látogató==maxlátogató)
                {
                    Console.WriteLine($"Eredeti cím: {l.EredetiCím}");
                    Console.WriteLine($"Magyar Cím: {l.MagyarCím}");
                    Console.WriteLine($"Forgalmazó: {l.Forgalmazó}");
                    Console.WriteLine($"Bevétel az első héten: {l.Bevétel} Ft");
                    Console.WriteLine($"Látogatók száma: {l.Látogató} fő");
                }
            }
            
            Console.ReadKey();
        }
    }
}
