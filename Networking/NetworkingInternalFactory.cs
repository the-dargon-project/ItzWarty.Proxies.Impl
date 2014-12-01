using System.Net.Sockets;
using ItzWarty.IO;
using ItzWarty.Threading;

namespace ItzWarty.Networking {
   public class NetworkingInternalFactory : INetworkingInternalFactory {
      private readonly IThreadingProxy threadingProxy;
      private readonly IStreamFactory streamFactory;

      public NetworkingInternalFactory(IThreadingProxy threadingProxy, IStreamFactory streamFactory) {
         this.threadingProxy = threadingProxy;
         this.streamFactory = streamFactory;
      }

      public IConnectedSocket CreateConnectedSocket(Socket socket) {
         return new ConnectedSocket(streamFactory, this, socket);
      }

      public IListenerSocket CreateListenerSocket(Socket listener) {
         return new ListenerSocket(threadingProxy, this, listener);
      }

      public NetworkStream CreateNetworkStream(Socket socket, bool ownsSocket) {
         return new NetworkStream(socket, ownsSocket);
      }
   }
}