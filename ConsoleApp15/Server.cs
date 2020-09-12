using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using LiteNetLib;
using LiteNetLib.Utils;

namespace ConsoleApp15 {
   public static class Server {
        public static void VärdServer(EventBasedNetListener listener) {
            värdserver(listener);
        }
        private static EventBasedNetListener värdserver(EventBasedNetListener listener) {
            listener = new EventBasedNetListener();
            NetManager server = new NetManager(listener);
            server.Start(14882 /* port */);

            listener.ConnectionRequestEvent += request => {
                if(server.ConnectedPeersCount < 10 /* max connections */)
                    request.AcceptIfKey("SomeConnectionKey");
                else
                    request.Reject();
            };

            listener.PeerConnectedEvent += peer => {
                Console.WriteLine("We got connection: {0}" , peer.EndPoint); // Show peer ip
                NetDataWriter writer = new NetDataWriter();                 // Create writer class
                writer.Put("Hello client!");                                // Put some string
                peer.Send(writer , DeliveryMethod.ReliableOrdered);             // Send with reliability
            };

            while(!Console.KeyAvailable) {
                server.PollEvents();
                Thread.Sleep(15);
            }
            server.Stop();
            return listener;
        }
    }
}
