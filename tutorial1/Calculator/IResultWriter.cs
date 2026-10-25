namespace Calculator
{
    public interface IResultWriter // 定义一个 接口
    {
        void WriteResult(double result); //所有实现这个接口的类，都必须有一个 WriteResult(double result) 方法。
    }
}