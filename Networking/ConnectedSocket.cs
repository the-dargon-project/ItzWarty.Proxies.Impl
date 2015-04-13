using System;
using System.IO;
using ItzWarty.IO;
using System.Net.Sockets;
using System.Text;

namespace ItzWarty.Networking {
   public class ConnectedSocket : IConnectedSocket {
      private readonly INetworkingInternalFactory networkingInternalFactory;
      private readonly Socket socket;
      private readonly IStream stream;
      private readonly IBinaryReader reader;
      private readonly IBinaryWriter writer;

      public ConnectedSocket(IStreamFactory streamFactory, INetworkingInternalFactory networkingInternalFactory, Socket socket) {
         this.networkingInternalFactory = networkingInternalFactory;
         this.socket = socket;
         this.stream = streamFactory.CreateFromStream(networkingInternalFactory.CreateNetworkStream(socket, true));
         this.reader = stream.GetReader();
         this.writer = stream.GetWriter();
      }

      public Socket __Socket { get { return socket; } }
      public IStream Stream { get { return stream; } }
      public IBinaryReader Reader { get { return reader; } }
      public IBinaryWriter Writer { get { return writer; } }

      public IStream GetStream() { return stream; }
      public IBinaryReader GetReader() { return reader; }
      public IBinaryWriter GetWriter() { return writer; }

      public void Dispose() {
         writer.Dispose();
         reader.Dispose();
         stream.Dispose();
         socket.Dispose();
      }
   }
}