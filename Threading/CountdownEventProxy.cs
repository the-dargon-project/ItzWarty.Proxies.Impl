using System;
using System.Threading;

namespace ItzWarty.Threading {
   public class CountdownEventProxy : ICountdownEvent {
      private readonly CountdownEvent obj;

      public CountdownEventProxy(int initialCount) {
         this.obj = new CountdownEvent(initialCount);
      }

      public void Dispose() {
         obj.Dispose();
      }

      public void AddCount() {
         obj.AddCount();
      }

      public void AddCount(int count) {
         obj.AddCount(count);
      }

      public void Reset() {
         obj.Reset();
      }

      public void Reset(int count) {
         obj.Reset(count);
      }

      public void Signal() {
         obj.Signal();
      }

      public void Signal(int count) {
         obj.Signal(count);
      }

      public void Wait() {
         obj.Wait();
      }

      public bool Wait(TimeSpan timespan) {
         return obj.Wait(timespan);
      }

      public bool Wait(CancellationToken cancellationToken) {
         return !Util.IsThrown<OperationCanceledException>(() => obj.Wait(cancellationToken));
      }

      public bool Wait(TimeSpan timespan, CancellationToken cancellationToken) {
         return obj.Wait(timespan, cancellationToken);
      }

      public int CurrentCount { get { return obj.CurrentCount; } }
      public int InitialCount { get { return obj.InitialCount; } }
      public bool IsSet { get { return obj.IsSet; } }
   }
}