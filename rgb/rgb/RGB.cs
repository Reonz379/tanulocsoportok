using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgb
{
    internal class RGB
    {
        private int _r;
        private int _g;
        private int _b;
        private int _rgbt;
        static public int Vilagosok;
        static public int Sotet = 10000;
        public RGB(int r, int g, int b)
        {
            this._r = r;
            this._g = g;
            this._b = b;
            this._rgbt = _r+_g+_b;
            if (_rgbt > 600) 
            {
                Vilagosok++;
            }
            if (this._rgbt < Sotet)
            {
                Sotet = this._rgbt ;
                
            }
        }
        public int R { get { return _r; } }
        public int G { get { return _g; } }
        public int B { get { return _b; } }
        public int RGBT { get { return _rgbt; } } 

        public static void Lekerdezes(List<RGB[]> colors)
        {
            Console.Write($"2. feladat:\nKérem egy képpont adatait!\nSor:");
            int sor = 0;
            int oszlop = 0;
            if (int.TryParse(Console.ReadLine(), out int s)) sor = s;
            Console.Write("Oszlop:");
            if (int.TryParse(Console.ReadLine(), out int o)) oszlop = o;
            Console.WriteLine($"A képpont színe RGB({colors[sor-1][oszlop-1].R},{colors[sor - 1][oszlop - 1].G},{colors[sor - 1][oszlop - 1].B})");
        }
        public static void Legsotetebbek(List<RGB[]> colors)
        {
            Console.WriteLine($"4. feladat:\nA legsötétebb pont RGB összege: {RGB.Sotet}\nA legsötétebb pixelek színe:");
            List<RGB> rgbs = new List<RGB>();
            foreach(RGB[] rgb in colors)
            {
                foreach (RGB item in rgb)
                {
                    if(item.RGBT == RGB.Sotet&&!rgbs.Contains(item))
                    {
                        rgbs.Add(item);
                    }
                }
            }
            foreach(RGB item in rgbs) Console.WriteLine($"RGB({item.R},{item.G},{item.B})");
        }
        public static bool hatar(List<RGB[]> colors, int sorszam, int elteres)
        {
            bool elter = false;
            RGB[] sor = colors[sorszam];
            for(int i = 0; i < sor.Length-1; i++)
            {
                if (sor[i].B - sor[i+1].B > elteres || sor[i+1].B - sor[i].B > elteres)
                {
                    elter = true;
                    break;
                }
            }
            return elter;
        }
    }
}
