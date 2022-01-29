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
        public DateTime BemutatóDátuma { get; set; }
        public string Forgalmazó { get; set; }
        public int Bevétel { get; set; }
        public int Látogató { get; set; }

        public Film(string sor)
        {
            string[] x = sor.Split(';');
            this.EredetiCím = x[0];
            this.MagyarCím = x[1];
            this.BemutatóDátuma = DateTime.Parse(x[2]);
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
            Console.ReadKey();
        }
    }
}
