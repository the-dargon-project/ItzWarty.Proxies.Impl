using ImpromptuInterface;
using System.Threading;

namespace ItzWarty.Threading {
   public class ThreadingFactory : IThreadingFactory {
      public IThread CreateThread(ThreadEntryPoint entryPoint, ThreadCreationOptions options) {
         var thread = new Thread(() => entryPoint());
         thread.IsBackground = options.IsBackground;
         return thread.ActLike<IThread>();
      }
   }
}
