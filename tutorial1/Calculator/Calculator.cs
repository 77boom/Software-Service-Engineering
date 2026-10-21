namespace Calculator
{
    public class Calculator
    {
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if(b == 0)
            {
                return double.NaN;
            }

            return a / b;
        }

    }
}