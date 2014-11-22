using System.Threading;

namespace ItzWarty.Threading {
   public class CancellationTokenWrapper : ICancellationToken {
      private readonly ICancellationTokenSource source;
      private readonly CancellationToken token;

      public CancellationTokenWrapper(ICancellationTokenSource source, CancellationToken token) {
         this.source = source;
         this.token = token;
      }

      public ICancellationTokenSource Source { get { return source; } }
      public bool IsCancellationRequested { get { return token.IsCancellationRequested; } }
      public bool CanBeCanceled { get { return token.CanBeCanceled; } }
      public CancellationToken __InnerToken { get { return token; } }

      public void ThrowIfCancellationRequested() {
         token.ThrowIfCancellationRequested();
      }

      public bool Equals(ICancellationToken other) {
         return other.__InnerToken.Equals(token);
      }
      public void Dispose() {
         source.Dispose();
      }
   }
}