using System.Net.Sockets;

namespace ItzWarty.Networking {
   internal class ListenerSocket : IListenerSocket {
      private readonly Socket socket;

      public ListenerSocket(Socket socket) {
         this.socket = socket;
      }

      public Socket __Socket { get { return socket; } }
   }
}