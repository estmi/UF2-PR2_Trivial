using System;
using System.Collections.Generic;
using System.Linq;
using Programacio;
using System.IO;

namespace Esteve
{
    public class Esteve
    {
        public static Tematica FarmingSim;
        public static Tematica Dates;
        public static Tematica Mates;
        public static Random _random = new Random();
        public static string[] abc =  { "a)","b)","c)","d)","e)","f)","g)","h)","i)","j)","k)","l)","m)","n)"};
        public struct Tematica
        {
            public string nom;
            public Correccio pregunta1;
            public Correccio pregunta2;
            public Correccio pregunta3;
            public Correccio pregunta4;
            public Correccio pregunta5;
            public Tematica(string nom, Correccio c1,Correccio c2,Correccio c3,Correccio c4,Correccio c5)
            {
                this.nom = nom;
                this.pregunta1 = c1;
                this.pregunta2 = c2;
                this.pregunta3 = c3;
                this.pregunta4 = c4;
                this.pregunta5 = c5;
            }
        }
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
        public static void Main() 
        {
            StreamReader sr = new StreamReader("../../../Preguntes Farming.txt");
            FarmingSim.nom = sr.ReadLine();
            FarmingSim.pregunta1 = AfegirPregunta(sr);
            sr.ReadLine();
            FarmingSim.pregunta2 = AfegirPregunta(sr);
            sr.ReadLine();
            Console.WriteLine(FerPregunta(FarmingSim.pregunta1));
            
            

        }
        /// <summary>
        /// Aquesta funcio fa una pregunta i retorna si s'ha fet be o no
        /// </summary>
        /// <param name="c">Aqui entrem la correccio de la pregunta</param>
        /// <returns>1 punt correcte, 0 punts incorrecte</returns>
        public static bool FerPregunta(Correccio c)
        {
            
            c = RandomizeOptions(c);
            MostrarOpcions(c);
            return RecollirResposta(c);
            
        }
        public static bool RecollirResposta(Correccio c)
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
        }
        public static Correccio AfegirPregunta(StreamReader sr)
        {
            Correccio c;
            c.pregunta = sr.ReadLine();
            c.opcions = sr.ReadLine().Split('|');
            c.OpcioCorrecta = new bool[c.opcions.Length];
            c.OpcioCorrecta[Convert.ToInt32(sr.ReadLine()) - 1] = true;
            return c;
        }
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
        /// Barreja les opcions, s'ha d'entrar una Correccio i et retorna la correccio amb les opcions barrejades
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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

    }
}
