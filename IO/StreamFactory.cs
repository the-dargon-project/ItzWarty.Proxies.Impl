using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   public class StreamFactory : IStreamFactory {
      public IStream CreateFromStream(Stream stream) {
         return new StreamWrapper(stream);
      }

      public IStream CreateFromStream(Stream stream, bool leaveOpen) {
         return new StreamWrapper(stream, leaveOpen);
      }

      public IFileStream CreateFileStream(string path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.ReadWrite, FileShare share = FileShare.None) {
         return new FileStreamWrapper(new FileStream(path, mode, access, share));
      }

      public IMemoryStream CreateMemoryStream() {
         return new MemoryStreamWrapper(new MemoryStream());
      }

      public IMemoryStream CreateMemoryStream(byte[] buffer) {
         return new MemoryStreamWrapper(new MemoryStream(buffer));
      }

      public IMemoryStream CreateMemoryStream(int capacity) {
         return new MemoryStreamWrapper(new MemoryStream(capacity));
      }

      public IMemoryStream CreateMemoryStream(byte[] buffer, bool writable) {
         return new MemoryStreamWrapper(new MemoryStream(buffer, writable));
      }

      public IMemoryStream CreateMemoryStream(byte[] buffer, int index, int count) {
         return new MemoryStreamWrapper(new MemoryStream(buffer, index, count));
      }

      public IMemoryStream CreateMemoryStream(byte[] buffer, int index, int count, bool writable) {
         return new MemoryStreamWrapper(new MemoryStream(buffer, index, count, writable));
      }

      public IBinaryReader CreateBinaryReader(IStream stream) {
         return new BinaryReaderWrapper(stream);
      }

      public IBinaryReader CreateBinaryReader(IStream stream, Encoding encoding) {
         return new BinaryReaderWrapper(stream, encoding);
      }

      public IBinaryReader CreateBinaryReader(IStream stream, Encoding encoding, bool leaveOpen) {
         return new BinaryReaderWrapper(stream, encoding, leaveOpen);
      }

      public IBinaryWriter CreateBinaryWriter(IStream stream) {
         return new BinaryWriterWrapper(stream);
      }

      public IBinaryWriter CreateBinaryWriter(IStream stream, Encoding encoding) {
         return new BinaryWriterWrapper(stream, encoding);
      }

      public IBinaryWriter CreateBinaryWriter(IStream stream, Encoding encoding, bool leaveOpen) {
         return new BinaryWriterWrapper(stream, encoding, leaveOpen);
      }
   }
}
