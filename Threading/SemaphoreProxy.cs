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

      public bool Wait(CancellationToken cancellationToken) {
         return !Util.IsThrown<OperationCanceledException>(() => obj.Wait(cancellationToken));
      }

      public bool Wait(int millseconds, CancellationToken cancellationToken) {
         return obj.Wait(millseconds, cancellationToken);
      }

      public bool Wait(TimeSpan timespan, CancellationToken cancellationToken) {
         return obj.Wait(timespan, cancellationToken);
      }
   }
}