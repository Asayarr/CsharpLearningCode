using System.Security.Cryptography.X509Certificates;

namespace 成员属性
{
    internal class Program
    {
        class Person 
        {
            private string name;
            private int age;
            private int money;
            private bool sex;
        
            public string Name
            {
                get
                {
                    return name;
                }
                set 
                {
                    //可以在返回之前添加逻辑规则
                    name = value;
                }

            }

            public int Money
            {
                get 
                {
                    //解密处理
                    return (money-5)/8;
                }
                set 
                {
                    //保护机制
                    if (value < 0) 
                    { 
                        value= 0;
                        Console.WriteLine("不能小于0系统强制等于0");
                    }
                    //加密处理
                    money = value * 8 +5;
                }
            }

            public bool Sex 
            {
                get 
                {
                    return sex;
                }
                private set//不能改 
                { 
                    sex= value;
                }
                //可以直接不写set
            }

            #region 自动属性
            public float Height 
            {
                get;
                private set;
            }
            #endregion
        }
        static void Main(string[] args)
        {
            Person p =new Person();
            p.Name = "王五";//set
            Console.WriteLine(p.Name);//get
            p.Money = 1000;
            Console.WriteLine(p.Money);

        }
    }
}
