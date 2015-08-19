using System.Net;

namespace ItzWarty.Networking {
   public class NetworkingProxy : INetworkingProxy {
      private readonly ISocketFactory socketFactory;
      private readonly ITcpEndPointFactory tcpEndPointFactory;

      public NetworkingProxy(ISocketFactory socketFactory, ITcpEndPointFactory tcpEndPointFactory) {
         this.socketFactory = socketFactory;
         this.tcpEndPointFactory = tcpEndPointFactory;
      }

      #region ISocketFactory
      public IConnectedSocket CreateConnectedSocket(string host, int port) {
         return socketFactory.CreateConnectedSocket(host, port);
      }

      public IConnectedSocket CreateConnectedSocket(ITcpEndPoint endpoint) {
         return socketFactory.CreateConnectedSocket(endpoint);
      }

      public IListenerSocket CreateListenerSocket(int port) {
         return socketFactory.CreateListenerSocket(port);
      }

      public IListenerSocket CreateListenerSocket(ITcpEndPoint endpoint) {
         return socketFactory.CreateListenerSocket(endpoint);
      }
      #endregion

      #region ITcpEndPointFactory
      public ITcpEndPoint CreateLoopbackEndPoint(int port) {
         return tcpEndPointFactory.CreateLoopbackEndPoint(port);
      }

      public ITcpEndPoint CreateAnyEndPoint(int port) {
         return tcpEndPointFactory.CreateAnyEndPoint(port);
      }

      public ITcpEndPoint CreateEndPoint(string host, int port) {
         return tcpEndPointFactory.CreateEndPoint(host, port);
      }

      public ITcpEndPoint CreateEndPoint(IPAddress address, int port) {
         return tcpEndPointFactory.CreateEndPoint(address, port);
      }
      #endregion
   }
}
