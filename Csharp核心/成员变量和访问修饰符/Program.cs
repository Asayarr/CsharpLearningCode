namespace 成员变量和访问修饰符
{
    internal class Program
    {
        enum E_sexType 
        { 
            Wan,
            Woman,
        }
        struct Position 
        {
        
        
        }
        class  Pet 
        {
        
        }
        class Person 
        {
            public string name = "李四";
            public int age;
            public E_sexType sex;
            public Person girlfriend;
            public Person[] friends;
            public Position pos;
            public Pet pet;
        
        
        }
        static void Main(string[] args)
        {
            Person p = new Person();
            //初始值 数字类型：0  bool类型：false 引用类型：null
            p.age = 10;
        }
    }
}
