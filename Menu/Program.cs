using System;
using Jordi;
using System.IO;
using static Esteve.Esteve;
using System.Collections.Generic;

namespace Menu
{
    class Program
    {
        
        public struct Informe
        {
            public List<string> temesFets;
            public List<int> puntuacio;
            public List<List<string>> opcioTriada;
            public Informe(string s)
            {
                this.temesFets = new List<string> { };
                this.puntuacio = new List<int> { };
                this.opcioTriada = new List<List<string>> { };
            }
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            Informe informe = new Informe("");
            int teclaNum;
            bool acabat = false;
            string tema;
            Tematica contingutTema;
            int punts = 0;
            do
            {
                MostrarMenu();
                tecla = Console.ReadKey();
                teclaNum = Convert.ToInt32(tecla.Key) - 65;
                Console.WriteLine();
                if (0 <= teclaNum && teclaNum <= 25)
                {
                    informe.opcioTriada.Add(new List<string> { });
                    tema = ObtenirOpcio(teclaNum);
                    contingutTema = AfegirTematica(tema);
                    for (int i=0; i<contingutTema.preguntes.Length;i++)
                    {
                        punts = ComptadorPunts(FerPregunta(contingutTema.preguntes[i]),punts);
                        informe.opcioTriada[informe.temesFets.Count].Add(Esteve.Esteve.opcio);
                    }
                    informe.temesFets.Add(tema);
                    informe.puntuacio.Add(punts);
                    
                    punts = 0;
                }
                else if (tecla.Key == ConsoleKey.Multiply)
                {
                    VeureInforme(informe.temesFets.ToArray(), informe.puntuacio.ToArray(), informe.opcioTriada);
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

        /// <summary>
        /// Logica per mostrar un informe sobre tots els intents efectuats
        /// </summary>
        /// <param name="temesFets">array sobre els temes fets a cada intent</param>
        /// <param name="puntuacio">array que conte les puntuacions de cada intent</param>
        /// <param name="opcioTriada">llista que conte les opcions triades a cada intent</param>
        public static void VeureInforme(string[] temesFets, int[] puntuacio,List<List<string>> opcioTriada)
        {
            int teclaInforme;
            Tematica tema;
            string correcte;
            do
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════════╗");
                for (int i = 0; i < temesFets.Length; i++)
                {
                    Console.WriteLine("║{0,-34} {1,2}║", temesFets[i], puntuacio[i]);
                    if (i + 1 < temesFets.Length)
                        Console.WriteLine("╠═════════════════════════════════════╣");

                }
                Console.WriteLine("╚═════════════════════════════════════╝");

                teclaInforme = Convert.ToInt32(Console.ReadKey().Key) - 65;
                Console.Clear();
                if (0 <= teclaInforme && teclaInforme <= 25)
                {
                    tema = AfegirTematica(temesFets[teclaInforme]);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
                    for (int i = 0; i < tema.preguntes.Length; i++)
                    {

                        if (tema.preguntes[i].opcions[indexCorrecte(tema.preguntes[i])] == opcioTriada[teclaInforme][i])
                            correcte = "Correcte";
                        else
                            correcte = "Incorrecte";
                        Console.WriteLine("║{0,-52} {1,10}║", tema.preguntes[i].pregunta, correcte);
                        Console.WriteLine("╟───────────────────────────────────────────────────────────────╢");
                        if (correcte == "Incorrecte")
                            Console.WriteLine("║{0,-63}║", opcioTriada[teclaInforme][i], "Resposta Donada");
                        Console.WriteLine("║{0,-63}║", tema.preguntes[i].opcions[indexCorrecte(tema.preguntes[i])], "Resposta Correcta");
                        if (i + 1 < tema.preguntes.Length)
                            Console.WriteLine("╠═══════════════════════════════════════════════════════════════╣");

                    }
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
                    //╢╟─
                    Console.ReadKey();
                } 
            }
            while (teclaInforme != 13-65);
        }

        /// <summary>
        /// obte l'index de la opcio correcta
        /// </summary>
        /// <param name="c">correccio on buscar</param>
        /// <returns>index opcio correcte</returns>
        public static int indexCorrecte(Correccio c)
        {
            int idx=0;
            while (!c.OpcioCorrecta[idx])
            {
                idx++;
            }
            return idx;
        }

        /// <summary>
        /// amb un index obte el nom de la tematica desitjada
        /// </summary>
        /// <param name="tecla">index</param>
        /// <returns>nom de la tematica</returns>
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

        /// <summary>
        /// Mostra el menu
        /// </summary>
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
