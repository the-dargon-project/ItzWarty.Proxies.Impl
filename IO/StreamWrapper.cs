using System.IO;
using System.Text;

namespace ItzWarty.IO {
   public class StreamWrapper : IStream {
      private readonly Stream stream;
      private IBinaryReader reader;
      private IBinaryWriter writer;

      public StreamWrapper(Stream stream) {
         this.stream = stream;
         this.reader = new BinaryReaderWrapper(this, Encoding.UTF8, true);
         this.writer = new BinaryWriterWrapper(this, Encoding.UTF8, true);
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

      public void Flush() {
         stream.Flush();
      }

      public void Close() {
         stream.Close();
      }

      public Stream __Stream { get { return stream; } }

      public IBinaryReader GetReader() { return reader; }
      public IBinaryWriter GetWriter() { return writer; }
   }
}