using System;
using Jordi;
using System.IO;
using static Esteve.Esteve;
using static Victor.Program;
using System.Collections.Generic;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            int teclaNum;
            bool acabat = false;
            string tema;
            Tematica contingutTema;
            int punts = 0;
            List<string> TemesFets = new List<string> { };
            List<int> puntuacio = new List<int> { };
            do
            {
                MostrarMenu();
                tecla = Console.ReadKey();
                teclaNum = Convert.ToInt32(tecla.Key) - 65;
                Console.WriteLine();
                if (0 <= teclaNum && teclaNum <= 25)
                {
                    tema = ObtenirOpcio(teclaNum);
                    contingutTema = AfegirTematica(tema);
                    foreach (Correccio c in contingutTema.preguntes)
                    {
                        punts = ComptadorPunts(FerPregunta(c),punts);
                    }
                    TemesFets.Add(tema);
                    puntuacio.Add(punts);
                    punts = 0;
                }
                else if (tecla.Key == ConsoleKey.Multiply)
                {
                    Console.Clear();
                    VeureInforme(TemesFets.ToArray(), puntuacio.ToArray());
                    acabat = true;
                }
                else if (tecla.Key == ConsoleKey.NumPad0)
                {
                    Console.Clear();
                    Console.WriteLine("Has entrat en mode desenvolupador. Ara es solicitaran una serie de preguntes per afegir una tematica.");
                    GuardarTematica(AfegirTematica());
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (tecla.Key != ConsoleKey.Enter&&!acabat);
        }

        private static void VeureInforme(string[] temesFets, int[] puntuacio)
        {
            Console.WriteLine("╔═════════════════════════════════════╗");
            for (int i = 0; i < temesFets.Length; i++)
            {
                Console.WriteLine("║{0,-34} {1,2}║", temesFets[i], puntuacio[i]);
                if (i + 1 < temesFets.Length)
                    Console.WriteLine("╠═════════════════════════════════════╣");
                
            }
            Console.WriteLine("╚═════════════════════════════════════╝");
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
            int idx = 0;
            while (!sr.EndOfStream)
            {
                
                Console.WriteLine("║{0} {1,-34}║",abc[idx], sr.ReadLine());
                Console.WriteLine("╠═════════════════════════════════════╣");
                idx++;
            }
            Console.WriteLine("║{0} {1,-34}║", "*)","Veure informe final" );
            Console.WriteLine("╚═════════════════════════════════════╝");
            sr.Close();
        }
        
    }
}
