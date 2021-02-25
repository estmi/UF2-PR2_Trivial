using System;
using System.Collections.Generic;
using System.Linq;
using Programacio;
using System.IO;

namespace Esteve
{
    public class Esteve
    {
        public static string opcio;
        public static Random _random = new Random(); // Creacio d'una variable random
        // llistat de prefixos per poder mostrar les respostes
        public static string[] abc =  { "a)","b)","c)","d)","e)","f)","g)","h)","i)","j)","k)","l)","m)","n)"};
        // Tematica, conte el nom i les 5 preguntes de cada tematica
        public struct Tematica
        {
            public string nom;
            public Correccio[] preguntes ;
            public Tematica(string nom, Correccio[] preguntes)
            {
                this.nom = nom;
                this.preguntes = preguntes;
               
            }
        }
        // Correccio, conte la pregunta, conte les possibles respostes, conte tambe una booleana per saber quina és la correcta
        public struct Correccio
        {
            public string pregunta;
            public string[] opcions;
            public bool[] OpcioCorrecta;
            public  Correccio(string z, string[] x, bool[] y)
            {
                this.pregunta = z;
                this.opcions = x;
                this.OpcioCorrecta = y;
            }
        }
        // Proves
        public static void Main() 
        {
            
            //StreamReader sr = new StreamReader("../../../Farming Simulator.txt");
            /*Tematica FarmingSim;/*Tematica FarmingSim;
            FarmingSim.nom = sr.ReadLine();
            FarmingSim.pregunta1 = AfegirPregunta(sr);
            sr.ReadLine();
            FarmingSim.pregunta2 = AfegirPregunta(sr);
            sr.ReadLine();
            Console.WriteLine(FerPregunta(FarmingSim.pregunta1));*/
            //Tematica tema = new Tematica(Console.ReadLine(), AfegirPregunta(), AfegirPregunta(), AfegirPregunta(),AfegirPregunta(),AfegirPregunta());

            GuardarTematica(new Tematica(Console.ReadLine(), new Correccio[] { AfegirPregunta(), AfegirPregunta(), AfegirPregunta(), AfegirPregunta(), AfegirPregunta() }));
        }
       
        public static void GuardarTematica(Tematica t)
        {
            StreamWriter sw = new StreamWriter(string.Format("../../../../Tematiques/{0}.txt", "tematiques"), true);
            sw.WriteLine(t.nom);
            sw.Close();
            sw = new StreamWriter(string.Format("../../../../Tematiques/{0}.txt", t.nom),false);
            GuardarPregunta(t.preguntes, sw);
            sw.Close();
        }
        public static void GuardarPregunta(Correccio[] preguntes, StreamWriter sw)
        {
            int idx;
            foreach (Correccio c in preguntes)
            {
                sw.WriteLine(c.pregunta);
                for (int i = 0; i < c.opcions.Length; i++)
                {
                    sw.Write(c.opcions[i]);
                    if (i != c.opcions.Length - 1)
                    {
                        sw.Write("|");
                    }
                }
                idx = 0;
                while (!c.OpcioCorrecta[idx])
                    idx++;
                sw.WriteLine("\n{0}\n", idx + 1);
            }
        }
        /// <summary>
        /// Aquesta funcio fa una pregunta, barreja les opcions i recull la resposta
        /// </summary>
        /// <param name="c">Aqui entrem la correccio de la pregunta</param>
        /// <returns>true correcte, false incorrecte</returns>
        public static bool FerPregunta(Correccio c)
        {
            
            c = RandomizeOptions(c);
            MostrarOpcions(c);
            return RecollirResposta(c);
            
        }
        /// <summary>
        /// Demana una resposta i comprova si és correcta
        /// </summary>
        /// <param name="c">Aqui entrem la correccio de la pregunta</param>
        /// <returns>true correcte, false incorrecte</returns>
        public static bool RecollirResposta(Correccio c)
        {
            bool correcte=false,fet=false;
            int tecla;
            Console.Write("Resposta: ");
            do
            {
                tecla = (int)Console.ReadKey().Key - 65;
                Console.WriteLine();
                try
                {
                    correcte = c.OpcioCorrecta[tecla];
                    opcio = c.opcions[tecla];
                    fet = true;
                }
                catch
                {
                    Console.WriteLine("Opcio incorrecta");
                }
            } while (!fet);
            
            return correcte;
        }
        /// <summary>
        /// LLegeix una pregunta i les respostes d'un arxiu BDD correctament formatat
        /// </summary>
        /// <param name="sr">StreamReader de l'arxiu BDD</param>
        /// <returns>retorna la correccio d'una pregunta</returns>
        public static Correccio AfegirPregunta(StreamReader sr)
        {
            Correccio c;
            c.pregunta = sr.ReadLine();
            c.opcions = sr.ReadLine().Split('|');
            c.OpcioCorrecta = new bool[c.opcions.Length];
            c.OpcioCorrecta[Convert.ToInt32(sr.ReadLine()) - 1] = true;
            return c;
        }
        /// <summary>
        /// Llegeix una pregunta i la seves respostes de teclat
        /// </summary>
        /// <returns>retorna la correccio d'una pregunta</returns>
        public static Correccio AfegirPregunta()
        {
            Correccio c;
            Console.WriteLine("Pregunta a guardar:");
            c.pregunta=Console.ReadLine();
            Console.WriteLine("Possibles respostes a guardar, separades per Pipe [|]:");
            c.opcions = Console.ReadLine().Split('|');
            c.OpcioCorrecta = new bool[c.opcions.Length];
            Console.WriteLine("Opcio correcta: ");
            c.OpcioCorrecta[Convert.ToInt32(Console.ReadLine()) - 1] = true;
            return c;
        }
        public static Tematica AfegirTematica()
        {
            Tematica tema;
            bool b = true;
            List<Correccio> preguntes = new List<Correccio> { };
            Console.WriteLine("Digues el nom del tema");
            tema.nom = Console.ReadLine();
            
            while (b)
            {
                preguntes.Add(AfegirPregunta());
                Console.WriteLine("Vols fer una altra pregunta? [Y/n]");
                if (Console.ReadLine().ToLower() == "n")
                    b = false;
            }
            tema.preguntes = new Correccio[preguntes.Count];
            for (int i=0; i<tema.preguntes.Length;i++)
                tema.preguntes[i] = preguntes[i];
            
            return tema;
        }
        public static Tematica AfegirTematica(string fileName)
        {
            Tematica tema;
            int idx;
            StreamReader sr = new StreamReader(string.Format("../../../../Tematiques/{0}.txt", fileName));
            List<Correccio> preguntes = new List<Correccio> { };
            tema.nom = fileName;
            
            while (sr.Peek() != -1)
            {
                preguntes.Add(AfegirPregunta(sr));
                sr.ReadLine();
            }
            tema.preguntes = new Correccio[preguntes.Count];
            idx = 0;
            while (idx < tema.preguntes.Length)
            {
                tema.preguntes[idx] = preguntes[idx];
                idx++;
            }
            
            return tema;
        }
        /// <summary>
        /// Mostra les opcions d'una pregunta, afegeix un prefix obtingut de l'array abc
        /// </summary>
        /// <param name="ss">Correccio d'on obtenir les respostes</param>
        public static void MostrarOpcions(Correccio ss)
        {
            Console.Write("Pregunta: ");
            Console.Write("{0}\n",ss.pregunta);
            for (int i = 0; i < ss.opcions.Length; i++)
            {
                Console.WriteLine("{0} {1}",abc[i],ss.opcions[i]);
                //Console.WriteLine("{0} {1}", abc[i], ss.OpcioCorrecta[i]);
            }
        }
        /// <summary>
        /// Barreja les opcions d'una correccio
        /// </summary>
        /// <param name="arr">Correccio de la qual es volen barrejar les opcions</param>
        /// <returns>Correccio amb les opcions barrejades</returns>
        public static Correccio RandomizeOptions(Correccio arr)
        {
            
            List<KeyValuePair<int, string>> list =
                new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, bool>> list2 =
                new List<KeyValuePair<int, bool>>();
            string[] result = new string[arr.opcions.Length];
            bool[] result2 = new bool[arr.OpcioCorrecta.Length];
            int index;
            for (int i=0; i<arr.opcions.Length; i++)
            {
                int x = _random.Next();

                list.Add(new KeyValuePair<int, string>(x, arr.opcions[i]));
                list2.Add(new KeyValuePair<int, bool>(x, arr.OpcioCorrecta[i]));
            }
            
            var sorted = from item in list
                         orderby item.Key
                         select item;
            var sorted2 = from item in list2
                         orderby item.Key
                         select item;
            
            index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            arr.opcions = result;
            
            index = 0;
            foreach (KeyValuePair<int, bool> pair in sorted2)
            {
                result2[index] = pair.Value;
                index++;
            }
            arr.OpcioCorrecta = result2;
            
            return arr;
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
