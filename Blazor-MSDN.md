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

### 级联值和参数

​	级联值和参数用于在有多个组件层时使祖先组件为**所有**子组件提供值。使用 CascadingValue\<TValue> 组件包装组件层次结构的子树，并向该子树内的所有组件提供单个值。如果有多个级联值，可以嵌套多个该组件。

​	为了使用级联值，组件使用`[CascadingParameter\]` 特性来声明级联参数，级联值按类型绑定到级联参数。如果有多个相同类型的级联参数，需要向级联组件和对应的`[CascadingParameter]`特性提供唯一的Name。

```c#
/// 作为级联值的类
public class ThemeInfo { public string Class { get; set; } }
```

````html
@* 布局组件 *@
@inherits LayoutComponentBase

<div class="container-fluid">
    <div class="col-sm-9">
        @* 使用CascadingValue组件包装并传递级联值 *@
        <CascadingValue Value="labelTheme" Name="LabelClass">
            <CascadingValue Value="buttonTheme" Name="ButtonClass">
            	<div class="content px-4">
                	@Body
	            </div>
    	    </CascadingValue>
        </CascadingValue>
    </div>
</div>

@code {
    private ThemeInfo buttonTheme = new ThemeInfo { Class = "btn-success" };
    private ThemeInfo labelTheme = new ThemeInfo { Class = "h3" };
}
````

```html
@page "/page"
@layout MainLayout

<p class="@labelTheme.Class">I am a label</p>
<button class="btn @buttonTheme.Class">Click Me</button>

@code {
	[CascadingParameter(Name = "ButtonTheme")]
    protected ThemeInfo buttonTheme { get; set; }

	[CascadingParameter(Name = "LabelTheme")]
	protected ThemeInfo labelTheme { get; set; }
}
```

## 数据绑定

​	Razor 组件使用`@bing`HTML元素特性实现数据绑定，其具有字段、属性或Razor表达式值。

```html
<input @bind="CurrentValue" />

@code {
    private string CurrentValue { get; set; }
}
```

​	等效于：

```c#
<input value="@CurrentValue"
    @onchange="@((ChangeEventArgs __e) => CurrentValue = 
        __e.Value.ToString())" />
        
@code {
    private string CurrentValue { get; set; }
}
```

​	呈现组件时，输入元素的 `value` 来自 `CurrentValue` 属性。 用户在文本框中键入并更改元素焦点时，会激发 `onchange` 事件并将 `CurrentValue` 属性设置为更改的值。 实际上，代码生成更加复杂，因为 `@bind` 会处理执行类型转换的情况。 原则上，`@bind` 将表达式的当前值与 `value` 属性关联，并使用注册的处理程序处理更改。

​	通过同时包含带有 `event` 参数的 `@bind:event` 属性，在其他事件上绑定属性或字段。

​	通过 `@bind-{ATTRIBUTE}:event` 语法使用 `@bind-{ATTRIBUTE}` 可绑定除 `value` 之外的元素属性。

​	注意bind的大小写，`@bind`有效，`@Bind`和`@BIND`无效。

### 无法分析的值

​	如果用户向数据绑定元素提供无法分析的值，则在触发绑定事件时，无法分析的值会自动还原为以前的值。

### 格式字符串

​	数据绑定使用 `@bind:format` 作为格式字符串。

### 使用组件参数的父级到子级绑定

​	绑定可识别组件参数，其中 `@bind-{PROPERTY}` 可以将属性值从父组件向下绑定到子组件。

​	要求子组件必有与绑定属性匹配的事件：

- EventCallBack\<TValue> 必须命名为组件参数后跟 `Changed` 后缀。

```C#
<h2>Child Component</h2>

<p>Year: @Year</p>

@code {
    [Parameter]
    public int Year { get; set; }
    
    [Parameter]
    public EventCallback<int> YearChanged { get; set; }
}
```

```asp
@page "/ParentComponent"

<h1>Parent Component</h1>
<p>ParentYear: @ParentYear</p>

@* 绑定父组件的 ParentYear 到子组件的 Year *@
<ChildComponent @bind-Year="ParentYear" />
@* 等效于 *@
<ChildComponent @bind-Year="ParentYear" @bind-Year:event="YearChanged" />

<button class="btn btn-primary" @onclick="ChangeTheYear">Change ParentYear to 1986</button>

@code {
    [Parameter]
    public int ParentYear { get; set; } = 1978;

    private void ChangeTheYear()
    {
        ParentYear = 1986;
    }
}
```

### 使用链接绑定的子级到父级绑定

​	一种常见方案是将数据绑定参数链接到组件输出中的页面元素。 此方案称为链接绑定，因为多个级别的绑定会同时进行。

​	无法在页面元素中使用 `@bind` 语法实现链接绑定。 必须单独指定事件处理程序和值。 但是，父组件可以将 `@bind` 语法用于组件的参数。

```C#
<h1>Child Component</h1>
<input @oninput="OnPasswordChanged" value="@Password" />

@code {
    [Parameter]
    public string Password { get; set; }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        Password = e.Value.ToString();
        return PasswordChanged.InvokeAsync(Password);
    }
}
```

```asp
@page "/ParentComponent"

<h1>Parent Component</h1>

<PasswordField @bind-Password="password" />

@code {
    private string password;
}
```



## 事件处理

​	Razor 组件提供事件处理功能。 对于具有委托类型值的名为 `@on{EVENT}` 的 HTML 元素属性，Razor 组件将此属性的值视为事件处理程序。

​	事件处理程序也可以是异步处理程序，并返回 Task，无需手动调用StateHasChanged。异常发生时，将会被记录下来。

```c#
<button class="btn btn-primary" @onclick="UpdateHeading">Update heading</button>
<input type="checkbox" class="form-check-input" @onchange="CheckChanged" />

@code {
    private async Task UpdateHeading(MouseEventArgs e) { ... }
    private void CheckChanged() { ... }
}
```

### 事件参数类型

​	对于某些事件，允许使用事件参数类型。 在事件方法定义中指定事件参数是可选操作，只有当方法中使用了事件类型时才是必需的。

| 事件      | 类               | DOM 事件和说明         |
| :------- | :--------------- | :------------------- |
| 剪贴板   | ClipboardEventArgs | `oncut`, `oncopy`, `onpaste`                                 |
| 拖动     | DragEventArgs | `ondrag`, `ondragstart`, `ondragenter`, `ondragleave`, `ondragover`, `ondrop`, `ondragend`  DataTransfer 和 DataTransferItem 保留拖动的项数据。 |
| 错误     | ErrorEventArgs | `onerror' |
| 事件     | EventArgs | *常规* `onactivate`, `onbeforeactivate`, `onbeforedeactivate`, `ondeactivate`, `onfullscreenchange`, `onfullscreenerror`, `onloadeddata`, `onloadedmetadata`, `onpointerlockchange`, `onpointerlockerror`, `onreadystatechange`, `onscroll`  *剪贴板* `onbeforecut`, `onbeforecopy`, `onbeforepaste`  *输入* `oninvalid`, `onreset`, `onselect`, `onselectionchange`, `onselectstart`, OnSubmit  *介质* `oncanplay`, `oncanplaythrough`, `oncuechange`, `ondurationchange`, `onemptied`, `onended`, `onpause`, `onplay`, `onplaying`, `onratechange`, `onseeked`, `onseeking`, `onstalled`, `onstop`, `onsuspend`, `ontimeupdate`, `onvolumechange`, `onwaiting`  EventHandlers 保留属性，以配置事件名称和事件参数类型之间的映射。 |
| 焦点     | FocusEventArgs | `onfocus`, `onblur`, `onfocusin`, `onfocusout`  不包含对 `relatedTarget` 的支持。 |
| 输入     | ChangeEventArgs | `onchange`，`oninput' |
| 键盘     | KeyboardEventArgs | `onkeydown`, `onkeypress`, `onkeyup' |
| 鼠标     | MouseEventArgs | `onclick`, `oncontextmenu`, `ondblclick`, `onmousedown`, `onmouseup`, `onmouseover`, `onmousemove`, `onmouseout' |
| 鼠标指针 | PointerEventArgs | `onpointerdown`, `onpointerup`, `onpointercancel`, `onpointermove`, `onpointerover`, `onpointerout`, `onpointerenter`, `onpointerleave`, `ongotpointercapture`, `onlostpointercapture' |
| 鼠标滚轮 | WheelEventArgs | `onwheel`，`onmousewheel' |
| 进度     | ProgressEventArgs | `onabort`, `onload`, `onloadend`, `onloadstart`, `onprogress`, `ontimeout' |
| 触控     | TouchEventArgs | `ontouchstart`, `ontouchend`, `ontouchmove`, `ontouchenter`, `ontouchleave`, `ontouchcancel`  TouchPoint 表示触控敏感型设备上的单个接触点。 |

### Lambda表达式

```html
<button @onclick="@(e => Console.WriteLine("Hello, world!"))">Say hello</button>
```

### EventCallback

​		嵌套组件的一个常见场景：希望在子组件事件发生时运行父组件的方法。 子组件中发生的 `onclick` 事件是一个常见用例。 若要跨组件公开事件，请使用 EventCallback，父组件可向子组件的 EventCallback 分配回调方法。

​	EventCallback 和 EventCallback 允许异步委托。EventCallback 是弱类型，允许将任何类型参数传入 `InvokeAsync(Object)`。EventCallback 是强类型，需要将 `T` 参数传入可分配到 `TValue` 的 `InvokeAsync(T)` 中。

### 阻止默认操作

​	使用 `@on{EVENT}:preventDefault` 指令属性可阻止事件的默认操作。

​	属性的值也可以是表达式。指定没有值的 `@on{EVENT}:preventDefault` 属性等同于 `@on{EVENT}:preventDefault="true"`。

```c#
<input value="@count" @onkeypress="KeyHandler" @onkeypress:preventDefault />

@code {
    private int count = 0;

    private void KeyHandler(KeyboardEventArgs e)
    {
        if (e.Key == "+")
        {
            count++;
        }
    }
}
```

### 停止事件传播

​	使用 `@on{EVENT}:stopPropagation` 指令属性来停止事件传播。

```c#
<label>
    <input @bind="stopPropagation" type="checkbox" />
    Stop Propagation
</label>

<div @onclick="OnSelectParentDiv">
    <h3>Parent div</h3>

    <div @onclick="OnSelectChildDiv">
        Child div that doesn't stop propagation when selected.
    </div>

    <div @onclick="OnSelectChildDiv" @onclick:stopPropagation="stopPropagation">
        Child div that stops propagation when selected.
    </div>
</div>

@code {
    private bool stopPropagation = false;

    private void OnSelectParentDiv() => 
        Console.WriteLine($"The parent div was selected. {DateTime.Now}");
    private void OnSelectChildDiv() => 
        Console.WriteLine($"A child div was selected. {DateTime.Now}");
}
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

​	使用 `RenderFragment` 和 `RenderFragment<TValue>` 在组件中直接呈现目标片段，也可以将呈现片段作为参数传递给模板化组件。

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

​	Blazor WebAssembly 支持通过 `Microsoft.AspNetCore.Components.WebAssembly.Authentication` 库使用 `OIDC(Open ID Connect)` 对应用进行身份验证和授权。 该库提供一组基元，可用于对 ASP.NET Core 后端进行无缝身份验证。

​	Balzor WebAssembly 中的身份验证支持建立在 `oidc-client.js` 库的基础上，用于处理基础身份验证协议。Blazor Web Assembly的工程设计决定，OAuth和OIDC是在BlazorWebAssembly应用中进行身份验证的最佳选择。

​	基于以下原因选择以 `JSONWebToken (JWT)` 而不是 cookie 为基础的身份验证。

- 使用基于令牌的协议可以减小攻击面，因为并非所有请求中都会发送令牌。
- 服务器终结点不要求针对跨站点请求伪造 (CSRF)进行保护，因为会显式发送令牌。
- 令牌的权限比 cookie 窄。 例如，令牌不能用于管理用户帐户或更改用户密码，除非显式实现了此类功能。
- 令牌的生命周期更短（默认为一小时），这限制了攻击时间窗口。 还可随时撤销令牌。
- 自包含 JWT 向客户端和服务器提供身份验证进程保证。
- OAuth 和 OIDC 的令牌不依赖于用户代理行为正确以确保应用安全。
- 基于令牌的协议允许用同一组安全特征对托管和独立应用进行验证和授权。

### 使用 OIDC 的身份验证进程

​	`Microsoft.AspNetCore.Components.WebAssembly.Authentication` 库提供几个基元，用于使用 OIDC 实现身份验证和授权。

​	从广义上说来，身份验证的原理如下：

- 当匿名用户选择登录按钮或请求应用了 `[Authorize\]` 特性的页面时，会将其重定向到应用的登录页 (`/authentication/login`)。
- 在登录页上，身份验证库准备重定向到授权终结点。

​	授权终结点在 Blazor WebAssembly 应用之外，可以托管在单独的原点上。该终结点负责确定用户是否通过身份验证，并发送一个或更多令牌作为响应。

 

身份验证库提供登录回叫以接收身份验证响应。

- 如果用户未通过身份验证，则会被重定向到底层身份验证系统，通常是 ASP.NET Core Identity。
- 如果用户已通过身份验证，则授权终结点会生成相应的令牌，并将浏览器重定向回登录回叫终结点 (`/authentication/login-callback`)。
- 当 Blazor WebAssembly 应用加载登录回叫终结点 (`/authentication/login-callback`) 时，就处理了身份验证响应。
  - 如果身份验证进程成功完成，则用户通过身份验证，可以选择返回该用户请求的原受保护 URL。
  - 如果身份验证进程由于任何原因而失败，会将用户导向登录失败页 (`/authentication/login-failed`)，并显示错误。

### Authentication 组件

​	`Authentication` 组件 (`Pages/Authentication.razor`) 会处理远程身份验证操作并允许应用：

- 为身份验证状态配置应用路由。
- 为身份验证状态设置 UI 内容。
- 管理身份验证状态。

​	身份验证操作（例如注册用户或使用户登录）传递到 Blazor 框架的 [RemoteAuthenticatorViewCore](https://docs.microsoft.com/zh-cn/dotnet/api/microsoft.aspnetcore.components.webassembly.authentication.remoteauthenticatorviewcore-1) 组件，该组件会保留和控制整个身份验证操作中的状态。

### 授权

​	在 Blazor WebAssembly 应用中，可绕过授权检查，因为用户可修改所有客户端代码。 所有客户端应用程序技术都是如此，其中包括 JavaScript SPA 框架或任何操作系统的本机应用程序。

​	**始终对客户端应用程序访问的任何 API 终结点内的服务器执行授权检查。**

### 需要对整个应用授权

​	使用以下方法之一将 `[Authorize]` 特性应用到每个Razor组件上：

- 在 `_Imports.razor` 文件中使用 `@attribute` 指令

```
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize]
```

- 向 Pages 目录下每个Razor组件添加属性

### 刷新令牌

​	在 Blazor WebAssembly 应用中，无法在客户端保护刷新令牌。 因此，不得将刷新令牌发送到应用以供直接使用。在托管的 Blazor WebAssembly 解决方案中，服务器端应用可以维护和使用刷新令牌来访问第三方 API。

### AuthorizeView 组件

​	AuthorizeView 组件可以根据用户是否有权查看来选择性显示UI。如果需要为用户显示数据，而不需要在过程逻辑中使用用户标识，此方法很有用。

​	此组件公开一个 `AuthenticationState`类型的`context`变量，可以使用变量来访问有关登录用户的信息。并通过 `<Authorized>` 和 `<NotAuthorized>` 显示登录前后的内容。

```html
<AuthorizeView>
    <h1>Hello, @context.User.Identity.Name!</h1>
    <p>You can only see this content if you're authenticated.</p>
</AuthorizeView>

<AuthorizeView>
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're authenticated.</p>
    </Authorized>
    <NotAuthorized>
        <h1>Authentication Failure!</h1>
        <p>You're not signed in.</p>
    </NotAuthorized>
</AuthorizeView>
```

​	可以在导航组件使用此组件用于区分显示导航，但是仅仅隐藏了导航项目，并不能阻止用户尝试访问此地址。

​	如果未指定授权条件，则此组件使用默认策略，登录用户视为授权，未登录用户视为未授权。

#### 基于角色和基于策略的授权

​	使用 `Roles` 参数指定基于角色的授权。

```html
<AuthorizeView Roles="admin, superuser">
    <p>You can only see this if you're an admin or superuser.</p>
</AuthorizeView>
```

​	使用 `Policy` 参数指定基于策略的授权。

```html
<AuthorizeView Policy="content-editor">
    <p>You can only see this if you satisfy the "content-editor" policy.</p>
</AuthorizeView>
```

#### 异步身份验证期间显示的内容

​	通过 Blazor，可通过异步方式确定身份验证状态。正在进行身份验证时，AuthorizeView 默认情况下不显示任何内容。 若要在进行身份验证期间显示内容，请使用 `<Authorizing>` 标记：

```html
<AuthorizeView>
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're authenticated.</p>
    </Authorized>
    <Authorizing>
        <h1>Authentication in progress</h1>
        <p>You can only see this content while authentication is in progress.</p>
    </Authorizing>
</AuthorizeView>
```

### Authorize 特性

​	`[Authorize]` 特性可以在Razor组件中使用。

​	只在通过 Blazor 路由器到达的 `@page` 组件上使用 `[Authorize\]`。授权仅作为路由的一个方面执行，而不是作为页面中呈现的子组件来执行。 若要授权在页面中显示特定部分，请改用 AuthorizeView。

```
@page "/"
@attribute [Authorize]

You can only see this if you're signed in.
```

​	基于角色或基于策略的授权：

```c#
@page "/"
@attribute [Authorize(Roles = "admin, superuser")]

<p>You can only see this if you're in the 'admin' or 'superuser' role.</p>
```

### 使用路由器组件自定义未授权内容

​	Router 组件与 AuthorizeRouteView 组件搭配使用时，可允许应用程序在以下情况下指定自定义内容：

- 找不到内容。
- 用户不符合应用于组件的 `[Authorize]` 条件。
- 正在进行异步身份验证。

### 有关身份验证状态更改的通知

​	如果应用确定基础身份验证状态数据已更改（例如，由于用户已注销或其他用户已更改其角色），则自定义 `AuthenticationStateProvider` 可以选择对 `AuthenticationStateProvider` 基类调用 `NotifyAuthenticationStateChanged` 方法。 这会通知身份验证状态数据使用者使用新数据重新呈现。

### 过程逻辑

​	如果需要应用在过程逻辑中检查授权规则，请使用类型为 `Task<AuthenticationState>` 的级联参数来获取用户的 ClaimsPrincipal。 `Task<AuthenticationState>` 可以与其他服务结合使用来评估策略。

```c#
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@inject IAuthorizationService AuthorizationService

<button @onclick="@DoSomething">Do something important</button>

@code {
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private async Task DoSomething()
    {
        var user = (await authenticationStateTask).User;

        if (user.Identity.IsAuthenticated)
        {
            // Perform an action only available to authenticated (signed-in) users.
        }

        if (user.IsInRole("admin"))
        {
            // Perform an action only available to users in the 'admin' role.
        }

        if ((await AuthorizationService.AuthorizeAsync(user, "content-editor")).Succeeded)
        {
            // Perform an action only available to users satisfying the 'content-editor' policy.
        }
    }
}
```

### 排查错误

​	常见错误：

- **授权需要 `Task<AuthenticationState>` 类型的级联参数。请考虑使用 `CascadingAuthenticationState` 来提供此参数。**
- **对于 `authenticationStateTask`，收到了 `null` 值**

## 内置表单组件

​	Blazor 支持数据注释特性定义数据验证逻辑。

```c#
using System.ComponentModel.DataAnnotations;

public class ExampleModel
{
    [Required]
    [StringLength(10, ErrorMessage = "Name is too long.")]
    public string Name { get; set; }
}
```

​	表单使用`<EditForm>`组件定义。

```html
<EditForm Model="@exampleModel" OnValidSubmit="HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <InputText id="name" @bind-Value="exampleModel.Name" />
	<ValidationMessage For="()=>exampleModel.Name" />
    
    <button type="submit">Submit</button>
</EditForm>

@code {
    private ExampleModel exampleModel = new ExampleModel();

    private void HandleValidSubmit()
    {
        Console.WriteLine("OnValidSubmit");
    }
}
```

-  `<EditForm>` 元素的 `Model` 指向需要表单验证的对象。
- `InputText` 组件的 `@bind-Value` 进行以下绑定：
  - 将模型属性绑定到 InputText 组件的 `Value` 属性。
  - 将更改事件委托绑定到 InputText 组件的 `ValueChanged` 属性。
- `DataAnnotationsValidator` 组件使用数据注释附加验证支持。
-  `ValidationSummary` 组件汇总验证消息。
-  `ValidationMessage` 组件显示单个属性的验证消息。
   - 在 `app.css` 或 `site.css` 中控制验证消息的样式：`validation-message`
- 窗体成功提交（通过验证）时触发 `OnValidSubmit` 指向的方法。

### 可用的表单组件

| 输入组件      | 呈现为…                   |
| :------------ | :------------------------ |
| InputText     | `<input>`                 |
| InputTextArea | `<textarea>`              |
| InputSelect   | `<select>`                |
| InputNumber   | `<input type="number">`   |
| InputCheckbox | `<input type="checkbox">` |
| InputDate     | `<input type="date">`     |

### 一个完善的创建/编辑两用表单

```C#
@* 使用两个路由，分别匹配创建和编辑的功能 *@
@page "/PublishCounter"
@page "/PublishCounter/{Area}"

<h3>PublishCounter</h3>

@* 判断表单是否提交并显示提交结果 *@
@if (Result.Status.HasValue)
{
    <div class="alert alert-@(Result.Status.Value?"success":"danger")">
        @Result.Message
    </div>
}
else
{
    @* 向表单绑定数据实例、验证方法 *@
    <EditForm Model="@AreaCounterEntity" OnValidSubmit="OnValidSubmit" OnInvalidSubmit="OnInvalidSubmit">
        @* 数据验证器和验证消息组件 *@
        <DataAnnotationsValidator />
        <ValidationSummary />

        @* 标签和表单控件组合 *@
        <div class="form-group row">
            <label for="@nameof(AreaCounterEntity.Area)" class="col-sm-2 col-form-label">@nameof(AreaCounterEntity.Area)</label>
            <div class="col-sm-10">
                <InputText class="form-control" @bind-Value="AreaCounterEntity.Area" />
                @* 显示针对属性的验证信息 *@
                <ValidationMessage For="()=>AreaCounterEntity.Area" />
            </div>
        </div>

        <div class="form-group row">
            <label for="@nameof(AreaCounterEntity.Count)" class="col-sm-2 col-form-label">@nameof(AreaCounterEntity.Count)</label>
            <div class="col-sm-10">
                <InputNumber class="form-control" @bind-Value="AreaCounterEntity.Count" />
            </div>
        </div>

        <div class="form-group row">
            <label for="@nameof(AreaCounterEntity.PublishDate)" class="col-sm-2 col-form-label">@nameof(AreaCounterEntity.PublishDate)</label>
            <div class="col-sm-10">
                <InputDate class="form-control" @bind-Value="AreaCounterEntity.PublishDate" />
            </div>
        </div>

        <div class="form-group row">
            <label for="@nameof(AreaCounterEntity.DataSource)" class="col-sm-2 col-form-label">@nameof(AreaCounterEntity.DataSource)</label>
            <div class="col-sm-10">
                <InputSelect TValue="DataSources" class="form-control" @bind-Value="AreaCounterEntity.DataSource">
                    @* 使用循环使用枚举项为下拉框填充项 **@
                    @foreach (var item in Enum.GetValues(typeof(DataSources)))
                    {
                        <option value="@item">@item</option>
                    }
                </InputSelect>
            </div>
        </div>

        <div class="form-group row">
            <label for="@nameof(AreaCounterEntity.Hide)" class="col-sm-2 col-form-label">@nameof(AreaCounterEntity.Hide)</label>
            <div class="col-sm-10">
                <InputCheckbox class="form-control" @bind-Value="AreaCounterEntity.Hide" />
            </div>
        </div>

        <div class="form-group row">
            <label for="@nameof(AreaCounterEntity.Remark)" class="col-sm-2 col-form-label">@nameof(AreaCounterEntity.Remark)</label>
            <div class="col-sm-10">
                <InputTextArea class="form-control" @bind-Value="AreaCounterEntity.Remark" />
            </div>
        </div>

        <hr />
        @* 提交事件按钮 *@
        <button type="submit" class="btn btn-primary">Submit</button>
    </EditForm>
}

@code {
    /// <summary>
    /// 表单绑定的对象不可以为空引用
    /// </summary>
    public AreaCounter AreaCounterEntity { get; set; } = new AreaCounter() { Area = "C_" };

    /// <summary>
    /// 接收路由参数
    /// </summary>
    [Parameter]
    public string Area { get; set; }

    [Inject]
    public ICovidCounterService CovidCounterService { get; set; }

    [Inject]
    public ILogger<PublishCounter> Logger { get; set; }

    /// <summary>
    /// 记录提交状态和结果
    /// </summary>
    private (bool? Status, string Message) Result = (null, string.Empty);

    private async Task OnValidSubmit()
    {
        Logger.LogInformation($"{nameof(OnValidSubmit)}: {AreaCounterEntity.Area}=>{AreaCounterEntity.Count}");
        try
        {
            var result = await CovidCounterService.PublishCounterAsync(this.AreaCounterEntity);
            this.Result.Status = result;
            this.Result.Message = "发布成功！";
        }
        catch (Exception ex)
        {
            Logger.LogWarning(ex, $"{nameof(OnValidSubmit)}: {AreaCounterEntity.Area}=>{AreaCounterEntity.Count}");
            this.Result.Status = false;
            this.Result.Message = $"发布失败！\n{ex.Message}";
        }
    }

    private async Task OnInvalidSubmit()
    {
        Result.Status = false;
        Result.Message = "表单验证失败！";
    }

    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation($"{nameof(OnInitializedAsync)}: {nameof(Area)}=>{Area}");
        try
        {
            // 存在路由参数时，读取已有数据，从创建状态进入编辑状态
            if (!string.IsNullOrEmpty(Area))
            {
                AreaCounterEntity = await CovidCounterService.GetAreaCounterAsync(Area);
            }
        }
        catch (Exception ex)
        {
            Logger.LogWarning(ex, $"{nameof(OnInitializedAsync)}: {nameof(Area)}=>{Area}");
        }

        await base.OnInitializedAsync();
    }
}
```

​	EditForm 创建一个 EditContext 作为级联值来跟踪有关编辑过程的元数据，其中包括已修改的字段和当前的验证消息。EditForm 还为有效和无效的提交提供便捷的事件（OnValidSubmit、OnInvalidSubmit）。或者，使用 OnSubmit 触发验证并使用自定义验证代码检查字段值。

```c#
<EditForm EditContext="@editContext" OnSubmit="HandleSubmit">
    <button type="submit">Submit</button>
</EditForm>

@code {
    private Starship starship = new Starship();
    private EditContext editContext;

    protected override void OnInitialized()
    {
        editContext = new EditContext(starship);
    }

    private async Task HandleSubmit()
    {
        var isValid = editContext.Validate() && 
            await ServerValidate(editContext);

        if (isValid)
        {
        }
        else
        {
        }
    }

    private async Task<bool> ServerValidate(EditContext editContext)
    {
        var serverChecksValid = ...
        return serverChecksValid;
    }
}
```

## Blazor布局组件

​	布局也是一个组件。布局在Razor模板或C#代码中定义，并可以使用数据绑定、依赖注入和其他组件方案。

​	创建一个布局组件，需要以下步骤：

- 继承自 LayoutComponentBase，为布局内的呈现内容定义Body属性。
- 使用Razor语法 `@Body` 在布局标记中指定呈现内容的位置。

````c#
@inherits LayoutComponentBase

<header>
    <h1>Doctor Who&trade; Episode Database</h1>
</header>

<nav>
    <a href="masterlist">Master Episode List</a>
    <a href="search">Search</a>
    <a href="new">Add Episode</a>
</nav>

@Body

<footer>
    @TrademarkMessage
</footer>

@code {
    public string TrademarkMessage { get; set; } = "Doctor Who is a registered trademark of the BBC. https://www.doctorwho.tv/";
}
````

### 默认布局

​	在应用的 `App.razor` 文件的 Router 组件中指定默认应用布局。 默认为 `MainLayout` 组件：

```html
<Router AppAssembly="@typeof(Startup).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <p>Sorry, there's nothing at this address.</p>
    </NotFound>
</Router>
```

​	若要为 NotFound 内容提供默认布局，请为 NotFound 内容指定 LayoutView：

```html
<Router AppAssembly="@typeof(Startup).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <h1>Page not found</h1>
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

### 在组件中使用布局

​	使用 Razor 指令 `@layout` 将布局应用于组件。 编译器将 `@layout` 转换为 LayoutAttribute，后者应用于组件类。

​	以下 `MasterList` 组件的内容插入到 `MasterLayout` 中 `@Body` 的位置：

```html
@layout MasterLayout
@page "/masterlist"

<h1>Master Episode List</h1>
```

### 集中式布局选择

​	应用的每个文件夹都可以选择包含名为 `_Imports.razor` 的模板文件。 编译器将导入文件中指定的指令包括在同一文件夹中的所有 Razor 模板内，并在其所有子文件夹中以递归方式包括。 因此，包含 `@layout MyCoolLayout` 的 `_Imports.razor` 文件可确保文件夹中的所有组件都使用 `MyCoolLayout`。 无需将 `@layout MyCoolLayout` 重复添加到文件夹和子文件夹内的所有 `.razor` 文件。 `@using` 指令也以相同的方式应用于组件。

> 请勿向根 `_Imports.razor` 文件添加 Razor `@layout` 指令，这会导致应用中的布局形成无限循环 （因为根_Imports.razor 文件和Shared目录在同一级，会向Shared目录内的布局组件循环嵌套自身布局组件）。 请在 `Router` 组件中指定布局，以控制默认应用布局。

### 嵌套布局

​	应用可以包含嵌套布局。 组件可以引用一个布局，该布局反过来引用另一个布局。

```c#
@layout ListLayout
@page "/list/{Id}/Detail"
<h1>@Id</h1>
@{ public string Id {get; set; } }
```

```asp
@layout MainLayout
@inherits LayoutComponentBase
@* ListLayout *@

<nav>
    ...
</nav>

@Body
```

```asp
@inherits LayoutComponentBase
@* MainLayout *@

<header>...</header>
<nav>...</nav>

@Body

<footer>...</footer>
```

### 与集成组件共享 Razor Pages 布局

​	当可路由组件集成到 Razor Pages 应用中时，该应用的共享布局可与这些组件配合使用。