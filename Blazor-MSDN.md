# Blazor

> https://docs.microsoft.com/zh-cn/aspnet/core/blazor/?view=aspnetcore-3.1

# 简介

​	Blazor 是一个使用 .NET 生成交互式客户端 Web UI 的框架：

- 使用 C# 代替 JavaScript 来创建丰富的交互式 UI。

- 共享使用 .NET 编写的服务器端和客户端应用逻辑。

- 将 UI 呈现为 HTML 和 CSS，以支持众多浏览器，其中包括移动浏览器。

- 与新式托管平台集成。

  使用 .NET 进行客户端 Web 开发可提供以下优势：

- 使用 C# 代替 JavaScript 来编写代码。

- 利用现有的 .NET 库生态系统。

- 在服务器和客户端之间共享应用逻辑。

- 受益于 .NET 的性能、可靠性和安全性。

- 始终高效支持 Windows、Linux 和 macOS 上的 Visual Studio。

- 以一组稳定、功能丰富且易用的通用语言、框架和工具为基础来进行生成。

## 组件

​	Blazor应用基于组件。 Blazor 中的组件是指 UI 元素，例如页面、对话框或数据输入窗体。

​	组件是内置到 .NET 程序集的 .NET 类，用来：

- 定义灵活的 UI 呈现逻辑。
- 处理用户事件。
- 可以嵌套和重用。
- 可作为 Razor 类库或 NuGet 包共享和分发。

​	组件类通常以 Razor 标记页（文件扩展名为 `.razor`）的形式编写。 Blazor 中的组件有时被称为 Razor 组件。 Razor 是一种语法，用于将 HTML 标记与专为提高开发人员工作效率而设计的 C# 代码结合在一起。

​	组件呈现为浏览器文档对象模型 (DOM) 的内存中表现形式，称为“呈现树”，用于以灵活高效的方式更新 UI。

### 组件可以嵌套

​	以下例子演示组件嵌套、事件绑定、属性绑定

```razor
<div>
    <h1>@Title</h1>

    @ChildContent

    <button @onclick="OnYes">Yes!</button>
</div>

@code {
    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private void OnYes()
    {
        Console.WriteLine("Write to the console in C#! 'Yes' button was selected.");
    }
}
```

​	以下例子演示设置属性和ChildContent

```razor
@page "/"

<h1>Hello, world!</h1>

Welcome to your new app.

<Dialog Title="Blazor">
    Do you want to <i>learn more</i> about Blazor?
</Dialog>
```

## Blazor WebAssembly (wasm)

​	Blazor WebAssembly 是单页应用框架，用于使用 .NET 生成交互式客户端 Web 应用。 Blazor WebAssembly 使用开放的 Web 标准（没有插件或代码置换），适用于包括移动浏览器在内的各种新式 Web 浏览器。

​	通过WebAssembly可以直接在Web浏览器内执行C#代码。 WebAssembly 是针对快速下载和最大执行速度优化的压缩字节码格式。 WebAssembly 是开放的 Web 标准，支持用于无插件的 Web 浏览器。

​	WebAssembly 代码可通过 JavaScript（称为 JavaScript 互操作性或 JavaScript 互操作）访问浏览器的完整功能。 通过浏览器中的 WebAssembly 执行的 .NET 代码在浏览器的 JavaScript 沙盒中运行，沙盒提供的保护可防御客户端计算机上的恶意操作。

### 执行C#代码

> - Browser
>   - WebAssembly
>     - .Net
>       - Razor Components
>         - Blazor
>   - DOM

​	当 Blazor WebAssembly 应用生成并在浏览器中运行时：

- C# 代码文件和 Razor 文件将被编译为 .NET 程序集。
- 该程序集和 .NET 运行时将被下载到浏览器。
- Blazor WebAssembly 启动 .NET 运行时，并配置运行时，以为应用加载程序集。 Blazor WebAssembly 运行时使用 JavaScript 互操作来处理 DOM 操作和浏览器 API 调用。

### 优化有效负载大小

​	已发布应用的大小（其有效负载大小）是应用可用性的关键性能因素。 大型应用需要相对较长的时间才能下载到浏览器，这会损害用户体验。 Blazor WebAssembly 优化有效负载大小，以缩短下载时间：

- 在中间语言 (IL) 链接器发布应用时，会从应用删除未使用的代码。
- 压缩 HTTP 响应。
- .NET 运行时和程序集缓存在浏览器中。

## Blazor Server

​	Blazor 将组件呈现逻辑从 UI 更新的应用方式中分离出来。 Blazor Server在 ASP.NET Core 应用中支持在服务器上托管 Razor 组件。 可通过 SignalR 连接处理 UI 更新。

​	运行时处理从浏览器向服务器发送 UI 事件，并在运行组件后，将服务器发送的 UI 更新重新应用到浏览器。

​	Blazor Server用于与浏览器通信的连接还用于处理 JavaScript 互操作调用。

### 执行C#代码

> - Server
>   - .Net
>     - Razor Components
>       - ASP.NET Core
>
> <= SignalR =>
>
> - Browser
>   - DOM

## JavaScript 互操作性

​	对于需要第三方 JavaScript 库和访问浏览器 API 的应用，组件与 JavaScript 进行互操作。 组件能够使用 JavaScript 能够使用的任何库或 API。 C# 代码可以调用到 JavaScript 代码，而 JavaScript 代码可以调用到 C# 代码。

## 代码共享和.Net Standard

​	Blazor 实现 .Net Standard 2.1，

# Blazor 托管模型

​	Blazor 是一种 Web 框架，专用于在基于 WebAssembly 的 .NET 运行时 (Blazor WebAssembly) 上的浏览器中运行客户端，或在 ASP.NET Core (Blazor Server) 中运行服务器端 。 对于任意托管模型，应用和组件模型都相同。

## Blazor WebAssembly

​	Blazor 的**主要托管模型**在 WebAssembly 上的浏览器中运行客户端。 将 Blazor 应用、其依赖项以及 .NET 运行时下载到浏览器。 应用将在浏览器线程中直接执行。 UI 更新和事件处理在同一进程中进行。 应用资产作为静态文件部署到可为客户端提供静态内容的 Web 服务器或服务中。

> Browser > UI Thread > Blazor

### blazor.webassembly.js

​	可处理以下任务：

- 下载 .NET 运行时、应用和应用依赖项。
- 初始化运行应用的运行时。

### 优点

- 没有 .NET 服务器端依赖项。 应用下载到客户端后即可正常运行。
- 可充分利用客户端资源和功能。
- 工作可从服务器转移到客户端。
- 无需 ASP.NET Core Web 服务器即可托管应用。 无服务器部署方案可行（例如通过 CDN 为应用提供服务的方案）。

### 缺点

- 应用仅可使用浏览器功能。
- 需要可用的客户端硬件和软件（例如 WebAssembly 支持）。
- 下载项大小较大，应用加载耗时较长。
- .NET 运行时和工具支持不够完善。 例如，[.NET Standard](https://docs.microsoft.com/zh-cn/dotnet/standard/net-standard) 支持和调试方面存在限制。

## Blazor Server

​	使用 Blazor Server 托管模型可从 ASP.NET Core 应用中在服务器上执行应用。 UI 更新、事件处理和 JavaScript 调用是通过 SignalR 连接进行处理。

### blazor.server.js

​	脚本会建立客户端连接。 应用负责根据需要保存和还原应用状态（例如在网络连接丢失时）。`blazor.server.js` 脚本由 ASP.NET Core 共享框架中的嵌入资源提供。

### 优点

- 下载项大小明显小于 Blazor WebAssembly 应用，且应用加载速度快得多。
- 应用可充分利用服务器功能，包括使用任何与 .NET Core 兼容的 API。
- 服务器上的 .NET Core 用于运行应用，因此调试等现有 .NET 工具可按预期正常工作。
- 支持瘦客户端。 例如，Blazor Server 应用适用于不支持 WebAssembly 的浏览器以及资源受限的设备。
- 应用的 .NET/C# 代码库（其中包括应用的组件代码）不适用于客户端。

### 缺点

- 通常延迟较高。 每次用户交互都涉及到网络跃点。
- 不支持脱机工作。 如果客户端连接失败，应用会停止工作。
- 如果具有多名用户，则应用扩缩性存在挑战。 服务器必须管理多个客户端连接并处理客户端状态。
- 需要 ASP.NET Core 服务器为应用提供服务。 无服务器部署方案不可行（例如通过 CDN 为应用提供服务的方案）。

# 模板

## Program.cs

- 应用程序入口

### Blazor Server

- 配置ASP.NET Core主机

### Blazor WebAssembly

- 指定APP根组件（RootComponent）
- 用ConfigureServices方法配置服务
- 使用Configuration属性配置主机

## Startup.cs (仅在Blazor Server)

- 使用ConfigureServices方法配置服务
- 使用Configuration属性配置请求处理管道

## wwwroot/index.html (仅在BlazorWebAssembly)

- HTML页面的根页面
- 指定APP根组件的呈现位置
- 加载 _framework/blazor.webassembly.js文件
  - 下载.NET运行时、应用、依赖项
  - 初始化运行时

## App.razor

- 应用的根组件
- 配置客户端路由

## Pages 目录

- 包含可路由组件/页面，路由使用@page指令指定

### _Host.cshtml (仅在 Blazor Server)

- 应用的根页面
- 指定APP根组件的呈现位置
- 加载 _framework/blazor.server.js文件
  - 浏览器和服务端之间建立实时SignalR连接
  - 初始化运行时

## Shared 目录

- 包含共享组件
- MainLayout
  - 应用布局组件
- NavMenu
  - 实现边栏导航

## _Imports.razor

​	包含在应用组件中的常见Razor指令，例如@using指令

## Data 目录(仅在 Blazor Server)

​	数据

## wwwroot 目录

​	应用的Web根目录，包含公共静态资产

## appsettings.json

​	应用的配置设置

# 路由

```html
<Router AppAssembly="typeof(Startup).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <p>Sorry, there's nothing at this address.</p>
    </NotFound>
</Router>
```

## 路由模板

​	Router组件可实现到具有指定的每个组件的路由，Router组件的配置在App.razor

​	编译带有 `@page` 指令的 `.razor` 文件时，将为生成的类提供指定路由模板的 RouteAttribute。

​	RouteView组件从Router接收RouteData以及任何所需的参数，通过指定参数使用指定组件的布局（或使用DefaultLayout指定的默认布局）呈现组件。

​	可以将多个路由模板应用于同一个组件，

## NotFound 自定义内容

​	可以在\<Router.NotFound/>里指定未能找到匹配路由时显示的自定义内容。

​	`<NotFound>` 标记的内容可以包括任意项，例如其他交互式组件。也可以为NotFound设置布局。

## 从多个程序集路由到组件

```html
<Router
    AppAssembly="typeof(Program).Assembly"
    AdditionalAssemblies="new[] { typeof(Component1).Assembly }">
    ...
</Router>
```

​	使用`AdditionalAssemblies`参数为Routerr组件指定搜索可路由组件时除了`AppAssembly`以外要考虑的其他程序集。

## 路由参数

​	可以使用路由参数以相同名称填充相应的组件参数（不区分大小写），不支持可选参数

```c#
@page "/RouteParameter"
@page "/RouteParameter/{text}"

<h1>Blazor is @Text!</h1>

@code {
    [Parameter]
    public string Text { get; set; }

    protected override void OnInitialized()
    {
        Text = Text ?? "fantastic";
    }
}
```

## 路由约束

​	路由约束强制在路由段和组件之间进行类型匹配。

```c#
@page "/Users/{Id:int}"

<h1>The user Id is @Id!</h1>

@code {
    [Parameter]
    public int Id { get; set; }
}
```

| 约束       | 示例              | 匹配项示例                                                   |
| :--------- | :---------------- | :----------------------------------------------------------- |
| `bool`     | `{active:bool}`   | `true`，`FALSE`                                              |
| `datetime` | `{dob:datetime}`  | `2016-12-31`，`2016-12-31 7:32pm`                            |
| `decimal`  | `{price:decimal}` | `49.99`，`-1,000.01`                                         |
| `double`   | `{weight:double}` | `1.234`，`-1,001.01e8`                                       |
| `float`    | `{weight:float}`  | `1.234`，`-1,001.01e8`                                       |
| `guid`     | `{id:guid}`       | `CD2C1638-1638-72D5-1638-DEADBEEF1638`，`{CD2C1638-1638-72D5-1638-DEADBEEF1638}` |
| `int`      | `{id:int}`        | `123456789`，`-123456789`                                    |
| `long`     | `{ticks:long}`    | `123456789`，`-123456789`                                    |

## 使用包含点的路由

​	包含点 (`.`) 的请求 URL 与默认路由不匹配，因为 URL 似乎在请求文件。 Blazor 应用针对不存在的静态文件返回“404 - 找不到”响应。 若要使用包含点的路由，请使用以下路由模板配置：

> Razor组件(.razor)不支持Catch-all语法(*/**)

```
@page "/{**path}"
```

- 双星号 catch-all语法，用于跨越文件夹边界捕捉路径，而无需编码正斜杠`/`
- path路由参数名称

## NavLink 组件

​	创建导航链接时，请使用 NavLink 组件代替 HTML 超链接元素 (`<a>`)。其组件的行为方式类似于 `<a>` 元素，但它根据其 `href` 是否与当前 URL 匹配来切换 `active` CSS 类。 `active` 类可帮助用户了解所显示导航链接中的哪个页面是活动页面。 也可以选择将 CSS 类名分配到 NavLink.ActiveClass，以便在当前路由与 `href` 匹配时将自定义 CSS 类应用到呈现的链接。

### Match

​	NavLink 组件由两种 Match 可用：

#### NavLinkMatch.All

​	NavLink在与当前整个 URL 匹配的情况下处于活动状态。

#### NavLinkMatch.Prefix

​	NavLink在与当前 URL 的任何前缀匹配的情况下处于活动状态。

### target

​	NavLink组件可以接收 target 属性

```
<NavLink href="my-page" target="_blank">My page</NavLink>
```

| target       | 行为                                                         |
| ------------ | ------------------------------------------------------------ |
| _blank       | 浏览器总在一个新打开、未命名的窗口中载入目标文档             |
| _self (默认) | 目标文档载入并显示在相同的框架或者窗口中作为源文档           |
| _parent      | 这个目标使得文档载入父窗口或者包含来超链接引用的框架的框架集 |
| _top         | 这个目标使得文档载入包含这个超链接的窗口，用 _top 目标将会清除所有被包含的框架并将文档载入整个浏览器窗口 |

## URI和导航状态帮助程序

​	应使用 NavigationManager 与 URI 和导航配合使用，具体事件和方法如下：

| 成员               | 描述                                                         |
| :----------------- | :----------------------------------------------------------- |
| Uri                | 获取当前绝对 URI。                                           |
| BaseUri            | 获取可在相对 URI 路径之前添加用于生成绝对 URI 的基 URI（带有尾部反斜杠）。 通常，BaseUri 对应于 `wwwroot/index.html` (Blazor WebAssembly) 或 `Pages/_Host.cshtml` (Blazor Server) 中文档的 `<base>` 元素上的 `href` 属性。 |
| NavigateTo         | 导航到指定 URI。 如果 `forceLoad` 为 `true`，则：客户端路由会被绕过。无论 URI 是否通常由客户端路由器处理，浏览器都必须从服务器加载新页面。 |
| LocationChanged    | 导航位置更改时触发的事件。                                   |
| ToAbsoluteUri      | 将相对 URI 转换为绝对 URI。                                  |
| ToBaseRelativePath | 给定基 URI，将绝对 URI 转换为相对于基 URI 前缀的 URI。       |

```c#
@page "/navigate"
@inject NavigationManager NavigationManager

<button class="btn btn-primary" @onclick="NavigateToCounterComponent">Navigate to the Counter component</button>

@code {
    private void NavigateToCounterComponent()
        => NavigationManager.NavigateTo("counter");
}
```

​	以下组件通过订阅 NavigationManager.LocationChanged 来处理位置改变事件。 在框架调用 `Dispose` 时，解除挂接 `HandleLocationChanged` 方法。 解除挂接该方法可允许组件进行垃圾回收。

```c#
@implements IDisposable
@inject NavigationManager NavigationManager


protected override void OnInitialized()
    => NavigationManager.LocationChanged += HandleLocationChanged;

private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
{
}

public void Dispose()
    => NavigationManager.LocationChanged -= HandleLocationChanged;

```

​	LocationChangedEventArgs

- Location: 新位置的URL
- IsNavigationIntercepted
  - True: Blazor 拦截了浏览器中的导航
  - False: NavigationManager.NavigateTo 导致了导航发生

## QueryString和分析查询字符串的参数

> 安装 Microsoft.AspNetCore.WebUtilities Nuget
>
> 使用 QueryHelper.ParseQuery 分析字符串并取值

```c#
@page "/"
@using Microsoft.AspNetCore.WebUtilities
@inject NavigationManager NavigationManager

<p>Value: @queryValue</p>

@code {
    private string queryValue = "Not set";

    protected override void OnInitialized()
    {
        var query = new Uri(NavigationManager.Uri).Query;

        if (QueryHelpers.ParseQuery(query).TryGetValue("{KEY}", out var value))
        {
            queryValue = value;
        }
    }
}
```

# Configuation (WebAssembly)

​	Blazor WebAssembly 加载以下来源的配置：

- 应用设置文件（默认）：
  - `wwwroot/appsettings.json`
  - `wwwroot/appsettings.{ENVIRONMENT}.json`
- 应用注册的其他 配置提供程序。 并非所有提供程序都适用于 Blazor WebAssembly 应用。 

## 应用配置设置

`wwwroot/appsettings.json`

```json
{
  "message": "Hello from config!"
}
```

​	注入 IConfiguration 以读取配置数据

```html
@page "/"
@using Microsoft.Extensions.Configuration
@inject IConfiguration Configuration

<h1>Configuration example</h1>
<p>Message: @Configuration["message"]</p>
```

## 提供程序配置

`Program.Main`

```c#
using Microsoft.Extensions.Configuration.Memory;
var vehicleData = new Dictionary<string, string>()
{
    { "color", "blue" },
    { "type", "car" },
    { "wheels:count", "3" },
    { "wheels:brand", "Blazin" },
    { "wheels:brand:type", "rally" },
    { "wheels:year", "2008" },
};

var memoryConfig = new MemoryConfigurationSource { InitialData = vehicleData };
builder.Configuration.Add(memoryConfig);
```

## HttpClient 读取静态JSON配置

​	可以将其他配置写入wwwroot目录下的JSON文件中，并使用HttpClient向本地读取。

`wwwroot/cars.json`

```json
{
	"size":"tiny"
}
```

`Program.Main`

```c#
using Microsoft.Extensions.Configuration;

var httpClient = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped<HttpClient>(serviceProvider => httpClient);

var stream = await new HttpClient().GetStreamAsync("carts");
builder.Configuration.AddJsonStream(stream);
```

## 日志记录器

> 添加 Microsoft.Extensions.Logging.Configuration Nuget

`appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

`Program.Main`

```C#
using Microsoft.Extensions.Logging;

builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));
```

## HostBuilder 配置

`Program.Main`

```c#
var hostname = builder.Configuration["HostName"];
```

# 依赖注入

​	Blazor 支持依赖注入，应用可以把服务注入组件以在整个应用中使用。

| 服务              | 生存期                                               | 描述                                                         |
| :---------------- | :--------------------------------------------------- | :----------------------------------------------------------- |
| HttpClient        | 范围内                                               | 提供用于发送 HTTP 请求以及从 URI 标识的资源接收 HTTP 响应的方法。  Blazor WebAssembly 应用中 [HttpClient](https://docs.microsoft.com/zh-cn/dotnet/api/system.net.http.httpclient) 的实例使用浏览器在后台处理 HTTP 流量。 |
| IJSRuntime        | 单一实例 (Blazor WebAssembly) 范围内 (Blazor Server) | 表示在其中调度 JavaScript 调用的 JavaScript 运行时实例。     |
| NavigationManager | 单一实例 (Blazor WebAssembly) 范围内 (Blazor Server) | 包含用于处理 URI 和导航状态的帮助程序。                      |

## 向应用添加服务

### Blazor WebAssembly

```c#
using Microsoft.Extensions.DependencyInjection;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddSingleton<IMyDependency, MyDependency>();
        var service = host.Services.GetRequiredService<IMyDependency>();
        
        await builder.Build().RunAsync();
    }
}
```

### Blazor Server

> 同 ASP.NET Core

## 服务生存周期

| 生存期    | 描述                                                         |
| :-------- | :----------------------------------------------------------- |
| Scoped    | **Blazor WebAssembly 应用当前没有 DI 范围的概念，已注册 `Scoped` 的服务的行为与 `Singleton` 服务类似**。在 Blazor Server 应用中，范围内服务注册的范围为“连接”。 因此，即使当前意图是在浏览器中运行客户端，**对于范围应限定为当前用户的服务来说，首选使用 Scoped 服务**。 |
| Singleton | DI 创建服务的单个实例。 需要 `Singleton` 服务的所有组件都会接收同一服务的实例。 |
| Transient | 每当组件从服务容器获取 `Transient` 服务的实例时，它都会接收该服务的新实例。 |

## 在组件中请求服务

​	将服务添加到服务集合后，使用 `@inject` 指令将服务注入Razor组件。

```C#
@inject IDataAccess DataRepository
protected override async Task OnInitializedAsync()
{
	collection = await DataRepository.QueryAll();
}
```

​	在基类中可以直接使用 `[Inject]` Attribute 注入服务。

```c#
public class ComponentBase : IComponent
{
    [Inject]
    protected IDataAccess DataRepository { get; set; }
}
```

​	在派生自此基类的组件中可以直接使用已经注入的服务

```html
@page "/demo"
@inherits ComponentBase
<h1>Demo Component</h1>
```

## 在服务中注入服务

​	复杂的服务中不可使用 `[Inject]` Attribute 来注入服务，而应该使用构造函数，DI容器创建服务时会自动在其构造函数中识别所需要的其他服务并提供。

```C#
public class DataAccess : IDataAccess
{
	private readonly HttpClient httpClient;
    public DataAccess(HttpClient client)
        => httpClient = client;
}
```

- 要求存在一个构造函数，其所需要的参数可完全通过DI实现。
- 适用的构造函数必须是`public`
- 必须存在一个使用构造函数，不可以出现歧义

## 用于管理 DI 范围的实用工具基组件类

​	在 ASP.NET Core 应用中，Scoped 服务的范围通常限定为当前请求。 请求完成后，DI 系统将处置所有 Scoped 或 Transient 服务。 **在 Blazor Server 应用中，请求范围会在客户端连接期间一直持续存在，这可能导致暂时性和范围内服务的生存期比预期要长得多。 在 Blazor WebAssembly 应用中，已注册范围内生存期的服务被视为单一实例，因此它们的生存期比典型 ASP.NET Core 应用中的范围内服务要长。**

​	限制 Blazor 应用中服务生存期的一种方法是使用 OwningComponentBase 类型。 OwningComponentBase 是派生自 ComponentBase 的一种抽象类型，**它会创建与组件生存期相对应的 DI 范围**。 通过使用此范围，可使用具有 Scoped 生存期的 DI 服务，并使其生存期与组件的生存期一样长。**销毁组件时，也会处置组件的 Scoped 服务提供程序提供的服务**。 这对以下服务很有用：

- 由于 Transient 生存期不适用而应在组件中重复使用的服务。
- 由于 Singleton 生存期不适用而不得跨组件共享的服务。

### OwningComponentBase

​	含有 IServiceProvider 类型的 ScopedService 属性，用于获取与组件生命周期一致的服务。

​	使用 [Inject] 或 @inject 注入的服务不具有和组件相同的生命周期，必须使用 ScopedService 的 GetRequiredService 或 GetService 方法获取的服务才具有。

```c#
@page "/preferences"
@using Microsoft.Extensions.DependencyInjection
@inherits OwningComponentBase

<ul>
    @foreach (var user in UserService.GetAll())
    {
        <li>@user.Name</li>
    }
</ul>

@code {
    private IUserService UserService { get; set; }
    protected override void OnInitialized()
    {
        UserService = ScopedServices.GetRequiredService<IUserService>();
    }
}
```

### OwningComponentBase\<TService>

​	TService 为组件需要使用的主服务的类型，组件可以自动创建出和组件具有相同生命周期的此类型的服务。

​	当然，IServiceProvider 类型的 ScopedService 属性依然可用，以获取与组件生命周期一致的其它服务。

```html
@page "/users"
@attribute [Authorize]
@inherits OwningComponentBase<AppDbContext>

<h1>Users (@Service.Users.Count())</h1>

<ul>
    @foreach (var user in Service.Users)
    {
        <li>@user.UserName</li>
    }
</ul>
```

## 使用DI的EntityFramework DbContext

​	一般情况下通过DI获取的EF DbContext服务也存在生命周期比组件更长而跨应用共享，DbContext不是线程安全的且不得同时使用。

### 组件内不存在并发

​	直接使用 OwningComponentBase 获取Scoped的DbContext即可避免组件之间共享同一DbContext对象并发的问题。

### 组件内存在并发

​	如果组件内仍可能存在并发的问题，则需要把DbContext服务注册为Transient生命周期，并在每次需要时临时获取

```c#
@inject IServiceProvider ServiceProvider
using (var context = ServiceProvider.GetRequiredService<AppDbContext>())
{
	return await context.Products.Select(p => p.Name).ToListAsync();
}
```

# 环境 (WebAssembly)

> 在本地运行应用时，环境默认为开发环境。 发布应用时，环境默认为生产环境。

​	对于在本地运行的独立应用，开发服务器会添加 `blazor-environment` 标头来指定开发环境。 要为其他宿主环境指定环境，请添加 `blazor-environment` 标头。

​	将自定义的标头添加到已发布的`web.config`文件中

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>
    <httpProtocol>
      <customHeaders>
        <add name="blazor-environment" value="Staging" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>
</configuration>
```

## 获取环境

```c#
@page "/"
@using Microsoft.AspNetCore.Components.WebAssembly.Hosting
@inject IWebAssemblyHostEnvironment HostEnvironment

<p>Environment: @HostEnvironment.Environment</p>

if (builder.HostEnvironment.Environment == "Custom");
if (builder.HostEnvironment.IsDevelopment());
if (builder.HostEnvironment.IsProduction());
if (builder.HostEnvironment.IsStaging());
if (builder.HostEnvironment.IsEnvironment("Custom"));
```

# Logging

​	使用 `Program.Main` 中的 `WebAssemblyHostBuilder.Logging` 属性在 Blazor WebAssembly 应用中配置日志：

```c#
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddProvider(new CustomLoggingProvider());
```

> 安装 Microsoft.Extensions.Logging Nuget 以使用 ILogger 的静态扩展方法

```c#
@page "/counter"
@using Microsoft.Extensions.Logging;
@inject ILogger<Counter> logger;

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
@code {
    private int currentCount = 0;
    private void IncrementCount()
    {
        logger.LogWarning("Someone has clicked me!");
        currentCount++;
    }
}
```

### ILoggerFactory

```c#
@page "/counter"
@using Microsoft.Extensions.Logging;
@inject ILoggerFactory LoggerFactory

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;
    private void IncrementCount()
    {
        var logger = LoggerFactory.CreateLogger<Counter>();
        logger.LogWarning("Someone has clicked me!");
        currentCount++;
    }
}
```

# 处理错误

​	出现异常时，Blazor应用会在底部显示一个黄色条框：

- 在开发过程中，黄色条框会将你定向到浏览器控制台，你可在其中查看异常。
- 在生产过程中，黄色条框会通知用户发生了错误，并建议刷新浏览器。

在 Blazor WebAssembly 应用的 `wwwroot/index.html` 文件中自定义体验：

```html
<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

在 Blazor Server 应用的 `Pages/_Host.cshtml` 文件中自定义体验：

```cshtml
<div id="blazor-error-ui">
    <environment include="Staging,Production">
        An error has occurred. This application may no longer respond until reloaded.
    </environment>
    <environment include="Development">
        An unhandled exception has occurred. See browser dev tools for details.
    </environment>
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

`blazor-error-ui` 元素被 Blazor 模板（`wwwroot/css/app.css` 或 `wwwroot/css/site.css`）附带的样式隐藏，并会在发生错误时显示：

## Blazor Server 应用如何应对未经处理的异常

​	Blazor Server 是一种有状态框架。 用户与应用进行交互时，会与服务器保持名为“线路”的连接。 线路包含活动组件实例，以及状态的许多其他方面，例如：

- 最新呈现的组件输出。
- 可由客户端事件触发的事件处理委托的当前集合。

​	如果用户在多个浏览器标签页中打开应用，则具有多条独立线路。

​	Blazor 将大部分未经处理的异常视为发生该异常的线路的严重异常。 如果线路由于未经处理的异常而终止，则用户只能重新加载页面来创建新线路，从而继续与应用进行交互。 终止的线路以外的其他线路（即其他用户或其他浏览器标签页的线路）不会受到影响。 此场景类似于出现故障的桌面应用。 出现故障的应用必须重新启动，但其他应用不受影响。

​	当发生未经处理的异常时，线路会终止，原因如下：

- 未经处理的异常通常会将线路置于未定义状态。
- 发生未经处理的异常后，应用可能无法正常运行。
- 如果不终止线路，则可能导致应用中出现安全漏洞。

## 在开发人员代码中管理未经处理的异常

​	在生产环境中，不要在 UI 中呈现框架异常消息或堆栈跟踪信息。 呈现异常消息或堆栈跟踪信息可能导致：

- 向最终用户公开敏感信息。
- 帮助恶意用户发现应用中可能会危及应用、服务器或网络安全的弱点

## 使用永久性提供程序记录错误信息

​	在发生未经处理的异常时，将异常记录到在服务容器中配置的 ILogger 实例。 默认情况下，Blazor 应用使用控制台日志记录提供程序记录到控制台输出中。 请考虑使用管理日志大小和日志轮换的提供程序将日志记录到更持久的位置。

​	在开发过程中，Blazor 通常会将异常的完整详细信息发送到浏览器的控制台，以帮助进行调试。 在生产环境中，浏览器控制台中的错误详细信息默认禁用，也就是说错误信息不会发送到客户端，但异常的完整详细信息仍记录在服务器端。

​	必须确定要记录的事件以及已记录的事件的严重性级别。 恶意用户也许能刻意触发错误。

## 可能发生错误的位置

### 组件实例化

​	DI容器无法提供组件所需Inject的服务，或构造函数的异常（需要try...catch）

### 生命周期方法

​	组件生命周期内会调用Component内的几个虚方法，其中可能会出现异常

### 呈现逻辑

​	组件内的标记会被编译到 BuildRenderTree 中，如果@的对象为空或@的属性内抛出异常等也会在UI线程发生错误

​	可以提前初始化组件的属性对象

### 事件处理程序

​	组件内绑定的数据或事件等抛出的异常

### 组件处置

​	当需要销毁实现了 IDisposable 的组件时，框架将调用组件的 Dispose 方法。如果 Dispose 方法可能抛出异常，则需要 try...catch 处理

### JavaScript 互操作

​	通过 IJSRuntion.InvokeAsync() 方法与 JavaScript 交互时可能发生的异常：

- 如果无法对 InvokeAsync 进行同步调用，则会发生 .NET 异常。 例如，不能序列化提供的自变量。 开发人员代码必须捕获异常。
- 如果无法对 InvokeAsync 进行异步调用，则 .NET Task 会失败。 例如，JavaScript 端代码会引发异常或返回完成状态为 `rejected` 的 `Promise`。 开发人员代码必须捕获异常。 如果使用 `await` 运算符，请考虑使用 `try...catch` 语句包装方法调用，并进行错误处理和日志记录。
- 默认情况下，对 InvokeAsync 的调用必须在特定时间段内完成，否则调用会超时。默认超时期限为一分钟。超时会保护代码免受网络连接丢失的影响，或者保护永远不会发回完成消息的 JavaScript 代码。 如果调用超时，则生成的 System.Threading.Tasks 将失败，并出现 OperationCanceledException。 捕获异常，并进行异常处理和日志记录。

​	JavaScript 可以调用具有 `[JSInvokable]` 特性的.NET方法，这些.NET方法也可能会引发一场，但不会被视为严重的异常，JavScript端Promise会被拒绝。

### Blazor Server 预呈现

​	Blazor 组件可使用组件标记帮助程序进行预呈现，以便在用户的初始 HTTP 请求过程中返回其呈现的 HTML 标记。 实现方式如下：

- 为属于同一页面的所有预呈现组件创建新的线路。

- 生成初始 HTML。

- 将线路视为 `disconnected`，直到用户浏览器与同一服务器重新建立起 SignalR 连接。 建立该连接后，将恢复线路的交互性，并更新组件的 HTML 标记。

  在正常情况下，如果预呈现失败，则继续生成和呈现组件都将没有作用，因为无法呈现工作组件。

## 高级方案

### 递归呈现

​	组件能以递归方式嵌套，使用与表示递归数据结构。但应避免导致无线递归的编码模式：

- 请勿以递归方式呈现包含循环的数据结构。
- 请勿创建包含循环的布局链。
- 请勿允许最终用户通过恶意数据输入或 JavaScript 互操作调用违反递归固定协定（规则）。

### 自定义呈现器树逻辑

> 高级且不安全，不建议在常规组件中使用

​	Devloper可以使用C#代码手动实现 RenderTreeBUilder 逻辑。需要确保对 OpenElement 和 CloseElement 的调用正确且均衡 (使用栈数据结构维护Element即可)，仅将特性添加到正确的位置。

# 组件

​	Blazor是基于组件构建的。组件包含用户界面、数据、事件、逻辑等，十分灵活，且可以嵌套、复用、共享。

## 名称

​	组件名称必须首字母大写，否则无效

## 路由

​	`@page` 指令为组件生成路由模板的 RouteAttribute

## 标记

​	编译时，HTML标记和C#呈现逻辑被转换为组件类。生成的类的名称与文件名匹配。

​	组件类的成员在 `@code` 块中定义，可以有多个。

​	可以使用 @ 开头的C#表达式将组件成员作为组件的呈现逻辑的一部分。

```c#
<h1 style="font-style:@headingFontStyle">@headingText</h1>
@code {
    private string headingFontStyle = "italic";
    private string headingText = "Put on your new Blazor!";
}
```

​	呈现组件后，组件会为响应事件而重新生成呈现树，然后Blazor将比较两个呈现树并对浏览器文档对象模型DOM应用任何修改。

## 命名空间

​	通常，组件的命名空间是从应用的跟命名空间和该组件在应用内的位置派生而来的。

​	使用指令 `@namespace` 指定组件的命名空间。

## 分部类支持

​	Razor组件会自动编译成分部类，也可以创建同名的C#类，并通过添加 `partial` 将其合并为分部类。

## 指定基类

​	使用 `@inherits` 指令指定组件的基类。

## 使用组件

​	通过HTML元素语法声明组件，标签的名称是组件的类型。

## 参数

### 路由参数

​	组件可以接受来自`@page`指令所提供的路由模板的路由参数。

​	不支持可选参数，可以使用多个`@page`指令配置多个包含不同参数的路由。

​	不支持 Catch-all (*/**) 参数语法。

### 组件参数

​	组件的参数是组件类中包含 `[Parameter]` 特性的公共属性定义的。使用这些属性在标记中为组件指定参数。

​	子内容和事件也以这种方式提供。

```c#
<div class="panel panel-default">
    <div class="panel-heading">@Title</div>
    <div class="panel-body">@ChildContent</div>
    <button class="btn btn-primary" @onclick="OnClickCallback">
        Trigger a Parent component method
    </button>
</div>

@code {
    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

```html
<ChildComponent Title="Panel Title from Parent" OnClickCallback="@ShowMessage">
    Content of the child component is supplied by the parent component.
</ChildComponent>
```

## 子内容

​	组件可以在组件标记之间提供另一个组件的内容。属性名称和类型是固定的。

```c#
[Parameter]
public RenderFragment ChildContent { get; set; }
```

## 属性展开和任意参数

​	除了组件声明的参数以外，还可以捕获和呈现其他属性。其他属性可以在字典中捕获，并通过 `@attributes` 指令呈现。

```c#
<input id="useIndividualParams" placeholder="@Placeholder" />
<input id="useAttributesDict" @attributes="InputAttributes" />

@code {
    [Parameter]
    public string Placeholder { get; set; } = "Input placeholder text 1";

    [Parameter]
    public Dictionary<string, object> InputAttributes { get; set; } =
        new Dictionary<string, object>()
        {
            { "placeholder", "Input placeholder text 2" },
        };
}
```

​	参数的类型必须使用字符串键实现`IEnumerable<KeyValuePair<string, object>>` 或 `IReadOnlyDictionary<string, object>`。

​	要接受任意特性，需要使用 `Parameter` 特性定义组件参数，并将 `CaptureUnmatchedValue` 属性设置为 true

```c#
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }
}
```

## 捕捉对组件的引用

​	可以使用 `@ref` 指令引用组件的实例到同类型的字段，以便于向实例发出命令。

​	仅在呈现组件后填充成员，可以在 `OnAfterRenderAsync` 或 `OnAfterRender` 方法后操作组件引用。

```c#
<MyLoginDialog @ref="loginDialog" ... />
    
@code {
    private MyLoginDialog loginDialog;
    
    private void OnSomething()
    {
        loginDialog.Show();
    }
}
```

### 捕捉循环中的组件

​	需要一点骚操作。

```c#
@for (int i = 0; i < 10; i++)
{
    <MyComponent @ref="component"/>
}

@code
{
    MyComponent component { set => components.Add(value); }

    List<MyComponent> components = new List<MyComponent>();
}
```

​	或者

```c#
@for (int i = 0; i < 10; i++)
{
    <MyComponent @ref="components.Add((MyComponent)__value);//" />
}

@code
{
    List<MyComponent> components = new List<MyComponent>();
}
```

​	引用组件不是JavaScript互操作功能，组件引用不会传递给JS，而只可以在.Net代码中使用。

## 同步上下文

​	Blazor 使用同步上下文(SynchronizationContext)强制执行单个逻辑线程。组件的生命周期方法和事件回调都在此同步上下文上执行。

## 避免阻止线程的调用

​	通常，不要调用一下方法，以免阻止线程直到Task完成。

## 在外部调用组件方法以更新状态

​	如果组件需要根据外部事件进行更新，使用 InvokeAsync() 和 StateHasChanged() 方法更新UI。

```c#
@page "/"
@inject NotifierService Notifier
@implements IDisposable

<p>Last update: @lastNotification.key = @lastNotification.value</p>

@code {
    private (string key, int value) lastNotification;

    protected override void OnInitialized()
        => Notifier.Notify += OnNotify;

    public async Task OnNotify(string key, int value)
        => await InvokeAsync(() =>
        {
            lastNotification = (key, value);
            StateHasChanged();
        });

    public void Dispose()
        => Notifier.Notify -= OnNotify;
}
```

## @key 控制是否保留元素和组件

​	呈现元素或组件的列表发生更改时，Blazor需要先决定哪些可以保留，以及模型对象如何映射到元素或组件。通常，这个过程是自动的，也可以通过`@key`控制该映射过程，使比较算法基于key的值保留元素或组件。

```
@foreach (var person in People)
{
    <DetailsEditor @key="people" Details="@person.Details" />
}

@code {
    [Parameter]
    public IEnumerable<Person> People { get; set; }
}
```

​	每个容器元素或组件而言，键是本地的，不会在整个文档中全局比较key。

### 何时使用@key

​	通常，每当列表呈现且存在合适的值来定义key时，最好使用key。还可以使用key来防止Blazor在对象发生变化时保留元素或组件子树。

```html
<div @key="currentPerson">
    ... content that depends on currentPerson ...
</div>
```

​	Blazor可以在currentPeople变化时强制放弃整个\<div>及其子组件，并生成新的元素。对于不保留UI状态的场景很有用。

### 何时不适用@key

​	使用key比较也会产生性能成本，因此应该在key有益的场景下使用。

### @key使用哪些值

​	key的值不允许冲突，否则Blazor将会引发异常。

- 模型对象实例，可以确保基于对象引用相等性的保留。
- 唯一的主键标识符

## 请勿创建会写入其自己的组参数属性的组件

​	下述情况会重写参数：

- 子组件以RenderFragment呈现
- 调用父组件的StateHasChanged方法

​	反例：

```C#
<div @onclick="@Toggle" class="card text-white bg-success mb-3">
    <div class="card-body">
        <div class="panel-heading">
            <h2>Toggle (<code>Expanded</code> = @Expanded)</h2>
        </div>

        @if (Expanded)
        {
            <div class="card-text">
                @ChildContent
            </div>
        }
    </div>
</div>

@code {
    [Parameter]
    public bool Expanded { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private void Toggle()
    {
        Expanded = !Expanded;
    }
}
```

```html
@page "/expander"

<Expander Expanded="true">
    Expander 1 content
</Expander>

<Expander Expanded="true" />

<button @onclick="StateHasChanged">
    Call StateHasChanged
</button>
```

​	在父组件StateHasChanged()之后，第一个Expander的Expanded属性均会被重写为true，而第二个不会，因为其没有子内容。

​	正确的做法是使用私有字段来保留状态：

- 使用公开属性接受父组件传递的参数
- 将组件参数值在OnInitialized事件中分配给私有字段
- 使用私有字段维持内部状态

```c#
<div @onclick="@Toggle" class="card text-white bg-success mb-3">
    <div class="card-body">
        <div class="panel-heading">
            <h2>Toggle (<code>expanded</code> = @expanded)</h2>
        </div>

        @if (expanded)
        {
            <div class="card-text">
                @ChildContent
            </div>
        }
    </div>
</div>

@code {
    private bool expanded;

    [Parameter]
    public bool Expanded { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    protected override void OnInitialized()
    {
        expanded = Expanded;
    }

    private void Toggle()
    {
        expanded = !expanded;
    }
}
```

## 应用属性

​	可以通过`@attribute`指令在Razor组件中应用属性。

```
@attribute [Authorize]
```

## 条件HTML元素属性

​	HTML元素属性基于.Net 值有条件的呈现。如果为false或null则布城线属性，否则为true，以最小化呈现属性。

```c#
<input type="checkbox" checked="@IsCompleted" />

@code {
    [Parameter]
    public bool IsCompleted { get; set; }
}
```

​	有些属性无法使用bool类型，请改成string类型。

## 原始HTML

​	如果需要将文本显示为HTML，应该将文本包装在`MarkupString`中。

> 从任何不受信任的源构造原始HTML存在风险，应避免！

```c#
@((MarkupString)myMarkup)

@code {
    private string myMarkup = 
        "<p class='markup'>This is a <em>markup string</em>.</p>";
}
```

## Razor模板

​	使用 `RenderFragment` 和 `RenderFragment\<TValue>` 在组件中直接呈现目标那，也可以将呈现片段作为参数传递给模板化组件。

```c#
@timeTemplate

@petTemplate(new Pet { Name = "Rex" })

@code {
    private RenderFragment timeTemplate = @<p>The time is @DateTime.Now.</p>;
    private RenderFragment<Pet> petTemplate = (pet) => @<p>Pet: @pet.Name</p>;

    private class Pet
    {
        public string Name { get; set; }
    }
}
```

## 静态资产

​	静态资产放在`wwwroot`下，使用基相对路径`/`即可引用。

```html
<img alt="Company logo" src="/images/logo.png" />
```

# 内置组件

## 身份验证

> https://docs.microsoft.com/zh-cn/aspnet/core/blazor/security/webassembly/?view=aspnetcore-3.1#authentication-component