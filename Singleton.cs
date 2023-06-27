using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISTest
{
    internal class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
    new Lazy<Singleton>(() => new Singleton());

        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            return lazy.Value;
        }

        public int DoCalculation(int value)
        {
            if (value >= Convert.ToInt32(Math.Sqrt(int.MaxValue)))
                throw new ArgumentException($"Value is too large: {value}/{Convert.ToInt32(Math.Sqrt(int.MaxValue))-1}");
            System.Threading.Thread.Sleep(1000);
            return Convert.ToInt32(Math.Pow(value, 2));
        }
    }
}
