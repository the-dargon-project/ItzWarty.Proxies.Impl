using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty {
   public class GuidProxyImpl : GuidProxy {
      public Guid NewGuid() {
         return Guid.NewGuid();
      }

      public Guid Parse(string input) {
         return Guid.Parse(input);
      }

      public Guid ParseExact(string input, string format) {
         return Guid.ParseExact(input, format);
      }

      public bool TryParse(string input, out Guid result) {
         return Guid.TryParse(input, out result);
      }

      public bool TryParseExact(string input, string format, out Guid result) {
         return Guid.TryParseExact(input, format, out result);
      }
   }
}
