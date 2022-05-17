using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bableves_TemplateExample
{
    class Babgulyas : Bableves
    {
        protected override void Elokeszit()
        {
            Console.WriteLine("Felvágom a zöldséget és a húst.");
        }

        protected override void Talal()
        {
            Console.WriteLine("Tarhonyával tálalom.");
        }

        protected override void Izesit()
        {
            Console.WriteLine("Pirospaprikával és sóval ízesítem.");
        }
    }
}
