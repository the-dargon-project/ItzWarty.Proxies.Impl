using System.Threading;
using ImpromptuInterface;

namespace ItzWarty.Threading {
   public class ThreadingProxy : IThreadingProxy {
      public IThread CreateThread(ThreadEntryPoint entryPoint, ThreadCreationOptions options) {
         var thread = new Thread(() => entryPoint());
         thread.IsBackground = options.IsBackground;
         return thread.ActLike<IThread>();
      }
   }
}
