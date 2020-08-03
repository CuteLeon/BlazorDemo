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

