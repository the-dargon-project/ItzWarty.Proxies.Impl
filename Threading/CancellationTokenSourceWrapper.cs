using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItzWarty.Threading {
   public class CancellationTokenSourceWrapper : ICancellationTokenSource {
      private readonly CancellationTokenSource source;
      private readonly CancellationTokenWrapper token;

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
         source.Dispose();
      }
   }
}
