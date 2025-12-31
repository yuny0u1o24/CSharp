using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Test_事件_Lx
{
    class Heater
    {
        public event Action<int> myEvent; // 当要绑定的函数有参数无返回时，使用泛型代表它的参数类型

        private int value = 0;
        public void AddHot()
        {
            int updateIndex = 0;
            while (true)
            {
                if(updateIndex % 9999999 == 0)
                {
                    ++value;
                    Console.WriteLine($"{value}");
                    if(value >= 95)
                    {
                        if(myEvent != null)
                        {
                            myEvent.Invoke(value); // 或者 myEvent(value)调用
                            return;
                        }
                    }
                    updateIndex = 0;
                }

                updateIndex++;
            }
        }
    }

    class Alarm
    {
        public void ShowInfo(int v)
        {
            Console.WriteLine($"当前水温{v}度");
        }
    }

    class Display
    {
        public void ShowInfo(int v)
        {
            Console.WriteLine("水已经烧开");
        }
    }


    /// <summary>
    /// 有一个热水器，包含一个加热器，一个报警器，一个显示器
    /// 我们给热水器通上电，当水温超过95度时
    /// 1.报警器会开始发出语音，告诉水温
    /// 2.显示器也会改变水温提示，提示水已经烧开了
    /// </summary
    public class Test
    {
        static void Main(string[] args)
        {
            Heater h = new Heater();
            Alarm alarm = new Alarm();  
            Display display = new Display();
            h.myEvent += alarm.ShowInfo;
            h.myEvent += display.ShowInfo;

            h.AddHot(); // 加热
        }
    }
}
