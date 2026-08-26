# C# 学习笔记

---

## 一、语法基础

### 1.1 控制台输入输出

`Console.WriteLine()` 输出内容并换行，`Console.Write()` 输出内容不换行，`Console.ReadLine()` 读取用户输入（返回 `string`）。

```csharp
Console.WriteLine("Hello World");
Console.Write("请输入你的名字：");
string name = Console.ReadLine();
Console.WriteLine("你好，" + name);
```

### 1.2 变量与数据类型

变量必须先声明再使用。C# 是强类型语言，声明时需指定类型。

| 类型 | 说明 | 示例 |
|------|------|------|
| `int` | 32位有符号整数 | `int a = 10;` |
| `byte` | 8位无符号整数(0-255) | `byte b = 25;` |
| `float` | 32位浮点数（需加 `f` 后缀） | `float f = 3.14f;` |
| `bool` | 布尔值 | `bool flag = true;` |
| `char` | 单个字符（单引号） | `char c = 'A';` |
| `string` | 字符串（双引号） | `string s = "hello";` |

```csharp
int i = 0;
byte bt = 25;
float f = 3.14159f;      // float 必须加 f 后缀
bool flag = true;
char c = '1';             // char 只能存一个字符
string str = "Hello";
str = "可以重新赋值";

// 一行声明多个变量
int a1 = 1, a2 = 2, a3 = 3;
```

### 1.3 数据类型大小

使用 `sizeof()` 获取值类型占用的字节数。

```csharp
int sbyteSize = sizeof(sbyte);   // 1
int intSize = sizeof(int);       // 4
int shortSize = sizeof(short);   // 2
int longSize = sizeof(long);     // 8
```

常见类型大小：

| 类型 | 字节数 | 范围 |
|------|--------|------|
| `sbyte` | 1 | -128 ~ 127 |
| `short` | 2 | -32768 ~ 32767 |
| `int` | 4 | -21亿 ~ 21亿 |
| `long`  | 8 | 极大范围 |
| `float` | 4 | 约7位精度 |
| `double` | 8 | 约15位精度 |

**浮点数精度陷阱**：浮点数以二进制存储，十进制小数（如 0.1）无法精确表示，运算会累积误差。

```csharp
double x = 1.0 - 0.1 - 0.1 - 0.1 - 0.1 - 0.1;
Console.WriteLine(x);   // 0.5000000000000001（不是精确的 0.5）
```

> 涉及金额等需要精确计算的场景，应使用 `decimal` 类型（精度更高，无此类误差）。

### 1.4 常量

`const` 声明的变量必须在定义时初始化，之后不可修改。

```csharp
const int a = 0;
Console.WriteLine(a);
// a = 1;   // 编译错误：常量不可修改
```

### 1.5 转义字符与逐字字符串

| 转义符 | 含义 |
|--------|------|
| `\"` | 双引号 |
| `\n` | 换行 |
| `\\` | 反斜杠 |
| `\t` | 制表符 |
| `\a` | 警报声 |

使用 `@` 前缀可忽略转义，称为**逐字字符串**，常用于文件路径。

```csharp
string str = "a s\"\n123132141\\";
Console.WriteLine(str);

str = @"你\t好";   // 逐字字符串，\t 被当作普通字符输出
Console.WriteLine(str);  // 输出：你\t好（不会变成制表符）
```

### 1.6 类型转换

**隐式转换**：大范围类型可以隐式接收小范围类型的值（自动安全转换）。转换方向：`long` ← `int` ← `short` ← `sbyte`

```csharp
long l = 1;
int i = 0;
sbyte sb = 13;
short s = 2;

l = i;   // int → long 隐式转换 OK
i = s;   // short → int 隐式转换 OK
s = sb;  // sbyte → short 隐式转换 OK
```

**显式转换（强制转换）**：大范围转小范围可能溢出或丢精度，必须用 `(类型)` 强转，风险由程序员承担。

```csharp
// 强制转换 —— 小范围装大范围
int i = 100;
short s = (short)i;        // OK，100 在 short 范围内

long l = 3000000000;       // 超过 int 范围
int j = (int)l;            // 溢出！结果不确定，需谨慎

// 浮点 → 整数：直接截断小数部分（不四舍五入）
double d = 3.99;
int k = (int)d;            // 3（丢弃小数）
```

**字符串与数值互转：**

```csharp
// string → 数值
int a = int.Parse("123");              // 解析失败会抛异常
float b = float.Parse("3.14");

// 数值 → string
string s1 = 123.ToString();
string s2 = 3.14f.ToString();
```

> 三种方式对比：隐式转换自动安全；显式转换 `(类型)` 可能溢出需谨慎；`int.Parse` / `Convert.ToInt32` 处理字符串转数值。
### 1.7 随机数

使用 `Random` 类生成随机数。`Next(max)` 返回 `[0, max)` 范围内的整数。

```csharp
Random r = new Random();
int i = r.Next(20);      // 0 到 19 之间的随机整数
Console.WriteLine(i);
int damage = r.Next(5, 15);  // 5 到 14 之间
```


---

## 二、流程控制

### 2.1 算术运算符

| 运算符 | 含义 | 示例 |
|--------|------|------|
| `+` | 加 | `a + b` |
| `-` | 减 | `a - b` |
| `*` | 乘 | `a * b` |
| `/` | 除（整数相除得整数） | `a / b` |
| `%` | 取余 | `a % b` |

**自增/自减**：`++` 和 `--`。前置（`++a`）先加后用，后置（`a++`）先用后加。

```csharp
int a = 10, b = 20;

int r1 = ++a + b;    // a先变11, 再算 11+20 = 31
a = 10; b = 20;
int r2 = a + b++;    // 先算 10+20 = 30, b再变21
a = 10; b = 20;
int r3 = a++ + ++b;  // 10 + 21 = 31, a再变11
```

**变量交换**（两种方法）：

```csharp
// 方法1：借第三变量
int temp = a; a = b; b = temp;

// 方法2：算术交换
a = a + b; b = a - b; a = a - b;
```

### 2.2 逻辑运算符与短路求值

| 运算符 | 含义 |
|--------|------|
| `&&` | 逻辑与（两边都为 true 才为 true） |
| `\|\|` | 逻辑或（任意一边为 true 即为 true） |
| `!` | 逻辑非（取反） |

**关键：短路求值**

- `A && B`：如果 A 为 `false`，B 不会被执行（结果已确定为 false）
- `A || B`：如果 A 为 `true`，B 不会被执行（结果已确定为 true）

```csharp
int i = 1;
bool result = i > 0 || ++i > 2;
// i > 0 为 true，右边 ++i 不会执行
Console.WriteLine(result);  // True
Console.WriteLine(i);       // 1（i 没有被自增）
```

### 2.3 三目运算符

`条件 ? 值1 : 值2` —— 条件为真返回值1，为假返回值2。

```csharp
string str = true ? "你好" : "好在哪？";
Console.WriteLine(str);  // 输出：你好
```

### 2.4 位运算符

对整数的二进制位进行操作。

| 运算符 | 含义 | 示例 |
|--------|------|------|
| `&` | 按位与 | `5 & 3` = 1 |
| `\|` | 按位或 | `5 \| 3` = 7 |
| `^` | 按位异或 | `5 ^ 3` = 6 |
| `~` | 按位取反 | `~5` = -6 |
| `<<` | 左移 | `5 << 1` = 10 |
| `>>` | 右移 | `5 >> 1` = 2 |

```csharp
int a = 5, b = 5;
int c = a & b;      // 0101 & 0101 = 0101 = 5
Console.WriteLine(c);
```

### 2.5 条件语句

**if-else：**

```csharp
Console.WriteLine("请输入你的名字");
string str = Console.ReadLine();
if (str != null && str.Equals("张三", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("你好，管理员");
}
else
{
    Console.WriteLine("你好，访客");
}
```

> **注意**：字符串比较用 `.Equals()` 方法。`StringComparison.OrdinalIgnoreCase` 忽略大小写。

**switch-case：**

```csharp
int a = 1;
switch (a)
{
    case 1:
        Console.WriteLine("一");
        break;
    case 2:
        Console.WriteLine("二");
        break;
    default:
        Console.WriteLine("其他");
        break;
}
```

每个 `case` 必须以 `break` 结尾（C# 不允许 `case` 穿透），`default` 是可选的。

### 2.6 循环语句

**while 循环**：先判断条件，满足则执行。

```csharp
int a = 10;
while (a > 5)
{
    a -= 2;   // 等价于 a = a - 2
}
Console.WriteLine(a);  // 4
```

**for 循环**：适合已知循环次数的情况。

```csharp
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

### 2.7 异常处理

`try-catch-finally`：用于捕获和处理运行时的异常。`finally` 块无论是否发生异常都会执行。

```csharp
try
{
    string str = Console.ReadLine();
    int i = int.Parse(str);        // 输入非法字符会抛异常
    Console.WriteLine(i);
}
catch
{
    Console.WriteLine("请输入合法数字");
}
finally
{
    Console.WriteLine("程序结束");  // 始终执行
}
```

---

## 三、复合数据类型

### 3.1 字符串操作

**string.Format 格式化：**

```csharp
string str = string.Format("迎面走来的{0}让{1}如此心动，这种感觉{2}曾未有", "你", "我", "我");
Console.WriteLine(str);

// Console.WriteLine 也支持直接使用占位符
Console.WriteLine("我叫{0}，今年{1}岁", "李四", 18);
```

**索引访问与遍历：**

```csharp
string str = "Hello, World!";
Console.WriteLine(str[0]);           // 'H' — 索引访问，类似 Python

// 转为 char 数组
char[] chars = str.ToCharArray();
Console.WriteLine(chars[1]);         // 'e'

// 遍历每个字符
for (int i = 0; i < str.Length; i++)
{
    Console.WriteLine(str[i]);
}
```

**查找：**

```csharp
string str = "Hello, World!";

// 正向查找
int index = str.IndexOf('o');        // 4（第一个 'o' 的位置）
index = str.IndexOf("World");        // 7（子串位置）
index = str.IndexOf("S");            // -1（未找到）

// 反向查找
str = "我是一个字符串，我是一个字符串";
index = str.LastIndexOf("字符串");    // 12（最后一个匹配的位置）
```

**移除与替换：**

```csharp
string str = "我是张三张三";

// 移除
str = str.Remove(4);                 // "我是张三"（移除索引4及之后）
str = str.Remove(2, 2);              // "我是"（从索引2开始移除2个字符）

// 替换
str = "我是张三张三";
str = str.Replace("张三", "李四");     // "我是李四李四"
```

**大小写转换：**

```csharp
string str = "Hello World";
str = str.ToUpper();                 // "HELLO WORLD"
str = str.ToLower();                 // "hello world"
```

**截取（Substring）：**

```csharp
string str = "Hello, World!";
str = str.Substring(7);              // "World!"（从索引7到末尾）
str = str.Substring(1, 5);           // "ello,"（从索引1起取5个字符）
```

> `Substring` 不能越界（out of range），截取前注意检查长度。

**切割（Split）：**

```csharp
string str = "1,2,3,4,5,6,7,8,9";
string[] parts = str.Split(',');     // 以逗号为分隔符切割
foreach (string s in parts)
    Console.WriteLine(s);            // 依次输出 1 到 9
```

### 3.2 StringBuilder

`string` 是不可变的，每次修改（拼接、替换等）都会创建新对象，频繁操作时性能差。`StringBuilder` 位于 `System.Text` 命名空间，是**可变字符串**，适合频繁修改的场景。

```csharp
using System.Text;

// 创建
StringBuilder sb = new StringBuilder("123123123");
StringBuilder sb2 = new StringBuilder("hello", 100);  // 指定初始容量

// 容量 — 不需重新分配内存时可容纳的字符数，初始默认 16
Console.WriteLine(sb.Capacity);
```

**增删查改替换：**

| 方法 | 说明 |
|------|------|
| `Append(str)` | 末尾追加字符串 |
| `AppendFormat("{0}{1}", a, b)` | 格式化追加 |
| `Insert(index, str)` | 在指定索引处插入 |
| `Remove(index, count)` | 从索引处移除 count 个字符 |
| `this[index]` | 读取 / 修改指定位置字符 |
| `Replace(old, new)` | 替换所有匹配字符串 |
| `Clear()` | 清空内容 |

```csharp
StringBuilder sb = new StringBuilder("123123123");

// 增
sb.Append("456");                    // "123123123456"
sb.AppendFormat("{0}{1}", 100, 999); // "123123123456100999"
// 容量不足时自动扩容（翻倍）

// 插入
sb.Insert(3, "插入的内容");           // "123插入的内容123123456100999"

// 删
sb.Remove(3, 5);                     // 移除刚插入的5个字符

// 查 / 改
Console.WriteLine(sb[0]);            // '1'
sb[0] = 'X';                         // 修改第一个字符

// 替换
sb.Replace("123", "ABC");            // 所有 "123" → "ABC"

// 清空
sb.Clear();

// 比较
sb.Append("123123");
if (sb.Equals("123123"))             // 内容比较
    Console.WriteLine("字符串相等");
```

> `StringBuilder` 的 `Equals` 比较的是内容而非引用，和 `string` 行为一致。

---

### 3.3 值类型 vs 引用类型

这是 C# 中区分数据类型的两大类：

| | 值类型 | 引用类型 |
|------|------|------|
| **存储位置** | 栈(Stack) | 堆(Heap)，栈上存引用指针 |
| **赋值行为** | 复制值，独立副本 | 复制引用，指向同一对象 |
| **典型类型** | `int`, `float`, `bool`, `struct`, `enum` | `string`, `class`, `int[]`, `object` |

```csharp
// 值类型：赋值是独立拷贝
int a = 0;
int b = a;
b = 999;
Console.WriteLine(a);  // 0，a 不受影响

// 引用类型：赋值是共享同一对象
int[] arr = new int[] { 1, 2, 3, 4 };
int[] arr2 = arr;
arr2[0] = 999;
Console.WriteLine(arr[0]);  // 999，arr 和 arr2 指向同一数组

// 用 new 断开引用
arr2 = new int[] { 1, 2, 3, 4 };
Console.WriteLine(arr[0]);  // 999，arr 不受影响
```

### 3.4 特殊的引用类型 string

**string 是引用类型，但用起来像值类型：**

```csharp
string str1 = "hello";
string str2 = str1;       // 复制的是引用
Console.WriteLine(str1 == str2);   // True（内容相等）

str2 = "world";           // str2 指向新的字符串对象
Console.WriteLine(str1);  // hello（str1 不受影响）
```

**不可变性：** 字符串内容不可变！任何"修改"都是创建新对象。

```csharp
string s = "abc";
s = s + "def";            // 实际是创建新对象"abcdef"，s 指向它
Console.WriteLine(s);
```

**字符串驻留（常量池）：** 编译期确定的相同内容字符串指向同一对象。

```csharp
string a = "hello";
string b = "hello";
Console.WriteLine(ReferenceEquals(a, b));   // True（常量池同一个）

string d = "hel";
string e = d + "lo";              // 运行时拼接 → 新对象
Console.WriteLine(ReferenceEquals(a, e));   // False
```

**比较：`==` 和 `Equals` 比较内容，`ReferenceEquals` 比较引用：**

```csharp
string x = "abc";
string y = "ab" + "c";
Console.WriteLine(x == y);                 // True（内容相等）
Console.WriteLine(x.Equals(y));            // True（内容相等）
Console.WriteLine(ReferenceEquals(x, y));  // True（常量池同一个）

// 忽略大小写比较
string m = "Hello";
string n = "hello";
Console.WriteLine(m.Equals(n, StringComparison.OrdinalIgnoreCase));  // True
```

**与 char 数组互转：**

```csharp
string str = "hello";
char[] chars = str.ToCharArray();   // string → char[]
Console.WriteLine(chars[0]);        // 'h'

string newStr = new string(chars);  // char[] → string
Console.WriteLine(newStr);          // hello
```

> 重点：字符串 `==` 比较的是**内容**（编译器特殊处理），而普通引用类型 `==` 默认比较引用。string 的不可变性让"修改"字符串实际是换新对象，频繁拼接用 `StringBuilder`（见 3.2）。

### 3.5 数组

数组按**维度**可分为一维数组、二维数组、交错数组三种：

#### 3.5.I 一维数组

数组是定长的同类型元素集合。声明时必须指定类型，长度确定后不可变。

**五种声明方式：**

```csharp
int[] arr1;                           // 仅声明，未初始化
int[] arr2 = new int[5];              // 长度为5的空数组（元素为0）
int[] arr3 = new int[5] { 1, 2, 3, 4, 5 };  // 声明大小并初始化
int[] arr4 = new int[] { 1, 2, 3, 4 };      // 初始化列表推断大小
int[] arr5 = { 10, 9, 41, 421 };            // 最简写法
```

**常用操作：**

```csharp
int[] array = { 1, 2, 3, 4, 5 };

Console.WriteLine(array.Length);  // 获取长度：5
Console.WriteLine(array[0]);      // 访问元素：1 （索引从0开始）
array[1] = 99;                    // 修改元素

// 遍历
for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}
```

**动态增删**（C# 数组不可变长，需手动创建新数组）：

```csharp
// 增加元素
int[] newArray = new int[array.Length + 1];
for (int i = 0; i < array.Length; i++)
    newArray[i] = array[i];
newArray[newArray.Length - 1] = 6;
array = newArray;  // 指向新数组
```

#### 3.5.II 二维数组

二维数组是**两个下标**的数组（表格：行、列）。声明时同时指定行数和列数。

**四种声明方式：**

```csharp
int[,] arr1 = new int[2, 3];                    // 2行3列，元素默认0
int[,] arr2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };   // 声明并初始化
int[,] arr3 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };  // 由初始化列表推断
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };                // 最简写法
```

**访问与遍历：**

```csharp
// 通过 [行, 列] 访问
Console.WriteLine(arr2[0, 0]);   // 1（第0行第0列）
Console.WriteLine(arr2[1, 2]);   // 6（第1行第2列）
arr2[1, 1] = 99;                 // 修改

// 获取各维度长度
Console.WriteLine(arr2.GetLength(0));   // 2（行数）
Console.WriteLine(arr2.GetLength(1));   // 3（列数）

// 遍历方式1：两层 for 循环（外层行、内层列）
for (int i = 0; i < arr2.GetLength(0); i++)
{
    for (int j = 0; j < arr2.GetLength(1); j++)
    {
        Console.Write(arr2[i, j] + " ");
    }
    Console.WriteLine();
}

// 遍历方式2：foreach 按行优先顺序遍历所有元素
foreach (int item in arr2)
    Console.Write(item + " ");
```

#### 3.5.III 交错数组

交错数组（锯齿数组）是**数组的数组**：每个"行"是一个独立的数组，**每行的长度可以不同**。

```csharp
// 声明：先指定行数，每行再各自 new
int[][] arr1 = new int[3][];
arr1[0] = new int[2];          // 第0行 2 个元素
arr1[1] = new int[4];          // 第1行 4 个元素
arr1[2] = new int[3];          // 第2行 3 个元素

// 声明并初始化
int[][] arr2 = new int[][]
{
    new int[] { 1, 2 },
    new int[] { 3, 4, 5 },
    new int[] { 6, 7, 8, 9 }
};
```

**访问与遍历：**

```csharp
// 通过 [行][列] 访问（注意与二维数组 [,] 的写法区别）
Console.WriteLine(arr2[0][0]);   // 1
Console.WriteLine(arr2[1][2]);   // 5
arr2[2][1] = 99;

// 长度：Length 是行数，每行有自己的 Length
Console.WriteLine(arr2.Length);       // 3（行数）
Console.WriteLine(arr2[0].Length);    // 2（第0行元素个数）

// 遍历：外层遍历行，内层遍历当前行
for (int i = 0; i < arr2.Length; i++)
{
    for (int j = 0; j < arr2[i].Length; j++)
        Console.Write(arr2[i][j] + " ");
    Console.WriteLine();
}

// foreach
foreach (int[] row in arr2)
{
    foreach (int item in row)
        Console.Write(item + " ");
    Console.WriteLine();
}
```

> **二维数组 vs 交错数组**：二维数组 `int[,]` 是矩形（每行列数相同），用 `[行,列]` 和 `GetLength()`；交错数组 `int[][]` 是锯齿形（每行可不同长度），用 `[行][列]` 和 `Length`。

### 3.6 枚举

`enum` 是一组命名的整数常量，默认从 0 开始递增。约定命名前缀为 `E_` 或 `E`。

```csharp
// 命名空间内声明
enum E_MonsterType
{
    Normal,  // 0
    Boss,    // 1
}

enum E_PlayerType
{
    Main,   // 0
    Other,  // 1
}
```

**枚举与整数/字符串互转：**

```csharp
E_PlayerType playerType = E_PlayerType.Main;

int i = (int)playerType;           // 枚举 → int：0
string str = playerType.ToString(); // 枚举 → string："Main"

// 解析字符串为枚举
E_PlayerType type = (E_PlayerType)Enum.Parse(typeof(E_PlayerType), "Other");
```

**枚举配合 switch：**

```csharp
switch (monsterType)
{
    case E_MonsterType.Normal:
        Console.WriteLine("普通怪物");
        break;
    case E_MonsterType.Boss:
        Console.WriteLine("Boss怪物");
        break;
}
```

### 3.7 结构体

`struct` 是**值类型**（存储在栈上），适合表示轻量级数据对象。声明在 `namespace` 或 `class` 内部。

```csharp
struct Student
{
    // 字段 — 结构体中不能直接初始化
    public int age;
    public bool sex;
    public int number;
    public string name;

    // 方法
    public void Speak()
    {
        Console.WriteLine("我叫{0}，今年{1}岁", name, age);
    }

    // 构造函数
    public Student(int age, bool sex, int number, string name)
    {
        this.age = age;
        this.sex = sex;
        this.number = number;
        this.name = name;
    }
}
```

**使用方式：**

```csharp
// 方式1：逐字段赋值
Student s1;
s1.age = 10;
s1.sex = false;
s1.number = 1;
s1.name = "李四";
s1.Speak();

// 方式2：构造函数初始化
Student s2 = new Student(18, true, 2, "王五");
```

### 3.8 结构体与类的区别

| | 结构体（`struct`） | 类（`class`） |
|---|------|------|
| **类型** | 值类型 | 引用类型 |
| **存储位置** | 栈 | 堆（栈上存引用） |
| **赋值行为** | 复制整个数据，独立副本 | 复制引用，指向同一对象 |
| **继承** | 不能继承（隐式密封），只能实现接口 | 支持单继承 + 多接口 |
| **默认构造函数** | 不能自定义无参构造函数 | 可以自定义无参构造函数 |
| **析构函数** | 不允许 | 允许 |
| **字段初始化** | 不能直接初始化实例字段 | 可以直接初始化 |
| **适用场景** | 小型轻量数据（点、矩形、颜色） | 复杂对象、需要继承和引用语义 |

```csharp
// 值类型行为 — 赋值是独立拷贝
struct Point { public int X; public int Y; }

Point p1 = new Point { X = 1, Y = 2 };
Point p2 = p1;
p2.X = 100;
Console.WriteLine(p1.X);  // 1 — p1 不受影响

// 对比 class — 赋值共享引用
class PointClass { public int X; public int Y; }

PointClass c1 = new PointClass { X = 1, Y = 2 };
PointClass c2 = c1;
c2.X = 100;
Console.WriteLine(c1.X);  // 100 — c1 被修改
```

> 选择原则：数据量小、频繁创建、不需要继承 → `struct`；否则用 `class`。

---

## 四、排序算法

### 4.1 选择排序

经典排序算法：每一轮找到未排序部分的最大（小）值，放到已排序位置。

```csharp
int[] arr = new int[] { 8, 7, 1, 5, 6, 2, 4, 3, 9 };

for (int j = 0; j < arr.Length; j++)
{
    int index = 0;
    for (int i = 1; i < arr.Length - j; i++)
    {
        if (arr[index] < arr[i])
            index = i;     // 找到最大值的位置
    }
    // 将最大值交换到当前未排序部分的末尾
    if (index != arr.Length - 1 - j)
    {
        int temp = arr[index];
        arr[index] = arr[arr.Length - 1 - j];
        arr[arr.Length - 1 - j] = temp;
    }
}
```

### 4.2 冒泡排序

经典排序算法：**相邻元素两两比较，大的往后移（升序）**，每一轮把当前未排序部分的最大值"冒泡"到末尾。

```csharp
int[] arr = new int[] { 8, 7, 1, 5, 6, 2, 4, 3, 9 };

// 外层：共 n-1 轮
for (int i = 0; i < arr.Length - 1; i++)
{
    // 内层：相邻比较，把最大的移到末尾
    // 每轮结束，末尾 i+1 个元素已排好序，无需再比较
    for (int j = 0; j < arr.Length - 1 - i; j++)
    {
        if (arr[j] > arr[j + 1])
        {
            // 交换相邻元素
            int temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}
```

## 五、方法与函数

### 5.1 函数

**概念：**

函数（方法）是执行特定任务的代码块，通过函数名调用。定义在类中称为**成员方法**，定义在 `Program` 里配合 `static` 使用。

**语法结构：**

```
访问修饰符 + 返回类型 + 函数名(参数列表) { 函数体 }
```

```csharp
// 无参无返回值
static void SayHello()
{
    Console.WriteLine("你好");
}

// 有参无返回值
static void SayHi(string name)
{
    Console.WriteLine("你好，" + name);
}

// 无参有返回值
static int GetTen()
{
    return 10;
}

// 有参有返回值
static int Add(int a, int b)
{
    return a + b;
}

// 返回值为 void 表示不返回任何东西
```

**调用：**

```csharp
SayHello();                    // 你好
SayHi("李四");                  // 你好，李四
int sum = Add(3, 5);           // 8
```

**参数传递方式：**

```csharp
// 值类型参数：传的是值的副本，函数内修改不影响外部
int num = 10;
ChangeNum(num);
Console.WriteLine(num);        // 10（不受影响）

static void ChangeNum(int x)
{
    x = 999;
}

// 引用类型参数：传的是引用，函数内修改会影响外部
int[] arr = { 1, 2, 3 };
ChangeArr(arr);
Console.WriteLine(arr[0]);     // 99（被修改）

static void ChangeArr(int[] a)
{
    a[0] = 99;
}
```

> 值类型传副本、引用类型传引用，是理解函数参数的核心。

### 5.2 ref 和 out

**ref（按引用传递，双向）：** 函数内修改会反映到外部。**使用前必须先初始化**。

```csharp
static void AddOne(ref int num)
{
    num += 1;
}

static void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

int num = 10;
AddOne(ref num);       // 调用时也要写 ref
Console.WriteLine(num); // 11（被修改）

int x = 3, y = 5;
Swap(ref x, ref y);
Console.WriteLine(x);  // 5
Console.WriteLine(y);  // 3
```

**out（只出不进，单向）：** 函数必须给 out 参数赋值。**使用前不用初始化**。

```csharp
// out 常用于"尝试解析"模式：返回是否成功 + 结果
static bool TryParseInt(string str, out int result)
{
    result = 0;
    try
    {
        result = int.Parse(str);
        return true;
    }
    catch
    {
        return false;
    }
}

if (TryParseInt("123", out int r))
{
    Console.WriteLine("解析成功：" + r);
}
else
{
    Console.WriteLine("解析失败");
}

// out 可以"一次性返回多个值"
static void GetMinMax(int[] arr, out int min, out int max)
{
    min = arr[0];
    max = arr[0];
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < min) min = arr[i];
        if (arr[i] > max) max = arr[i];
    }
}

int[] nums = { 3, 1, 4, 1, 5, 9, 2, 6 };
GetMinMax(nums, out int min, out int max);
Console.WriteLine("最小值：" + min);   // 1
Console.WriteLine("最大值：" + max);   // 9
```

> **ref vs out**：`ref` 双向（进可传值、出可带值），调用前必须初始化；`out` 只出不进，调用前不用初始化，函数内必须赋值。共同点：都是按引用传递，函数内修改影响外部。

### 5.3 变长参数与默认值

**默认参数值**：给参数指定默认值，调用时可省略。

**params（变长参数）**：允许向方法传递任意数量的同类型参数。

```csharp
// 默认参数值
void PrintInfo(string name, int age = 18)
{
    Console.WriteLine("{0}，{1}岁", name, age);
}
PrintInfo("李四");           // age 使用默认值 18
PrintInfo("李四", 25);       // age 指定为 25

// params 变长参数
void TestFun(params int[] array)
{
    for (int i = 0; i < array.Length; i++)
        Console.WriteLine(array[i]);
}
TestFun(1, 2, 3, 4, 5);  // 传入任意多个参数
```

### 5.4 函数重载

**概念：** 函数名相同，**参数列表不同**（个数、类型、顺序不同）。编译器根据实参自动匹配对应版本。

```csharp
static int Add(int a, int b)
{
    return a + b;
}

static int Add(int a, int b, int c)   // 参数个数不同
{
    return a + b + c;
}

static float Add(float a, float b)    // 参数类型不同
{
    return a + b;
}

static string Add(string a, string b) // 参数类型不同
{
    return a + b;
}

// 调用：编译器自动匹配
int r1 = Add(1, 2);                // 匹配两个 int → 3
int r2 = Add(1, 2, 3);             // 匹配三个 int → 6
float r3 = Add(1.5f, 2.5f);        // 匹配两个 float → 4
string r4 = Add("hello", "world"); // 匹配两个 string → helloworld
```

> **重载只看参数列表，与返回类型无关**——只改返回类型不叫重载（编译错误）。

### 5.5 递归函数

函数内部调用自身。必须包含**终止条件**，否则会无限递归导致栈溢出。

```csharp
// 阶乘递归
int Factorial(int n)
{
    if (n <= 1)
        return 1;                   // 终止条件
    return n * Factorial(n - 1);     // 递归调用
}
Console.WriteLine(Factorial(5));     // 120

// 斐波那契递归
int Fib(int n)
{
    if (n <= 1) return n;
    return Fib(n - 1) + Fib(n - 2);
}
```

### 5.6 拓展方法

在不修改原类型代码的情况下，为已有类型"添加"新方法。**必须定义在静态类中**，第一个参数用 `this` 指定要拓展的类型。

```csharp
static class Tools
{
    // 为 int 类型拓展方法
    public static void SpeakValue(this int value)
    {
        Console.WriteLine("int的值是：" + value);
    }

    // 为 string 类型拓展方法
    public static void PrintInfo(this string str, string info)
    {
        Console.WriteLine("字符串：" + str + "，信息：" + info);
    }

    // 为自定义类型拓展方法
    public static void CustomMethod(this Test t)
    {
        Console.WriteLine("为Test拓展的方法");
    }
}

// 调用方式 — 就像实例方法一样
int i = 10;
i.SpeakValue();                     // int的值是：10

string s = "hello";
s.PrintInfo("world");              // 字符串：hello，信息：world
```

---

## 六、命名空间

命名空间用于组织和管理代码，避免类名冲突。类似文件系统中的文件夹。

### 6.1 基本使用

```csharp
// 声明命名空间
namespace MyGame
{
    class GameObject { }
    class Player : GameObject { }
}

// 使用 using 引用命名空间
using MyGame;

// 现在可以直接使用 MyGame 下的类
GameObject g = new GameObject();
Player p = new Player();
```

### 6.2 同名类的处理

- 同一命名空间不能有同名类
- 不同命名空间可以有同名类
- 如果多个引用的命名空间中有同名类，必须用全限定名指定

```csharp
namespace MyGame
{
    class GameObject { }
}

namespace MyGame2
{
    class GameObject { }  // 不同命名空间，同名 OK
}

// 使用 using 引用后，如果存在歧义，需指明出处：
using MyGame;
using MyGame2;

// GameObject g = new GameObject();     // 编译错误：歧义
MyGame.GameObject g1 = new MyGame.GameObject();   // 明确指定
MyGame2.GameObject g2 = new MyGame2.GameObject();
```

### 6.3 嵌套命名空间

命名空间可以包含子命名空间，用 `.` 分隔访问。

```csharp
namespace MyGame
{
    namespace UI
    {
        class Image { }
    }

    namespace Game
    {
        class Image { }   // 与 UI.Image 不冲突
    }
}

// 引用嵌套命名空间
using MyGame.UI;
using MyGame.Game;

Image uiImage = new Image();      // 来自 MyGame.UI
Image gameImage = new Image();    // 歧义！需用全限定名
MyGame.Game.Image img = new MyGame.Game.Image();
```

### 6.4 命名空间中类的访问修饰符

| 可用修饰符 | 不可用修饰符 |
|-----------|-------------|
| `public` | `protected` |
| `internal`（默认） | `private` |
| `abstract` | `protected internal` |
| `sealed` | `private protected` |
| `partial` | |

> 命名空间下的类默认是 `internal`，只能在同一个程序集内访问。

---

## 七、面向对象编程

### 7.1 类与对象、成员变量、访问修饰符

**概念：**

类是对象的模板（图纸），通过 `new` 创建实例（对象）。成员变量（字段）存储在类的实例中。

```csharp
// 类的定义：类是对象的模板
class Student
{
    public string name;    // 成员变量（字段）
    public int age;
    public bool sex;

    // 成员方法
    public void SayHello()
    {
        Console.WriteLine("大家好，我叫" + name);
    }
}

// 创建对象（实例化）
Student s1 = new Student();
Student s2 = new Student();

// 给成员变量赋值
s1.name = "张三";
s1.age = 18;

// 调用成员方法
s1.SayHello();    // 大家好，我叫张三
```

**默认值**：数值类型默认 `0`，`bool` 默认 `false`，引用类型默认 `null`。

**对象是引用类型：**

```csharp
// 对象变量存的是引用，赋值是共享同一对象
Student s3 = s1;
s3.age = 99;
Console.WriteLine(s1.age);   // 99（s1 和 s3 指向同一对象）
```

**访问修饰符：**

| 访问修饰符 | 含义 |
|-----------|------|
| `public` | 任意位置可访问 |
| `private` | 仅类内部可访问（默认） |
| `protected` | 类内部和子类可访问 |
| `internal` | 同一程序集内可访问 |

```csharp
class Person
{
    public string name = "李四";     // 初始化的成员
    public int age;                  // 默认值 0
    public E_SexType sex;            // 默认值 第一个枚举值
    public Person girlfriend;        // 默认值 null
    public Person[] friends;         // 默认值 null
}
```

### 7.2 构造函数与析构函数

构造函数在 `new` 创建对象时自动调用，用于初始化对象。构造函数名与类名相同，无返回类型。

```csharp
class Person
{
    public string name;
    public int age;

    // 无参构造函数
    public Person()
    {
        name = "李四";
        age = 18;
    }

    // 有参构造函数
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // 构造函数链 — 用 this() 调用自身其他构造函数
    public Person(string name, int age, string city) : this(name, age)
    {
        Console.WriteLine("城市：" + city);
    }
}
```

> **重要**：如果自定义了有参构造函数，则默认无参构造函数会被取消，除非手动再定义。

C# 有垃圾回收（GC），不需要手动释放内存。当对象不再被引用时，GC 会自动回收。

```csharp
Person p = new Person();
p = null;   // 原对象成为垃圾，等待 GC 回收
```

### 7.3 成员属性

属性是字段的封装，通过 `get`/`set` 访问器控制读写，可以在访问时添加验证或处理逻辑。

```csharp
class Person
{
    private int money;   // 私有字段

    public int Money
    {
        get
        {
            // 读取时解密
            return (money - 5) / 8;
        }
        set
        {
            // 写入时加密并验证
            if (value < 0)
            {
                value = 0;
                Console.WriteLine("金额不能为负，已设为0");
            }
            money = value * 8 + 5;
        }
    }
}
```

**自动属性**（无额外逻辑时）：

```csharp
public string Name { get; set; }              // 可读可写
public int Age { get; private set; }           // 外部只读
public float Height { get; private set; }      // 外部只读
```

### 7.4 静态成员与静态类

`static` 成员属于类本身，不属于任何实例。通过 `类名.成员` 访问。

```csharp
class MathHelper
{
    public const float G = 9.8f;           // const 编译时常量
    public static float PI = 3.14159f;      // static 字段

    // 静态方法只能访问静态成员
    public static float CalcCircleArea(float r)
    {
        return PI * r * r;
    }
}

// 调用（无需实例化）
float area = MathHelper.CalcCircleArea(5);
Console.WriteLine(MathHelper.PI);
```

**静态类**：用 `static class` 声明，不能实例化，所有成员必须是静态的。

```csharp
static class StaticClass
{
    public static int testInt = 100;

    static StaticClass()  // 静态构造函数：仅调用一次，在首次使用前自动执行
    {
        Console.WriteLine("静态类初始化");
    }
}
```

> 普通类也可以有静态构造函数：在首次实例化或访问静态成员时自动调用一次。

### 7.5 索引器

让对象能像数组一样用 `[]` 语法访问数据。

```csharp
class Person
{
    private string name;
    private int age;
    private Person[] friends;
    private int[,] array;

    // 按 int 索引，访问 friends 数组
    public Person this[int index]
    {
        get { return friends[index]; }
        set { friends[index] = value; }
    }

    // 二维索引器
    public int this[int i, int j]
    {
        get { return array[i, j]; }
        set { array[i, j] = value; }
    }

    // 按 string 索引，访问指定字段
    public string this[string fieldName]
    {
        get
        {
            switch (fieldName)
            {
                case "name": return name;
                case "age": return age.ToString();
                default: return "";
            }
        }
    }
}

// 使用
Person p = new Person();
p[0] = new Person();         // 调用 int 索引器 set
Console.WriteLine(p[0]);     // 调用 int 索引器 get
Console.WriteLine(p["name"]); // 调用 string 索引器 get
```

### 7.6 继承基本规则

C# 只支持**单继承**（一个类只能继承一个父类），但可以**多层继承**。子类获得父类所有 `public` 和 `protected` 成员。

```csharp
class Teacher
{
    public string name;
    public int number;

    public void SpeakName()
    {
        Console.WriteLine(name);
    }
}

// TeachingTeacher 继承 Teacher
class TeachingTeacher : Teacher
{
    public string subject;

    public void SpeakSubject()
    {
        Console.WriteLine("我是{0}老师", subject);
    }
}

// RapTeacher 继承 TeachingTeacher，形成三级继承链
class RapTeacher : TeachingTeacher
{
    public void Skill()
    {
        Console.WriteLine("{0}老师教你科目：{1}", name, subject);
        // 可以访问祖父类 Teacher 的 name 字段
    }
}
```

### 7.7 继承中的构造函数

创建子类对象时，构造函数从顶层父类开始逐级向下执行。如果父类没有无参构造函数，子类必须用 `base()` 显式调用父类构造函数。

```csharp
class GameObject
{
    public GameObject() { Console.WriteLine("GameObject构造"); }
}

class Player : GameObject
{
    public Player() { Console.WriteLine("Player构造"); }
}

class MainPlayer : Player
{
    public MainPlayer() { Console.WriteLine("MainPlayer构造"); }
}

// new MainPlayer() 输出：
// GameObject构造
// Player构造
// MainPlayer构造
```

**base() 调用父类指定构造函数：**

```csharp
class Father
{
    public Father(int i)
    {
        Console.WriteLine("父类构造函数：" + i);
    }
}

class Son : Father
{
    public Son(int i) : base(i)   // 必须调用 base，因为 Father 没有无参构造
    {
        Console.WriteLine("子类构造函数");
    }
}
```

### 7.8 密封类

`sealed` 修饰的类**不能被继承**。

```csharp
sealed class Father { }

// class Son : Father { }   // 编译错误：无法继承密封类
```

### 7.9 抽象类与抽象方法

`abstract` 类不能实例化，只能被继承。抽象方法没有方法体，子类必须用 `override` 实现。

```csharp
abstract class Fruits
{
    public string name;

    public abstract void Bad();   // 抽象方法：无实现体
}

class Apple : Fruits
{
    public override void Bad()    // 必须 override 实现
    {
        Console.WriteLine("苹果坏了");
    }
}

// Fruits f = new Fruits();   // 错误：抽象类不能实例化
Fruits f = new Apple();      // 正确：通过父类引用子类对象
```

**抽象方法规则：**

- 只能在抽象类中声明
- 不能是 `private`
- 没有方法体（只有声明）

### 7.10 多态

多态允许父类引用调用子类重写的方法，运行时决定具体调用哪个版本。

**virtual + override（真正的多态）：**

```csharp
class GameObject
{
    public virtual void Atk()
    {
        Console.WriteLine("游戏对象攻击");
    }
}

class Player : GameObject
{
    public override void Atk()
    {
        base.Atk();                    // 调用父类版本
        Console.WriteLine("玩家的攻击");
    }
}

// 多态行为
GameObject p = new Player("李四");
p.Atk();  // 输出：游戏对象攻击  +  玩家的攻击
          // 运行时调用的是 Player 的版本
```

**new 方法隐藏（不是多态）：**

```csharp
class Son : Father
{
    public new void SpeakName()
    {
        Console.WriteLine("Son的方法");
    }
}

Father f = new Son();
f.SpeakName();            // 输出："Father的方法"（父类引用调父类方法）
(f as Son).SpeakName();   // 输出："Son的方法"（必须转成子类才调子类方法）
```

> `new` 只是隐藏，不是覆盖。父类引用仍然调用父类方法。只有 `virtual + override` 才是真正的运行时多态。

### 7.11 接口

接口声明了一组功能契约，实现接口的类必须实现其中所有成员。接口不能有成员变量和方法实现。

```csharp
interface IFly
{
    void Fly();
    string Name { get; set; }       // 属性声明
    int this[int index] { get; set; } // 索引器声明
}
```

**接口规则：**

- 不能包含成员变量（字段）
- 只能有方法、属性、索引器、事件的声明
- 成员不能有实现体
- 所有成员隐式为 `public`
- 接口可以继承其他接口（但不能继承类）
- 类可以同时实现多个接口

```csharp
class Person : Animal, IFly    // 继承类 + 实现接口
{
    public void Fly() { }
    public string Name { get; set; }
    public int this[int index]
    {
        get { return 0; }
        set { }
    }
}
```

**接口继承接口：**

```csharp
interface IMove : IFly, IWalk   // 接口可多继承
{
    void Run();
}
```

**显式接口实现**（解决命名冲突）：

```csharp
class Player : IAtk, ISuperAtk
{
    void IAtk.Atk()            // 显式实现，不能加 public
    {
        Console.WriteLine("普通攻击");
    }
    void ISuperAtk.Atk()
    {
        Console.WriteLine("大招攻击");
    }
}

Player p = new Player();
(p as IAtk).Atk();        // "普通攻击"
(p as ISuperAtk).Atk();   // "大招攻击"
```

> 显式实现用于两个接口有同名方法时区分调用。调用时必须转换为对应接口类型。

### 7.12 抽象类与接口的区别

| | 抽象类（`abstract class`） | 接口（`interface`） |
|---|------|------|
| **关键字** | `abstract class` | `interface` |
| **继承** | 单继承（一个类只能继承一个抽象类） | 多实现（一个类可实现多个接口） |
| **成员** | 可以有字段、属性、方法、构造函数等 | 只能有方法/属性/索引器/事件的声明 |
| **方法实现** | 可以有已实现的方法和抽象方法 | 所有方法都没有实现（仅声明） |
| **访问修饰符** | 成员可以有任意访问修饰符 | 成员隐式为 `public` |
| **构造函数** | 可以有 | 不能有 |
| **实例化** | 不能直接实例化 | 不能直接实例化 |
| **适用场景** | "是什么" — 有共同基类的继承关系 | "能做什么" — 跨类的能力契约 |

```csharp
// 抽象类：定义"是什么"
abstract class Animal
{
    public string Name;
    public abstract void Speak();    // 子类必须实现
    public void Sleep()              // 可以包含已实现的方法
    {
        Console.WriteLine(Name + "在睡觉");
    }
}

// 接口：定义"能做什么"
interface IFly
{
    void Fly();
}
interface ISwim
{
    void Swim();
}

// 类可以继承一个抽象类 + 实现多个接口
class Duck : Animal, IFly, ISwim
{
    public override void Speak() { Console.WriteLine("嘎嘎"); }
    public void Fly() { Console.WriteLine("鸭子飞"); }
    public void Swim() { Console.WriteLine("鸭子游"); }
}
```

> 选择原则：当多个类共享代码和字段 → 抽象类；当多个不相关的类需要相同行为 → 接口。

### 7.13 内部类与分部类

**内部类（嵌套类）**：类定义在另一个类的内部。用 `OuterClass.InnerClass` 访问。

```csharp
class Person
{
    public class Body
    {
        class Arm { }    // 甚至可多层嵌套
    }
}

Person.Body body = new Person.Body();
```

**分部类（partial）**：同一个类拆分到多个文件中声明，编译时自动合并。

```csharp
partial class Student
{
    public bool sex;
    public string name;

    partial void Speak();       // 分部方法：只声明
}

partial class Student
{
    public int number;

    partial void Speak()        // 分部方法：实现
    {
        Console.WriteLine("Student的方法");
    }
}
```

### 7.14 密封方法

`sealed override` 阻止子类进一步重写已被 `override` 的方法。

```csharp
class Person : Animal
{
    public override void Eat()
    {
        Console.WriteLine("人吃饭");
    }

    public override void Speak()
    {
        Console.WriteLine("人说话");
    }
}

class WhitePerson : Person
{
    public sealed override void Eat()
    {
        base.Eat();    // 调用 Person.Eat
    }
    public sealed override void Speak()
    {
        base.Speak();  // 调用 Person.Speak
    }
}
// WhitePerson 的子类无法再 override Eat 和 Speak
```
### 7.15 万物之父与装箱拆箱

`object` 是所有类型的基类（C# 中一切皆派生自 `object`）。

```csharp
// object 可以引用任何类型
object o1 = 3;
object o2 = "hello";
object o3 = new Person();
```

**装箱**：值类型 → `object`（数据从栈移到堆）  
**拆箱**：`object` → 值类型（数据从堆移到栈）

```csharp
// 装箱
int a = 42;
object obj = a;        // 装箱：值类型包装成 object

// 拆箱
int b = (int)obj;      // 拆箱：object 还原为 int
```

> 装箱拆箱有性能开销，应避免在热路径中频繁使用。

**类型检查与安全转换：**

```csharp
object o = new Son();

// is：判断是否为某类型
if (o is Son)
{
    (o as Son).Speak();  // as：安全转换（失败返回 null，不抛异常）
}
```

### 7.16 万物之父中的方法

`object` 类提供了三类方法：静态方法、成员方法、虚方法。

**静态方法：**

| 方法 | 说明 |
|------|------|
| `Object.Equals(a, b)` | 判断两个对象是否相等（值类型比值，引用类型比引用地址） |
| `Object.ReferenceEquals(a, b)` | 判断两个对象是否为同一引用（值类型始终返回 `false`） |

```csharp
// Equals — 静态版本
Console.WriteLine(Object.Equals(1, 1));          // True（值类型比值）

Test t = new Test();
Test t2 = t;
Console.WriteLine(Object.Equals(t, t2));          // True（同一引用）

// ReferenceEquals — 只比较引用
Console.WriteLine(Object.ReferenceEquals(t, t2));  // True（同一引用）
Console.WriteLine(Object.ReferenceEquals(1, 1));   // False（值类型装箱后地址不同）
```

**成员方法：**

| 方法 | 说明 |
|------|------|
| `GetType()` | 获取对象的运行时 `Type` 对象，用于反射 |
| `MemberwiseClone()` | 创建**浅拷贝**：值类型字段独立复制，引用类型字段仍指向原对象 |

> `MemberwiseClone()` 是 `protected` 方法，只能在类内部通过自定义方法调用。

```csharp
class Test
{
    public int i = 1;
    public Test2 t2 = new Test2();

    public Test Clone()
    {
        return MemberwiseClone() as Test;  // 浅拷贝
    }
}

class Test2 { public int i = 2; }

// 使用
Test T = new Test();
Test T2 = T.Clone();         // 浅拷贝

// 修改克隆体
T2.i = 20;                   // 值类型：独立副本，T.i 不受影响
T2.t2.i = 21;                // 引用类型：共享对象，T.t2.i 也变为 21！

Console.WriteLine(T.t2.i);   // 21 ← 被 T2 的修改影响
```

> **浅拷贝 vs 深拷贝**：浅拷贝只复制对象本身，引用成员仍指向同一对象；深拷贝会递归复制整个对象图。

**虚方法（可 override）：**

| 方法 | 说明 |
|------|------|
| `Equals(object)` | 实例版比较，可重写实现自定义相等逻辑 |
| `GetHashCode()` | 获取哈希码，用于 `Dictionary`、`HashSet` 等哈希集合 |
| `ToString()` | 返回对象的字符串表示，默认返回类型全名 |

```csharp
class Test
{
    public override string ToString()
    {
        return "原神牛逼";    // 自定义字符串表示
    }
}

Test t = new Test();
Console.WriteLine(t);          // 输出：原神牛逼（隐式调用 ToString()）
```

---

## 八、设计原则

### 8.1 里氏替换原则（LSP）

核心思想：**父类容器可以装子类对象**，子类可以替换父类出现的位置，且程序行为不变。

**为什么需要 LSP：**

LSP 是**多态的前提**。多态允许"父类引用调用子类方法"，但要保证替换后程序行为一致，子类不能破坏父类定义的规则。如果子类随意改变行为语义，父类容器调用时就会出现意外结果。

```csharp
// 正例：父类容器装子类对象
GameObject player = new Player();
GameObject monster = new Monster();
GameObject boss = new Boss();

// 多态数组
GameObject[] objects = new GameObject[]
{
    new Player(),
    new Monster(),
    new Boss()
};

// 使用 is 类型检查 + as 安全转换
if (player is Player)
{
    (player as Player).PlayerAtk();   // 调用子类特有方法
}
```

**反例（违反 LSP）：**

子类重写时**破坏父类约定的行为语义**，父类容器调用时抛异常/结果错误。

```csharp
class GameObject
{
    public virtual void Move()
    {
        Console.WriteLine("物体移动");
    }
}

// 违反 LSP：Wall 不是"会移动的物体"，却强行继承 Move
class Wall : GameObject
{
    public override void Move()
    {
        throw new Exception("墙不能移动！");   // 破坏了父类的行为约定
    }
}

// 父类容器统一调用 —— Wall 抛异常，程序崩溃
GameObject[] objects = { new Player(), new Wall() };
foreach (GameObject obj in objects)
{
    obj.Move();   // Player 正常，Wall 抛异常 → 违反 LSP
}
```

> **如何避免**：子类只能扩展（加新行为），不能破坏父类的行为语义。Wall 不应该继承 GameObject 的 Move——把 Move 抽到子类各自的接口/抽象类里，而不是让"不能动的物体"硬实现 Move。


---

## 九、高级特性

### 9.1 运算符重载

通过 `operator` 关键字为自定义类型定义运算符行为。必须是 `public static` 方法。

```csharp
class Point
{
    public int X;
    public int Y;

    // Point + Point
    public static Point operator +(Point p1, Point p2)
    {
        return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
    }

    // Point + int
    public static Point operator +(Point p1, int value)
    {
        return new Point { X = p1.X + value, Y = p1.Y + value };
    }
}

// 使用
Point p1 = new Point { X = 1, Y = 2 };
Point p2 = new Point { X = 3, Y = 4 };
Point p3 = p1 + p2;     // X=4, Y=6
Point p4 = p1 + 5;      // X=6, Y=7
```

---

## 十、泛型

泛型是**类型参数化**的机制：在定义类/方法/接口时先用占位符 `T` 表示类型，使用时再指定具体类型。好处是**类型安全**（编译期检查）+ **代码复用**（一份代码适配多种类型）。

### 10.1 泛型类

```csharp
class TestClass<T>
{
    public T value;
}

// 使用 —— 实例化时指定具体类型
TestClass<int> t = new TestClass<int>();
t.value = 1;

TestClass<string> t2 = new TestClass<string>();
t2.value = "Hello";
```

**多个类型参数**：

```csharp
class TestClass2<T1, T2, Z, M, JJ, KK>
{
    public T1 value1;
    public T2 value2;
    public Z value3;
    // ...
}

TestClass2<int, string, double, float, TestClass<int>, short> t3 =
    new TestClass2<int, string, double, float, TestClass<int>, short>();
```

### 10.2 泛型接口

```csharp
interface ITestInterface<T>
{
    T Value { get; set; }
}

// 实现时指定具体类型
class Test : ITestInterface<int>
{
    public int Value { get; set; }
}
```

### 10.3 泛型方法

**普通类中的泛型方法**：方法自己带类型参数。

```csharp
class Test2
{
    public void TestFun<T>(T value)
    {
        Console.WriteLine(value);
    }

    public T TestFun<T>(string v)      // 泛型返回值
    {
        return default(T);             // default(T)：T 的默认值
    }

    public void TestFun<T1, T2>(T1 v1, T2 v2)  // 多个类型参数
    { }
}
```

**泛型类中的泛型方法**：

> 注意：`Test2` 和 `Test2<T>` 是两个不同的类（C# 允许泛型与非泛型同名共存，因为类型参数数量不同）。上面演示普通类中的泛型方法，这里演示泛型类中的方法。

```csharp
class Test2<T>
{
    public T value;

    // 这不是泛型方法，是泛型类中的普通方法
    // T 在实例化类时已确定，调用时不能再指定
    public void TestFun(T t) { }

    // 这才是泛型方法 —— K 由方法调用时指定
    public void TestFun<K>(K k) { }
}

Test2<int> tt = new Test2<int>();
tt.TestFun(1);                  // 用类的 T = int
tt.TestFun<string>("123");      // 方法自己的 K = string
```

### 10.4 泛型的作用

解决了非泛型集合（如 ArrayList）的两个问题：**类型不安全**（什么都能塞）和**装箱拆箱开销**。用泛型手写一个类型安全的动态数组：

```csharp
class MyArrayList<T>
{
    private T[] array;
    private int count;

    public MyArrayList()
    {
        array = new T[10];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= array.Length)
            Array.Resize(ref array, array.Length * 2);  // 自动扩容
        array[count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();
        return array[index];
    }

    public int Count { get { return count; } }
}
```

> 这就是 `List<T>` 的实现思路。泛型让集合在**编译期**就确定元素类型，存取不再需要拆箱，也比 ArrayList 更快。

### 10.5 泛型约束

泛型约束用 `where` 关键字**限制类型参数 T 的取值**，让泛型代码能安全地使用特定类型才有的功能。

**约束种类：**

| 约束写法 | 含义 |
|----------|------|
| `where T : struct` | T 必须是**值类型**（int、float、bool、struct 等） |
| `where T : class` | T 必须是**引用类型**（string、class、数组等） |
| `where T : new()` | T 必须有无参构造函数（可 `new T()`） |
| `where T : <基类名>` | T 必须继承自指定基类 |
| `where T : <接口名>` | T 必须实现指定接口 |
| `where T : U` | T 必须是 U 的派生类或实现 U 接口 |

**各约束示例：**

```csharp
// 值类型约束
class ValueBox<T> where T : struct
{
    public T Value;
    public void TestFun<K>(K v) where K : struct { }
}

// 引用类型约束
class ReferenceBox<T> where T : class
{
    public T Value;
    public void TestFun<K>(K v) where K : class { }
}

// 无参构造函数约束 —— 可以安全 new T()
class NewableBox<T> where T : new()
{
    public T Value = new T();
}
```

```csharp
class Animal { }                 // 基类
class Dog
{
    public Dog(int age) { }      // 只有有参构造
}
class Cat : Animal { }           // 继承 Animal

// 基类约束 —— T 必须是 Animal 或其派生类
class AnimalBox<T> where T : Animal
{
    public T Value;
}

AnimalBox<Animal> box1 = new AnimalBox<Animal>();
AnimalBox<Cat> box2 = new AnimalBox<Cat>();      // Cat 继承 Animal，可以
//AnimalBox<Dog> box3 = new AnimalBox<Dog>();    // 不行：Dog 与 Animal 无关
```

```csharp
interface IFly { }
interface IMove : IFly { }       // 接口继承接口
class Bird : IFly { }            // 实现 IFly

// 接口约束 —— T 必须实现 IFly
class FlyBox<T> where T : IFly
{
    public T Value;
}

FlyBox<IFly> box1 = new FlyBox<IFly>();
box1.Value = new Bird();         // Bird 实现了 IFly，可以
FlyBox<IMove> box2 = new FlyBox<IMove>();
```

```csharp
// 另一个泛型参数约束 —— T 必须是 U 的派生类或实现 U 接口
class DerivedBox<T, U> where T : U
{
    public T Value;
}

DerivedBox<IMove, IFly> box = new DerivedBox<IMove, IFly>();
// IMove 继承自 IFly，满足 T : U
```

**约束组合与多参数约束：**

```csharp
// 多个约束组合（用逗号分隔）
class CombinedBox<T> where T : class, new()   // 必须是引用类型 + 有无参构造
{ }

// 多个类型参数各自有约束
class MultiBox<T, K>
    where T : class, new()
    where K : struct
{ }
```

**约束使用场景：**

```csharp
// 错误示范：不约束时不能用 new T()
class UnconstrainedBox<T>
{
    //public T t = new T();  // 编译错误：无法确定 T 有无无参构造
}

// 正确：加上 new() 约束后可以
class ConstrainedBox<T> where T : new()
{
    public T t = new T();    // OK
}
```

> **记忆口诀**：`struct` 管值类型，`class` 管引用类型，`new()` 管能构造，基类/接口管继承关系。约束让泛型代码从"什么都能装"变成"符合条件的才能装"。

---

## 十一、集合

集合类是存放一组数据的容器。分为**非泛型集合**（`System.Collections`，存 `object`）和**泛型集合**（`System.Collections.Generic`，类型安全）两类。先学非泛型理解概念，再学泛型版本——泛型版本是日常开发首选。

### 11.1 非泛型集合（System.Collections）

#### 11.1.I ArrayList（可变数组）


解决了普通数组**长度固定**的问题：可以动态增删，长度自动变化。

```csharp
using System.Collections;

ArrayList array = new ArrayList();

// 增 —— 可以放任意类型
array.Add(1);
array.Add("123");
array.Add(true);
array.Add(new Test());       // 自定义类也可以

ArrayList array2 = new ArrayList();
array2.Add(123);
array.AddRange(array2);      // 把另一个集合整体追加进来

array.Insert(1, "插入的元素"); // 指定位置插入

// 删
array.Remove(1);             // 从头删除第一个值为1的元素
array.RemoveAt(2);           // 删除指定索引的元素
//array.Clear();             // 清空所有元素

// 查
Console.WriteLine(array[0]);          // 索引访问
array.Contains("123");                // 是否包含某元素 → bool
int index = array.IndexOf(true);      // 正向查找，返回索引；找不到返回 -1
int lastIndex = array.LastIndexOf(true); // 反向查找

// 改
array[0] = "999";            // 索引赋值

// 遍历
for (int i = 0; i < array.Count; i++)   // Count = 元素个数（不是 Length）
    Console.WriteLine(array[i]);

foreach (object item in array)          // 遍历出来都是 object
    Console.WriteLine(item);
```

> 与数组对比：数组用 `Length`，ArrayList 用 `Count`。ArrayList 存的是 `object`，取出使用时可能需要类型转换。

#### 11.1.II Hashtable（哈希表）


以**键值对（key-value）**形式存储，类似字典。**key 唯一，value 可以重复**。

```csharp
using System.Collections;

Hashtable hashtable = new Hashtable();

// 增 —— key 和 value 都可以是任意类型
hashtable.Add(1, "123");
hashtable.Add("123", 2);
hashtable.Add(true, false);

// 删
hashtable.Remove(1);         // 只能通过 key 删除
hashtable.Remove(2);         // 删除不存在的 key 不会报错
hashtable.Clear();           // 清空

// 查 —— 通过 key 取值，找不到返回 null
Console.WriteLine(hashtable[1]);
Console.WriteLine(hashtable[4]);        // null

hashtable.Contains(1);                 // 按 key 判断是否存在
hashtable.ContainsKey(2);              // 等价写法
hashtable.ContainsValue("123");        // 按 value 判断是否存在

// 改 —— 只能改 value，不能改 key
hashtable[1] = 100.5f;

// 遍历
Console.WriteLine(hashtable.Count);    // 键值对个数

// 1. 遍历 key
foreach (object key in hashtable.Keys)
    Console.WriteLine("键:" + key + " 值:" + hashtable[key]);

// 2. 遍历 value
foreach (object value in hashtable.Values)
    Console.WriteLine("值:" + value);

// 3. 遍历键值对（DictionaryEntry 是键值对结构体）
foreach (DictionaryEntry item in hashtable)
    Console.WriteLine("键:" + item.Key + ", 值:" + item.Value);

// 4. 迭代器遍历
IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
while (myEnumerator.MoveNext())
    Console.WriteLine("键:" + myEnumerator.Key + ", 值:" + myEnumerator.Value);
```

#### 11.1.III Queue（队列）


**先进先出（FIFO）**。就像排队：先来的先走。只能从队首取、队尾进。

```csharp
using System.Collections;

Queue queue = new Queue();

// 增 —— 入队（队尾）
queue.Enqueue(1);
queue.Enqueue("123");
queue.Enqueue(1.4f);

// 取 —— 出队（队首），取出后元素被移除
object v = queue.Dequeue();
Console.WriteLine(v);        // 1

// 查
v = queue.Peek();            // 只看队首，不移除
queue.Contains("123");       // 是否包含某元素

// 改
// 队列不支持直接修改元素，要先 Dequeue 出来，改完再 Enqueue 回去
queue.Clear();               // 清空

// 遍历
foreach (object item in queue)
    Console.WriteLine(item);

object[] array = queue.ToArray();   // 转成数组

while (queue.Count > 0)             // 边取边删，直到取空
    Console.WriteLine(queue.Dequeue());
```

> 队列只关心两端的操作，中间的元素不能直接访问。

#### 11.1.IV Stack（栈）


**后进先出（LIFO）**。就像叠盘子：最后放的先拿。只能从栈顶存取。

```csharp
using System.Collections;

Stack stack = new Stack();

// 增 —— 入栈（压到栈顶）
stack.Push(1);
stack.Push("123");
stack.Push(true);

// 取 —— 出栈（弹栈顶），取出后元素被移除
object v = stack.Pop();
Console.WriteLine(v);        // true（最后放的先出来）

// 查
v = stack.Peek();            // 只看栈顶，不移除
stack.Contains("123");       // 是否包含某元素

// 改
// 栈中的元素无法直接修改，也没有索引器，不能用 for 循环遍历
stack.Clear();               // 清空

// 遍历
foreach (object item in stack)       // foreach 从栈顶开始
    Console.WriteLine(item);

object[] arr = stack.ToArray();      // 转成数组

while (stack.Count > 0)
    Console.WriteLine(stack.Pop());
```

#### 11.1.V 四者对比


| 集合 | 结构 | 顺序 | 增删位置 | 特点 |
|------|------|------|----------|------|
| `ArrayList` | 动态数组 | 插入顺序 | 任意位置 | 可动态增删、可索引访问 |
| `Hashtable` | 键值对 | 无序 | 按 key | key 唯一，查找快 |
| `Queue` | 队列 | FIFO | 队尾进、队首出 | 先进先出 |
| `Stack` | 栈 | LIFO | 栈顶进出 | 后进先出 |

> 这些是非泛型集合，存取的是 `object`（有装箱/拆箱开销）。泛型版本 `List<T>`、`Dictionary<K,V>`、`Queue<T>`、`Stack<T>` 类型安全且性能更好，是日常开发的首选。

---

### 11.2 泛型集合（System.Collections.Generic）

#### 11.2.I List\<T\> 的增删查改


```csharp
using System.Collections.Generic;

List<int> list = new List<int>();       // 声明时指定元素类型
List<string> list2 = new List<string>();
List<bool> list3 = new List<bool>();
```

**增：**

```csharp
list.Add(1);                    // 末尾追加
list.Add(2);
list.Add(3);

List<string> other = new List<string>();
other.Add("123");
list2.AddRange(other);          // 整体追加另一个集合

list.Insert(0, 999);            // 指定位置插入
```

**删：**

```csharp
list.Remove(1);                 // 按值删除第一个匹配项
list.RemoveAt(0);               // 按索引删除
list.Clear();                   // 清空所有元素
```

**查：**

```csharp
Console.WriteLine(list[0]);     // 索引访问

list.Contains(1);               // 是否包含 → bool

int index = list.IndexOf(2);    // 正向查找，返回索引；找不到返回 -1
int last = list.LastIndexOf(2); // 反向查找
```

**改：**

```csharp
list[0] = 99;                   // 索引赋值
```

**遍历：**

```csharp
Console.WriteLine(list.Count);      // 元素个数
Console.WriteLine(list.Capacity);   // 容量（自动扩容）

for (int i = 0; i < list.Count; i++)    // for 遍历
    Console.WriteLine(list[i]);

foreach (int item in list)              // foreach 遍历
    Console.WriteLine(item);
```

#### 11.2.II List\<T\> vs ArrayList


| | `List<T>`（泛型） | `ArrayList`（非泛型） |
|---|------|------|
| **类型安全** | 编译期确定，只能存 T 类型 | 存 `object`，什么都能塞 |
| **装箱拆箱** | 无（值类型直接存储） | 有（值类型装箱） |
| **性能** | 快 | 慢（有装箱开销） |
| **取值** | 直接得到 T，无需强转 | 取出是 `object`，需强转 |

```csharp
// ArrayList 的痛点
ArrayList list = new ArrayList();
list.Add(1);                  // 装箱
int a = (int)list[0];         // 取出需强转，还可能类型不一致出错

// List<T> 的改进
List<int> list = new List<int>();
list.Add(1);                  // 直接存 int，无装箱
int a = list[0];              // 直接得到 int，无需强转
```

> 日常开发优先用 `List<T>`。后续的 `Dictionary<K,V>`（键值对）、`Queue<T>`（队列）、`Stack<T>`（栈）也都是对应非泛型版本的泛型替代品。

#### 11.2.III Dictionary\<K, V\>（泛型键值对）


`Dictionary<K, V>` 是 `Hashtable` 的泛型版本，以**键值对**存储，**key 唯一、value 可重复**。声明时指定 key 和 value 的类型，无需装箱拆箱和强转。

```csharp
Dictionary<int, string> dictionary = new Dictionary<int, string>();
```

**增删查改：**

```csharp
// 增
dictionary.Add(1, "123");
dictionary.Add(2, "222");
dictionary.Add(3, "222");        // value 可以重复

// 删
dictionary.Remove(1);            // 按 key 删除
dictionary.Remove(4);            // 删除不存在的 key 不会报错
dictionary.Clear();              // 清空

// 查 —— 通过 key 取值
Console.WriteLine(dictionary[2]);    // "222"
Console.WriteLine(dictionary[1]);    // "123"

dictionary.ContainsKey(1);           // 按 key 判断是否存在
dictionary.ContainsValue("222");     // 按 value 判断是否存在

// 改 —— 只能改 value，不能改 key
dictionary[3] = "555";
Console.WriteLine(dictionary[3]);    // "555"
```

**遍历（三种方式）：**

```csharp
Console.WriteLine(dictionary.Count);     // 键值对个数

// 1. 遍历 key（通过 key 取 value）
foreach (int item in dictionary.Keys)
    Console.WriteLine(item + ":" + dictionary[item]);

// 2. 遍历 value
foreach (string item in dictionary.Values)
    Console.WriteLine(item);

// 3. 遍历键值对（KeyValuePair<K,V> 结构体）
foreach (KeyValuePair<int, string> item in dictionary)
    Console.WriteLine("键:" + item.Key + "；值:" + item.Value);
```

> `Dictionary<K,V>` 与 `Hashtable` 的关系，等同于 `List<T>` 与 `ArrayList`：前者类型安全、无装箱、性能更好，日常开发优先用泛型版。

#### 11.2.IV LinkedList\<T\>（双向链表）


**概念与原理：**

`LinkedList<T>` 是 .NET 内置的**双向链表**，位于 `System.Collections.Generic`。与第十二章手写的单向链表不同，它的每个节点 `LinkedListNode<T>` 同时记录**前一个节点**和**后一个节点**两个引用：

```
                 ┌────┐   ┌────┐   ┌────┐
   null ◄─────── │ 10 │ ◄─│ 20 │ ◄─│ 30 │ ◄─────── null
                 │    │───>│    │───>│    │
                 └────┘   └────┘   └────┘
                 First              Last
```

- **双向**：既能从头往尾走（`Next`），也能从尾往头走（`Previous`）
- **没有索引器**：不能 `list[2]` 按下标访问，只能从头部/尾部遍历
- **增删快**：中间插入/删除只改节点引用，不需要移动元素（O(1)）
- **查改慢**：查找必须从头/尾遍历（O(n)）

**创建：**

```csharp
LinkedList<int> linkedList = new LinkedList<int>();
```

**增（四种方式）：**

| 方法 | 说明 |
|------|------|
| `AddFirst(value)` | 在头部添加 |
| `AddLast(value)` | 在尾部添加 |
| `AddAfter(node, value)` | 在指定节点**之后**插入 |
| `AddBefore(node, value)` | 在指定节点**之前**插入 |

```csharp
linkedList.AddLast(10);             // [10]
linkedList.AddFirst(20);            // [20, 10]
linkedList.AddLast(30);             // [20, 10, 30]

// 在指定节点前后插入 —— 先 Find 定位到节点
LinkedListNode<int> node = linkedList.Find(10);
linkedList.AddAfter(node, 15);      // [20, 10, 15, 30]
linkedList.AddBefore(node, 12);     // [20, 12, 10, 15, 30]
```

**删：**

| 方法 | 说明 |
|------|------|
| `RemoveFirst()` | 删除头节点 |
| `RemoveLast()` | 删除尾节点 |
| `Remove(value)` | 按值删除第一个匹配节点 |
| `Remove(node)` | 删除指定节点 |
| `Clear()` | 清空所有节点 |

```csharp
linkedList.RemoveFirst();           // 删除头部
linkedList.RemoveLast();            // 删除尾部
linkedList.Remove(12);              // 按值删除
linkedList.Clear();                 // 清空
```

**查：**

| 成员 | 说明 |
|------|------|
| `First` | 头节点（`LinkedListNode<T>`） |
| `Last` | 尾节点（`LinkedListNode<T>`） |
| `Find(value)` | 按值从头查找节点，找不到返回 `null` |
| `FindLast(value)` | 按值从尾查找节点 |
| `Contains(value)` | 是否包含 → bool |
| `Count` | 节点个数 |

```csharp
LinkedListNode<int> first = linkedList.First;   // 头节点
LinkedListNode<int> last = linkedList.Last;     // 尾节点

LinkedListNode<int> node = linkedList.Find(3);  // 按值查找
Console.WriteLine(node.Value);                  // 3

linkedList.Contains(1);             // true/false
```

**改（通过节点改值）：**

```csharp
Console.WriteLine(linkedList.First.Value);   // 1
linkedList.First.Value = 10;                 // 修改节点值
Console.WriteLine(linkedList.First.Value);   // 10
```

> 链表没有索引器，**改也只能通过节点**（`First.Value` / `Find(...).Value`），不能 `linkedList[0] = x`。

**遍历（三种方式）：**

```csharp
// 1. foreach 直接遍历值
foreach (int item in linkedList)
    Console.WriteLine(item);

// 2. 从头到尾：用 Next 逐个走
LinkedListNode<int> node = linkedList.First;
while (node != null)
{
    Console.WriteLine(node.Value);
    node = node.Next;
}

// 3. 从尾到头：用 Previous（双向链表的独有能力）
node = linkedList.Last;
while (node != null)
{
    Console.WriteLine(node.Value);
    node = node.Previous;
}
```

**LinkedList\<T\> vs List\<T\>：**

| | `List<T>`（动态数组） | `LinkedList<T>`（双向链表） |
|---|------|------|
| **底层** | 连续数组（顺序存储） | 分散节点（链式存储） |
| **下标访问** | `list[2]` 直接访问 O(1) | 不支持索引器 |
| **中间插入/删除** | 慢：移动元素 O(n) | 快：只改引用 O(1) |
| **内存** | 连续空间，可能扩容拷贝 | 每节点多存前后两个引用 |
| **适用** | 频繁按下标查改 | 频繁在中间增删 |

> **选择原则**：需要下标访问、频繁查改 → `List<T>`；频繁在头部/中间插入删除 → `LinkedList<T>`。

#### 11.2.V 泛型 Stack\<T\>

**概念与原理：**

第十一章 11.1 学过非泛型 `Stack`（后进先出 LIFO）。泛型版本 `Stack<T>` 结构、规则、API 完全一样，只是**声明时指定元素类型**，不再存 `object`，避免了装箱拆箱和强转。

```
Stack<T>（后进先出 LIFO，像叠盘子）
    ┌───┐
    │ 3 │ ← 栈顶（最后进，最先出）
    ├───┤
    │ 2 │
    ├───┤
    │ 1 │ ← 栈底
    └───┘
```

**API：**

| 方法 | 说明 |
|------|------|
| `Push(value)` | 入栈（压到栈顶） |
| `Pop()` | 出栈（弹出栈顶，元素被移除） |
| `Peek()` | 只看栈顶，不移除 |
| `Contains(value)` | 是否包含 → bool |
| `Clear()` | 清空 |
| `Count` | 元素个数 |
| `ToArray()` | 转成数组 |

```csharp
Stack<int> stack = new Stack<int>();

stack.Push(1);                  // [1]
stack.Push(2);                  // [1, 2]
stack.Push(3);                  // [1, 2, 3]

int top = stack.Pop();          // 3（最后进的先出）
Console.WriteLine(top);

top = stack.Peek();             // 2（只看不移除）
stack.Contains(2);              // true
stack.Count;                    // 2
```

> 栈的典型场景：撤销操作（Ctrl+Z 的记录栈）、函数调用栈、浏览器的后退历史。

#### 11.2.VI 泛型 Queue\<T\>

**概念与原理：**

第十一章 11.1 学过非泛型 `Queue`（先进先出 FIFO）。泛型版本 `Queue<T>` 结构、规则、API 完全一样，只是**声明时指定元素类型**，不再存 `object`，避免了装箱拆箱和强转。

```
Queue<T>（先进先出 FIFO，像排队）
    ┌───┐
    │ 1 │ ← 队首（最先出）
    ├───┤
    │ 2 │
    ├───┤
    │ 3 │ ← 队尾（最后进）
    └───┘
```

**API：**

| 方法 | 说明 |
|------|------|
| `Enqueue(value)` | 入队（加到队尾） |
| `Dequeue()` | 出队（取队首，元素被移除） |
| `Peek()` | 只看队首，不移除 |
| `Contains(value)` | 是否包含 → bool |
| `Clear()` | 清空 |
| `Count` | 元素个数 |
| `ToArray()` | 转成数组 |

```csharp
Queue<int> queue = new Queue<int>();

queue.Enqueue(1);               // [1]
queue.Enqueue(2);               // [1, 2]
queue.Enqueue(3);               // [1, 2, 3]

int head = queue.Dequeue();     // 1（先来的先出）
Console.WriteLine(head);

head = queue.Peek();            // 2（只看不移除）
queue.Contains(2);              // true
queue.Count;                    // 2
```

> 队列的典型场景：消息队列、任务调度、打印机任务排队、游戏匹配排队。

**泛型 vs 非泛型：**

| | `Stack<T>` / `Queue<T>` | `Stack` / `Queue` |
|---|------|------|
| **类型安全** | 只能存 T 类型，编译期检查 | 存 `object`，什么都能塞 |
| **装箱拆箱** | 无 | 值类型有装箱开销 |
| **取值** | 直接得到 T | 需强转 |

```csharp
// 非泛型：装箱 + 强转
Stack stack = new Stack();
stack.Push(1);
int a = (int)stack.Pop();

// 泛型：直接存取，无装箱无强转
Stack<int> stack2 = new Stack<int>();
stack2.Push(1);
int b = stack2.Pop();
```

> 日常开发直接用泛型版本 `Stack<T>` / `Queue<T>`。


---

## 十二、顺序存储和链式存储

数据在内存中存储的两种基本方式，决定了增删查改的性能差异。

### 12.1 顺序存储（数组）

元素**连续**存放在内存中，通过下标直接访问。

```
内存地址:  [0]  [1]  [2]  [3]  [4]
           ┌────┬────┬────┬────┬────┐
           │ 10 │ 20 │ 30 │ 40 │ 50 │
           └────┴────┴────┴────┴────┘
```

- **查/改快**：`arr[2]` 直接按下标跳转，O(1)
- **增/删慢**：中间插入/删除要移动后面的所有元素，O(n)

```csharp
int[] array = { 10, 20, 30, 40, 50 };
Console.WriteLine(array[2]);    // 30 —— 下标直达，快

// 中间插入：后面的元素全部后移
// [10][20][30][40][50] → [10][99][20][30][40][50]
```

### 12.2 链式存储（链表）

元素**分散**在内存中，每个节点（Node）记录自己的值 + 下一个节点的位置（引用），用"链"串起来。

```
head                                          tail
 │                                             │
 ▼                                             ▼
┌──────┬────┐   ┌──────┬────┐   ┌──────┬────┐   ┌──────┬────┐
│ 值:10│ ●──┼──>│ 值:20│ ●──┼──>│ 值:30│ ●──┼──>│ 值:40│ ●──┼──> null
└──────┴────┘   └──────┴────┘   └──────┴────┘   └──────┴────┘
  Node            Node            Node            Node
```

**节点结构：**

```csharp
class LinkedNode<T>
{
    public T value;                 // 当前节点的值
    public LinkedNode<T> NextNode;  // 记录下一个节点的位置

    public LinkedNode(T value)
    {
        this.value = value;
    }
}
```

**链表管理类：**

```csharp
class LinkedList<T>
{
    public LinkedNode<T> head;   // 头节点
    public LinkedNode<T> tail;   // 尾节点

    // 添加 —— 新节点挂到尾部
    public void Add(T value)
    {
        LinkedNode<T> node = new LinkedNode<T>(value);
        if (head == null)        // 链表为空
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.NextNode = node;   // 原尾节点指向新节点
            tail = node;            // 更新尾节点
        }
    }

    // 删除 —— 断开中间节点
    public void Remove(T value)
    {
        if (head == null)
            return;
        else if (head.value.Equals(value))   // 删除头节点
        {
            head = head.NextNode;
            if (head == null)                // 只有一个节点，删完链表空了
                tail = null;
            return;
        }

        LinkedNode<T> node = head;
        while (node.NextNode != null)        // 遍历找目标
        {
            if (node.NextNode.value.Equals(value))
            {
                node.NextNode = node.NextNode.NextNode;  // 跳过目标节点
                break;
            }
            node = node.NextNode;
        }
    }
}
```

**使用：**

```csharp
LinkedList<int> link = new LinkedList<int>();
link.Add(1);
link.Add(2);
link.Add(3);

// 遍历 —— 只能从头节点开始逐个访问
LinkedNode<int> node = link.head;
while (node != null)
{
    Console.WriteLine(node.value);
    node = node.NextNode;
}
```

### 12.3 两种存储方式对比

| | 顺序存储（数组） | 链式存储（链表） |
|---|------|------|
| **内存布局** | 连续 | 分散，靠引用连接 |
| **查/改** | 快：下标直达 O(1) | 慢：必须从头遍历 O(n) |
| **增/删** | 慢：需要移动元素 O(n) | 快：改引用即可 O(1) |
| **空间** | 需要连续大块内存 | 每个节点多存一个引用，略占空间 |

```csharp
// 增：链式优于顺序（中间插入时链式不用移动位置）
// 删：链式优于顺序（中间删除时链式不用移动位置）
// 查：顺序优于链式（数组下标直达，链表要遍历）
// 改：顺序优于链式（数组下标直达，链表要遍历）
```

> **总结**：频繁查改用数组（List\<T\>），频繁中间增删用链表（LinkedList\<T\>，但 .NET 自带的 LinkedList\<T\> 是双向链表）。