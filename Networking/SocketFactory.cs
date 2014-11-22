using ItzWarty.Threading;
using System.Net.Sockets;

namespace ItzWarty.Networking {
   public class SocketFactory : ISocketFactory {
      private const int kListenBacklog = 1337;

      private readonly ITcpEndPointFactory tcpEndPointFactory;
      private readonly INetworkingInternalFactory networkingInternalFactory;

      public SocketFactory(ITcpEndPointFactory tcpEndPointFactory, INetworkingInternalFactory networkingInternalFactory) {
         this.tcpEndPointFactory = tcpEndPointFactory;
         this.networkingInternalFactory = networkingInternalFactory;
      }

      public IConnectedSocket CreateConnectedSocket(string host, int port) {
         return CreateConnectedSocket(tcpEndPointFactory.CreateEndPoint(host, port));
      }

      public IConnectedSocket CreateConnectedSocket(ITcpEndPoint endpoint) {
         var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         socket.Connect(endpoint.ToIPEndPoint());
         return networkingInternalFactory.CreateConnectedSocket(socket);
      }

      public IListenerSocket CreateListenerSocket(int port) {
         return CreateListenerSocket(tcpEndPointFactory.CreateAnyEndPoint(port));
      }

      public IListenerSocket CreateListenerSocket(ITcpEndPoint endpoint) {
         var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         listener.Bind(endpoint.ToIPEndPoint());
         listener.Listen(kListenBacklog);
         return networkingInternalFactory.CreateListenerSocket(listener);
      }
   }
}
