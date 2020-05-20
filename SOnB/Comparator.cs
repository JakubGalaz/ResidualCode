using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SOnB
{
    class Comparator
    {

        public string outputinfo = "TO JEST INFO nowe";



        public string getInfo(string inf)
        {
            return inf;
        }




        private static string Serve()
        {
            TcpListener tcpLsn;
            int i = 0;
            Socket sckt;
            string text = "";
            Byte[] receivedBytes = new Byte[100];
            tcpLsn = new TcpListener(IPAddress.Parse("127.0.0.1"), 2223); //zainicjiuj listenera na podanym porcie i adresie
            tcpLsn.Start();
            while (i < 2)
            {
                sckt = tcpLsn.AcceptSocket(); //funkcja blokujaca do czasu nadejscia - połaczenia
                sckt.Receive(receivedBytes, receivedBytes.Length, 0);
                text += System.Text.Encoding.ASCII.GetString(receivedBytes);
                text += ";";
                i++;

            }
            tcpLsn.Stop();
            return text;
        }
        private void CompareResults(int result1, int result2)
        {



   
            // Console.WriteLine("\nKomparator:");
            if (result1 != -1 && result2 == -1)
            {
                Console.WriteLine("Wynik to {0}, ale układ 2 nie jest sprawny", result1);
                var info = "Wynik to" + result1 + ", ale układ 2 nie jest sprawny";
             //   f1.changeInfo(info);



            }
            else if (result1 == -1 && result2 != -1)
            {
                Console.WriteLine("Wynik to {0}, ale układ 1 nie jest sprawny", result2);
                var info = "Wynik to" + result1 + ", oba układy sprawne";
            //    f1.changeInfo(info);

            }
            else if (result1 == -1 && result2 == -1)
            {
                Console.WriteLine("Coś poszło nie tak, wynik1 = {0} , wynik2 = {1}", result1, result2);
                var info = "Wynik to" + result1 + ", oba układy sprawne";
              //  f1.changeInfo(info);
    

            }
            else if (result1 == result2)
            {
             //   Console.WriteLine("Wynik to {0}, oba układy sprawne", result1);
                var info = "Wynik to" + result1 + ", oba układy sprawne";


            }


        }


        public void getData()
        {

            string tmp = Serve();
            var values = tmp.Split(';');
            CompareResults(Int32.Parse(values[0]), Int32.Parse(values[1]));


        }
    }
}
