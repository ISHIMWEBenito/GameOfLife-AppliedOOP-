using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime;
namespace Conway
{
 
    internal class Game
    {
        static void Main(string[] args)
        {
            printing();
            double density;
            Console.Write("Enter the population density(%): ");
            density = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Which character do you want to use as an Alive cell: ");
            string a=Console.ReadLine();   
                Console.WriteLine();
           
                Generation gen = new Generation(20, 20, density);
            //  gen.one();
            gen = new Generation(gen,a);
            const int FPS = 10;
   
            for (int c = 0; c < 100; c++)
                   {
            //    gen.check(c);
                Thread.Sleep(1000 / FPS);
                /* if (gen.check(c) == 1)
                 {
                     break;
                 }
                */
                Console.Clear();
                Console.WriteLine(gen);
                gen.step();
                if (gen.AliveCellsinBoard() <= 0)
                {
                    break;
                }

              
            }
      //    Generation generation1 = new Generation(gen, a);
            //Console.WriteLine( generation1.ToString());

            string path = @"Game.txt";
            if (File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(gen.ToString());
                    sw.WriteLine("Alive Cells: "+gen.AliveCellsinBoard());
                    sw.Close();
                    
                }
            }
            string d;
                Console.WriteLine("Do you want to read the board from the file:");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Yes(y) or No(n)");
           d= Console.ReadLine();
            if (d == "y")
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else
            {
                Console.Clear();
            }



         

        }
        public static void printing()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string intro = @"  ᴡᴇʟᴄᴏᴍᴇ░ᴛᴏ░ᴄᴏɴᴡᴀʏ's░ɢᴀᴍᴇ░ᴏғ ░ ʟɪғᴇ";
            Console.WriteLine("\t \t \t \t \t" + intro);
            Console.WriteLine();
        }
    }
}
