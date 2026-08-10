using System.Collections;

namespace Queues
{
    class Test
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            #region 增
            queue.Enqueue(1);
            queue.Enqueue("123");
            queue.Enqueue(1.4f);
            queue.Enqueue(new Test());
            #endregion

            #region 取
            object v = queue.Dequeue();
            Console.WriteLine(v);
            v = queue.Dequeue();
            Console.WriteLine(v);
            #endregion

            #region 查
            v = queue.Peek();
            Console.WriteLine(v);

            if (queue.Contains("123"))
            {
                Console.WriteLine("Queue contains '123'");
            }
            #endregion

            #region 改
            //队列不支持直接修改元素的操作，如果需要修改元素，需要先出队，再修改后重新入队。
            queue.Clear();//清空队列

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            #endregion

            #region 遍历
            Console.WriteLine("-----------------");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------");
            object[] array = queue.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine("-----------------");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            #endregion
        }

    }
}
