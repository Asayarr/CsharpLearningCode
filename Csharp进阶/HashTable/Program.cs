using System.Collections;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();

            #region 增
            //key value
            //类似于字典，key是唯一的，value可以重复
            hashtable.Add(1, "123");
            hashtable.Add("123", 2);
            hashtable.Add(true, false);
            hashtable.Add(false, false);
            #endregion

            #region 删
            //1.只能通过键取删除
            hashtable.Remove(1);
            //2.删除不存在的键不会报错
            hashtable.Remove(2);
            //3.清空哈希表
            hashtable.Clear();

            #endregion

            hashtable.Add(1, "123");
            hashtable.Add(2, "1234");
            hashtable.Add(3, "123");
            hashtable.Add("123123", 12);

            #region 查
            //1.通过键取值
            //找不到会返回null
            Console.WriteLine(hashtable[1]);
            Console.WriteLine(hashtable[4]);
            Console.WriteLine(hashtable["123123"]);

            //2.查看是否存在
            //跟据键查找
            if (hashtable.Contains(1))
            {
                Console.WriteLine("键1存在");
            }

            if (hashtable.ContainsKey(2))
            {
                Console.WriteLine("键2存在");
            }

            //跟据值查找
            if (hashtable.ContainsValue("123"))
            {
                Console.WriteLine("值123存在");
            }
            #endregion

            #region 改
            //只能改变值，不能改变键
            hashtable[1] = 100.5f;
            #endregion

            #region 遍历
            //得到键值对对数
            Console.WriteLine(hashtable.Count);

            //1.遍历key
            Console.WriteLine("-----------------");
            foreach (object key in hashtable.Keys)
            {
                Console.WriteLine("键:" + key);
                Console.WriteLine("值:" + hashtable[key]);
            }

            //2.遍历value
            Console.WriteLine("-----------------");
            foreach (object value in hashtable.Values)
            {
                Console.WriteLine("值:" + value);
            }

            //3.遍历键值对
            Console.WriteLine("-----------------");
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine("键:" + item.Key + ", 值:" + item.Value);
            }

            //4.迭代器遍历法
            Console.WriteLine("-----------------");
            IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
            bool flag = myEnumerator.MoveNext();
            while (flag)
            {
                Console.WriteLine("键:" + myEnumerator.Key + ", 值:" + myEnumerator.Value);
                flag = myEnumerator.MoveNext();
            }
            #endregion
        }
    }
}
