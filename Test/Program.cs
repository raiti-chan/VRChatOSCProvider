using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Test {
	internal class Program {
		private static void Main(string[] args) {
			Console.WriteLine("Hello World!");
			IPAddress address = IPAddress.Parse("127.0.0.1");
			int port = 9000;

			IPEndPoint endPoint = new(address, port);

			using UdpClient udp = new(endPoint);

			for (; ; ) {
				IPEndPoint remoteEndPoint = null;
				byte[] rcvBytes = udp.Receive(ref remoteEndPoint);

				string rcvMsg = Encoding.UTF8.GetString(rcvBytes);

				Console.WriteLine($"受信データ:{rcvMsg}");
				Console.WriteLine($"送信元アドレス:{remoteEndPoint.Address}, ポート:{remoteEndPoint.Port}");

			}

		}
	}
}
