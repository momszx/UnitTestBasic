using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bableves_TemplateExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bableves babgulyas = new Babgulyas(); //GOF1!!! A legősibbet kell választani
            babgulyas.Elkeszit();

            Bableves habartBableves = new HabartBableves();
            habartBableves.Elkeszit();
            Console.ReadKey();
        }
    }
}
