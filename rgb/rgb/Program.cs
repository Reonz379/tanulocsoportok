using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rgb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RGB[]> colors = new List<RGB[]>();
            try
            {
                foreach (string line in File.ReadAllLines("kep.txt"))
                {
                    string[] nums = line.Split(' ');
                    RGB[] rgb = new RGB[640];
                    int j = 0;
                    for (int i = 0; i < nums.Length; i += 3)
                    {
                        rgb[j] = new RGB(int.Parse(nums[i]), int.Parse(nums[i + 1]), int.Parse(nums[i + 2]));
                        j++;
                    }
                    colors.Add(rgb);
                }
                RGB.Lekerdezes(colors);
                Console.WriteLine($"3. feladat:\nA világos képpontok száma: {RGB.Vilagosok}");
                RGB.Legsotetebbek(colors);
                Console.WriteLine("6. feladat:");
                for (int i = 0; i < colors.Count; i++) {
                    bool meghaladja = RGB.hatar(colors, i, 10);
                    if (meghaladja)
                    {
                        Console.WriteLine($"A felhő legfelső sora: {i+1}");
                        break;
                    }
                }
                for (int i = colors.Count-1; i >-1 ; i--)
                {
                    bool meghaladja = RGB.hatar(colors, i, 10);
                    if (meghaladja)
                    {
                        Console.WriteLine($"A felhő legalsó sora: {i+1}");
                        break;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
           
            Console.ReadKey();
        }
    }
}
