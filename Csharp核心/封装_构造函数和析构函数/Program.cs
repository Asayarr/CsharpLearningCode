namespace 封装_构造函数和析构函数
{
    internal class Program
    {
        class Person 
        {
            public string name;
            public int age;
            //类中是允许自己申明无参构造函数的
            public Person() //构造函数 不写默认有 函数名与类名一样
            {
                name = "李四";
                age = 18;
            }
            public Person(string name, int age) : this(age)
            {
                Console.WriteLine("hi");
            }
            public Person(int age) 
            { 
                this.age= age;
            }
            public Person(string name) 
            {
                this.name = name;
            }

            //如果不实现无参构造函数而实现了有参构造函数
            //失去默认的无参构造函数
        }
        static void Main(string[] args)
        {
            Person p =new Person("王五",19);
            Console.WriteLine(p.name);

            p = null;//垃圾回收 C#会自动回收垃圾
        }
    }
}
