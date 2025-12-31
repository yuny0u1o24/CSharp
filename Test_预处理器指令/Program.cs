// 
#define Unity4
#define Unity5
#define Unity2017
#define Unity2019
// 取消定义一个符号
#undef Unity4

namespace Test_预处理器指令
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.什么是编译器
            // 编译器是一种翻译程序
            // 它用于将源语言程序翻译为目标语言程序

            // 源语言程序: 某种程序设计语言写成的, 比如: C#、C/C++、Java等语言写的程序
            // 目标语言程序: 二进制数表示的伪机器代码写的程序
            #endregion

            #region 2.什么是预处理器指令
            // 预处理器指令 指导编译器 在实际变异开始之前对信息进行预处理
            // 预处理器指令 都是以#开始
            // 预处理器指令不是语句，所以它们不以分号`;`结束
            // 目前我们经常用到的 折叠代码块就是预处理器指令
            #endregion

            #region 3.常见的预处理器指令
            // 1
            // #define
            // 定义一个符号，类似一个没有值的变量
            // #undef
            // 取消define定义的符号, 让其失效
            // 两者都是写在脚本文件最前面
            // 一般配合 if指令使用 或配合特性

            // 2
            // #if
            // #elif
            // #else
            // #endif
            // 和if语句规则一样，一般配合#define定义的符号使用
            // 用于高速编译器进行编译代码的流程控制

            // 3
            // #warning
            // #error

            #endregion
        }
    }
}
