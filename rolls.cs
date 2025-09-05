using System;

namespace Letra
{
    internal class Rolls
    {
        public int Rollnum { get; set; }
        public int Rollval { get; set; }

        public Rolls(string r)
        {
            var parts = r.Split(new string[] { " + " }, StringSplitOptions.None);
            Rollnum = Convert.ToInt32(parts[0]);
            Rollval = Convert.ToInt32(parts[1]);
        }
    }
}