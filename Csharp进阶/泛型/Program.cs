namespace 泛型
{
    // 泛型类
    // 泛型类是指在定义类时使用类型参数的类。泛型类可以在实例化时指定具体的类型，从而实现类型安全和代码复用。
    #region 泛型类和泛型接口
    class TestClass<T>
    {
        public T value;
    }

    class TestClass2<T1, T2, Z, M, JJ, KK>
    {
        public T1 value1;
        public T2 value2;
        public Z value3;
        public M value4;
        public JJ value5;
        public KK value6;
    }

    interface ITestInterface<T>
    {
        T Value 
        {
            get;
            set;
        }
    }

    class Test: ITestInterface<int>
    {
        public int Value { get; set; }
    }
    #endregion

    #region 泛型方法
    //1.普通类中的泛型方法
    class Test2 
    {
        public void TestFun<T>(T value) 
        { 
            Console.WriteLine(value);
        }

        public void TestFun<T>() 
        { 
            T t = default(T);
        }

        public T TestFun<T>(string v)
        {
            return default(T);
        }

        public void TestFun<T1, T2>(T1 v1, T2 v2)
        {
            Console.WriteLine(v1);
            Console.WriteLine(v2);
        }
    }
    //2.泛型类中的泛型方法
    class Test2<T>
    {
        public T value;
        //这不是泛型方法，而是泛型类中的普通方法
        //不能动态指定类型参数T，必须在实例化类时指定类型参数T
        public void TestFun(T t) 
        {
        
        }

        public void TestFun<K>(K k)
        {

        }
    }

    #endregion

    #region 泛型作用
    //举例：优化ArrayList
    class Arraylist<T>
    {
        private T[] array;
        private int count;
        public Arraylist()
        {
            array = new T[10];
            count = 0;
        }
        public void Add(T item)
        {
            if (count >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[count++] = item;
        }
        public T Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            return array[index];
        }
        public int Count
        {
            get { return count; }
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            TestClass<int> t = new TestClass<int>();
            t.value = 1;
            Console.WriteLine(t.value);

            TestClass<string> t2 = new TestClass<string>();
            t2.value = "Hello";
            Console.WriteLine(t2.value);

            TestClass2<int, string, double, float, TestClass<int>, short> t3 = new TestClass2<int, string, double, float, TestClass<int>, short>();

            Test2 tt = new Test2();
            tt.TestFun<string>("Hello, World!");

            Test2<int> tt2 = new Test2<int>();
            tt2.TestFun(1);
            tt2.TestFun<string>("123");
            tt2.TestFun<float>(1.2f);
        }
    }
}
