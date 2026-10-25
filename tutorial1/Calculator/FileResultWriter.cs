using System.Globalization;

namespace Calculator
{
    public class FileResultWriter : IResultWriter //FileResultWriter 实现了 IResultWriter 这个接口
    {
        private readonly string filePath;

        public FileResultWriter(string filePath) //是保存“结果要写到哪个文件”
        {
            this.filePath = filePath;

        }

        public void WriteResult(double result)
        {
            string text = result.ToString(CultureInfo.InvariantCulture) + Environment.NewLine; //invariantCulture 避免不同系统的小数格式不一样

            File.AppendAllText(filePath, text); //把内容追加写进这个文件。如果文件不存在，就创建；如果已经有内容，就继续往后加

        }
    }
}