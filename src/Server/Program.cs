using System;
using System.IO.Pipes;
using System.Text;

class NamedPipeServer
{
    static void Main(string[] args)
    {
        while (true)
        {
            using (var server = new NamedPipeServerStream("mypipe"))
            {
                Console.WriteLine("Waiting for client connection...");
                server.WaitForConnection();
                Console.WriteLine("Client connected.");

                // Read message from the client
                byte[] buffer = new byte[256];
                var bytesRead = server.Read(buffer, 0, buffer.Length);
                var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received message: " + message);

                // Send a response to the client
                var response = Encoding.UTF8.GetBytes("Hello, client!");
                server.Write(response, 0, response.Length);
                Console.WriteLine("Sent response.");

                server.Disconnect();
            }
        }
    }
}
