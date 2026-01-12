# Game 目录结构说明

## 目录结构

```
Game/
├── AssetsPackage/    # 资源文件夹 - 存放游戏相关的资源文件
│   └── (资源文件)
│
├── Editor/          # 编辑器扩展 - 存放编辑器模式下的扩展代码
│   └── (编辑器脚本)
│
├── Runtime/         # 运行时代码 - 存放运行时游戏逻辑的代码
│   └── (运行时脚本)
│
└── 3rd/             # 第三方库 - 存放第三方代码与库
    └── (第三方代码)
```

---

## 目录职责

### 📁 AssetsPackage/
**用途：** 存放游戏相关的资源文件

**包含内容：**
- 游戏Prefab预制体
- 游戏材质、贴图、模型等资源
- 游戏配置文件（ScriptableObject等）
- 游戏音频资源
- 游戏UI资源
- 其他游戏需要的资源文件

**建议子目录结构：**
```
AssetsPackage/
├── Prefab/          # 预制体
│   ├── Player/
│   ├── Enemy/
│   └── Item/
├── Material/        # 材质
├── Texture/         # 贴图
├── Model/           # 模型
├── Audio/           # 音频
│   ├── Music/
│   └── Sound/
├── UI/              # UI资源
│   ├── Sprite/
│   └── Font/
└── Config/          # 配置文件
    └── GameConfig.asset
```

---

### 📁 Editor/
**用途：** 存放编辑器模式下的扩展代码

**包含内容：**
- 游戏相关的编辑器窗口脚本
- 游戏组件的自定义Inspector脚本
- 游戏相关的编辑器菜单工具
- 游戏数据编辑器工具

**命名规范：**
- 所有脚本必须以 `.cs` 结尾
- 建议使用 `Editor` 后缀，如 `GameEditor.cs`
- 必须放在 `Editor` 文件夹中，Unity会自动识别为编辑器脚本

**示例：**
```
Editor/
├── GameEditor.cs          # 游戏编辑器
├── PlayerEditor.cs         # 玩家组件编辑器
├── LevelEditor.cs          # 关卡编辑器
└── GameMenu.cs             # 游戏相关菜单工具
```

**注意事项：**
- Editor文件夹中的脚本只在编辑器模式下编译
- 运行时代码不能引用Editor文件夹中的代码
- 使用 `#if UNITY_EDITOR` 预处理指令来区分编辑器代码
- 可以引用Runtime文件夹中的代码

---

### 📁 Runtime/
**用途：** 存放运行时游戏逻辑的代码

**包含内容：**
- 游戏逻辑代码
- 游戏数据类
- 游戏组件脚本
- 游戏管理器
- 游戏状态机
- 其他运行时需要的脚本

**建议子目录结构：**
```
Runtime/
├── Data/           # 游戏数据
│   ├── PlayerData.cs
│   ├── GameData.cs
│   └── LevelData.cs
├── Logic/          # 游戏逻辑
│   ├── Player/
│   │   ├── PlayerController.cs
│   │   └── PlayerState.cs
│   ├── Enemy/
│   │   ├── EnemyController.cs
│   │   └── EnemyAI.cs
│   └── Item/
│       ├── ItemController.cs
│       └── ItemEffect.cs
├── Manager/        # 游戏管理器
│   ├── GameManager.cs
│   └── LevelManager.cs
└── Component/      # 游戏组件
    ├── Health.cs
    └── Damage.cs
```

**命名空间建议：**
```
Game.Data           # 游戏数据
Game.Logic          # 游戏逻辑
Game.Logic.Player   # 玩家逻辑
Game.Logic.Enemy    # 敌人逻辑
Game.Manager        # 游戏管理器
Game.Component      # 游戏组件
```

**注意事项：**
- Runtime文件夹中的代码会在运行时编译
- 可以被其他游戏逻辑层引用
- 不应该引用Editor文件夹中的代码
- 可以引用FrameWork.Runtime中的代码

---

### 📁 3rd/
**用途：** 存放第三方代码与库

**包含内容：**
- 游戏特定的第三方插件和库
- 第三方工具类
- 第三方扩展

**示例：**
```
3rd/
├── BehaviorTree/   # 行为树库
├── Pathfinding/    # 寻路库
└── Animation/      # 动画库
```

**注意事项：**
- 第三方代码应该保持原样，不要修改
- 如果需要修改，应该创建包装类或扩展类
- 建议为每个第三方库创建独立的子文件夹
- 与FrameWork/3rd区分：Game/3rd存放游戏特定的第三方库

---

## 使用规范

### 1. 代码组织

- **编辑器代码** → 放在 `Editor/` 文件夹
- **运行时代码** → 放在 `Runtime/` 文件夹
- **资源文件** → 放在 `AssetsPackage/` 文件夹
- **第三方代码** → 放在 `3rd/` 文件夹

### 2. 命名规范

- 文件夹使用PascalCase：`AssetsPackage`, `Editor`, `Runtime`, `3rd`
- 脚本文件使用PascalCase：`PlayerController.cs`
- 命名空间使用PascalCase：`Game.Logic.Player`

### 3. 依赖关系

```
Runtime/  ←── 游戏逻辑代码
    ↓
AssetsPackage/  ←── 资源可以被Runtime使用
    ↓
Editor/  ←── 只能引用Runtime，不能引用游戏逻辑层
    ↓
3rd/  ←── 可以被Runtime和Editor引用
    ↓
FrameWork.Runtime/  ←── 框架代码可以被Game.Runtime引用
```

### 4. 与FrameWork的关系

- **Game.Runtime** 可以引用 **FrameWork.Runtime**
- **Game.Editor** 可以引用 **FrameWork.Runtime** 和 **FrameWork.Editor**
- **FrameWork** 不应该引用 **Game** 中的代码（保持框架独立性）

---

## 最佳实践

### ✅ 推荐做法

1. **清晰的职责分离**
   - 编辑器代码和运行时代码分开
   - 资源文件和代码文件分开
   - 游戏逻辑和框架代码分离

2. **合理的文件组织**
   - 相关文件放在同一文件夹
   - 使用子文件夹进一步分类
   - 按功能模块组织代码

3. **统一的命名规范**
   - 遵循项目命名规范
   - 使用有意义的文件名
   - 保持命名空间的一致性

4. **充分利用框架**
   - 使用FrameWork提供的模块
   - 通过事件系统通信
   - 使用框架的工具类

### ❌ 避免做法

1. **不要在Runtime中放编辑器代码**
   ```csharp
   // ❌ 错误 - Runtime/PlayerController.cs
   #if UNITY_EDITOR
   [MenuItem("Tools/Player")]
   #endif
   
   // ✅ 正确 - Editor/PlayerEditor.cs
   [MenuItem("Tools/Player")]
   ```

2. **不要在Editor中引用游戏逻辑层**
   ```csharp
   // ❌ 错误 - Editor/GameEditor.cs
   using Game.Logic.Player;  // 不应该直接引用逻辑层
   
   // ✅ 正确 - Editor/GameEditor.cs
   using Framework.Core;  // 可以引用框架
   ```

3. **不要将资源文件放在代码文件夹中**
   ```
   // ❌ 错误
   Runtime/Player.prefab
   
   // ✅ 正确
   AssetsPackage/Prefab/Player/Player.prefab
   ```

4. **不要直接修改框架代码**
   ```
   // ❌ 错误 - 直接修改FrameWork中的代码
   
   // ✅ 正确 - 通过继承或组合扩展功能
   ```

---

## 开发流程建议

### 1. 创建新功能模块

1. 在 `Runtime/Logic/` 下创建模块文件夹
2. 实现游戏逻辑代码
3. 在 `AssetsPackage/Prefab/` 下创建相关Prefab
4. 在 `Editor/` 下创建编辑器工具（如需要）

### 2. 使用框架模块

```csharp
using Framework.Core;
using Framework.Module.Audio;
using Framework.Module.UI;

namespace Game.Logic
{
    public class PlayerController : MonoBehaviour
    {
        private void Start()
        {
            // 获取框架模块
            var audioManager = GameManager.Instance.GetModule<IAudioManager>();
            audioManager.PlaySound("Jump");
        }
    }
}
```

### 3. 通过事件系统通信

```csharp
using Framework.Module.Event;

// 发布事件
EventManager.Instance.Emit("OnPlayerDeath", playerData);

// 订阅事件
EventManager.Instance.On("OnPlayerDeath", OnPlayerDeath);
```

---

## 目录迁移指南

如果现有代码需要迁移到新结构：

1. **运行时脚本** → 移动到 `Runtime/` 文件夹
2. **编辑器脚本** → 移动到 `Editor/` 文件夹（如果不在Editor文件夹中）
3. **资源文件** → 移动到 `AssetsPackage/` 文件夹
4. **第三方代码** → 移动到 `3rd/` 文件夹
5. **更新引用** → 检查并更新所有引用路径

---

## 总结

Game目录的新结构提供了清晰的职责分离：

- **AssetsPackage/** - 游戏资源管理
- **Editor/** - 游戏编辑器工具
- **Runtime/** - 游戏运行时代码
- **3rd/** - 游戏第三方库

这种结构使得游戏代码组织更加清晰，便于维护和扩展，同时与FrameWork框架保持清晰的边界。
