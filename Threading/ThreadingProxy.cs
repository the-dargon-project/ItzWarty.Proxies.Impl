using System.Threading;
using ImpromptuInterface;

namespace ItzWarty.Threading {
   public class ThreadingProxy : IThreadingProxy {
      public IThread CreateThread(ThreadEntryPoint entryPoint, ThreadCreationOptions options) {
         var thread = new Thread(() => entryPoint());
         thread.IsBackground = options.IsBackground;
         return thread.ActLike<IThread>();
      }

      public ISemaphore CreateSemaphore(int initialCount, int maximumCount) {
         return new SemaphoreProxy(initialCount, maximumCount);
      }

      public ICountdownEvent CreateCountdownEvent(int initialCount) {
         return new CountdownEventProxy(initialCount);
      }
   }
}
