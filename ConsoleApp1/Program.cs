using System;

namespace Programacio
{
    public class FuncionsStandard
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                MostrarMenu();
                tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        DoAnyTraspas();
                        break;
                    case ConsoleKey.D2:
                        DoMCD();
                        break;
                    case ConsoleKey.D3:
                        DoMCM();
                        break;
                    case ConsoleKey.D4:
                        DoLlegirMostrarDataValida();
                        break;
                    case ConsoleKey.D5:
                        DoEsParell();
                        break;
                    case ConsoleKey.D6:
                        DoPrimer();
                        break;
                    case ConsoleKey.D7:
                        DoNPrimersPrimers();
                        break;
                    case ConsoleKey.D8:
                        DoQuiEsMesJove();
                        break;
                    case ConsoleKey.D0:
                        MsgNextScreen("PRESS ANY KEY 2 EXIT");

                        break;
                    default:
                        MsgNextScreen("Error. Prem una tecla per tornar al menú...");
                        break;
                }

            } while (tecla.Key != ConsoleKey.D0);
        }

        /// <summary>
        /// Text que es mostra al menu d'inici
        /// </summary>
        public static void MostrarMenu()
        {
            Console.WriteLine("1- ANY DE TRASPAS");
            Console.WriteLine("2- CALCULAR MCD");
            Console.WriteLine("3- CALCULAR MCM");
            Console.WriteLine("4- VALIDAR DATA");
            Console.WriteLine("5- ES PARELL");
            Console.WriteLine("6- NOMBRE PRIMER");
            Console.WriteLine("7- N PRIMERS");
            Console.WriteLine("8- QUI ES MES JOVE");
            Console.WriteLine("0- EXIT");
        }

        /// <summary>
        /// Comprova si un any és de Traspas
        /// </summary>
        public static void DoAnyTraspas()
        {
            int anyIn = EntrarEnterPositiu("Introdueix l'any: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");

            if (AnyTraspas(anyIn)) Console.WriteLine("L'any {0} és de traspàs", anyIn);
            else Console.WriteLine("L'any {0} NO és de traspàs", anyIn);

            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Calcula el MCD després de demanar-te dos valors enters positius.
        /// </summary>
        public static void DoMCD()
        {
            int valorA, valorB, resultatMCD;

            valorA = EntrarEnterPositiu("Introdueix el primer nombre enter positiu: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");
            valorB = EntrarEnterPositiu("Introdueix el segon nombre enter positiu: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");

            resultatMCD = MCD(valorA, valorB);

            Console.WriteLine("El Màxim Comú Divisor entre {0} i {1} és -> {2}", valorA, valorB, resultatMCD);
            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Calcula el MCM després de demanar-te dos valors enters positius.
        /// </summary>
        public static void DoMCM()
        {
            int valorA, valorB, resultatMCM;

            valorA = EntrarEnterPositiu("Introdueix el primer nombre enter positiu: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");
            valorB = EntrarEnterPositiu("Introdueix el segon nombre enter positiu: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");

            resultatMCM = MCM(valorA, valorB);

            Console.WriteLine("El Màxim Comú Múltiple entre {0} i {1} és -> {2}", valorA, valorB, resultatMCM);
            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Demana una data en format ddmmaaaa i la mostra en dd/mm/aaaa
        /// </summary>
        public static void DoLlegirMostrarDataValida()
        {
            int dataIn = EntrarData();
            Console.WriteLine("{0:00}/{1:00}/{2}", Dia(dataIn), Mes(dataIn), Any(dataIn));

            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Comprova si un nombre és parell
        /// </summary>
        public static void DoEsParell()
        {
            int valorIn = EntrarEnterPositiu("Introdueix un nombre enter positiu: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");

            if (EsParell(valorIn)) Console.WriteLine("El valor {0} és parell", valorIn);
            else Console.WriteLine("El valor {0} NO és parell", valorIn);

            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Comprova si un valor és primer a partir d'un nombre positiu
        /// </summary>
        public static void DoPrimer()
        {
            int valor = EntrarEnterPositiu("Introdueix un nombre enter positiu: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");

            if (EsPrimer(valor)) Console.WriteLine("El nombre {0} és Primer", valor);
            else Console.WriteLine("El nombre {0} NO és Primer", valor);

            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Genera una quantitat de nombres primers igual al nombre netat per teclat
        /// </summary>
        public static void DoNPrimersPrimers()
        {
            int quantitatNPrimers, nPrimersTrobats = 0, valor = 0;

            quantitatNPrimers = EntrarEnterPositiu("Introdueix la quantitat de nombres primers que vols generar: ", "Nombre entrat incorrecte. Ha de ser un Nombre enter positiu: ");

            while (nPrimersTrobats != quantitatNPrimers)
            {
                if (EsPrimer(valor))
                {
                    Console.WriteLine(valor);
                    nPrimersTrobats++;
                }
                valor++;
            }

            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Comprova qui és més jove introduint dos dates de naixement
        /// </summary>
        public static void DoQuiEsMesJove()
        {
            int data1, data2;

            data1 = EntrarData();
            data2 = EntrarData();

            if (data1 == data2) Console.WriteLine("Els dos van neixer al mateix dia");
            else
            {
                if (PrimerMesJove(data1, data2)) Console.WriteLine("La primera persona és més jove que la segona");
                else Console.WriteLine("La primera persona és més gran que la segona");
            }
            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
        }

        /// <summary>
        /// Demana que entris un nombre enter positiu. En cas de no fer-ho te'l torna a demanar.
        /// </summary>
        /// <param name="msg">Missatge per defecte</param>
        /// <param name="msgError">Missatge en cas d'entrada incorrecte</param>
        /// <returns></returns>
        public static int EntrarEnterPositiu(string msg, string msgError)
        {
            int entrada = 0;
            Console.Write(msg);

            while (entrada <= 0)
            {

                entrada = Convert.ToInt32(Console.ReadLine());
                if (entrada <= 0) Console.Write(msgError);
            }
            return entrada;
        }

        /// <summary>
        /// Comprova que una data sigui valida
        /// </summary>
        /// <returns></returns>
        public static int EntrarData()
        {
            int data;
            bool dataValida;
            Console.WriteLine("Entra una data en format ddmmaaaa:");
            data = Convert.ToInt32(Console.ReadLine());
            dataValida = ValidarData(Dia(data), Mes(data), Any(data));
            while (!dataValida)
            {
                Console.WriteLine("Data entrada incorrecta.Ha de ser en format ddmmaaaa: ");
                data = Convert.ToInt32(Console.ReadLine());
                dataValida = ValidarData(Dia(data), Mes(data), Any(data));
            }
            return data;
        }

        /// <summary>
        /// Mostra un missatge i espera que premis una tecla per continuar
        /// </summary>
        /// <param name="msg"></param>
        public static void MsgNextScreen(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Comprova si un any és de traspàs
        /// </summary>
        /// <param name="any">Any</param>
        /// <returns></returns>
        public static bool AnyTraspas(int any)
        {
            return any % 4 == 0 && any % 100 != 0 || any % 400 == 0;
        }

        /// <summary>
        /// Calcula el MCD a partir de dos nombres enters
        /// </summary>
        /// <param name="n">Valor 1</param>
        /// <param name="m">Valor 2</param>
        /// <returns></returns>
        public static int MCD(int n, int m)
        {
            int dividend = 0, divisor = 1, residu = 0;

            if (n < m)
            {
                divisor = n;
                dividend = m;
            }
            else
            {
                divisor = m;
                dividend = n;
            }

            while (dividend % divisor != 0)
            {
                residu = dividend % divisor;
                dividend = divisor;
                divisor = residu;
            }

            return divisor;
        }

        /// <summary>
        /// Calcula el MCM a partir de dos nombres enters
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int MCM(int n, int m)
        {
            return n * m / MCD(n, m);
        }

        /// <summary>
        /// Valida una data a partir del dia, mes i any. Cal que l'any sigui igual o superior a 1900.
        /// </summary>
        /// <param name="dia">Dia</param>
        /// <param name="mes">Mes</param>
        /// <param name="any">Any (Igual o superior a 1900)</param>
        /// <returns></returns>
        public static bool ValidarData(int dia, int mes, int any)
        {
            bool dataValida = false;
            if (any >= 1900 && dia > 0)
            {
                if (mes >= 1 && mes <= 12)
                {
                    switch (mes)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            if (dia <= 31) dataValida = true;
                            break;
                        case 2:
                            if (AnyTraspas(any))
                            {
                                if (dia <= 29) dataValida = true;

                            }
                            else
                            {
                                if (dia <= 28) dataValida = true;
                            }
                            break;
                        default:
                            if (dia <= 30) dataValida = true;
                            break;
                    }
                }
            }
            return dataValida;
        }

        /// <summary>
        /// Retorna el Dia d'una data entrada en format ddmmaaaa
        /// </summary>
        /// <param name="data">Data en format ddmmaaaa</param>
        /// <returns></returns>
        public static int Dia(int data)
        {
            return data / 1000000;
        }

        /// <summary>
        /// Retorna el Mes d'una data entrada en format ddmmaaaa
        /// </summary>
        /// <param name="data">Data en format ddmmaaaa</param>
        /// <returns></returns>
        public static int Mes(int data)
        {
            return data / 10000 % 100;
        }

        /// <summary>
        /// Retorna l'Any d'una data entrada en format ddmmaaaa
        /// </summary>
        /// <param name="data">Data en format ddmmaaaa</param>
        /// <returns></returns>
        public static int Any(int data)
        {
            return data % 10000;
        }

        /// <summary>
        /// Comprova si un nombre és primer i et retorna true o false
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool EsPrimer(int n)
        {
            bool esPrimer = true;
            int arrelValor, divisor = 2;

            if (n > 1)
            {
                arrelValor = (int)Math.Sqrt(n);

                while (esPrimer && divisor <= arrelValor)
                {
                    if (n % divisor == 0) esPrimer = false;
                    divisor++;
                }
            }
            else esPrimer = false;

            return esPrimer;

        }

        /// <summary>
        /// Comprova si un nombre és parell
        /// </summary>
        /// <param name="valor">Valor enter superior a 0</param>
        /// <returns></returns>
        public static bool EsParell(int valor)
        {
            return valor % 2 == 0;
        }

        /// <summary>
        /// Comprova si la primera data és major que la segona (1a persona més jove que la segona)
        /// </summary>
        /// <param name="data1">Data naixement 1a persona</param>
        /// <param name="data2">Data naixement 2a persona</param>
        /// <returns></returns>
        public static bool PrimerMesJove(int data1, int data2)
        {
            bool primeraDataMesGran;
            if (Any(data1) > Any(data2))
            {
                primeraDataMesGran = true;
            }
            else if (Any(data1) < Any(data2))
            {
                primeraDataMesGran = false;
            }
            else
            {
                if (Mes(data1) > Mes(data2))
                {
                    primeraDataMesGran = true;
                }
                else if (Mes(data1) < Mes(data2))
                {
                    primeraDataMesGran = false;
                }
                else
                {
                    if (Dia(data1) > Dia(data2))
                    {
                        primeraDataMesGran = true;
                    }
                    else
                    {
                        primeraDataMesGran = false;
                    }
                }
            }
            return primeraDataMesGran;

        }
    }
}
