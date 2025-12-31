using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_List
{
    public abstract class Monster
    {
        public static List<Monster> monsters = new List<Monster>();

        public abstract void Attack();

        public Monster()
        {
            monsters.Add(this);
        }
    }

    public class Boss : Monster
    {
        public override void Attack()
        {
            Console.WriteLine("Boss释放技能");
        }

        public Boss() : base()
        {

        }
    }

    public class Gablin : Monster
    {
        public override void Attack()
        {
            Console.WriteLine("哥布林攻击");
        }

        public Gablin() : base()
        {

        }
    }

    public class Exercise
    {
        public static void Main()
        {
            Boss boss = new Boss();
            Gablin gablin = new Gablin();

            foreach (Monster monster in Monster.monsters )
            {
                monster.Attack();
            }

        }
    }
}
