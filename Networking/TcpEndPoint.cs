using System.Net;

namespace ItzWarty.Networking {
   public class TcpEndPoint : ITcpEndPoint {
      private readonly IPEndPoint ipEndPoint;

      public TcpEndPoint(IPEndPoint ipEndPoint) {
         this.ipEndPoint = ipEndPoint;
      }

      public IPEndPoint ToIPEndPoint() {
         return ipEndPoint;
      }
   }
}