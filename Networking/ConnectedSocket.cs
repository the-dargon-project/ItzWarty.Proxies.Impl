using System.Net.Sockets;

namespace ItzWarty.Networking {
   public class ConnectedSocket : IConnectedSocket {
      private readonly Socket socket;

      public ConnectedSocket(Socket socket) {
         this.socket = socket;
      }

      public Socket __Socket { get { return socket; } }
   }
}