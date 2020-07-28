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