namespace Calculator
{
    public class Calculator
    {

        private readonly IResultWriter resultWriter;

        public Calculator(IResultWriter resultWriter)
        {
            this.resultWriter = resultWriter;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;

            resultWriter.WriteResult(result); // 把结果写出去

            return result; //写出去后再返回 result

        }

        public double Divide(double a, double b)
        {
            double result;

            if(b == 0)
            {
                result = double.NaN;
            }
            else
            {
                result = a / b;

            }

            resultWriter.WriteResult(result);

            return result;
        }

    }
}