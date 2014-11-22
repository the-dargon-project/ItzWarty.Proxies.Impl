using System;
using NMockito;
using Xunit;

namespace ItzWarty.Threading {
   public class ThreadingProxyTests : NMockitoInstance {
      private ThreadingProxy testObj;

      [Mock] private readonly IThreadingFactory threadingFactory = null;
      [Mock] private readonly ISynchronizationFactory synchronizationFactory = null;

      public ThreadingProxyTests() {
         testObj = new ThreadingProxy(threadingFactory, synchronizationFactory);
      }

      [Fact]
      public void CreateThreadDelegatesToThreadingFactory() {
         var entryPoint = new ThreadEntryPoint(() => { });
         var options = new ThreadCreationOptions();
         var result = CreateMock<IThread>();
         When(threadingFactory.CreateThread(entryPoint, options)).ThenReturn(result);
         AssertEquals(result, testObj.CreateThread(entryPoint, options));
         Verify(threadingFactory).CreateThread(entryPoint, options);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateSemaphoreDelegatesToSynchronizationFactory() {
         const int initialCount = 128928;
         const int maximumCount = 2894832;
         var result = CreateMock<ISemaphore>();
         When(synchronizationFactory.CreateSemaphore(initialCount, maximumCount)).ThenReturn(result);
         AssertEquals(result, testObj.CreateSemaphore(initialCount, maximumCount));
         Verify(synchronizationFactory).CreateSemaphore(initialCount, maximumCount);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateCountdownEventDelegatesToSynchronizationFactory() {
         const int initialCount = 2438293;
         var result = CreateMock<ICountdownEvent>();
         When(synchronizationFactory.CreateCountdownEvent(initialCount)).ThenReturn(result);
         AssertEquals(result, testObj.CreateCountdownEvent(initialCount));
         Verify(synchronizationFactory).CreateCountdownEvent(initialCount);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateCancellationTokenSourceDelegatesToSynchronizationFactory() {
         var result = CreateMock<ICancellationTokenSource>();
         When(synchronizationFactory.CreateCancellationTokenSource()).ThenReturn(result);
         AssertEquals(result, testObj.CreateCancellationTokenSource());
         Verify(synchronizationFactory).CreateCancellationTokenSource();
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateCancellationTokenSourceWithIntegerCancellationDelayDelegatesToSynchronizationFactory() {
         const int cancellationDelayMilliseconds = 128397198;
         var result = CreateMock<ICancellationTokenSource>();
         When(synchronizationFactory.CreateCancellationTokenSource(cancellationDelayMilliseconds)).ThenReturn(result);
         AssertEquals(result, testObj.CreateCancellationTokenSource(cancellationDelayMilliseconds));
         Verify(synchronizationFactory).CreateCancellationTokenSource(cancellationDelayMilliseconds);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateCancellationTokenSourceWithTimeSpanCancellationDelayDelegatesToSynchronizationFactory() {
         var cancellationDelay = new TimeSpan(123010932);
         var result = CreateMock<ICancellationTokenSource>();
         When(synchronizationFactory.CreateCancellationTokenSource(cancellationDelay)).ThenReturn(result);
         AssertEquals(result, testObj.CreateCancellationTokenSource(cancellationDelay));
         Verify(synchronizationFactory).CreateCancellationTokenSource(cancellationDelay);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateLinkedCancellationTokenSourceDelegatesToSynchronizationFactory() {
         var token1 = CreateMock<ICancellationToken>();
         var token2 = CreateMock<ICancellationToken>();
         var token3 = CreateMock<ICancellationToken>();
         var tokens = new[] { token1, token2, token3 };
         var result = CreateMock<ICancellationTokenSource>();
         When(synchronizationFactory.CreateLinkedCancellationTokenSource(EqSequence(tokens))).ThenReturn(result);
         AssertEquals(result, testObj.CreateLinkedCancellationTokenSource(token1, token2, token3));
         Verify(synchronizationFactory).CreateLinkedCancellationTokenSource(EqSequence(tokens));
         VerifyNoMoreInteractions();
      }
   }
}
