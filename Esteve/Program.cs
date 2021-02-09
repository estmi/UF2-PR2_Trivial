using System;
using System.Collections.Generic;
using System.Linq;
using Programacio;

namespace Esteve
{
    public class Esteve
    {
        public static Random _random = new Random();
        public static string[] abc =  { "a)","b)","c)","d)","e)","f)","g)","h)","i)","j)","k)","l)","m)","n)"};
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
            Correccio c,c2,c3,c4,c5;
            c.pregunta = "És any de traspas?";
            c.opcions = new string[3] { "2000", "2002", "2003" };
            c.OpcioCorrecta = new bool[c.opcions.Length];
            c = CompletarCorrecio(c, "EsAnyDeTraspas");
            c2.pregunta = "Quin nombre és primer?";
            c2.opcions =new string[4] { "3", "6","8","15" };
            c2.OpcioCorrecta = new bool[c.opcions.Length];
            c = CompletarCorrecio(c, "EsAnyDeTraspas");
            c2 = CompletarCorrecio(c2, "EsPrimer");
            c = RandomizeOptions(c);
            MostrarOpcions(c);
            MostrarOpcions(c2);
            
        }
        public static Correccio CompletarCorrecio(Correccio c, string s)
        {
            if (s == "EsAnyDeTranspas")
                for (int i = 0; i < c.opcions.Length; i++)
                    c.OpcioCorrecta[i] = FuncionsStandard.EsAnyDeTraspas(Convert.ToInt32(c.opcions[i]));
            
            else if (s == "EsPrimer") 
                for (int i = 0; i < c.opcions.Length; i++)
                    c.OpcioCorrecta[i] = FuncionsStandard.EsPrimer(Convert.ToInt32(c.opcions[i]));
            return c;
        }
        public static void MostrarOpcions(Correccio ss)
        {
            Console.Write("Pregunta: ");
            Console.Write("{0}\n",ss.pregunta);
            for (int i = 0; i < ss.opcions.Length; i++)
            {
                Console.WriteLine("{0}{1}",abc[i],ss.opcions[i]);
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
