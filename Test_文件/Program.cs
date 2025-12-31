using System;
using System.IO;

namespace Test_文件
{
    public class Program
    {
        public static void Main()
        {
            // FileInfo详解
            string fileName = "text.txt";
            // 
            FileStream aFile = new FileStream(fileName, FileMode.Open,FileAccess.Read);


        }
    }
}