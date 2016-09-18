using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_dispatcher
{
    class Program
    {
        static void Main(string[] args)
        {


            String strConsolIn = "";
            string strConsolOut = "";

            //string strarg;
            Console.WriteLine("Start program, Vers. 1.2");
            Console.WriteLine("Аргументы:");

            foreach (string strarg in args)
            {
                //strConsolOut.Contains(" " + strarg);
                Console.WriteLine(strarg);
            }

            Console.WriteLine("Инициализация...");

            Console.WriteLine("Start");


            while (!strConsolIn.Equals("exit"))
            {

                strConsolIn = Console.ReadLine().ToLower();

                if (strConsolIn.Equals("exit"))
                    Console.WriteLine("OK");
                else {

                    string[] strcom = strConsolIn.Split(' ');

                    if (strcom[0].Equals("status")) {


                        Console.WriteLine("");
                    
                    }

                    if (strcom[0].Equals("help"))
                    {
                        Console.WriteLine("'status' 'name algoritm'");
                        Console.WriteLine("name algoritm: kanal, kanal5, fromextr, test, tramp");
                        Console.WriteLine("");
                    }
                
                
                
                }

                

            }

            //objGen.Stop();
            Console.ReadKey();

        }
    }
}
