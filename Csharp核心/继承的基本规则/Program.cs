namespace 继承的基本规则
{
    class Teacher 
    {
        public string name;
        //职工号
        public int number;
        public void SpeakeName() 
        {
            Console.WriteLine(name);
        }

    }

    class TeachingTeacher : Teacher
    {
        public string subject;

        public void SpeakSubject() 
        {
            Console.WriteLine("我是"+ subject + "老师");
        }
    }

    class RapTeacher : TeachingTeacher 
    {
        public void skill() 
        { 
            Console.WriteLine("{0}老师{1}说：'I say 那曾经的画面我都记得，消失不见的801末班车'",subject,name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("继承的基本规则");
            TeachingTeacher tt = new TeachingTeacher();
            tt.name = "李四";
            tt.number = 91;
            tt.subject = "说唱";
            tt.SpeakSubject();
            
            RapTeacher ttr = new RapTeacher();
            ttr.name = "王五";
            ttr.subject = "原神";
            ttr.skill();



        }
    }
}
