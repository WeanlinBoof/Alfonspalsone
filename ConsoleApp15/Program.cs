using System;
using System.ComponentModel;
using System.Threading;

using LiteNetLib;
using LiteNetLib.Utils;

namespace ConsoleApp15 {
    public static class Program {
        static void Main(string[] args) {
            EventBasedNetListener listener = new EventBasedNetListener();
            ConsoleKeyInfo knappinfo;
            knappinfo = Console.ReadKey(true);
            ConsoleKey knapp = knappinfo.Key;
            switch(knapp) {
                case ConsoleKey.Spacebar:
                    Klient.klient(listener);
                    Console.WriteLine("Klient setspå");
                    break; 
                case ConsoleKey.Enter:
                    Server.VärdServer(listener);
                    Console.WriteLine("Server setspå");
                    break;
            }

        }

        
      
    }
}
