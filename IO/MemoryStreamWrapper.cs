using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   class MemoryStreamWrapper : StreamWrapper, IMemoryStream {
      private readonly MemoryStream stream;

      public MemoryStreamWrapper(MemoryStream stream) : base(stream) {
         this.stream = stream;
      }

      public byte[] GetBuffer() {
         return this.stream.GetBuffer();
      }

      public byte[] ToArray() {
         return this.stream.ToArray();
      }
   }
}
