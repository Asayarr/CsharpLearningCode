namespace 结构体
{
    //写在namespace下
    struct Student
    {
        #region 访问修饰符
        //piblic 和 private
        //不写默认private
        #endregion




        //结构体中申明的变量不能直接初始化
        public int age;
        public bool sex;
        public int number;
        public string name;
        //函数方法
        //在结构体中的方法 目前不需要static关键字
        public void Speak() 
        { 
            Console.WriteLine("我的名字是{0},我今年{1}岁", name, age);
        }
        public Student(int age, bool sex, int number, string name) 
        { 
            this.age= age;
            this.sex= sex;
            this.number= number;
            this.name= name;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1;
            s1.age = 10;
            s1.sex = false;
            s1.number = 1;
            s1.name = "李四";
            s1.Speak();

            Student s2 = new Student(18,true,2,"王五");

        }
    }
}
