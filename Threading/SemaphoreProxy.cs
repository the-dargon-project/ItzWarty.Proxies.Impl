using System;
using System.Threading;

namespace ItzWarty.Threading {
   public class SemaphoreProxy : ISemaphore {
      private readonly SemaphoreSlim obj;

      public SemaphoreProxy(int initialCount, int maximumCount) {
         this.obj = new SemaphoreSlim(initialCount, maximumCount);
      }

      public void Dispose() {
         obj.Dispose();
      }

      public void Release() {
         obj.Release();
      }

      public void Release(int count) {
         obj.Release(count);
      }

      public void Wait() {
         obj.Wait();
      }

      public bool Wait(int milliseconds) {
         return obj.Wait(milliseconds);
      }

      public bool Wait(TimeSpan timespan) {
         return obj.Wait(timespan);
      }

      public bool Wait(ICancellationToken cancellationToken) {
         return !Util.IsThrown<OperationCanceledException>(() => obj.Wait(cancellationToken.GetInnerTokenOrNone()));
      }

      public bool Wait(int millseconds, ICancellationToken cancellationToken) {
         return obj.Wait(millseconds, cancellationToken.GetInnerTokenOrNone());
      }

      public bool Wait(TimeSpan timespan, ICancellationToken cancellationToken) {
         return obj.Wait(timespan, cancellationToken.GetInnerTokenOrNone());
      }
   }
}