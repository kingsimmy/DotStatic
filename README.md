# DotStatic
[![NuGet](https://img.shields.io/badge/nuget-v1.0-green.svg)](https://www.nuget.org/packages/DotStatic.Core/1.0.0)

C Sharp C# Static Analysis


DotStatic utilises the Roslyn platform to analyse source code.

DotStatic can run analysis on the files in a C# project to determine all the classes defined in the project and all the classes referenced in the project. This could be used to help in dead code detection.

DotStatic is available as a command line application or as a Nuget package.

The Nuget package is called DotStatic.Core - https://www.nuget.org/packages/DotStatic.Core

The command line version is on the releases tab

Command line example:
--------------------
```
>DotStatic.CommandLine.exe "C:\src\Alchemy-Websockets\Alchemy.sln"
```
```
{
  "ReferencedTypesByProj": {
    "Alchemy": [
      "Alchemy.TcpServer",
      "System.IDisposable",
      "System.Net.IPAddress",
      "string",
      "System.Net.Sockets.TcpClient",
      "System.Net.Sockets.SocketException",
      "System.Text.Encoding",
      "System.Globalization.CultureInfo",
      "int",
      "bool",
      "object",
      "System.Net.Sockets.Socket",
      "byte",
      "Alchemy.Classes.UserContext",
      "Alchemy.Handlers.Handler",
      "Alchemy.Classes.Header",
      "ulong",
      "System.Threading.SemaphoreSlim",
      "Alchemy.WebSocketServer",
      "System.Net.Sockets.SocketAsyncEventArgs",
      "System.Exception",
      "Alchemy.Handlers.WebSocket.DataFrame",
      "Alchemy.Handlers.WebSocket.DataFrame.DataState",
      "Alchemy.Classes.Context",
      "System.Net.EndPoint",
      "Alchemy.Handlers.IAuthentication",
      "Alchemy.Classes.Protocol",
      "Alchemy.Handlers.WebSocket.DataFrame.DataFormat",
      "System.Convert",
      "System.Text.StringBuilder",
      "System.ArraySegment<T>",
      "System.ArraySegment<byte>",
      "System.Collections.Generic.List<T>",
      "Alchemy.Handlers.WebSocket.hybi00.DataFrame",
      "System.Array",
      "Alchemy.Handlers.WebSocket.rfc6455.FrameHeader",
      "Alchemy.Handlers.WebSocket.rfc6455.DataFrame",
      "Alchemy.Handlers.WebSocket.rfc6455.DataFrame.OpCode",
      "System.BitConverter",
      "System.Math",
      "System.Collections.Specialized.NameValueCollection",
      "System.Web.HttpCookieCollection",
      "System.Text.RegularExpressions.Regex",
      "System.Text.RegularExpressions.RegexOptions",
      "System.Text.RegularExpressions.Match",
      "System.Text.RegularExpressions.GroupCollection",
      "System.Text.RegularExpressions.Group",
      "System.Web.HttpCookie",
      "System.Text.RegularExpressions.CaptureCollection",
      "System.Text.RegularExpressions.Capture",
      "char",
      "Alchemy.OnEventDelegate",
      "System.Threading.Thread",
      "System.Environment",
      "Alchemy.Handlers.Handler.HandlerMessage",
      "System.Threading.CancellationTokenSource",
      "Alchemy.Handlers.WebSocket.hybi00.Handler",
      "Alchemy.Handlers.WebSocket.rfc6455.Handler",
      "Alchemy.Classes.Response",
      "System.OperationCanceledException",
      "System.Net.Sockets.SocketError",
      "System.Collections.Concurrent.ConcurrentQueue<T>",
      "Alchemy.AccessPolicyServer",
      "System.Threading.CancellationToken",
      "System.Collections.Generic.IList<T>",
      "System.EventHandler<TEventArgs>",
      "Alchemy.Handlers.WebSocket.WebSocketHandler",
      "Alchemy.Handlers.WebSocket.hybi00.Authentication",
      "System.Collections.Generic.Dictionary<TKey, TValue>",
      "System.Collections.Generic.KeyValuePair<TKey, TValue>",
      "Alchemy.Handlers.Authentication",
      "Alchemy.Handlers.WebSocket.hybi00.ClientHandshake",
      "System.StringComparison",
      "Alchemy.Handlers.WebSocket.hybi00.ServerHandshake",
      "long",
      "System.Security.Cryptography.MD5",
      "System.Collections.Generic.IEnumerable<T>",
      "byte[]",
      "ushort",
      "Alchemy.Handlers.WebSocket.rfc6455.ClientHandshake",
      "Alchemy.Handlers.WebSocket.rfc6455.ServerHandshake",
      "System.Security.Cryptography.SHA1",
      "Alchemy.Handlers.WebSocket.rfc6455.Authentication",
      "System.Net.Sockets.TcpListener",
      "System.Threading.ThreadPool",
      "System.IAsyncResult",
      "System.TimeSpan",
      "Alchemy.WebSocketClient.ReadyStates",
      "Alchemy.WebSocketClient",
      "System.Random",
      "System.Collections.Generic.Queue<T>",
      "System.Reflection.AssemblyTitleAttribute",
      "System.Reflection.AssemblyDescriptionAttribute",
      "System.Reflection.AssemblyConfigurationAttribute",
      "System.Reflection.AssemblyCompanyAttribute",
      "System.Reflection.AssemblyProductAttribute",
      "System.Reflection.AssemblyCopyrightAttribute",
      "System.Reflection.AssemblyTrademarkAttribute",
      "System.Reflection.AssemblyCultureAttribute",
      "System.Runtime.InteropServices.ComVisibleAttribute",
      "System.Runtime.InteropServices.GuidAttribute",
      "System.Reflection.AssemblyVersionAttribute",
      "System.Reflection.AssemblyFileVersionAttribute",
      "System.Runtime.Versioning.TargetFrameworkAttribute",
      "NUnit.Framework.Assert",
      "NUnit.Framework.TestFixtureAttribute",
      "NUnit.Framework.SetUpAttribute",
      "NUnit.Framework.TearDownAttribute",
      "NUnit.Framework.TestAttribute",
      "NUnit.Framework.TestFixtureSetUpAttribute",
      "NUnit.Framework.TestFixtureTearDownAttribute"
    ]
  },
  "DeclaredTypesByProj": {
    "Alchemy": [
      "Alchemy.Classes.Context",
      "Alchemy.Handlers.WebSocket.DataFrame",
      "Alchemy.Handlers.WebSocket.hybi00.DataFrame",
      "Alchemy.Handlers.WebSocket.rfc6455.DataFrame",
      "Alchemy.Classes.Header",
      "Alchemy.Classes.Response",
      "Alchemy.Classes.UserContext",
      "Alchemy.Handlers.Handler",
      "Alchemy.Handlers.WebSocket.hybi00.ClientHandshake",
      "Alchemy.Handlers.WebSocket.hybi00.ServerHandshake",
      "Alchemy.Handlers.WebSocket.rfc6455.ClientHandshake",
      "Alchemy.Handlers.WebSocket.rfc6455.ServerHandshake",
      "Alchemy.TcpServer",
      "Alchemy.WebSocketClient",
      "Alchemy.WebSocketServer",
      "Alchemy.Handlers.WebSocket.hybi00.DataFrameTest",
      "Alchemy.Handlers.WebSocket.rfc6455.DataFrameTest",
      "Alchemy.ClientServer",
      "Alchemy.ClientServerSubProtocol"
    ]
  }
}
```
