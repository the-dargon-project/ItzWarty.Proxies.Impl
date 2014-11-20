using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.Networking {
   public class NetworkingProxy : INetworkingProxy {
      private const int kListenBacklog = 1337;

      public IConnectedSocket CreateConnectedSocket(string host, int port) {
         return CreateConnectedSocket(CreateEndPoint(host, port));
      }

      public IConnectedSocket CreateConnectedSocket(ITcpEndPoint endpoint) {
         var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         socket.Connect(endpoint.ToIPEndPoint());
         return new ConnectedSocket(socket);
      }

      public IListenerSocket CreateListenerSocket(int port) {
         return CreateListenerSocket(CreateAnyEndPoint(port));
      }

      public IListenerSocket CreateListenerSocket(ITcpEndPoint endpoint) {
         var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         socket.Bind(endpoint.ToIPEndPoint());
         socket.Listen(kListenBacklog);
         return new ListenerSocket(socket);
      }

      public IConnectedSocket Accept(IListenerSocket listenerSocket) {
         return new ConnectedSocket(listenerSocket.__Socket.Accept());
      }

      public NetworkStream CreateNetworkStream(IConnectedSocket connectedSocket, bool ownsSocket = true) {
         return new NetworkStream(connectedSocket.__Socket, ownsSocket);
      }

      public ITcpEndPoint CreateLoopbackEndPoint(int port) {
         return new TcpEndPoint(new IPEndPoint(IPAddress.Loopback, port));
      }

      public ITcpEndPoint CreateAnyEndPoint(int port) {
         return new TcpEndPoint(new IPEndPoint(IPAddress.Any, port));
      }

      public ITcpEndPoint CreateEndPoint(string host, int port) {
         var resolution = Dns.GetHostEntry(host);
         var address = resolution.AddressList[0];
         return new TcpEndPoint(new IPEndPoint(address, port));
      }
   }
}
