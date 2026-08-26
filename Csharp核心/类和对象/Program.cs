namespace 类和对象
{
    // 类的定义：类是对象的模板
    class Student
    {
        // 成员变量（字段）
        public string name;
        public int age;
        public bool sex;

        // 成员方法
        public void SayHello()
        {
            Console.WriteLine("大家好，我叫" + name);
        }

        public void PrintInfo()
        {
            Console.WriteLine("我叫{0}，今年{1}岁", name, age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("类和对象");

            #region 创建对象（实例化）
            // new 类名() 创建对象，得到的是该类的实例
            Student s1 = new Student();
            Student s2 = new Student();
            #endregion

            #region 给成员变量赋值
            s1.name = "张三";
            s1.age = 18;
            s1.sex = true;

            s2.name = "李四";
            s2.age = 20;
            s2.sex = false;
            #endregion

            #region 调用成员方法
            s1.SayHello();      // 大家好，我叫张三
            s2.SayHello();      // 大家好，我叫李四

            s1.PrintInfo();     // 我叫张三，今年18岁
            s2.PrintInfo();     // 我叫李四，今年20岁
            #endregion

            #region 对象是引用类型
            // 对象变量存的是引用，赋值是共享同一对象
            Student s3 = s1;
            s3.age = 99;
            Console.WriteLine(s1.age);   // 99（s1 和 s3 指向同一对象）
            #endregion
        }
    }
}
