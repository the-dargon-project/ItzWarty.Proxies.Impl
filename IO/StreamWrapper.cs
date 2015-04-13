using ItzWarty.Threading;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   public class StreamWrapper : IStream {
      private readonly Stream stream;
      private IBinaryReader reader;
      private IBinaryWriter writer;

      public StreamWrapper(Stream stream) : this(stream, true) {
      }

      public StreamWrapper(Stream stream, bool leaveOpen) {
         this.stream = stream;
         this.reader = stream.CanRead ? new BinaryReaderWrapper(this, Encoding.UTF8, leaveOpen) : null;
         this.writer = stream.CanWrite ? new BinaryWriterWrapper(this, Encoding.UTF8, leaveOpen) : null;
      }

      public long Length { get { return stream.Length; } }
      public long Position { get { return stream.Position; } set { stream.Position = value; } }
      public void SetLength(long value) {
         stream.SetLength(value);
      }

      public bool CanRead { get { return stream.CanRead; } }
      public int ReadByte() {
         return stream.ReadByte();
      }

      public int Read(byte[] buffer, int offset, int count) {
         return stream.Read(buffer, offset, count);
      }
      public Task<int> ReadAsync(byte[] buffer, int offset, int count) {
         return stream.ReadAsync(buffer, offset, count);
      }

      public Task<int> ReadAsync(byte[] buffer, int offset, int count, ICancellationToken cancellationToken) {
         return stream.ReadAsync(buffer, offset, count, cancellationToken.__InnerToken);
      }

      public bool CanSeek { get { return stream.CanSeek; } }
      public long Seek(long offset, SeekOrigin origin) {
         return stream.Seek(offset, origin);
      }

      public bool CanWrite { get { return stream.CanWrite; } }
      public void WriteByte(byte value) {
         stream.WriteByte(value);
      }

      public void Write(byte[] buffer, int offset, int count) {
         stream.Write(buffer, offset, count);
      }

      public Task WriteAsync(byte[] buffer, int offset, int count) {
         return stream.WriteAsync(buffer, offset, count);
      }
      public Task WriteAsync(byte[] buffer, int offset, int count, ICancellationToken cancellationToken) {
         return stream.WriteAsync(buffer, offset, count, cancellationToken.__InnerToken);
      }

      public void Flush() {
         stream.Flush();
      }

      public void Close() {
         stream.Close();
      }

      public Stream __Stream { get { return stream; } }
      public IBinaryReader Reader { get { return reader; } }
      public IBinaryWriter Writer { get { return writer; } }

      public IBinaryReader GetReader() { return reader; }
      public IBinaryWriter GetWriter() { return writer; }
      public void Dispose() { stream.Dispose(); }
   }
}