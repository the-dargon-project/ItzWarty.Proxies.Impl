using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.Ryu;
using ItzWarty.IO;
using ItzWarty.Networking;
using ItzWarty.Processes;
using ItzWarty.Threading;
using NMockito;
using Xunit;

namespace ItzWarty {
   public class RyuPackageTests : NMockitoInstance {
      [Fact]
      public void Run() {
         var ryu = new RyuFactory().Create();
         ryu.Setup();

         AssertTrue(ryu.Get<GuidProxy>() is GuidProxyImpl);

         // IO
         AssertTrue(ryu.Get<InternalFileSystemProxy>() is FileSystemProxy);
         AssertTrue(ryu.Get<IFileSystemProxy>() is FileSystemProxy);

         // Processes
         AssertTrue(ryu.Get<IProcessProxy>() is ProcessProxy);

         // Threading
         AssertTrue(ryu.Get<ISynchronizationFactory>() is SynchronizationFactory);
         AssertTrue(ryu.Get<IThreadingFactory>() is ThreadingFactory);
         AssertTrue(ryu.Get<IThreadingProxy>() is ThreadingProxy);

         // Networking
         AssertTrue(ryu.Get<IDnsProxy>() is DnsProxy);
         AssertTrue(ryu.Get<INetworkingInternalFactory>() is NetworkingInternalFactory);
         AssertTrue(ryu.Get<ISocketFactory>() is SocketFactory);
         AssertTrue(ryu.Get<INetworkingProxy>() is NetworkingProxy);
         AssertTrue(ryu.Get<ITcpEndPointFactory>() is TcpEndPointFactory);
      }
   }
}
