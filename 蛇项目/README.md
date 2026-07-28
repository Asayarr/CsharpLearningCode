# 贪食蛇

> 基于控制台的经典贪食蛇游戏，采用面向对象分层架构，从场景管理到游戏实体逐层构建。

## 运行

```bash
dotnet run --project 贪食蛇
```

## 操作

| 按键 | 功能 |
|------|------|
| `W` / `↑` | 上移 / 菜单上选 |
| `S` / `↓` | 下移 / 菜单下选 |
| `A` / `←` | 左移 |
| `D` / `→` | 右移 |
| `J` / `Enter` | 确认 |

## 项目结构

```
蛇项目/
├── UML类图.vsdx              # 类图
├── 蛇项目.slnx               # 解决方案
└── 贪食蛇/
    ├── Program.cs             # 入口
    ├── lesson1/               # 游戏框架与场景接口
    │   ├── Game.cs            # 主循环 + 窗口设置 + 场景切换
    │   └── ISceneUpdate.cs    # 场景更新接口
    ├── lesson2/               # 菜单场景
    │   ├── BeginOrEndBaseScene.cs  # 开始/结束场景基类（抽象类）
    │   ├── StartScene.cs      # 开始界面
    │   └── EndSence.cs        # 结束界面
    ├── lesson3/               # 游戏对象基类
    │   ├── IDraw.cs           # 绘制接口
    │   ├── GameObject.cs      # 游戏对象抽象类
    │   └── position.cs        # 坐标结构体（含运算符重载）
    ├── lesson4/               # 游戏实体
    │   ├── Wall.cs            # 墙壁
    │   ├── Food.cs            # 食物
    │   └── SnakeBody.cs       # 蛇身节点（头/身体）
    ├── lesson5/               # 地图
    │   └── Map.cs             # 地图 + 墙壁初始化
    └── lesson6/               # 蛇
        └── Snake.cs           # 蛇的移动、方向控制
```

## 架构设计

### 场景管理（状态模式）

```
ISceneUpdate (接口)
  ├── BeginOrEndBaseScene (抽象类：菜单选择逻辑)
  │     ├── StartScene      → 开始界面 → 进入游戏 / 退出
  │     └── EndSence        → 结束界面 → 返回开始 / 退出
  └── GameScene             → 游戏主场景
```

`Game.ChangeScene()` 切换场景，主循环中通过 `ISceneUpdate.Update()` 实现多态调用。

### 游戏对象继承树

```
IDraw (接口：Draw)
  ├── Map (地图，管理墙壁数组)
  └── GameObject (抽象类：位置 + Draw)
        ├── Wall       (红色 ■)
        ├── Food       (青色 ※)
        └── SnakeBody  (蛇头 ● 黄色 / 蛇身 ○ 绿色)
```

### 蛇的移动

每 `updateIndex % 4444 == 0` 帧移动一次（简易帧率控制）。移动时擦除尾部（写空格），根据 `E_MoveDir` 修改蛇头坐标。`ChangeDir()` 防止 180° 掉头和同方向重复设置。

## 覆盖的知识点

| 知识点 | 应用位置 |
|--------|----------|
| 接口 | `ISceneUpdate`、`IDraw` |
| 抽象类 | `GameObject`、`BeginOrEndBaseScene` |
| 继承 | `Wall/Food/SnakeBody → GameObject`、`StartScene/EndSence → BeginOrEndBaseScene` |
| 多态 | `ISceneUpdate.Update()`、`IDraw.Draw()` |
| 结构体 | `Position` |
| 运算符重载 | `Position.==` / `Position.!=` |
| 枚举 | `E_SceneType`、`E_MoveDir`、`E_SnakeBodyType` |
| 静态成员 | `Game.nowScene`、`Game.ChangeScene()` |
| 数组 | `walls[]`（墙壁）、`bodys[]`（蛇身） |
| 控制台 API | `SetCursorPosition`、`SetWindowSize`、`ForegroundColor`、`KeyAvailable`、`ReadKey` |
