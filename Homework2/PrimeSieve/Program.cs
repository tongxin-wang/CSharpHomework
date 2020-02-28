using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSieve
{
    class Program
    {
        //埃拉托斯特尼筛法
        private static void sievePrime(int n)
        {
            //flag标记数组
            bool[] flag;
            flag = new bool[n + 1];
            for (int i = 0; i <= n; i++)
            {
                //flag置初值为true
                flag[i] = true;
            }

            for (int i = 2; i * i <= n; i++)
            {
                //跳过合数
                if (!flag[i])
                {
                    continue;
                }

                //从i*i开始筛选，不需考虑之前的，因为i*(i-1)之前已经被标记了
                int tmp = i * i;
                while (tmp <= n)
                {
                    flag[tmp] = false;
                    tmp += i;
                }
            }

            Console.Write($"从2到{n}的所有素数为：");
            for (int i = 2; i <= n; i++)
            {
                if (flag[i])
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("输入素数筛选范围（2~n）上限n（n >= 2）：");
            int n;
            while (!Int32.TryParse(Console.ReadLine(), out n) || n < 2)
            {
                Console.WriteLine("输入不合法！请重新输入：");
            }

            sievePrime(n);
        }
    }
}
