using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Should.Fluent;
using NUnit.Framework;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzer(1, 100).Subscribe(Console.WriteLine);
            Console.ReadLine();
        }


        internal static IObservable<string> FizzBuzzer(int start, int stop)
        {
            return Observable.Generate(start, x => x <= stop, x =>
                                        {
                                            if (IsFizz(x) && IsBuzz(x))
                                                return "FizzBuzz";
                                            if (IsFizz(x))
                                                return "Fizz";
                                            if (IsBuzz(x))
                                                return "Buzz";
                                            return x.ToString();
                                        }, x => x + 1);
        }

        internal static bool IsFizz(int x)
        {
            return (x % 3 == 0);
        }

        internal static bool IsBuzz(int x)
        {
            return (x % 5 == 0);
        }
    }

    [TestFixture]
    class FizzBuzzTest
    {
        [TestCase(1, 1, "1")]
        [TestCase(3, 3, "Fizz")]
        [TestCase(5, 5, "Buzz")]
        [TestCase(15, 15, "FizzBuzz")]
        public void FizzBuzzAlgoShouldNotFail(int from, int to, string result)
        {
            Program.FizzBuzzer(from, to).Subscribe(x => x.Should().Equal(result));
        }
    }
}
