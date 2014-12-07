using System.Net;
using System.Net.Sockets;

namespace ItzWarty.Networking {
   public class DnsProxy : IDnsProxy {
      public IPAddress ResolveIPAddress(string host) {
         var addresses = Dns.GetHostEntry(host).AddressList;
         foreach (var address in addresses) {
            if (address.AddressFamily == AddressFamily.InterNetwork) {
               return address;
            }
         }
         return addresses[0];
      }
   }
}