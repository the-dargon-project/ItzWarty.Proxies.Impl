using System;
using System.Threading;

namespace ItzWarty.Threading {
   public class ThreadingProxy : IThreadingProxy {
      private readonly IThreadingFactory threadingFactory;
      private readonly ISynchronizationFactory synchronizationFactory;

      public ThreadingProxy(IThreadingFactory threadingFactory, ISynchronizationFactory synchronizationFactory) {
         this.threadingFactory = threadingFactory;
         this.synchronizationFactory = synchronizationFactory;
      }

      #region IThreadingProxy
      public void Sleep(int durationMilliseconds) {
         Thread.Sleep(durationMilliseconds);
      }

      public void Sleep(TimeSpan duration) {
         Thread.Sleep(duration);
      }
      #endregion

      #region IThreadingFactory
      public IThread CreateThread(ThreadEntryPoint entryPoint, ThreadCreationOptions options) {
         return threadingFactory.CreateThread(entryPoint, options);
      }
      #endregion

      #region ISynchronizationFactory
      public ISemaphore CreateSemaphore(int initialCount, int maximumCount) {
         return synchronizationFactory.CreateSemaphore(initialCount, maximumCount);
      }

      public ICountdownEvent CreateCountdownEvent(int initialCount) {
         return synchronizationFactory.CreateCountdownEvent(initialCount);
      }

      public ICancellationTokenSource CreateCancellationTokenSource() {
         return synchronizationFactory.CreateCancellationTokenSource();
      }

      public ICancellationTokenSource CreateCancellationTokenSource(int cancellationDelayMilliseconds) {
         return synchronizationFactory.CreateCancellationTokenSource(cancellationDelayMilliseconds);
      }

      public ICancellationTokenSource CreateCancellationTokenSource(TimeSpan cancellationDelay) {
         return synchronizationFactory.CreateCancellationTokenSource(cancellationDelay);
      }

      public ICancellationTokenSource CreateLinkedCancellationTokenSource(params ICancellationToken[] tokens) {
         return synchronizationFactory.CreateLinkedCancellationTokenSource(tokens);
      }
      #endregion
   }
}
