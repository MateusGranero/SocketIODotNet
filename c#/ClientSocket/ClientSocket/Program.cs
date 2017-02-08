using System;
using Quobject.SocketIoClientDotNet.Client;
using System.Linq;

namespace ClientSocket
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("To Exit  Console: 'q'");
            Console.WriteLine("To Clear Console: 'c'");
            Console.WriteLine("Send your message: 'Enter'");
            Console.WriteLine("=============================");
            Console.WriteLine("");
            Console.ResetColor();

            // Install-Package SocketIoClientDotNet
            var socket = IO.Socket("http://localhost:3000");

            socket.On("response_server", (data) =>
            {
                Console.WriteLine(data);
            });
            
            bool run = true;
            while (run)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    char key = line.FirstOrDefault();

                    switch (key)
                    {
                        case 'c':
                        case 'C':
                            Console.Clear();
                            break;
                        case 'q':
                        case 'Q':
                            socket.Emit("client_bye", "Bye Bye Server");
                            socket.Disconnect();
                            run = false;
                            break;
                        default:
                            socket.Emit("client_message", line);
                            break;
                    }
                }
            }
        }
    }
}
