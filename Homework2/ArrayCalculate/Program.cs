using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCalculate
{
    class Program
    {
        //获取用户输入
        private static List<int> getInput()
        {
            List<int> tempList = new List<int>();
            int tempInt;
            string tempString;
            Console.WriteLine("请输入数组元素（按q退出）：");
            tempString = Console.ReadLine();
            while (tempString != "q" && tempString != "Q")
            {
                if (Int32.TryParse(tempString, out tempInt))
                {
                    tempList.Add(tempInt);
                }
                else
                {
                    Console.WriteLine("输入错误！请重新输入：");
                }
                tempString = Console.ReadLine();
            }
            return tempList;
        }

        //返回一个整形数组分别存储数组的最大值，最小值和数组元素之和
        private static int[] dealArray(int[] nums)
        {
            int[] res;
            //分别为最大值，最小值，数组元素和
            res = new int[3];
            res[0] = nums[0];
            res[1] = nums[0];
            foreach (int num in nums)
            {
                if (num > res[0])
                {
                    res[0] = num;
                }
                if (num < res[1])
                {
                    res[1] = num;
                }

                res[2] += num;
            }
            return res;
        }

        static void Main(string[] args)
        {
            List<int> numList = getInput();
            while (!numList.Any())
            {
                //list中没有元素的话重新获取用户输入
                Console.WriteLine("输入不可为空！请重新输入！\n");
                numList = getInput();
            }

            int[] nums = numList.ToArray();
            Console.Write("该数组序列为：");
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            int[] res = dealArray(nums);
            Console.WriteLine($"该数组的最大值为：{res[0]}");
            Console.WriteLine($"该数组的最小值为：{res[1]}");
            Console.WriteLine($"该数组的平均值为：{(double)res[2] / nums.Length}");
            Console.WriteLine($"该数组元素之和为：{res[2]}");
        }
    }
}
