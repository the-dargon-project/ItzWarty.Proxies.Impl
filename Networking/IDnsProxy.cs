using System.Net;

namespace ItzWarty.Networking {
   public interface IDnsProxy {
      IPAddress ResolveIPAddress(string host);
   }
}
