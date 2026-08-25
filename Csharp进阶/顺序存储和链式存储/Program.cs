using System.Diagnostics.Metrics;

namespace 顺序存储和链式存储
{
    internal class Program
    {
        /// <summary>
        /// 单向链表节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class LinkedNode<T>
        {
            public T value; //当前节点的值
            public LinkedNode<T> NextNode; //记录下一个节点的位置

            public LinkedNode(T value) //实例化
            {
                this.value = value;
            }
        }

        /// <summary>
        /// 单项链表类 管理节点 管理添加等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class LinkedList<T>
        {
            public LinkedNode<T> head; //链表的头节点
            public LinkedNode<T> tail; //链表的尾节点

            public void Add(T value)
            {
                LinkedNode<T> node = new LinkedNode<T>(value); //添加节点就是new一个新节点
                if(head == null) //链表为空
                {
                    head = node; //头节点为node
                    tail = node; //尾节点为node
                }
                else
                {
                    tail.NextNode = node; //上一个节点指向当前加入的节点的位置node
                    tail = node; //尾节点为当前的node
                }
            }

            public void Remove(T value)
            {
                if(head == null)
                {
                    return;
                }
                else if (head.value.Equals(value))
                {
                    head = head.NextNode;
                    //如果头节点被一处 发现头节点变孔
                    //证明只有一个节点 那尾也要清空
                    if(head == null)
                    {
                        tail = null;
                    }
                    return;
                }
                LinkedNode<T> node = head;
                while(node.NextNode != null)
                {
                    if (node.NextNode.value.Equals(value))
                    {
                        node.NextNode = node.NextNode.NextNode;
                        break;
                    }
                    node = node.NextNode;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("顺序存储和链式存储");

            LinkedList<int> link = new LinkedList<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            link.Add(4);

            LinkedNode<int> node = link.head;
            while(node != null)
            {
                Console.WriteLine(node.value);
                node = node.NextNode;
            }

            Console.WriteLine("===========");
            link.Remove(2);
            node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.NextNode;
            }

            Console.WriteLine("===========");
            link.Remove(1);
            node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.NextNode;
            }

            Console.WriteLine("===========");
            link.Add(99);
            node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.NextNode;
            }

        }

        //增:链式存储 计算上 优于顺序存储 (中间插入时链式不用像顺序一样去移动位置)
        //删:链式存储 计算上 优于顺序存储 (中间删除时链式不用像顺序一样去移动位置)
        //查:顺序存储 使用上 优于链式存储 (数组可以直接通过下标得到元素，链式需要遍历)
        //改:顺序存储 使用上 优于链式存储 (数组可以直接通过下标得到元素，链式需要遍历)
    }
}
