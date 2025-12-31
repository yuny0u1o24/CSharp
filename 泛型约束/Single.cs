using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_泛型约束
{
    #region 单例模式
    // 用泛型实现一个单例模式基类
    class SingleBase<T> where T : new()
    {
        private static T instance = new T();

        public static T Instance
        {
            get
            {
                return instance;
            }
        }
    }


    class GameMgr : SingleBase<GameMgr>
    {
        public void hhh()
        {
            Console.WriteLine("hhh");
        }
    }

    class Test
    {
        private static Test instance;

        private Test()
        {

        }

        public static Test Instance
        {
            get { return instance; }
        }
    }
    #endregion

    /// <summary>
    /// 练习1.单例模式
    /// </summary>
    public class Single
    {
        public void Show()
        {
            SingleBase<GameMgr>.Instance.hhh();
        }
    }
}
