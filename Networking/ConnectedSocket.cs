using System.IO;
using ItzWarty.IO;
using System.Net.Sockets;
using System.Text;

namespace ItzWarty.Networking {
   public class ConnectedSocket : IConnectedSocket {
      private readonly INetworkingInternalFactory networkingInternalFactory;
      private readonly Socket socket;
      private readonly IStream networkStream;
      private readonly IBinaryReader reader;
      private readonly IBinaryWriter writer;

      public ConnectedSocket(IStreamFactory streamFactory, INetworkingInternalFactory networkingInternalFactory, Socket socket) {
         this.networkingInternalFactory = networkingInternalFactory;
         this.socket = socket;
         this.networkStream = streamFactory.CreateFromStream(networkingInternalFactory.CreateNetworkStream(socket, true));
         this.reader = networkStream.GetReader();
         this.writer = networkStream.GetWriter();
      }

      public Socket __Socket { get { return socket; } }

      public IBinaryReader GetReader() { return reader; }

      public IBinaryWriter GetWriter() { return writer; }

      public void Dispose() {
         writer.Dispose();
         reader.Dispose();
         networkStream.Dispose();
         socket.Dispose();
      }
   }
}