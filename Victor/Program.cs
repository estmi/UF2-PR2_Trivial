using System;
using System.IO;
using static Esteve.Esteve;

namespace Victor
{
    public class Program
    {
        static void Main()
        {
            //StreamReader sR = new StreamReader("bichos.txt");

            Tematica FarmingSim;
            StreamReader sr = new StreamReader("../../../../Esteve/Preguntes Farming.txt");
            int punts = 0;
            
            FarmingSim.pregunta1 = AfegirPregunta(sr);
            sr.ReadLine();
            FarmingSim.pregunta2 = AfegirPregunta(sr);
            sr.ReadLine();
            punts = ComptadorPunts(FerPregunta(FarmingSim.pregunta1),punts);
            punts = ComptadorPunts(FerPregunta(FarmingSim.pregunta2), punts);

        }
        /*public static bool FerPregunta(Correccio c)
        {
            bool correcte = false;
            int tecla;
            c = RandomizeOptions(c);
            MostrarOpcions(c);
            tecla = (int)Console.ReadKey().Key - 65;
            Console.WriteLine();
            if (c.OpcioCorrecta[tecla])
                correcte = true;
            return correcte;
        }*/
        /*public static bool FerPregunta(Correccio c)
        {
            bool resposta;
            c = RandomizeOptions(c);
            MostrarOpcions(c);
            resposta = RecollirResposta(c);
            return resposta;
        }*/
        /*public static bool RecollirResposta(Correccio c)
        {
            bool correcte;
            int tecla = (int)Console.ReadKey().Key - 65;
            Console.WriteLine();
            try
            {
                correcte = c.OpcioCorrecta[tecla];
            }
            catch
            {
                Console.WriteLine("Opcio incorrecta");
                tecla = (int)Console.ReadKey().Key - 65;
                correcte = c.OpcioCorrecta[tecla];
            }

            return correcte;
        }*/
        public static int ComptadorPunts(bool b, int punts)
        {

            string s;
            if (b) s = string.Format("Correcte! la teva puntuació és {0} punt/s", ++punts);
            else s = string.Format("Incorrecte! la teva puntuació és {0} punt/s", punts);
            Console.WriteLine(s);
            return punts;

        }
    }
}
