using System;

namespace Shape
{
    public class ShapeFactory
    {
        //使用随机数生成形状中长宽高，边长等属性
        private Random rand;

        public ShapeFactory()
        {
            rand = new Random();
        }

        //根据shape类型返回不同的形状
        public Shape GetShape(string shapeType)
        {
            if(shapeType == null)
            {
                return null;
            }

            if(shapeType.Equals("RECTANGLE",StringComparison.OrdinalIgnoreCase))
            {
                return new Rectangle(rand.Next(21), rand.Next(21));
            }
            else if(shapeType.Equals("SQUARE", StringComparison.OrdinalIgnoreCase))
            {
                return new Square(rand.Next(21));
            }
            else if(shapeType.Equals("TRIANGLE", StringComparison.OrdinalIgnoreCase))
            {
                return new Triangle(rand.Next(21), rand.Next(21), rand.Next(21));
            }

            return null;
        }
    }
}
