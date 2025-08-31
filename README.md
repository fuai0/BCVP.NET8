# BCVP.NET8 项目学习文档

## 项目概述

本项目是一个基于 [ASP.NET](https://asp.net/) Core 8 的学习示例仓库，主要用于记录和实践多层架构设计、依赖注入、AutoMapper 等核心技术。项目采用了分层设计思想，包含仓储层、服务层等常见架构组件，适合作为 [ASP.NET](https://asp.net/) Core 初学者的学习参考。

## 项目结构

从项目文件分析，整体采用了多层架构设计，主要包含以下项目 / 模块：

1. **BCVP.NET8**：主应用程序项目，包含 API 控制器和启动配置
2. **BCVP.NET8.Repository**：仓储层，负责数据访问操作
3. **BCVP.NET8.Service**：服务层，包含业务逻辑
4. **BCVP.NET8.IService**：服务接口层，定义服务契约
5. **BCVP.NET8.Model**：模型层，包含实体类定义
6. **BCVP.NET8.Common**：公共类库，包含通用工具类和扩展方法

## 核心技术实践

### 1. 多层架构设计

项目采用经典的多层架构，各层职责分明：

- **表示层（BCVP.NET8）**：处理 HTTP 请求，包含控制器和 API 配置
- **业务逻辑层（BCVP.NET8.Service）**：实现业务逻辑，依赖于仓储层
- **数据访问层（BCVP.NET8.Repository）**：负责数据操作，提供数据访问接口
- **实体模型层（BCVP.NET8.Model）**：定义业务实体和数据模型
- **接口层（BCVP.NET8.IService）**：定义服务接口，实现接口与实现分离

### 2. 依赖注入配置

在 Program.cs 中配置了依赖注入，实现了接口与实现的解耦：

csharp

```csharp
// 注册仓储和服务
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
```

- 使用 `AddScoped` 注册作用域服务，确保在每个请求生命周期内使用相同的服务实例
- 通过泛型注册实现了通用接口与实现的映射，减少了重复代码

### 3. AutoMapper 应用

项目集成了 AutoMapper 用于对象映射：

csharp

```csharp
// 注册 AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
AutoMapperConfig.RegisterMappings();
```

AutoMapper 主要用于：

- 实体模型与视图模型之间的转换
- 简化对象属性复制代码，提高开发效率

### 4. 仓储模式实现

仓储层实现了基础的数据访问操作，以 BaseRepository.cs 为例：

csharp

```csharp
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    public async Task<List<TEntity>> Query()
    {
        await Task.CompletedTask;
        var data = "[{\"Id\":1 ,\"Name\":\"basebase\"}]";
        return JsonConvert.DeserializeObject<List<TEntity>>(data) ?? new List<TEntity>();
    }
}
```

- 使用泛型实现通用仓储，减少重复代码
- 实现了异步方法，符合 [ASP.NET](https://asp.net/) Core 异步编程模型
- 目前使用 JSON 字符串模拟数据，实际项目中可替换为数据库操作
