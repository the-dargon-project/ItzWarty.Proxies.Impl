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

namespace ItzWarty {
   public class ItzWartyProxiesRyuPackage : RyuPackageV1 {
      public ItzWartyProxiesRyuPackage() {
         Singleton<GuidProxy, GuidProxyImpl>();

         // IO
         Singleton<InternalFileSystemProxy, FileSystemProxy>();
         Singleton<IFileSystemProxy, FileSystemProxy>();
         Singleton<IStreamFactory, StreamFactory>();

         // Processes
         Singleton<IProcessProxy, ProcessProxy>();

         // Threading
         Singleton<ISynchronizationFactory, SynchronizationFactory>();
         Singleton<IThreadingFactory, ThreadingFactory>();
         Singleton<IThreadingProxy, ThreadingProxy>();

         // Networking
         Singleton<IDnsProxy, DnsProxy>();
         Singleton<INetworkingInternalFactory, NetworkingInternalFactory>();
         Singleton<ISocketFactory, SocketFactory>();
         Singleton<INetworkingProxy, NetworkingProxy>();
         Singleton<ITcpEndPointFactory, TcpEndPointFactory>();
      }
   }
}
