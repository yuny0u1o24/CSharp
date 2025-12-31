using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Test_单例模式
{
    public class Web
    {
        public static Web instance;
        public static Web Instance()
        {
            if(instance == null)
                instance = new Web();
            return instance;
        }
        private Web()
        {
        }

        
    }
}
