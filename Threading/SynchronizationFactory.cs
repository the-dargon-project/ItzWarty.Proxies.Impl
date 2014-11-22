using System;
using System.Threading;

namespace ItzWarty.Threading {
   public class SynchronizationFactory : ISynchronizationFactory {
      public ISemaphore CreateSemaphore(int initialCount, int maximumCount) {
         return new SemaphoreProxy(initialCount, maximumCount);
      }

      public ICountdownEvent CreateCountdownEvent(int initialCount) {
         return new CountdownEventProxy(initialCount);
      }

      public ICancellationTokenSource CreateCancellationTokenSource() {
         return new CancellationTokenSourceWrapper(new CancellationTokenSource());
      }

      public ICancellationTokenSource CreateCancellationTokenSource(int cancellationDelayMilliseconds) {
         return new CancellationTokenSourceWrapper(new CancellationTokenSource(cancellationDelayMilliseconds));
      }

      public ICancellationTokenSource CreateCancellationTokenSource(TimeSpan cancellationDelay) {
         return new CancellationTokenSourceWrapper(new CancellationTokenSource(cancellationDelay));
      }

      public ICancellationTokenSource CreateLinkedCancellationTokenSource(params ICancellationToken[] tokens) {
         var innerTokens = Util.Generate(tokens.Length, i => tokens[i].__InnerToken);
         return new CancellationTokenSourceWrapper(CancellationTokenSource.CreateLinkedTokenSource(innerTokens));
      }
   }
}
