# FrameWork 目录结构说明

## 目录结构

```
FrameWork/
├── AssetsPackage/    # 资源文件夹 - 存放框架相关的资源文件
│   └── (资源文件)
│
├── Editor/           # 编辑器扩展 - 存放编辑器模式下的扩展代码
│   └── (编辑器脚本)
│
├── Runtime/          # 运行时代码 - 存放运行时框架的代码
│   ├── Core/        # 核心系统
│   ├── Module/      # 功能模块
│   ├── Config/      # 配置管理
│   └── Utility/     # 工具类
│
├── 3rd/              # 第三方库 - 存放第三方代码与库
│   └── (第三方代码)
│
└── ARCHITECTURE.md   # 架构设计文档
```

---

## 目录职责

### 📁 AssetsPackage/
**用途：** 存放框架相关的资源文件

**包含内容：**
- 框架相关的Prefab预制体
- 框架相关的材质、贴图等资源
- 框架相关的配置文件（ScriptableObject等）
- 其他框架需要的资源文件

**示例：**
```
AssetsPackage/
├── Prefab/
│   └── FrameworkManager.prefab
├── Material/
│   └── FrameworkMaterial.mat
└── Config/
    └── FrameworkConfig.asset
```

---

### 📁 Editor/
**用途：** 存放编辑器模式下的扩展代码

**包含内容：**
- 编辑器窗口脚本
- 自定义Inspector脚本
- 编辑器菜单工具
- 框架相关的编辑器工具

**命名规范：**
- 所有脚本必须以 `.cs` 结尾
- 建议使用 `Editor` 后缀，如 `FrameworkEditor.cs`
- 必须放在 `Editor` 文件夹中，Unity会自动识别为编辑器脚本

**示例：**
```
Editor/
├── FrameworkEditor.cs        # 框架编辑器
├── ModuleWindow.cs            # 模块管理窗口
└── ConfigWindow.cs            # 配置管理窗口
```

**注意事项：**
- Editor文件夹中的脚本只在编辑器模式下编译
- 运行时代码不能引用Editor文件夹中的代码
- 使用 `#if UNITY_EDITOR` 预处理指令来区分编辑器代码

---

### 📁 Runtime/
**用途：** 存放运行时框架的代码

**包含内容：**
- **Core/** - 核心系统（GameManager, IModule等）
- **Module/** - 功能模块（Audio, UI, Network等）
- **Config/** - 配置管理（ConfigManager等）
- **Utility/** - 工具类（Logger, Pool等）

**命名空间：**
- `Framework.Core` - 核心系统
- `Framework.Module.*` - 功能模块
- `Framework.Config` - 配置管理
- `Framework.Utility` - 工具类

**示例：**
```
Runtime/
├── Core/
│   ├── GameManager.cs        # 游戏管理器
│   ├── IModule.cs            # 模块接口
│   └── ModuleManager.cs      # 模块管理器
├── Module/
│   ├── Audio/                # 音频模块
│   ├── UI/                   # UI模块
│   └── Network/             # 网络模块
├── Config/
│   └── ConfigManager.cs      # 配置管理器
└── Utility/
    ├── Logger.cs             # 日志工具
    └── Pool.cs               # 对象池
```

**注意事项：**
- Runtime文件夹中的代码会在运行时编译
- 可以被游戏逻辑层引用
- 不应该引用Editor文件夹中的代码
- 所有跨命名空间的引用应使用完整的命名空间或using语句

---

### 📁 3rd/
**用途：** 存放第三方代码与库

**包含内容：**
- 第三方插件和库
- 第三方工具类
- 第三方扩展

**示例：**
```
3rd/
├── DotNetZip/                # DotNetZip库
├── Newtonsoft.Json/         # JSON库
└── ThirdPartyTools/          # 其他第三方工具
```

**注意事项：**
- 第三方代码应该保持原样，不要修改
- 如果需要修改，应该创建包装类或扩展类
- 建议为每个第三方库创建独立的子文件夹

---

## 命名空间规范

### 命名空间结构

```
Framework.Core              # 核心系统
Framework.Module.Audio      # 音频模块
Framework.Module.UI         # UI模块
Framework.Module.Network    # 网络模块
Framework.Module.Event      # 事件模块
Framework.Module.Resource   # 资源模块
Framework.Module.Scene      # 场景模块
Framework.Module.Data       # 数据模块
Framework.Config            # 配置管理
Framework.Utility           # 工具类
```

### 引用规范

**✅ 正确示例：**
```csharp
using Framework.Core;

namespace Framework.Module.Audio
{
    public interface IAudioManager : IModule
    {
        // ...
    }
}
```

**❌ 错误示例：**
```csharp
namespace Framework.Module.Audio
{
    // ❌ 错误：使用相对命名空间
    public interface IAudioManager : Core.IModule
    {
        // ...
    }
}
```

---

## 依赖关系

```
Runtime/  ←── 可以被游戏逻辑层引用
    ↓
AssetsPackage/  ←── 资源可以被Runtime和游戏逻辑层使用
    ↓
Editor/  ←── 只能引用Runtime，不能引用游戏逻辑层
    ↓
3rd/  ←── 可以被Runtime和Editor引用
```

---

## 代码组织原则

### 1. 职责分离
- **编辑器代码** → 放在 `Editor/` 文件夹
- **运行时代码** → 放在 `Runtime/` 文件夹
- **资源文件** → 放在 `AssetsPackage/` 文件夹
- **第三方代码** → 放在 `3rd/` 文件夹

### 2. 命名规范
- 文件夹使用PascalCase：`AssetsPackage`, `Editor`, `Runtime`, `3rd`
- 脚本文件使用PascalCase：`GameManager.cs`
- 命名空间使用PascalCase：`Framework.Core`

### 3. 引用规范
- 使用完整的命名空间或using语句
- 避免使用相对命名空间引用
- 跨命名空间引用必须显式声明

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

4. **正确的命名空间引用**
   - 使用using语句引入命名空间
   - 避免使用相对命名空间引用

### ❌ 避免做法

1. **不要在Runtime中放编辑器代码**
   ```csharp
   // ❌ 错误 - Runtime/GameManager.cs
   #if UNITY_EDITOR
   [MenuItem("Tools/Game")]
   #endif
   
   // ✅ 正确 - Editor/GameMenu.cs
   [MenuItem("Tools/Game")]
   ```

2. **不要在Editor中引用游戏逻辑层**
   ```csharp
   // ❌ 错误 - Editor/FrameworkEditor.cs
   using Game.Logic;  // 不应该引用游戏逻辑层
   
   // ✅ 正确 - Editor/FrameworkEditor.cs
   using Framework.Core;  // 可以引用Runtime
   ```

3. **不要使用相对命名空间引用**
   ```csharp
   // ❌ 错误
   public interface IAudioManager : Core.IModule
   
   // ✅ 正确
   using Framework.Core;
   public interface IAudioManager : IModule
   ```

---

## 迁移说明

所有原有的代码目录（Core, Module, Config, Utility）已移动到 `Runtime/` 文件夹下，结构保持不变：

- `Core/` → `Runtime/Core/`
- `Module/` → `Runtime/Module/`
- `Config/` → `Runtime/Config/`
- `Utility/` → `Runtime/Utility/`

所有命名空间引用已修复，确保代码可以正常编译和运行。

---

## 总结

FrameWork目录的新结构提供了清晰的职责分离：

- **AssetsPackage/** - 资源管理
- **Editor/** - 编辑器工具
- **Runtime/** - 运行时代码
- **3rd/** - 第三方库

这种结构使得代码组织更加清晰，便于维护和扩展，同时充分利用了Unity的特性。
