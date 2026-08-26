namespace 常用泛型数据结构类LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinkedList");
            LinkedList<int> linkedList = new LinkedList<int>();

            #region 增
            linkedList.AddLast(10);
            linkedList.AddFirst(20);

            LinkedListNode<int> n = linkedList.Find(20);
            linkedList.AddAfter(n, 15);
            LinkedListNode<int> n1 = linkedList.Find(10);
            linkedList.AddBefore(n1, 12);
            #endregion

            #region 删
            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.Remove(20);

            linkedList.Clear();
            #endregion

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            #region 查
            LinkedListNode<int> first = linkedList.First;
            LinkedListNode<int> last = linkedList.Last;

            LinkedListNode<int> node = linkedList.Find(3);
            Console.WriteLine(node.Value);

            if (linkedList.Contains(1))
            {
                Console.WriteLine("存在1");
            }
            #endregion

            #region 改
            Console.WriteLine(linkedList.First.Value);
            linkedList.First.Value = 10;
            Console.WriteLine(linkedList.First.Value);
            #endregion

            #region 遍历
            Console.WriteLine("==============");
            foreach (int item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==============");
            LinkedListNode<int> nowNode = linkedList.First;
            while(nowNode != null)
            {
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Next;
            }

            Console.WriteLine("==============");
            nowNode = linkedList.Last;
            while(nowNode != null)
            {
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Previous;
            }
            #endregion

        }
    }
}
