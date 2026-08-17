namespace 泛型约束
{
    #region 泛型约束
    //关键字 where
    //where T : struct 约束T为值类型
    //where T : class 约束T为引用类型
    //where T : new() 约束T必须有一个无参数的构造函数
    //where T : <base class name> 约束T必须继承自指定的基类
    //where T : <interface name> 约束T必须实现指定的接口
    //where T : U 约束T必须是U的派生类或实现U接口
    #endregion

    #region 泛型约束示例
    //值类型约束
    class Test1<T> where T : struct
    {
        public T Value;

        public void TestFun<K>(K v) where K : struct
        {

        }
    }

    //引用类型约束
    class Test2<T> where T : class
    {
        public T Value;
        public void TestFun<K>(K v) where K : class
        {

        }
    }

    //公共无参构造函数约束
    class Test3<T> where T : new()
    {
        public T Value = new T();
        public void TestFun<K>(K v) where K : new()
        {

        }
    }

    class Test1
    {

    }

    class Test2
    {
        public Test2(int a)
        {

        }
    }

    class Test3 : Test1
    {

    }

    //类约束
    class Test4<T> where T : Test1
    {
        public T Value;
        public void TestFun<K>(K v) where K : Test1
        {

        }
    }

    //接口约束
    interface IFly
    {

    }

    interface IMove : IFly
    {

    }
    class Test4 : IFly
    {

    }

    class Test5<T> where T : IFly
    {
        public T Value;
        public void TestFun<K>(K v) where K : IFly
        {

        }
    }

    //另一个泛型约束
    class Test6<T, U> where T : U
    {
        public T Value;

        public void TestFun<K, V>(K k) where K : V
        {

        }
    }
    #endregion

    #region 约束的组合使用
    class Test7<T> where T : class, new()
    {

    }
    #endregion

    #region 多个泛型有约束
    class Test8<T,K>where T:class,new() where K : struct
    {

    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型约束");

            Test1<int> t1 = new Test1<int>();
            t1.TestFun<int>(5);
            t1.TestFun<float>(5.5f);

            Test2<Random> t2 = new Test2<Random>();
            t2.Value = new Random();
            t2.TestFun<string>("Hello");
            t2.TestFun<object>(new object());

            Test3<Test1> t3 = new Test3<Test1>();
            //Test3<Test2> t3 = new Test3<Test2>(); 不可

            Test4<Test1> t4 = new Test4<Test1>();
            Test4<Test3> tt4 = new Test4<Test3>();

            Test5<IFly> t5 = new Test5<IFly>();
            t5.Value = new Test4();
            Test5<IMove> tt5 = new Test5<IMove>();

            Test6<IMove,IFly> t6 = new Test6<IMove, IFly>();
        }
    }
}
