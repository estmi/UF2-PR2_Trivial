using System;
using Jordi;
using Victor;
using System.IO;
using static Esteve.Esteve;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            int teclaNum;
            string tema;
            Tematica contingutTema;
            int punts = 0;
            do
            {
                MostrarMenu();
                tecla = Console.ReadKey();
                teclaNum = Convert.ToInt32(tecla.Key) - 65;
                if (0 < teclaNum && teclaNum < 25)
                {
                    tema = ObtenirOpcio(teclaNum);
                    contingutTema = AfegirTematica(tema);
                    punts = Victor.Program.ComptadorPunts(FerPregunta(contingutTema.pregunta1), punts);
                    punts = Victor.Program.ComptadorPunts(FerPregunta(contingutTema.pregunta2), punts);
                    punts = Victor.Program.ComptadorPunts(FerPregunta(contingutTema.pregunta3), punts);
                    punts = Victor.Program.ComptadorPunts(FerPregunta(contingutTema.pregunta4), punts);
                    punts = Victor.Program.ComptadorPunts(FerPregunta(contingutTema.pregunta5), punts);
                }
                else if (tecla.Key == ConsoleKey.NumPad0)
                {
                    Console.Clear();
                    Console.WriteLine("Has entrat en mode desenvolupador. Ara es solicitaran una serie de preguntes per afegir una tematica.");
                    GuardarTematica(new Tematica(Console.ReadLine(), AfegirPregunta(), AfegirPregunta(), AfegirPregunta(), AfegirPregunta(), AfegirPregunta()));
                }
                Console.Clear();
            }
            while (tecla.Key != ConsoleKey.Enter);
        }
        public static string ObtenirOpcio(int tecla)
        {
            string s;
            StreamReader sr = new StreamReader("../../../../Tematiques/tematiques.txt");
            for (int i=0; i<tecla; i++)
            {
                sr.ReadLine();
            }
            s = sr.ReadLine();
            sr.Close();
            return s;
        }
        public static void MostrarMenu()
        {
            StreamReader sr = new StreamReader("../../../../Tematiques/tematiques.txt");
            Console.WriteLine("╔═════════════════════════════════════╗");
            while (!sr.EndOfStream)
            {
                
                Console.WriteLine("║{0,-37}║", sr.ReadLine());
                if (sr.Peek()!= -1)
                {
                    Console.WriteLine("╠═════════════════════════════════════╣");
                }
            }
            Console.WriteLine("╚═════════════════════════════════════╝");
            sr.Close();
        }
        
    }
}
