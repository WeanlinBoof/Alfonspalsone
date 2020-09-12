using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using LiteNetLib;

namespace ConsoleApp15 {
    public static class Klient {
        public static void klient(EventBasedNetListener listener) {
            client(listener);

        }
        private static void client(EventBasedNetListener listener) {
            listener = new EventBasedNetListener();
            NetManager client = new NetManager(listener);
            client.Start();
            client.Connect("109.225.80.163" /* host ip or name */, 14882 /* port */, "SomeConnectionKey" /* text key or NetDataWriter */);
            listener.NetworkReceiveEvent += (fromPeer , dataReader , deliveryMethod) => {
                Console.WriteLine("We got: {0}" , dataReader.GetString(100 /* max length of string */));
                dataReader.Recycle();
            };

            while(!Console.KeyAvailable) {
                client.PollEvents();
                Thread.Sleep(15);
            }

            client.Stop();
        }

    }
}
