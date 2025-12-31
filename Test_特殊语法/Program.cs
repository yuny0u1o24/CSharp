#region 知识点一 var隐式类型
// var是一种特殊的变量类型
// 它可以用来表示任意类型的变量
// 注意:
// 1.var不能作为类的成员 只能用于临时变量声明时使用
//  也就是 一般写在函数语句块中
// 2.var必须初始化
using System.Threading.Channels;

var i = 5;
var s = "213";
var array = new int[] { 1, 2, 3, 4, 5 };
var list = new List<int>();
#endregion

#region 知识点二 设置对象初始值
// 声明对象时
// 可以通过直接写大括号的形式初始化公共成员变量和属性

Test t = new Test(100) { sex = true, Age = 10, Name="云游" };
#endregion

#region 设置集合初始值
//声明集合对象时
//也可以通过大括号 直接初始化内部属性
int[] array2 = new int[] { 1,2,3,4,5 };
List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };
#endregion


#region 匿名函数
// var 变量声明为自定义的匿名类型
var v = new 
{
    age = 10,
    money = 100,
    name = "小明"
};

Console.WriteLine(v);
#endregion

#region 可控类型 重要！
// 1.值类型是不能赋值为空的
//int c = null // 不能直接赋值为空

// 2.声明时 在类型后面加? 可以赋值为空
int? c = null;
// 3.判断是否为空
if (c.HasValue)
{
    Console.WriteLine(c);
    Console.WriteLine(c.Value);
}
// 4.安全获取可控类型值
int? value = null;
//  4-1.如果为空 默认返回 值类型的默认值
Console.WriteLine(value.GetValueOrDefault());
//  4-2.也可以指定一个默认值
Console.WriteLine(value.GetValueOrDefault(100));
float? f = null;
double? d = null;

//object? o = null;
object? o = new Test(12);

if (o != null)
{
    //o.ToString();
    Console.WriteLine(o.ToString());
}
// 相当于一种语法糖，可以自动判断o是否为空
// 如果是null就不会执行tostring也不会报错
Console.WriteLine(o?.ToString());

#endregion

#region 空合并操作符
// 空合并操作符 ??
// 左边值 ?? 右边值
// 如果左边值为null 就返回右边值 否则返回左边值
// 只要是可以为null的类型都能用
int? intV = null;

int intI = intV == null ? 100 : intV.Value;
intI = intV ?? 100; // 上面的简写形式

Console.WriteLine(intI);
#endregion

#region 内插字符串
// 关键符号: $
// 用$来构造字符串，让字符串可以拼接变量
string name = "云游";
int age = 18;
Console.WriteLine($"好好学习,{name}, 年龄{age}");
#endregion

#region 单句逻辑简略写法
if(true)
    Console.WriteLine("你好");

for (int j = 0; j < 5; j++)
    Console.WriteLine("hhh");

void Fun() => Console.WriteLine("你好");
// 属性也可以写成
//public int Money
//{
//    get => 500;
//    set => money = value;
//}
#endregion
class Test
{
    private int money;
    public Test(int money)
    {
        this.money = money;
    }

    public bool sex;
    public string Name
    {
        get; set;
    }
    public int Age
    {
        get; set;
    }
}