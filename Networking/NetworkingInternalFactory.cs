using System.Net.Sockets;
using ItzWarty.Threading;

namespace ItzWarty.Networking {
   public class NetworkingInternalFactory : INetworkingInternalFactory {
      private readonly IThreadingProxy threadingProxy;

      public NetworkingInternalFactory(IThreadingProxy threadingProxy) {
         this.threadingProxy = threadingProxy;
      }

      public IConnectedSocket CreateConnectedSocket(Socket socket) {
         return new ConnectedSocket(this, socket);
      }

      public IListenerSocket CreateListenerSocket(Socket listener) {
         return new ListenerSocket(threadingProxy, this, listener);
      }

      public NetworkStream CreateNetworkStream(Socket socket, bool ownsSocket) {
         return new NetworkStream(socket, ownsSocket);
      }
   }
}