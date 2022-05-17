using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bableves_TemplateExample
{
    internal abstract class Bableves
    {
        /*
         * A receptben vannak opcionális és kötelező lépések.
         * A kötelező lépések között van közös/nem közös
         * 
         * Kötelező közös: Már az ősben kifejtjük
         * Kötelező nem közös: Gyermekosztályokra bízzuk, az ősben absztraktok.
         * Opcionális: Hook metódusok
         */
        //Template methodban csak egy public metódus van. Ez fixálja a lépések sorozatát.
        public void Elkeszit()
        {
            Elokeszit(); //Kötelező, nem közös. Gulyásleves/tarkabableves: bab beáztatása
            //Ez egy IoC.

            Foz(); //Kötelező, közös
            CukorBele(); //Opcionális. Ez is IoC.
            Izesit(); //Opcionális. Ez is IoC.
            Talal(); //Kötelező, nem közös Ez is IoC.

            /*
             * Akkor van IoC, ha az ős olyan metódust hív, ami benne
             * abstract, vagy hook. Ezeknek a kifejtése a gyermekosztály
             * feladata.
             * Konkrétan: A gyermekosztály ezt kifejti és késői
             * kötés miatt a gyermekben lévő kód fut le.
             */
        }

        protected virtual void CukorBele()
        {
        }

        /*
         * Control megfordítása: Inversion of Control (IoC):
         * Nem a gyermek hívja az ős metódusát, hanem az ős hívja a
         * gyermek metódusait.
         * 
         * OOP-ban természetes, hogy a gyermek hívhatja az ős metódusát.
         * Azokat megörökli.
         * 
         * Ez veszélyes, mert ha az ős megváltozik, akkor a gyermeknek is
         * valószínű meg kell változnia.
         * Ez az implementációs függőség.
         * 
         * Megfordítása: Ős hívja a gyermeket. Ez biztonságosabb.
         * 
         * Az IoC segítségével érem el, hogy a gyermekre hagyom a részletek
         * kidolgozását.
         */

        protected abstract void Talal();
        

        protected virtual void Izesit() //Ha nem void, akkor return null
        {
        }

        //A ToString hook metódust?

        private void Foz()
        {
            Console.WriteLine("Megfőzöm a levest.");
        }

        protected abstract void Elokeszit();
    }
}
