using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器
{
    public class Primes
    {
        private long min;
        private long max;

        public Primes() : this(2, 100) // 两个参数的构造函数默认值为:2,100
        {
        }

        public Primes(long min, long max)
        {
            this.min = min;
            this.max = max;

            if (min < 2)
                this.min = 2;
            else
                this.min = min;
        }
        public IEnumerator GetEnumerator()
        {
            for(long i = min; i <= max; i++)
            {
                bool isPrime = true;
                for (long k = 2; k <= (long)Math.Floor(Math.Sqrt(i)); k++)
                {
                    long reainderAfterDivision = i % k;
                    if(reainderAfterDivision == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return i;
                }
            }
        }
    }

    public class Test02
    {
        public static void Main(string[] args)
        {
            Primes primesFrom2To1000 = new Primes(2, 1000);
            foreach(long i in primesFrom2To1000)
            {
                Console.Write($"{i} ");
            }

        }
    }
}
