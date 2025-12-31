using System;
using System.Security.Policy;
namespace Test_基础实践_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.初始化控制台
            int w = 50;
            int h = 30;
            ConsoleInit(w, h);
            E_SceneType nowSceneType = E_SceneType.Begin;
            // 游戏主循环
            while (true)
            {
                // 3. 场景选择相关逻辑
                switch (nowSceneType)
                {
                    case E_SceneType.Begin:
                        // 开始场景逻辑
                        BeginScene(w, h, ref nowSceneType);
                        Console.Clear();
                        break;
                    case E_SceneType.Game:
                        // 游戏场景逻辑
                        GameScene(w, h, ref nowSceneType);
                        Console.Clear();
                        break;
                    case E_SceneType.End:
                        EndScene(w, h, ref nowSceneType);
                        Console.Clear();
                        break;
                }
            }
        }
        // 1.初始化控制台
        static void ConsoleInit(int w, int h)
        {
            // 基础设置
            // 隐藏光标
            Console.CursorVisible = false;
            // 舞台大小
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
        }
        // 2.场景选择相关
        enum E_SceneType
        {
            Begin,
            Game,
            End
        }


        // 3.开始场景逻辑
        static void BeginScene(int w, int h, ref E_SceneType e_Scene)
        {
            // 标题, 固定不变的
            Console.SetCursorPosition(w / 2 - 3, 8);
            Console.Write("飞行棋");
            int i = 0;
            bool isQuitBegin = false;
            while (true)
            {
                isQuitBegin = false;
                Console.SetCursorPosition(w / 2 - 3, 12);
                Console.ForegroundColor = i == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("开始游戏");
                Console.SetCursorPosition(w / 2 - 3, 14);
                Console.ForegroundColor = i == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("结束游戏");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        i--;
                        if (i < 0)
                        {
                            i = 0;
                        }
                        break;
                    case ConsoleKey.S:
                        i++;
                        if (i > 1)
                        {
                            i = 1;
                        }
                        break;

                    case ConsoleKey.J:
                        // 处理 'j' 或 'J' 按键的逻辑
                        if (i == 0)
                        {
                            e_Scene = E_SceneType.Game;
                            isQuitBegin = true;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isQuitBegin)
                {
                    break;
                }
            }
        }

        // 4.游戏界面
        static void GameScene(int w, int h, ref E_SceneType nowSceneType)
        {
            // 绘制不变的基本信息
            DrawWall(w, h);
            // 绘制地图
            Map map = new Map(14, 3, 81);
            map.Draw();
            // 绘制玩家
            Player player = new Player(0,E_PlayerType.Player);
            Player computer = new Player(0, E_PlayerType.Computer);
            DrawPlayer(player,computer,map);

            bool isGameOver = false;
            // 游戏场景循环
            while (true)
            {
                // 监测输入
                Console.ReadKey(true);
                // 扔色子逻辑
                isGameOver = RandomMove(w, h, ref player, ref computer, map);
                // 绘制地图
                map.Draw();
                // 绘制玩家
                DrawPlayer(player, computer, map);
                // 判断是否到达终点
                if (isGameOver)
                {
                    Console.ReadKey(true);
                    nowSceneType = E_SceneType.End;
                    break;
                }

                // 电脑扔色子逻辑
                // 监测输入
                Console.ReadKey(true);
                // 扔色子逻辑
                isGameOver = RandomMove(w, h, ref computer, ref player, map);
                // 绘制地图
                map.Draw();
                // 绘制玩家
                DrawPlayer(computer, player, map);
                // 判断是否到达终点
                if (isGameOver)
                {
                    Console.ReadKey(true);
                    nowSceneType = E_SceneType.End;
                    break;
                }
            }
        }

        // 9. jie shu chang jing
        static void EndScene(int w, int h, ref E_SceneType e_Scene)
        {
            // 标题, 固定不变的
            Console.SetCursorPosition(w / 2 - 3, 8);
            Console.Write("飞行棋");
            int i = 0;
            bool isQuitBegin = false;
            while (true)
            {
                isQuitBegin = false;
                Console.SetCursorPosition(w / 2 - 3, 12);
                Console.ForegroundColor = i == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("回到标题界面");
                Console.SetCursorPosition(w / 2 - 3, 14);
                Console.ForegroundColor = i == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("退出游戏");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        i--;
                        if (i < 0)
                        {
                            i = 0;
                        }
                        break;
                    case ConsoleKey.S:
                        i++;
                        if (i > 1)
                        {
                            i = 1;
                        }
                        break;

                    case ConsoleKey.J:
                        // 处理 'j' 或 'J' 按键的逻辑
                        if (i == 0)
                        {
                            e_Scene = E_SceneType.Begin;
                            isQuitBegin = true;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isQuitBegin)
                {
                    break;
                }
            }
        }

        // 8.扔色子a

        // 擦除提示的函数
        static void ClearInfo(int h)
        {
            Console.SetCursorPosition(2, h - 6);
            Console.Write("                                ");
            Console.SetCursorPosition(2, h - 5);
            Console.Write("                                ");
            Console.SetCursorPosition(2, h - 4);
            Console.Write("                                ");
            Console.SetCursorPosition(2, h - 3);
            Console.Write("                                ");
        }

        /// <summary>
        /// 扔色子
        /// </summary>
        /// <param name="w">窗口的宽</param>
        /// <param name="h">窗口的高</param>
        /// <param name="p">玩家/电脑谁扔色子</param>
        /// <param name="map">地图信息</param>
        /// <returns>默认返回false代表没有结束</returns>
        static bool RandomMove(int w, int h, ref Player p, ref Player otherP, Map map)
        {
            // 擦除之前显示的提示信息
            ClearInfo(h);
            Console.ForegroundColor = p.type == E_PlayerType.Player ? ConsoleColor.Blue : ConsoleColor.DarkRed;
            

            // 扔色子之前判断玩家是否处于暂停状态
            if (p.isPause)
            {
                Console.SetCursorPosition(2, h - 5);
                Console.Write("处于暂停点，{0}需要暂停一回合", p.type == E_PlayerType.Player ? "玩家" : "电脑");
                // 停止暂停
                p.isPause = false;
                return false;
            }

            // 扔色子目的 是改变玩家或者电脑的位置，计算位置的变化
            // 扔色子随机一个1到6的数加上去
            Random r = new Random();
            int randomNum = r.Next(1, 7);
            p.nowIndex += randomNum;

            // 打印扔的色子点数
            Console.SetCursorPosition(1, h - 6);
            Console.Write("{0}扔的点数是:{1}", p.type == E_PlayerType.Player ? "玩家" : "电脑", randomNum);

            // 判断是否到终点
            if(p.nowIndex >= map.grids.Length - 1)
            {
                p.nowIndex = map.grids.Length - 1;
                Console.SetCursorPosition(2, h - 5);
                if(p.type == E_PlayerType.Player)
                {
                    Console.Write("恭喜玩家胜利!");
                }
                else
                {
                    Console.Write("恭喜电脑胜利!");
                }
                Console.SetCursorPosition(2, h - 6);
                Console.Write("请按任意键结束!");


                return true;
            }
            else
            {
                // 没有到达终点处理
                Grid grid = map.grids[p.nowIndex];
                switch (grid.type)
                {
                    case E_Grid_Type.Normal:
                        // 不必理会
                        Console.SetCursorPosition(1, h - 5);
                        Console.Write("{0}到达了安全地带", p.type == E_PlayerType.Player ? "玩家" : "电脑");
                        break;
                    case E_Grid_Type.Boom:
                        // 退格
                        p.nowIndex -= 5; Console.SetCursorPosition(1, h - 5);
                        Console.Write("{0}碰到了炸弹！退格:{1}", p.type == E_PlayerType.Player ? "玩家" : "电脑", randomNum);
                        if (p.nowIndex < 0)
                        {
                            p.nowIndex = 0;
                        }
                        break;
                    case E_Grid_Type.Pause:
                        // 暂停一回合
                        p.isPause = true;
                        break;
                    case E_Grid_Type.Tunnel:
                        // 随机 暂停，退格或位置
                        randomNum = r.Next(1,91); Console.SetCursorPosition(1, h - 5);
                        Console.Write("{0}进入时空隧道!", p.type == E_PlayerType.Player ? "玩家" : "电脑");
                        if (randomNum <= 30)
                        {
                            p.nowIndex -= 5;
                            if(p.nowIndex < 0)
                            {
                                p.nowIndex = 0;
                            }
                        }
                        // 触发暂停
                        else if(randomNum <= 60)
                        {
                            p.isPause = false;
                        }
                        else
                        {
                            int temp = p.nowIndex;
                            p.nowIndex = otherP.nowIndex;
                            otherP.nowIndex = temp; 
                             
                        }
                        break;
                }

            }
            // 默认没有结束
            return false;
        }

        // 7.绘制玩家
        static void DrawPlayer(Player player, Player computer, Map map)
        {
            // 重合时
            if(player.nowIndex == computer.nowIndex)
            {
                // 得到重合的位置
                Grid grid = map.grids[player.nowIndex];
                Console.SetCursorPosition(grid.pos.x, grid.pos.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('◎');
            }
            // 不重合时
            else
            {
                player.Draw(map);
                computer.Draw(map);
            }
        }

        // 绘制不变的内容 墙、提示等
        static void DrawWall(int w, int h)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            // 横着的墙壁
            for (int i = 0; i < w; i++)
            {
                // 上方的墙
                Console.SetCursorPosition(i, 0);
                Console.Write('■');
                // 下方的墙
                Console.SetCursorPosition(i, h - 1);
                Console.Write('■');

                // 中间的墙
                Console.SetCursorPosition(i, h - 7);
                Console.Write('■');

                Console.SetCursorPosition(i, h - 12);
                Console.Write('■');

            }
            // 竖着的墙壁
            for (int i = 0; i < h; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('■');

                Console.SetCursorPosition(w - 1, i);
                Console.Write('■');
            }

            // 显示文字信息
            ShowText(h);

        }
        // 显示文字信息
        static void ShowText(int h)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, h - 6);
            Console.Write("按下任意键投骰子...");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, h - 11);
            Console.Write("□:普通格子");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(1, h - 10);
            Console.Write("∥:暂停一回合");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(15, h - 10);
            Console.Write("●:炸弹，退五格");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, h - 9);
            Console.Write("¤:空间隧道, 随机倒退、暂停、换位置");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(1, h - 8);
            Console.Write("★:玩家");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(7, h - 8);
            Console.Write("▲:电脑");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(14, h - 8);
            Console.Write("◎:玩家电脑在同一位置");
        }
    }
    // 5. 格子结构体和格子枚举
    enum E_Grid_Type
    {
        /// <summary>
        /// 普通格子
        /// </summary>
        Normal,
        /// <summary>
        /// 炸弹格子
        /// </summary>
        Boom,
        /// <summary>
        /// 暂停一回合
        /// </summary>
        Pause,
        /// <summary>
        /// 时空隧道,随机 倒退，暂停，换位置
        /// </summary>
        Tunnel
    }
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    struct Grid
    {
        // 格子的类型
        public E_Grid_Type type;
        // 格子的位置
        public Vector2 pos;

        // 初始化构造函数
        public Grid(int x, int y, E_Grid_Type type)
        {
            pos.x = x;
            pos.y = y;
            this.type = type;
        }

        public void Draw()
        {
            // 下面几种类型的格子不管怎么设置，都需要设置位置
            Console.SetCursorPosition(pos.x, pos.y);
            switch (type)
            {
                case E_Grid_Type.Normal:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('□');
                    break;
                case E_Grid_Type.Boom:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('●');
                    break;
                case E_Grid_Type.Pause:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('∥');
                    break;
                case E_Grid_Type.Tunnel:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('¤');
                    break;
            }
        }
    }
    // 6. 地图结构体
    struct Map
    {
        public Grid[] grids;

        /// <summary>
        /// 初始化地图信息
        /// </summary>
        /// <param name="x">地图初始x位置</param>
        /// <param name="y">地图初始y位置</param>
        /// <param name="num">格子的数量</param>
        public Map(int x, int y, int num)
        {
            grids = new Grid[num];

            // 用于位置改变计数的变量
            int indexX = 0; // 表示x变化的次数
            int indexY = 0; // 表示y变化的次数
            int stepNum = 2; // x的步长

            Random r = new Random();
            int randomNum;
            for (int i = 0; i < num; i++)
            {
                randomNum = r.Next(0, 101);

                // 设置类型 普通格子 首位必然是普通格子
                if (randomNum < 85 || i == 0 || i == num - 1)
                {
                    grids[i].type = E_Grid_Type.Normal;
                }
                // 5% 炸弹
                else if (randomNum >= 85 && randomNum < 90)
                {
                    grids[i].type = E_Grid_Type.Boom;
                }
                // 暂停
                else if (randomNum >= 90 && randomNum < 95)
                {
                    grids[i].type = E_Grid_Type.Pause;
                }
                // 时空隧道
                else if (randomNum >= 95 && randomNum < 100)
                {
                    grids[i].type = E_Grid_Type.Tunnel;
                }
                // 位置应该如何设置
                grids[i].pos = new Vector2(x, y);

                // 每次循环都应该按一定规则去变化位置

                if (indexX == 10)
                {
                    y += 1;
                    indexY++;

                    if (indexY == 2)
                    {
                        indexX = 0;
                        indexY = 0;
                        stepNum = -stepNum;
                    }
                }
                else
                {
                    x += stepNum;
                    indexX++;
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < grids.Length; i++)
            {
                grids[i].Draw();
            }
        }


    }
    // 玩家枚举和玩家结构体
    enum E_PlayerType
    {
        /// <summary>
        /// 玩家
        /// </summary>
        Player,
        /// <summary>
        /// 电脑
        /// </summary>
        Computer
    }
    struct Player
    {
        public E_PlayerType type;
        // 当前处在那个一个地图格子的索引
        public int nowIndex;

        public bool isPause;
        public Player(int index, E_PlayerType type)
        {
            nowIndex = index;
            this.type = type;
            isPause = false;
        }

        public void Draw(Map mapInfo)
        {
            // 从传入的地图中得到格子的信息
            Grid grid = mapInfo.grids[nowIndex];
            // 设置位置
            Console.SetCursorPosition(grid.pos.x, grid.pos.y);
            // 必须要得到地图才能够确定玩家在格子上的位置

            //画 设置图标和颜色
            switch (type)
            {
                case E_PlayerType.Player:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('★');
                    break;
                case E_PlayerType.Computer:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write('▲');
                    break;
            }
        }
    }
}