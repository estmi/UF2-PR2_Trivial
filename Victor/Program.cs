using System;

namespace Victor
{
    public class Program
    {
        static void Main() { }
        public static int ComptadorPunts(bool b, int punts)
        {
            string s;
            if (b) s = string.Format("Correcte! la teva puntuació és de {0} punt/s", ++punts);
            else s = string.Format("Incorrecte! la teva puntuació és de {0} punt/s", punts);
            Console.WriteLine(s);
            return punts;
        }
    }
}
