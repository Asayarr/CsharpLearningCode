# C# 练习题（共 20 题）

> 难度：⭐ 基础 &nbsp;&nbsp; ⭐⭐ 进阶 &nbsp;&nbsp; ⭐⭐⭐ 综合

---

## 一、语法基础 + 流程控制

### 题 1 — 猜数字游戏 ⭐
用 `Random` 生成一个 1~100 的随机数，让用户输入猜测，每次提示"大了"或"小了"，直到猜对，输出猜了多少次。

**涉及**：变量、输入输出、Random、while、if-else、int.Parse、异常处理

---

### 题 2 — 短路求值陷阱 ⭐
以下代码输出什么？为什么？

```csharp
int a = 5;
bool result = a < 3 && ++a > 10;
Console.WriteLine(a);
```

改成 `&` 后输出什么？

**涉及**：短路求值、位运算符 vs 逻辑运算符

---

### 题 3 — 99 乘法表 ⭐
用 `for` 循环打印标准九九乘法表，格式对齐。

**涉及**：嵌套 for、Console.Write、格式化输出

---

## 二、字符串与数组

### 题 4 — 敏感词过滤器 ⭐⭐
写一个方法 `FilterBadWords(string text, params string[] badWords)`：
- 将 text 中出现的所有敏感词替换为 `**`
- 考虑大小写不敏感
- 提示用户输入一段文字，内置 3 个敏感词，输出过滤结果

**涉及**：string 操作（Replace、IndexOf、大小写）、params 变长参数

---

### 题 5 — 字符串统计 ⭐
输入一行英文句子，统计：
- 字母数（不含空格和标点）
- 单词数（空格分隔）
- 出现次数最多的字母

**涉及**：string 遍历、char 判断、数组计数

---

### 题 6 — 数组去重（不借助集合类） ⭐⭐
给定一个 `int[]`，返回一个不含重复元素的新数组。不能用 `List`、`HashSet` 或 LINQ，只能手动遍历。

**涉及**：数组动态创建、手动扩容

---

### 题 7 — 数组旋转 ⭐
写一个方法 `Rotate(int[] arr, int k)`，将数组**向右**旋转 k 位。
例：`{1,2,3,4,5}` 旋转 2 位 → `{4,5,1,2,3}`

**涉及**：数组索引、元素交换、取余

---

## 三、面向对象 — 继承与多态

### 题 8 — 动物园系统 ⭐⭐
设计以下类层次：

```
Animal（抽象类）
├── 字段：name, age
├── 抽象方法：MakeSound()
├── 虚方法：Eat() → 输出"动物在吃"
│
├── Dog : Animal    → MakeSound: "汪汪"，Eat: "狗在啃骨头"
├── Cat : Animal    → MakeSound: "喵喵"，Eat: "猫在吃鱼"
└── Bird : Animal   → MakeSound: "叽叽"，同时实现 IFly 接口
```

接口 `IFly { void Fly(); }`，Bird 的 Fly 输出"鸟在飞"。

在 `Main` 中：创建 Animal[] 数组装各子类对象，遍历调用 MakeSound 和 Eat。判断哪些能飞并调用 Fly。

**涉及**：抽象类、虚方法、接口、里氏替换、is/as

---

### 题 9 — 构造函数链 ⭐⭐
设计以下继承链，验证构造顺序：

```
Base（打印"Base构造"）
└── Middle : Base（打印"Middle构造"）
    └── Derived : Middle（打印"Derived构造"，用 base() 传参）
```

每个构造都打印自己的名字。`new Derived()` 后输出顺序是什么？

**涉及**：继承中构造函数执行顺序、base()

---

### 题 10 — 多态 vs new 隐藏 ⭐⭐
写出以下代码的完整输出，解释 `virtual/override` 与 `new` 的区别：

```csharp
class Parent
{
    public virtual void A() => Console.WriteLine("Parent.A");
    public void B() => Console.WriteLine("Parent.B");
}

class Child : Parent
{
    public override void A() => Console.WriteLine("Child.A");
    public new void B() => Console.WriteLine("Child.B");
}

// Main:
Parent p = new Child();
p.A();
p.B();
(p as Child).B();
```

**涉及**：virtual/override 多态、new 方法隐藏

---

## 四、索引器与属性

### 题 11 — 自定义 MyString 类 ⭐⭐
写一个类 `MyString`，封装一个 `private string`：
- 用**索引器**通过 `[int]` 获取/修改单个字符
- 提供 `Length` 属性（只读）
- 重写 `ToString()`
- 写一个**拓展方法** `Reverse()` 为该类增加字符串反转功能

**涉及**：索引器、属性、ToString 重写、拓展方法

---

### 题 12 — 温度类 ⭐
写一个 `Temperature` 类：
- 私有 `celsius` 字段
- `Celsius` 属性（get/set）
- `Fahrenheit` 属性：读取时自动换算 °F = °C × 9/5 + 32，设置时反向换算
- set 中验证：不能低于 -273.15°C（绝对零度）

**涉及**：属性 get/set 逻辑、自动换算

---

## 五、设计原则

### 题 13 — 浅拷贝陷阱 ⭐⭐
写一个类 `Student`，包含 `int Id` 和 `int[] Scores`，用 `MemberwiseClone()` 实现 `Clone()`。验证修改克隆体 Scores[0] 是否影响原对象，解释为什么。

**涉及**：浅拷贝、MemberwiseClone、引用类型 vs 值类型

---

### 题 14 — 装箱拆箱性能 ⭐
写一个方法，将 1 到 100000 先装箱到 `object[]`，再逐个拆箱求和。写另一个方法直接用 `int[]` 求和。用 `Stopwatch` 比较两者时间。

**涉及**：装箱拆箱、object 数组、性能对比

---

## 六、综合项目

### 题 15 — 图书管理系统 ⭐⭐⭐
设计一个简单的图书管理系统：

```
Book（类）
├── Title, Author, ISBN, IsBorrowed
├── 构造函数
├── ToString() 重写 → 输出图书信息

Library（类）
├── private Book[] books（最多 100 本）
├── AddBook(Book) → 添加图书
├── BorrowBook(string isbn) → 借书（改状态）
├── ReturnBook(string isbn) → 还书
├── SearchByTitle(string title) → 返回匹配图书（部分匹配，大小写不敏感）
├── 索引器：通过 isbn 查找图书
```

**涉及**：类设计、数组管理、字符串搜索、索引器、属性、密封方法

---

### 题 16 — 简单 RPG 战斗 ⭐⭐⭐
用 OOP 设计一个回合制战斗系统：

```
Fighter（抽象类）
├── Name, HP, ATK, DEF
├── 抽象方法：Skill(Fighter target)
├── 虚方法：TakeDamage(int damage)
│
├── Warrior : Fighter   Skill → "重击"，伤害 = ATK × 2 - target.DEF
├── Mage : Fighter      Skill → "火球"，伤害 = ATK × 3 - target.DEF × 0.5
└── Rogue : Fighter     Skill → "背刺"，50% 概率暴击伤害翻倍（用 Random）

+ 接口 IHealable { void Heal(int amount); }
  └── Mage 实现：可以治疗自己 20 点
```

两个 Fighter 交替攻击，直到一方 HP ≤ 0。

**涉及**：抽象类、虚方法、接口、Random、运算符重载（可选）、枚举

---

### 题 17 — 运算符重载 ⭐⭐
为 `Vector2D` 结构体实现：
- `+`、`-`、`*`（点乘，返回 float）、`*`（与标量乘，返回 Vector2D）
- `==`、`!=`（判断两个向量是否等长？不，判断 x 和 y 是否都相等）
- 重写 `Equals` 和 `GetHashCode`

验证：`v1 + v2`、`v1 * 3`、`v1 == v2`

**涉及**：结构体、运算符重载、Equals/GetHashCode

---

## 七、命名空间练习

### 题 18 — 模拟多团队开发 ⭐⭐
在**同一个文件**中创建两个命名空间 `TeamA` 和 `TeamB`，各自定义一个 `Logger` 类（同名但功能不同）：
- `TeamA.Logger`：有一个 `Log(string msg)` 输出 `[TeamA] msg`
- `TeamB.Logger`：有一个 `Log(string msg)` 输出 `[TeamB] msg`

在 `Main` 中同时使用两个 Logger，展示如何处理命名冲突。

**涉及**：命名空间、using、全限定名

---

## 八、经典算法

### 题 19 — 递归：汉诺塔 ⭐⭐
用递归实现汉诺塔问题：n 个盘子从 A 柱移到 C 柱（B 为辅助），打印每一步移动。
输入 n=3 时输出标准移动序列。

**涉及**：递归、终止条件

---

### 题 20 — 冒泡排序 + 选择排序 ⭐⭐
写两个方法分别用冒泡排序和选择排序对 `int[]` 排序。代码不能参考笔记，凭理解写出。完成后用随机数组验证两者结果一致。

**涉及**：数组、循环、排序算法

---

## 参考答案与提示

> 建议先独立完成，实在卡住再往下看。

<details>
<summary>题 2 答案</summary>

- `&&` 短路求值：`a < 3` 为 `false`，右边 `++a` 不执行 → 输出 `5`
- `&` 不短路：两边都执行 → `++a` 执行 → 输出 `6`

</details>

<details>
<summary>题 9 答案</summary>

构造函数从顶级父类向下执行：
```
Base构造
Middle构造
Derived构造
```

</details>

<details>
<summary>题 10 答案</summary>

```
p.A()   → "Child.A"    // virtual+override，运行时多态，调子类版本
p.B()   → "Parent.B"   // 普通方法，编译时决定，父类引用调父类版本
(p as Child).B() → "Child.B"  // 转成子类引用后才调子类的 new 方法
```

</details>

</details>
