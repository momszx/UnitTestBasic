using System;
using System.Collections.Generic;

namespace ConsoleApp67
{
    // PPP
    // Best practices    - Jól bevált módszerek
    //    - Páros programozás
    //    - TDD - Test Driven Development - Teszt Vezérelt Programozás
    //       - először írj Unit Tesztet és csak utánna üzemi kód
    //       - TDD másik neve: Piros - Zöld - Piros
    //       - amikor írok egy új unit tesztet az mindig piros
    //         mert még nincs hozzá üzemi küd
    //       - megírom az üzemi kódot, de csak annyit, hogy a teszt zöld legyen
    // Design patterns   - Tervezési minták
    // Principles        - Alapelvek
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class AlmaPiac
    {
        private double almaEgységÁr;
        private List<Kedvezmény> kedvezmények = new List<Kedvezmény>();

        public void SetAlmaEgységÁr(double almaEgységÁr)
        {
            if (almaEgységÁr < 0)
                throw new IllegálisParam();
            this.almaEgységÁr = almaEgységÁr;
        }
        public double AlmaÁr(double vásároltMennyiség)
        {
            if (vásároltMennyiség < 0) throw new IllegálisParam();
            double kedvezmény = legjobbKedvezmény(vásároltMennyiség);
            return almaEgységÁr * vásároltMennyiség * (1.0 - kedvezmény);
        }

        private double legjobbKedvezmény(double súly)
        {
            double maxKedvezmény = 0.0;
            foreach(Kedvezmény k in kedvezmények)
            {
                double aktKedvezmény = k.GetKedvezmény(súly);
                if (aktKedvezmény > maxKedvezmény)
                {
                    maxKedvezmény = aktKedvezmény;
                }
            }
            return maxKedvezmény;
        }

        public void AddKedvezmény(Kedvezmény újKedvezmény)
        {
            kedvezmények.Add(újKedvezmény);
        }
    }

    public class IllegálisParam : Exception
    {
    }
    public abstract class Kedvezmény
    {
        public abstract double GetKedvezmény(double súly);
    }
    public class Legalább1SúlyKedvezmény : Kedvezmény
    {
        private double súlyHatár;
        private double kedvezmény;

        public Legalább1SúlyKedvezmény(double súlyHatár, double kedvezmény)
        {
            this.súlyHatár = súlyHatár;
            this.kedvezmény = kedvezmény;
        }
        public override double GetKedvezmény(double súly)
        {
            if (súly >= súlyHatár) return kedvezmény;
            return 0.0;
        }
    }

    public class Legalább2SúlyKedvezmény : Kedvezmény
    {
        private double súlyHatár1;
        private double kedvezmény1;
        private double súlyHatár2;
        private double kedvezmény2;

        public Legalább2SúlyKedvezmény(double súlyHatár1, double kedvezmény1, double súlyHatár2, double kedvezmény2)
        {
            this.súlyHatár1 = súlyHatár1;
            this.kedvezmény1 = kedvezmény1;
            this.súlyHatár2 = súlyHatár2;
            this.kedvezmény2 = kedvezmény2;
        }
        public override double GetKedvezmény(double súly)
        {
            if (súly >= súlyHatár2) return kedvezmény2;
            if (súly >= súlyHatár1) return kedvezmény1;
            return 0.0;
        }
    }
}
