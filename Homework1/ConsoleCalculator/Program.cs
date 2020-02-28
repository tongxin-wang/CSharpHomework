using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            double num1;
            double num2;
            char op;
            double res;

            //输入错误时重新输入，下同
            Console.WriteLine("请输入第一个数字:");
            while (!Double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("输入错误！请重新输入:");
            }

            Console.WriteLine("请输入第二个数字:");
            while (!Double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("输入错误！请重新输入:");
            }

            Console.WriteLine("请输入运算符:");
            input = Console.ReadLine();
            op = input[0];
            while (!(op == '+' || op == '_' || op == '*' || op == '/'))
            {
                Console.WriteLine("输入错误！请重新输入:");
                input = Console.ReadLine();
                op = input[0];
            }

            switch (op)
            {
                case '+':
                    res = num1 + num2;
                    break;
                case '-':
                    res = num1 - num2;
                    break;
                case '*':
                    res = num1 * num2;
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("被除数不能为零！");
                        return;
                    }
                    res = num1 / num2;
                    break;
                default:
                    return;
            }

            Console.WriteLine($"运算结果为: {res}");
        }
    }
}