using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   public class FileStreamWrapper : StreamWrapper, IFileStream {
      private readonly FileStream stream;

      public FileStreamWrapper(FileStream stream) : base(stream) {
         this.stream = stream;
      }

      public string Path { get { return stream.Name; } }

      public void Lock(long position, long length) {
         stream.Lock(position, length);
      }

      public void Unlock(long position, long length) {
         stream.Unlock(position, length);
      }
   }
}
