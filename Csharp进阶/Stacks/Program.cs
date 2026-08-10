using System.Collections;

namespace Stacks
{
    class Test
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            #region 增
            //入栈
            stack.Push(1);
            stack.Push("123");
            stack.Push(true);
            stack.Push(1.2f);
            stack.Push(new Test());
            #endregion

            #region 取
            //出栈
            object v = stack.Pop();
            Console.WriteLine(v);

            v = stack.Pop();
            Console.WriteLine(v);
            #endregion

            #region 查
            //无法直接查找栈中的元素，因为栈是后进先出（LIFO）的数据结构，只能访问栈顶的元素
            v = stack.Peek();
            Console.WriteLine(v);

            //判断元素是否存在
            if (stack.Contains("123"))
            {
                Console.WriteLine("元素存在");
            }
            #endregion

            #region 改
            //栈中的元素无法直接修改
            stack.Clear(); //清空栈

            stack.Push("1");
            stack.Push(2);
            stack.Push("哈哈哈");
            #endregion

            #region 遍历
            //栈没有索引器方法
            //不能使用for循环遍历栈中的元素
            Console.WriteLine("--------------");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------");
            object[] arr = stack.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine("--------------");
            while(stack.Count > 0)
            {
                object o = stack.Pop();
                Console.WriteLine(o);
            }
            #endregion
        }
    }
}
