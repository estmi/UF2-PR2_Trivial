using System;
using System.IO;
using static Esteve.Esteve;

namespace Victor
{
    public class Program
    {
        static void Main()
        {
            Tematica Variable;
            string tema;
            tema = Console.ReadLine();
            StreamReader sr = new StreamReader(string.Format("../../../../Esteve/{0}.txt",tema));
            int punts = 0;
            Variable.nom = sr.ReadLine();
            Variable.pregunta1 = AfegirPregunta(sr);
            sr.ReadLine();
            Variable.pregunta2 = AfegirPregunta(sr);
            sr.ReadLine();
            punts = ComptadorPunts(FerPregunta(Variable.pregunta1), punts);
            punts = ComptadorPunts(FerPregunta(Variable.pregunta2), punts);
        }
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

