namespace 成员方法
{
    internal class Program
    {
        class Person 
        {
            public void Speak(string str) 
            {
                Console.WriteLine("{0}说{1}", name, str);
            }
            public bool IsAdult() 
            {
                return age >= 18;
            }
            public string name;
            public int age;
            
            public void AddFriend(Person p) 
            {
                if (friends == null)
                {
                    friends = new Person[] { p };
                }
                else 
                {
                    Person[] newFriends = new Person[friends.Length + 1];
                    for (int i = 0; i < friends.Length; i++) 
                    {
                        newFriends[i] = friends[i];
                    }
                    newFriends[newFriends.Length - 1] = p;
                    friends = newFriends;
                }
            }
            public Person[] friends;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("成员方法");
            Person p = new Person();
            p.name = "李四";
            p.Speak("楼下的是福瑞");

            Person p2 = new Person();
            p2.name = "林彧";
            p2.age = 19;

            p.AddFriend(p2);
            for (int i = 0; i < p.friends.Length;i++) 
            {
                Console.WriteLine(p.friends[i].name);
            }
        }
    }
}
