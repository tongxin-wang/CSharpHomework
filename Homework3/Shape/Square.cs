namespace Shape
{
    public class Square : Shape, IsLegal
    {
        public double SideLength { get; set; }
        public double Area { get; private set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public bool IsShapeLegal()
        {
            if(SideLength > 0)
            {
                return true;
            }

            return false;
        }


        override public double AreaCalculate()
        {
            if(IsShapeLegal())
            {
                return Area = SideLength * SideLength;
            }

            return Area = -1;
        }

        public override string ToString()
        {
            if(Area != -1)
            {
                return "Square(Legal  SideLength = " + SideLength + " Area = " + Area + ")";
            }

            return "Square(Illegal  SideLength = " + SideLength + ")";
        }
    }
}
