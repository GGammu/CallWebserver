using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CallWebserver
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
            Console.ReadLine();
        }

        public Program()
        {
            IPHostEntry host = Dns.Resolve("naver.com");
            IPAddress ip = host.AddressList[0];
            Console.WriteLine(ip.ToString());
            IPEndPoint ipep = new IPEndPoint(ip, 80);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipep);
            String send = @"
GET / HTTP / 1.1\r\n
Accept: image / gif, image / jpeg, image / pjpeg, image / pjpeg, application / x - shockwave - flash, application / x - ms - application, application / x - ms - xbap, application / vnd.ms - xpsdocument, application / xaml + xml, application / vnd.ms - excel, application / vnd.ms - powerpoint, application / msword, */*\r\n
Accept-Language: ko\r\n
User-Agent: Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; InfoPath.2)\r\n
Accept-Encoding: gzip, deflate\r\n
Host: 127.0.0.1\r\n
Connection: Keep-Alive\r\n";
            client.Send(Encoding.Default.GetBytes(send));
            client.Send(Encoding.Default.GetBytes("\r\n"));
            client.Send(Encoding.Default.GetBytes("\r\n"));
            byte[] data = new byte[4096];
            client.Receive(data);
            client.Close();
            Console.WriteLine(Encoding.Default.GetString(data));
        }
    }
}
