namespace 多态vob
{
    class Father 
    {
        public void SpeakName() 
        {
            Console.WriteLine("Father的方法");
        }

    }

    class Son:Father 
    {
        public new void SpeakName() 
        {
            Console.WriteLine("Son的方法");
        
        }
    }

    class GameObject 
    {
        public string name;

        public GameObject(string name) 
        { 
            this.name = name;
        }

        public virtual void Atk() 
        {
            Console.WriteLine("游戏对象进行攻击");
        }
    }

    class Player : GameObject 
    {
        public Player(string name) : base(name) 
        { 
            
        }

        public override void Atk()
        {
            base.Atk();
            Console.WriteLine("玩家的攻击");
        }
    }

    class Monster : GameObject 
    {
        public Monster(string name) : base(name) 
        { 
        
        }

        public override void Atk()
        {
            base.Atk();
            Console.WriteLine("怪物对象进行攻击");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("多态vob");

            Father f = new Son();
            f.SpeakName();

            (f as Son).SpeakName();

            GameObject p = new Player("李四");
            p.Atk();

            GameObject m = new Monster("Bobbynopeace");
            m.Atk();
        }
    }
}
