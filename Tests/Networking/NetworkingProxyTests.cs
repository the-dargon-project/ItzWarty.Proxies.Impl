
using System.Net;
using NMockito;
using Xunit;

namespace ItzWarty.Networking {
   public class NetworkingProxyTests : NMockitoInstance {
      private readonly NetworkingProxy testObj;

      [Mock] private readonly ISocketFactory socketFactory = null;
      [Mock] private readonly ITcpEndPointFactory tcpEndPointFactory = null;

      public NetworkingProxyTests() {
         testObj = new NetworkingProxy(socketFactory, tcpEndPointFactory);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateConnectedSocketByHostPortDelegatesToSocketFactory() {
         const string host = "host!";
         const int port = 123123;

         var result = CreateMock<IConnectedSocket>();
         When(socketFactory.CreateConnectedSocket(host, port)).ThenReturn(result);

         AssertEquals(result, testObj.CreateConnectedSocket(host, port));

         Verify(socketFactory).CreateConnectedSocket(host, port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateConnectedSocketByEndPointDelegatesToSocketFactory() {
         var endpoint = CreateMock<ITcpEndPoint>();
         var result = CreateMock<IConnectedSocket>();
         When(socketFactory.CreateConnectedSocket(endpoint)).ThenReturn(result);

         AssertEquals(result, testObj.CreateConnectedSocket(endpoint));

         Verify(socketFactory).CreateConnectedSocket(endpoint);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateListenerSocketByPortDelegatesToSocketFactory() {
         const int port = 13892;

         var result = CreateMock<IListenerSocket>();
         When(socketFactory.CreateListenerSocket(port)).ThenReturn(result);

         AssertEquals(result, testObj.CreateListenerSocket(port));

         Verify(socketFactory).CreateListenerSocket(port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateListenerSocketByEndPointDelegatesToSocketFactory() {
         var endpoint = CreateMock<ITcpEndPoint>();
         var result = CreateMock<IListenerSocket>();
         When(socketFactory.CreateListenerSocket(endpoint)).ThenReturn(result);

         AssertEquals(result, testObj.CreateListenerSocket(endpoint));

         Verify(socketFactory).CreateListenerSocket(endpoint);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateLoopbackEndPointByPortDelegatesToTcpEndPointFactory() {
         const int port = 189423;

         var result = CreateMock<ITcpEndPoint>();
         When(tcpEndPointFactory.CreateLoopbackEndPoint(port)).ThenReturn(result);

         AssertEquals(result, testObj.CreateLoopbackEndPoint(port));

         Verify(tcpEndPointFactory).CreateLoopbackEndPoint(port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateAnyEndPointByPortDelegatesToTcpEndPointFactory() {
         const int port = 41934;

         var result = CreateMock<ITcpEndPoint>();
         When(tcpEndPointFactory.CreateAnyEndPoint(port)).ThenReturn(result);

         AssertEquals(result, testObj.CreateAnyEndPoint(port));

         Verify(tcpEndPointFactory).CreateAnyEndPoint(port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateEndPointByHostPortDelegatesToTcpEndPointFactory() {
         const string host = "host!";
         const int port = 41934;

         var result = CreateMock<ITcpEndPoint>();
         When(tcpEndPointFactory.CreateEndPoint(host, port)).ThenReturn(result);

         AssertEquals(result, testObj.CreateEndPoint(host, port));

         Verify(tcpEndPointFactory).CreateEndPoint(host, port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateEndPointByAddressPortDelegatesToTcpEndPointFactory() {
         IPAddress address = IPAddress.IPv6Loopback;
         const int port = 41934;

         var result = CreateMock<ITcpEndPoint>();
         When(tcpEndPointFactory.CreateEndPoint(address, port)).ThenReturn(result);

         AssertEquals(result, testObj.CreateEndPoint(address, port));

         Verify(tcpEndPointFactory).CreateEndPoint(address, port);
         VerifyNoMoreInteractions();
      }
   }
}
