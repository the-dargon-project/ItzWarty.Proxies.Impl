using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ItzWarty.Networking {
   public class ConnectedSocket : IConnectedSocket {
      private readonly INetworkingInternalFactory networkingInternalFactory;
      private readonly Socket socket;
      private readonly NetworkStream networkStream;
      private readonly BinaryReader reader;
      private readonly BinaryWriter writer;

      public ConnectedSocket(INetworkingInternalFactory networkingInternalFactory, Socket socket) {
         this.networkingInternalFactory = networkingInternalFactory;
         this.socket = socket;
         this.networkStream = networkingInternalFactory.CreateNetworkStream(socket, true);
         this.reader = new BinaryReader(networkStream, Encoding.UTF8, true);
         this.writer = new BinaryWriter(networkStream, Encoding.UTF8, true);
      }

      public Socket __Socket { get { return socket; } }

      public BinaryReader GetReader() { return reader; }

      public BinaryWriter GetWriter() { return writer; }

      public void Dispose() {
         writer.Dispose();
         reader.Dispose();
         networkStream.Dispose();
         socket.Dispose();
      }
   }
}