using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    abstract public class Shape
    {
        abstract public double AreaCalculate();
    }

    public interface IsLegal
    {
        bool IsShapeLegal();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape;
            ShapeFactory shapeFactory = new ShapeFactory();
            string[] shapes = { "RECTANGLE", "SQUARE", "TRIANGLE" };
            Random rand = new Random();
            double totalArea = 0;   //有效的总面积
            double tempArea;

            for(int i = 0; i < 10; i++)
            {
                shape = shapeFactory.GetShape(shapes[rand.Next(3)]);
                tempArea = shape.AreaCalculate();
                if(tempArea != -1)
                {
                    totalArea += tempArea;
                }
                Console.WriteLine(shape.ToString());
            }

            Console.WriteLine("The total area of the legal shapes above are " + totalArea);
        }
    }
}
