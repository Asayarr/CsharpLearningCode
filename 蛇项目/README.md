# 贪食蛇

> 基于控制台的经典贪食蛇，采用面向对象分层架构，从场景状态机、游戏对象继承树到碰撞检测系统逐层构建。


## 目录

- [快速开始](#快速开始)
- [操作说明](#操作说明)
- [项目结构](#项目结构)
- [架构设计](#架构设计)
- [游戏流程](#游戏流程)
- [核心模块详解](#核心模块详解)
- [关键算法](#关键算法)
- [面向对象概念应用](#面向对象概念应用)


## 快速开始

```bash
dotnet run --project 贪食蛇
```

窗口大小 80×20，建议使用支持中文的控制台（Windows Terminal 或 VS Code 终端）。


## 操作说明

### 菜单界面

| 按键 | 功能 |
|------|------|
| `W` / `↑` | 上移选择 |
| `S` / `↓` | 下移选择 |
| `J` / `Enter` | 确认选择 |

菜单有两个选项：开始游戏 / 结束游戏。当前选中项以红色高亮。

### 游戏界面

| 按键 | 功能 |
|------|------|
| `W` | 蛇向上移动 |
| `S` | 蛇向下移动 |
| `A` | 蛇向左移动 |
| `D` | 蛇向右移动 |

规则：
- 吃到食物（青色 `※`）蛇身增长一节
- 撞墙或撞到自己身体则游戏结束，切换到结束界面
- 不能 180° 掉头（如正在向右时不能直接按左）


## 项目结构

```
蛇项目/
├── UML类图.vsdx             # 类图
├── 蛇项目.slnx              # 解决方案
├── README.md                # 本文档
└── 贪食蛇/
    ├── Program.cs            # 程序入口
    ├── 贪食蛇.csproj          # 项目文件
    ├── lesson1/              # 游戏框架
    │   ├── Game.cs           # 游戏主循环、窗口初始化、场景切换
    │   └── ISceneUpdate.cs   # 场景更新接口
    ├── lesson2/              # 菜单场景
    │   ├── BeginOrEndBaseScene.cs  # 菜单基类（抽象类）
    │   ├── StartScene.cs     # 开始界面
    │   ├── EndSence.cs       # 结束界面
    │   └── GameScene.cs      # 游戏主场景
    ├── lesson3/              # 游戏对象基础
    │   ├── IDraw.cs          # 绘制接口
    │   ├── GameObject.cs     # 游戏对象抽象基类
    │   └── position.cs       # 坐标结构体
    ├── lesson4/              # 游戏实体
    │   ├── Wall.cs           # 墙壁
    │   ├── Food.cs           # 食物
    │   └── SnakeBody.cs      # 蛇身节点（蛇头/蛇身）
    ├── lesson5/              # 地图
    │   └── Map.cs            # 地图与墙壁管理
    └── lesson6/              # 蛇
        └── Snake.cs          # 蛇的移动、碰撞、吃食物、增长
```

项目按 lesson1~6 分层，对应面向对象概念由浅入深的学习路径：

| 分层 | 学习内容 |
|------|----------|
| lesson1 | 类、枚举、静态成员、主循环 |
| lesson2 | 接口、抽象类、继承、模板方法模式 |
| lesson3 | 接口、抽象类、结构体、运算符重载 |
| lesson4 | 继承、枚举、随机数 |
| lesson5 | 数组、循环、构造函数 |
| lesson6 | 数组操作、碰撞检测、递归（食物随机位置） |


## 架构设计

### 场景状态机

游戏使用简单的状态机管理三个场景的切换：

```
    ┌──────────┐  开始游戏  ┌──────────┐
    │  Start   │ ─────────> │   Game   │
    │  开始界面 │            │  游戏场景 │
    └──────────┘            └──────────┘
         ^                       │
         │      撞墙/撞自己       │
         │    ┌──────────┐       │
         └─── │   End    │ <─────┘
              │  结束界面 │
              └──────────┘
```

- `Game.nowScene` 持有当前场景（`static ISceneUpdate`）
- `Game.ChangeScene(type)` 清屏后切换场景实例
- 主循环调用 `nowScene.Update()`，多态分发到具体场景

### 接口与抽象基类

```
ISceneUpdate (接口)
  │
  ├── BeginOrEndBaseScene (抽象类)
  │     │  [模板方法：Update() 实现菜单绘制 + 输入处理]
  │     │  [抽象方法：EneterJorEnterDoSomething() — 子类决定确认后的行为]
  │     ├── StartScene
  │     └── EndSence
  │
  └── GameScene
        │  [持有 Map + Snake + Food]
        │  [Update()：帧率控制 → 绘制 → 移动 → 碰撞检测 → 吃食物 → 输入]

IDraw (接口)
  │
  ├── Map
  │     └── 管理 Wall[] 数组，边界生成算法
  │
  └── GameObject (抽象类)
        │  [字段：Position pos]
        │  [抽象方法：Draw()]
        ├── Wall      (红色 ■)
        ├── Food      (青色 ※)
        └── SnakeBody (蛇头 ● 黄色 / 蛇身 ○ 绿色)
```

### 蛇的内部结构

```csharp
class Snake : IDraw
{
    SnakeBody[] bodys;    // 固定容量 200，前 nowLength 个有效
    int nowLength;        // 当前身体长度（初始 1）
    E_MoveDir moveDir;    // 当前移动方向（初始 Right）
}
```

身体跟随逻辑（`Move` 方法）：

1. 擦除尾部：在最后一节的位置写空格
2. 身体跟随：从尾到头，每节坐标 = 前一节坐标
3. 蛇头移动：根据 `moveDir` 修改蛇头坐标（x 步长为 2，因为中文字符占两个英文字符宽度）


## 核心模块详解

### Game.cs — 游戏框架

| 成员 | 说明 |
|------|------|
| `w = 80, h = 20` | 控制台窗口宽高（`const`） |
| `nowScene` | 当前场景（`static`，游戏生命周期内唯一） |
| `Game()` | 构造函数：隐藏光标、设置窗口/缓冲区大小、切换到开始场景 |
| `Start()` | 主循环：`while(true)` 持续调用 `nowScene.Update()` |
| `ChangeScene(type)` | 清屏 → 根据 `E_SceneType` 创建新场景实例 |

### BeginOrEndBaseScene.cs — 菜单模板

抽象类，实现 `ISceneUpdate.Update()`，封装了菜单的通用逻辑：

- 居中绘制标题（`title`）
- 居中绘制第一选项（`choiceOne`）+ 固定第二选项"结束游戏"
- 红/白高亮当前选中项（`nowSelIndex`）
- 上下键切换选中项（带边界限制）
- Enter/J 键触发 `EneterJorEnterDoSomething()`（**模板方法**，由子类实现）

### StartScene.cs — 开始界面

`EneterJorEnterDoSomething()` 逻辑：
- 选中"开始游戏" → `Game.ChangeScene(E_SceneType.Game)`
- 选中"结束游戏" → `Environment.Exit(0)`

### EndSence.cs — 结束界面

`EneterJorEnterDoSomething()` 逻辑：
- 选中"回到开始界面" → `Game.ChangeScene(E_SceneType.Start)`
- 选中"结束游戏" → `Environment.Exit(0)`

### GameScene.cs — 游戏主场景

`Update()` 方法完成一帧的逻辑流程：

```
updateIndex % 4444 == 0 时执行一帧：
  1. map.Draw()           — 绘制墙壁
  2. food.Draw()          — 绘制食物
  3. snake.Move()         — 蛇移动
  4. snake.Draw()         — 绘制蛇
  5. snake.CheakEnd(map)  — 碰撞检测，撞墙/撞身则切换到 End 场景
  6. snake.CheakEatFood() — 检测是否吃到食物
```

帧率控制：`updateIndex % 4444` 是简单的忙等分频。每约 4444 次循环执行一帧（在循环内同时检测键盘输入）。

### Position.cs — 坐标结构体

```csharp
struct Position { int x; int y; }
```

- **值类型**：赋值时复制整个坐标，独立副本
- 重载 `==` 和 `!=`：比较 x 和 y 是否都相等
- 用于碰撞检测中的位置比较（蛇与墙壁、蛇与食物、蛇与自身）

### Food.cs — 食物

| 成员 | 说明 |
|------|------|
| `Food(Snake snake)` | 构造函数，调用 `RandomPos` 生成不重叠的位置 |
| `RandomPos(snake)` | 随机生成 x∈[2, w/2-1]*2, y∈[1, h-4]，若与蛇重叠则**递归**重新生成 |
| `Draw()` | 青色 `※` |

> x 坐标限制为偶数（`*2`），确保对齐控制台字符网格。

### SnakeBody.cs — 蛇身节点

```
E_SnakeBodyType { Head = 蛇头, Body = 蛇身 }
```

| 成员 | 说明 |
|------|------|
| `type` | 区分蛇头/蛇身（决定绘制的字符和颜色） |
| `Draw()` | 蛇头 → 黄色 `●`，蛇身 → 绿色 `○` |

继承自 `GameObject`，通过 `type` 字段实现同类的形态差异。

### Map.cs — 地图

构造函数在窗口边界生成墙壁数组：

```
walls = new Wall[Game.w + (Game.h - 3) * 2]
```

- 上边界 + 下边界：遍历 x∈[0, w)，步长 2
- 左边界 + 右边界：遍历 y∈[1, h-2)
- 底部留 2 行空白（h-2 处画墙，h-1/h 行不使用）

### Snake.cs — 蛇

| 方法 | 说明 |
|------|------|
| `Snake(x, y)` | 创建容量 200 的数组，初始化蛇头，初始长度为 1，方向向右 |
| `Draw()` | 绘制所有身体节点 |
| `Move()` | 擦尾 → 身体跟随 → 蛇头按方向移动 |
| `ChangeDir(dir)` | 改方向，过滤同方向和 180° 反转 |
| `CheakEnd(map)` | 检测是否撞墙（遍历 walls）+ 检测是否撞自己（遍历 bodys[1..]） |
| `CheakSamePos(p)` | 检测给定位置是否与蛇身任意节点重叠 |
| `CheakEatFood(food)` | 蛇头与食物重叠 → 食物重新随机 + 蛇增长 |
| `AddBody()` | 在尾部追加一节蛇身（私有方法） |


## 关键算法

### 蛇的移动（跟随 + 擦除）

```
1. 记录最后一节位置
2. 在最后一节位置写 "  "（擦除尾部）
3. 从尾到头：bodys[i].pos = bodys[i-1].pos（每节跟随前一节）
4. 蛇头按方向偏移坐标
```

身体跟随后蛇头再移动，保证"拖尾"效果正确。

### 方向反转检测

`ChangeDir` 中的过滤逻辑：

- 同方向 → 忽略
- 长度 > 1 时，禁止直接反向：
  - Left ↔ Right
  - Up ↔ Down
- 长度 = 1（只有蛇头）时允许任意方向

### 食物随机位置

```csharp
x = Random.Range(2, w/2 - 1) * 2;   // 偶数，对齐网格
y = Random.Range(1, h - 4);          // 避开墙壁区域
if (snake.CheakSamePos(pos))
    RandomPos(snake);                // 递归重试直到不重叠
```

### 碰撞检测

**撞墙**：遍历 `map.walls[]`，比较蛇头 `pos == wall.pos`（使用重载的 `==`）

**撞自己**：遍历 `bodys[1..nowLength-1]`，比较蛇头 `pos == bodys[i].pos`


## 面向对象概念应用

| 概念 | 位置 | 说明 |
|------|------|------|
| **接口** | `ISceneUpdate`, `IDraw` | 定义场景更新和绘制契约 |
| **抽象类** | `GameObject`, `BeginOrEndBaseScene` | 定义公共字段和模板方法，强制子类实现 |
| **继承** | `Wall/Food/SnakeBody → GameObject`、`StartScene/EndSence → BeginOrEndBaseScene` | 代码复用和层级分类 |
| **多态** | `ISceneUpdate.Update()`, `IDraw.Draw()` | 父类/接口引用调用子类实现 |
| **模板方法** | `BeginOrEndBaseScene.Update()` → `EneterJorEnterDoSomething()` | 骨架在父类，步骤由子类填充 |
| **结构体** | `Position` | 值类型，栈分配，赋值独立副本 |
| **运算符重载** | `Position.==`, `Position.!=` | 比较两个坐标是否相同 |
| **枚举** | `E_SceneType`, `E_MoveDir`, `E_SnakeBodyType` | 给状态/方向/类型赋予语义名称 |
| **静态成员** | `Game.nowScene`, `Game.ChangeScene()` | 全局唯一的场景控制 |
| **常量** | `Game.w`, `Game.h` | 窗口大小不可变 |
| **数组** | `walls[]`（墙壁管理）, `bodys[]`（蛇身，固定预分配容量） | 定长集合 |
| **递归** | `Food.RandomPos()` | 生成食物位置直到不与蛇重叠 |
| **封装** | `AddBody()` 标记为 `private` | 仅蛇自身调用增长逻辑 |
