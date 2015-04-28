using System.Threading;
using ItzWarty.Threading;

namespace ItzWarty {
   internal static class InternalUtilities {
      public static CancellationToken GetInnerTokenOrNone(this ICancellationToken token) {
         return token?.__InnerToken ?? CancellationToken.None;
      }
   }
}
