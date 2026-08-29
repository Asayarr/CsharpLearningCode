using System;

namespace 委托
{
    //委托是 函数的容器
    //委托本质是一个类

    //关键字 delegate
    //可以申明在namespace和class中 更多的申明在namespace中

    //访问修饰符默认不写 为public

    //申明了一个可以用来储存无参无返回值函数的容器
    //这里只是定义了规则 并没有使用
    delegate void MyFun();

    //委托规则的申明 是不能重名（同一语句块中）
    //表示用来装在或传递 返回值为int 有一个int参数的函数的 委托 容器规则
    delegate int MyFun2(int a);

    //委托是支持泛型的 可以让返回值和参数可变 更方便我们的使用
    delegate T MyFun3<T, K>(T t, K k);

    //委托常用在：
    //1.作为类的成员
    //2.作为函数的参数
    class Test
    {
        public MyFun fun;
        public MyFun2 fun2;

        public void TestFun(MyFun fun, MyFun2 fun2)
        {
            //先处理一些别的逻辑 当这些逻辑处理完了 再执行传入的函数
            int i = 1;
            i *= 2;
            i += 2;

            //fun();
            //fun2(i);

            this.fun = fun;
            this.fun2 = fun2;
        }

        public void AddFun(MyFun fun, MyFun2 fun2)
        {
            this.fun += fun;
            this.fun2 = fun2;
        }

        public void RemoveFun(MyFun fun, MyFun2 fun2)
        {
            this.fun -= fun;
            this.fun2 -= fun2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("委托");
            //专门用来装载 函数的 容器
            MyFun f = new MyFun(Fun);
            Console.WriteLine("========");
            f.Invoke();

            MyFun f2 = Fun;
            Console.WriteLine("========");
            f2();

            MyFun2 f3 = Fun2;
            Console.WriteLine(f3(1));

            Test t = new Test();

            t.TestFun(Fun, Fun2);

            #region 多播委托
            Console.WriteLine("========");
            MyFun ff = Fun;

            //增
            ff += Fun3;
            ff();
            //减
            ff -= Fun;
            ff -= Fun; //多减 不会报错 无非就是不处理而已
            ff();
            //清空
            ff = null;
            //ff(); 清空后调用会报错
            if (ff != null)
            {
                ff();
            }
            #endregion

            //using System
            #region 系统定义好的委托
            //无参无返回值
            Action action = Fun;
            action += Fun3;
            action();

            //泛型委托
            Func<string> funcString = Fun4;
            Func<int> FuncInt = Fun5;

            //可以传n个参数的委托
            Action<int, string> action2 = Fun6;

            //可以传n个参数且有返回值的委托
            Func<int, int> funInt2 = Fun2;
            #endregion
        }

        static void Fun()
        {
            Console.WriteLine("张三做什么");
        }

        static int Fun2(int value)
        {
            return value;
        }

        static void Fun3()
        {
            Console.WriteLine("李四做什么");
        }

        static string Fun4()
        {
            return "hello";
        }

        static int Fun5()
        {
            return 1;
        }

        static void Fun6(int i, string s)
        {

        }
    }
}
