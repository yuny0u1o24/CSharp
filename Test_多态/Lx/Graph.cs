using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_多态.Lx
{
    public class Graph
    {
        protected float s;
        protected float c;
        public Graph(float s, float c)
        {
            this.s = s;
            this.c = c;
        }

        /// <summary>
        /// 面积
        /// </summary>
        /// <returns></returns>
        public virtual float S()
        {
            return s * c;
        }
        /// <summary>
        /// 周长
        /// </summary>
        /// <returns></returns>
        public virtual float C()
        {
            return c * 4;
        }
    }

    public class Rectangle : Graph
    {
        public Rectangle(float s, float c) : base(s, c)
        { 
            
        }

        public override float S()
        {
            return base.S();
        }

        public override float C()
        {
            return base.C();
        }

    }

    public class Square : Graph
    {
        public Square(float s, float c) : base(s, c)
        {

        }

        public override float S()
        {
            return base.S();
        }

        public override float C()
        {
            return base.C();
        }

    }

    public class Roundness : Graph
    {
        public Roundness(float s, float c) : base(s, c)
        {

        }

        public override float S()
        {
            return 2 * s * 3.14169f;
        }

        public override float C()
        {
            return (3.14169f * s) * (3.14169f * s);
        }

    }
}
