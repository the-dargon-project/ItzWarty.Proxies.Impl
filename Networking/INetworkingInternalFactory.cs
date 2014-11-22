using System.Net.Sockets;

namespace ItzWarty.Networking {
   public interface INetworkingInternalFactory {
      IConnectedSocket CreateConnectedSocket(Socket socket);
      IListenerSocket CreateListenerSocket(Socket listener);
      NetworkStream CreateNetworkStream(Socket socket, bool ownsSocket);
   }
}
