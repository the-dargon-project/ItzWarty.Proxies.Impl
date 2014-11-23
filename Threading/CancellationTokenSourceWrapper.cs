using System;
using System.Threading;

namespace ItzWarty.Threading {
   public class CancellationTokenSourceWrapper : ICancellationTokenSource {
      private readonly CancellationTokenSource source;
      private readonly CancellationTokenWrapper token;
      private bool isDisposed = false;

      public CancellationTokenSourceWrapper(CancellationTokenSource source) {
         this.source = source;
         this.token = new CancellationTokenWrapper(this, source.Token);
      }

      public void CancelAfter(int millisecondDelay) {
         source.CancelAfter(millisecondDelay);
      }

      public void CancelAfter(TimeSpan delay) {
         source.CancelAfter(delay);
      }

      public void Cancel() {
         source.Cancel();
      }

      public bool IsCancellationRequested { get { return source.IsCancellationRequested; } }
      public ICancellationToken Token { get { return token; } }

      public void Dispose() {
         if (!isDisposed) {
            isDisposed = true;

            source.Cancel();
            source.Dispose();
         }
      }
   }
}
