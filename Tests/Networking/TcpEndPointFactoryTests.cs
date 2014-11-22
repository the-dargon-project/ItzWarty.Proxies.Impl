using System.Net;
using NMockito;
using Xunit;

namespace ItzWarty.Networking {
   public class TcpEndPointFactoryTests : NMockitoInstance {
      private readonly TcpEndPointFactory testObj;

      [Mock] private readonly IDnsProxy dnsProxy = null;

      public TcpEndPointFactoryTests() {
         testObj = new TcpEndPointFactory(dnsProxy);
      }

      [Fact]
      public void CreateLoopbackEndPointTest() {
         const int port = 21337;
         var result = testObj.CreateLoopbackEndPoint(port);
         var endpoint = result.ToIPEndPoint();
         AssertEquals(IPAddress.Loopback, endpoint.Address);
         AssertEquals(port, endpoint.Port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateAnyEndPointTest() {
         const int port = 21337;
         var result = testObj.CreateAnyEndPoint(port);
         var endpoint = result.ToIPEndPoint();
         AssertEquals(IPAddress.Any, endpoint.Address);
         AssertEquals(port, endpoint.Port);
         VerifyNoMoreInteractions();
      }

      [Fact]
      public void CreateEndPointTest() {
         const string host = "host!";
         const int port = 21337;
         var address = new IPAddress(0x21337F);

         When(dnsProxy.ResolveIPAddress(host)).ThenReturn(address);

         var result = testObj.CreateEndPoint(host, port);

         Verify(dnsProxy, Once()).ResolveIPAddress(host);
         VerifyNoMoreInteractions();

         var endpoint = result.ToIPEndPoint();
         AssertEquals(address, endpoint.Address);
         AssertEquals(port, endpoint.Port);
      }
   }
}
