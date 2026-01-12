# Boot 目录结构说明

## 目录结构

```
Boot/
├── AssetsPackage/    # 资源文件夹 - 存放启动相关的资源文件
│   └── (资源文件)
│
├── Editor/          # 编辑器扩展 - 存放编辑器模式下的扩展代码
│   └── (编辑器脚本)
│
├── Runtime/         # 运行时代码 - 存放运行时框架的代码
│   └── (运行时脚本)
│
└── Scene/           # 启动场景
    └── Startup.unity
```

---

## 目录职责

### 📁 AssetsPackage/
**用途：** 存放启动相关的资源文件

**包含内容：**
- 启动相关的Prefab预制体
- 启动相关的材质、贴图等资源
- 启动相关的配置文件（ScriptableObject等）
- 其他启动时需要的资源文件

**示例：**
```
AssetsPackage/
├── Prefab/
│   └── BootManager.prefab
├── Material/
│   └── BootMaterial.mat
└── Config/
    └── BootConfig.asset
```

---

### 📁 Editor/
**用途：** 存放编辑器模式下的扩展代码

**包含内容：**
- 编辑器窗口脚本
- 自定义Inspector脚本
- 编辑器菜单工具
- 启动相关的编辑器工具

**命名规范：**
- 所有脚本必须以 `.cs` 结尾
- 建议使用 `Editor` 后缀，如 `BootEditor.cs`
- 必须放在 `Editor` 文件夹中，Unity会自动识别为编辑器脚本

**示例：**
```
Editor/
├── BootEditor.cs          # 启动管理器编辑器
├── BootWindow.cs          # 启动配置窗口
└── BootMenu.cs            # 启动相关菜单工具
```

**注意事项：**
- Editor文件夹中的脚本只在编辑器模式下编译
- 运行时代码不能引用Editor文件夹中的代码
- 使用 `#if UNITY_EDITOR` 预处理指令来区分编辑器代码

---

### 📁 Runtime/
**用途：** 存放运行时框架的代码

**包含内容：**
- 启动管理器脚本
- 框架初始化代码
- 启动流程控制代码
- 其他运行时需要的脚本

**命名规范：**
- 所有脚本必须以 `.cs` 结尾
- 建议使用清晰的命名，如 `BootManager.cs`

**示例：**
```
Runtime/
├── BootManager.cs         # 启动管理器（主入口）
├── BootInitializer.cs    # 框架初始化器
└── BootConfig.cs         # 启动配置类
```

**注意事项：**
- Runtime文件夹中的代码会在运行时编译
- 可以被游戏逻辑层引用
- 不应该引用Editor文件夹中的代码

---

### 📁 Scene/
**用途：** 存放启动场景

**包含内容：**
- `Startup.unity` - 框架启动场景

**说明：**
- 启动场景是框架的入口点
- 场景中应该包含BootManager等启动相关的GameObject
- 启动完成后可以跳转到游戏主场景

---

## 使用规范

### 1. 代码组织

- **编辑器代码** → 放在 `Editor/` 文件夹
- **运行时代码** → 放在 `Runtime/` 文件夹
- **资源文件** → 放在 `AssetsPackage/` 文件夹

### 2. 命名规范

- 文件夹使用PascalCase：`AssetsPackage`, `Editor`, `Runtime`
- 脚本文件使用PascalCase：`BootManager.cs`
- 资源文件使用PascalCase：`BootConfig.asset`

### 3. 依赖关系

```
Runtime/  ←── 可以被游戏逻辑层引用
    ↓
AssetsPackage/  ←── 资源可以被Runtime和游戏逻辑层使用
    ↓
Editor/  ←── 只能引用Runtime，不能引用游戏逻辑层
```

### 4. Unity特殊文件夹

- `Editor/` - Unity自动识别为编辑器脚本文件夹
- `Runtime/` - 普通运行时脚本文件夹
- `AssetsPackage/` - 普通资源文件夹

---

## 最佳实践

### ✅ 推荐做法

1. **清晰的职责分离**
   - 编辑器代码和运行时代码分开
   - 资源文件和代码文件分开

2. **合理的文件组织**
   - 相关文件放在同一文件夹
   - 使用子文件夹进一步分类

3. **统一的命名规范**
   - 遵循项目命名规范
   - 使用有意义的文件名

### ❌ 避免做法

1. **不要在Runtime中放编辑器代码**
   ```csharp
   // ❌ 错误 - Runtime/BootManager.cs
   #if UNITY_EDITOR
   [MenuItem("Tools/Boot")]
   #endif
   
   // ✅ 正确 - Editor/BootMenu.cs
   [MenuItem("Tools/Boot")]
   ```

2. **不要在Editor中引用游戏逻辑层**
   ```csharp
   // ❌ 错误 - Editor/BootEditor.cs
   using Game.Logic;  // 不应该引用游戏逻辑层
   
   // ✅ 正确 - Editor/BootEditor.cs
   using FrameWork.Boot.Runtime;  // 可以引用Runtime
   ```

3. **不要将资源文件放在代码文件夹中**
   ```
   // ❌ 错误
   Runtime/BootConfig.asset
   
   // ✅ 正确
   AssetsPackage/Config/BootConfig.asset
   ```

---

## 目录迁移指南

如果现有代码需要迁移到新结构：

1. **运行时脚本** → 移动到 `Runtime/` 文件夹
2. **编辑器脚本** → 移动到 `Editor/` 文件夹（如果不在Editor文件夹中）
3. **资源文件** → 移动到 `AssetsPackage/` 文件夹
4. **更新引用** → 检查并更新所有引用路径

---

## 总结

Boot目录的新结构提供了清晰的职责分离：

- **AssetsPackage/** - 资源管理
- **Editor/** - 编辑器工具
- **Runtime/** - 运行时代码
- **Scene/** - 启动场景

这种结构使得代码组织更加清晰，便于维护和扩展。
