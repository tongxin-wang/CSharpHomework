using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactor
{
    class Program
    {
        private static void parsePrimeFactor(int num)
        {
            Console.Write("该数的所有素数因子为：");
            for (int i = 2; i <= num;)
            {
                if (num % i == 0)
                {
                    Console.Write(i + " ");
                    num /= i;
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int num;

            Console.WriteLine("请输入你想解析的数字：");
            while (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("输入错误！请重新输入：");
            }

            parsePrimeFactor(num);
        }
    }
}
