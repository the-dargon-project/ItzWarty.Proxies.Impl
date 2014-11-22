using System.Net;

namespace ItzWarty.Networking {
   public class DnsProxy : IDnsProxy {
      public IPAddress ResolveIPAddress(string host) {
         return Dns.GetHostEntry(host).AddressList[0];
      }
   }
}