using System;
using ItzWarty.Threading;
using System.Net.Sockets;

namespace ItzWarty.Networking {
   internal class ListenerSocket : IListenerSocket {
      private readonly IThreadingProxy threadingProxy;
      private readonly INetworkingInternalFactory networkingInternalFactory;
      private readonly Socket listener;
      private readonly object synchronization = new object();

      private readonly ISemaphore acceptSemaphore;
      private readonly ICancellationTokenSource cancellationTokenSource;

      public ListenerSocket(IThreadingProxy threadingProxy, INetworkingInternalFactory networkingInternalFactory, Socket listener) {
         this.threadingProxy = threadingProxy;
         this.networkingInternalFactory = networkingInternalFactory;
         this.listener = listener;

         this.acceptSemaphore = threadingProxy.CreateSemaphore(0, int.MaxValue);
         this.cancellationTokenSource = threadingProxy.CreateCancellationTokenSource();
      }

      public Socket __Socket { get { return listener; } }

      public IConnectedSocket Accept() {
         lock (synchronization) {
            var asyncResult = listener.BeginAccept(ar => acceptSemaphore.Release(), null);
            acceptSemaphore.Wait(cancellationTokenSource.Token);

            if (asyncResult.IsCompleted) {
               return networkingInternalFactory.CreateConnectedSocket(listener.EndAccept(asyncResult));
            } else {
               // Program should never reach here due to operation cancellation exception
               throw new InvalidOperationException("Unexpected program state?");
            }
         }
      }

      public void Dispose() {
         cancellationTokenSource.Cancel();

         lock (synchronization) {
            cancellationTokenSource.Dispose();
            acceptSemaphore.Dispose();
            listener.Dispose();
         }
      }
   }
}