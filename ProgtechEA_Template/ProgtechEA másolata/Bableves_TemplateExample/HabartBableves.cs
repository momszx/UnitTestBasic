using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bableves_TemplateExample
{
    class HabartBableves : Bableves
    {
        protected override void Elokeszit()
        {
            Console.WriteLine("Beáztatom a tarkababot.");
        }

        protected override void Talal()
        {
            Console.WriteLine("Kenyérrel és tejföllel tálalom.");
        }

        protected override void Izesit()
        {
            Console.WriteLine("Behabarom, sóval ízesítem.");
        }
    }
}
