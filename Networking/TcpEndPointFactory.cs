using System.Net;

namespace ItzWarty.Networking {
   public class TcpEndPointFactory : ITcpEndPointFactory {
      private readonly IDnsProxy dnsProxy;

      public TcpEndPointFactory(IDnsProxy dnsProxy) {
         this.dnsProxy = dnsProxy;
      }

      public ITcpEndPoint CreateLoopbackEndPoint(int port) {
         return new TcpEndPoint(new IPEndPoint(IPAddress.Loopback, port));
      }

      public ITcpEndPoint CreateAnyEndPoint(int port) {
         return new TcpEndPoint(new IPEndPoint(IPAddress.Any, port));
      }

      public ITcpEndPoint CreateEndPoint(string host, int port) {
         var address = dnsProxy.ResolveIPAddress(host);
         return CreateEndPoint(address, port);
      }

      public ITcpEndPoint CreateEndPoint(IPAddress address, int port) {
         return new TcpEndPoint(new IPEndPoint(address, port));
      }
   }
}