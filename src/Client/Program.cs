using System;
using System.IO.Pipes;
using System.Text;

class NamedPipeClient
{
    static void Main(string[] args)
    {
        using (var client = new NamedPipeClientStream("mypipe"))
        {
            Console.WriteLine("Connecting to server...");
            client.Connect();
            Console.WriteLine("Connected to server.");

            // Send a message to the server
            var message = Encoding.UTF8.GetBytes("Hello, server!");
            client.Write(message, 0, message.Length);
            Console.WriteLine("Sent message.");

            // Read the response from the server
            byte[] buffer = new byte[256];
            var bytesRead = client.Read(buffer, 0, buffer.Length);
            var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received response: " + response);
        }
    }
}
