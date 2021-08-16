using System;

namespace LiskovSolidPrinciple
{
    internal class Program
    {
        private static void Main()
        {
            Automobile laMiaAuto = new Audi(100);
            
            Console.WriteLine(DatiAuto(laMiaAuto));
            
            laMiaAuto = new Mercedes(200);

            Console.WriteLine(DatiAuto(laMiaAuto));
        }

        /// <summary>
        /// Restituisce le caratteristiche dell'auto
        /// </summary>
        /// <param name="autoMobile"></param>
        /// <returns>stringa formattata</returns>
        private static string DatiAuto(Automobile autoMobile)
        {
            var descrizione = "La mia {0} ha {1} HP di potenza, che corrispondono a {2} cavalli.";
            return string.Format(descrizione, autoMobile.Marca(), autoMobile.HP(), autoMobile.Cavalli());
        }

        /// <summary>
        /// Classe di base
        /// </summary>
        public abstract class Automobile
        {
            protected readonly int _cavalli;
            protected Automobile(int cavalli)
            {
                _cavalli = cavalli;
            }

            public int Cavalli() => _cavalli;

            public double HP()
            {
                return _cavalli * 0.98631;
            }

            public abstract string Marca();

        }

        /// <summary>
        /// Classe derivata, quella definita come "S" nell'enunciato.
        /// Questa classe erediterà i metodi base e dovrà implementare i metodi astratti.
        /// </summary>
        public class Audi : Automobile
        {
            public Audi(int cavalli) : base(cavalli)
            {

            }
            public override string Marca() => "Audi";
        }

        /// <summary>
        /// Ulteriore classe derivata.
        /// Questa è la classe che possiamo sostituire
        /// se il Liskov Principle è rispettato.
        /// </summary>
        public class Mercedes : Automobile
        {
            public Mercedes(int cavalli) : base(cavalli)
            {

            }

            public override string Marca() => "Mercedes";
        }
	}
}
