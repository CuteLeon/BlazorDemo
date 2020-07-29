# Blazor Demo

# 历史

- 2018 开始实验
- 2019.04 预览版
- 2019.09 正式版
- 2020.05 Blazor WebAssembly 发布
- 其他平台：桌面、移动

# 两种宿主模型

- 两种方式均无需插件，基于Web标准
- 可以与JavaScript交互
- 可以结合.NetCore的优势：生态、库、性能、安全等

## 基于客户端（WebAssembly）

​	首次访问时，将应用程序的代码和运行时的代码均从服务器下载到客户端浏览器并运行。

### 优点

1. 可以运行在所有现代浏览器上面，包括移动设备
2. 服务器端可以不要求使用.Net技术栈，任何可以支持Blazor的技术栈均可
3. 具有SPA (Single Page Application)的用户体验

### 缺点

1. 古老的浏览器不支持，例如IE
2. 首次访问时下载的WebAssembly文件比较大
3. 调试体验较差

## 基于服务端 

​	Blazor应用仍然运行在服务端，服务端程序和客户端浏览器通过SignalR通讯。

### 优点

1. 需要下载的文件很小
2. 可以使用所有的服务端API
3. 完整的调试体验
4. 可以在不支持WebAssembly的浏览器中运行

### 缺点

1. 不支持离线运行
2. 网络延迟影响比较大
3. 可扩展性不佳

# ASP.NET Core Blazor

> ASP.NET Core hosted: 使用 ASP.NET Core 平台的 Blazor
>
> Progressive Web Application: 改进的Web应用程序，可以使应用程序脱离浏览器运行

## 目录

### wwwroot

​	静态资源

#### index.html

​	作为SPA的宿主页面

### Pages

​	页面组件

### Shared

​	共享组件

### Programs.cs

​	程序的入口，用于创建、配置并启动Host。

```csharp
builder.RootComponents.Add<App>("app");
```

​	使用App.razor作为根组件，对应 wwwroot/index.html 内的 \<app>Loading...\</app> 标签。

```csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
```

​	向DI容器注入HttpClient服务。

### App.Razor

```html
<Router AppAssembly="@typeof(Program).Assembly">
```

​	声明程序集，并扫描程序集查找可以被路由的组件。

```html
<Found Context="routeData">
    <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
</Found>
```

​	配置路由参数并配置页面布局模板。

### _Imports.razor

​	Page 引用名称空间

## Razor

​	Razor为Blazor的组件，Razor文件要求文件名首字母大写。

​	在编译时每个razor文件都会对应一个类。

### 覆写方法

#### OnInitialized[Async]

​	初始化

#### OnParametersSet[Async]

​	设置参数

#### OnAfterRender[Async]

​	渲染后

#### ShouldRender

​	请求渲染

### 关联后台代码

#### Partial

​	增加一个相同名称空间和类型的C#类，并将此类继承自ComponentBase，并为此类增加Partial修饰；

​	此C#类将和对应的razor组件以部分类合并。

#### Inherits

​	增加一个C#基类，并在razor通过@inherits指令继承自此C#类。

​	此razor将通过基类访问C#类。

### 引用

​	Razor可以嵌套，直接在Razor里通过标签引用其他Razor

```HTML
@page "/"
<h1>Hello, world!</h1>
<SurveyPrompt Title="How is Blazor working for you?" />
```

### 指令

#### @page *"/route"*

​	指定页面的路由，可以通过`{\}`为路由设置参数

#### @inherits

​	继承指定的组件

#### @inject *service* *name*

​	注入服务，也可以在C#里通过`[Inject]`特性修饰服务属性以注入

#### @code *{ ... }*

​	编写C#代码

### 公开参数

#### [Parameter]

​	使用`[Parameter]`修饰公开属性作为Razor组件的参数，可以在引用此组件时在标签内为属性赋值



## WebAssembly 与 WebAPI 项目跨域请求(CORS)问题

​	因为客户端WebAssembly和服务端WebAPI部署在独立的端口，Blazor使用HttpClient请求WebAPI时会因为CORS被WebAPI拒绝。

​	服务端WebAPI需要启用开放的CORS政策：

```csharp
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
    {
    	services.AddCors(options =>
        {
        	options.AddPolicy(
            	"OpenCorsPolicy",
                builder => builder.AllowAnyOrigin());
        });

        services.AddStackExchangeRedisCache(options =>
		{
            options.Configuration = "localhost:6379";
            options.InstanceName = "CovidRedis";
        });
	}
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("OpenCorsPolicy");
    }
}
```

