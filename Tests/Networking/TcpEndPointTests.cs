using System.Net;
using NMockito;
using Xunit;

namespace ItzWarty.Networking {
   public class TcpEndPointTests : NMockitoInstance {
      [Fact]
      public void ToIPEndPointReflectsConstructorParameter() {
         AssertEquals(null, new TcpEndPoint(null).ToIPEndPoint());

         var endpoint = new IPEndPoint(1333337, 21337);
         AssertEquals(endpoint, new TcpEndPoint(endpoint).ToIPEndPoint());
      }
   }
}
