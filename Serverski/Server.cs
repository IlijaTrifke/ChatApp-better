using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Serverski
{
    public class Server
    {
        Socket osluskujucisoket;
        public static List<ClientHandler> prijavljeniadmini = new List<ClientHandler>();

        public static List<Administrator> admini = new List<Administrator>()
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!public static list obaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        {

           new Administrator()
        {
            Email = "1",
                FirstName = "Pera1",
                LastName = "Peric1",
                Password = "1"
            },
         new Administrator()
        {
            Email = "2",
                FirstName = "Pera2",
                LastName = "Peric2",
                Password = "2"
            },
            new Administrator()
        {
            Email = "3",
                FirstName = "Pera3",
                LastName = "Peric3",
                Password = "3"
            }
    };

        public Server()
        {
            osluskujucisoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
        public void Start()
        {
            //IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            osluskujucisoket.Bind(ipendpoint);
            osluskujucisoket.Listen(5);
            Thread thread = new Thread(Listen);
            thread.Start();

        }
        public void Stop()
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Controller.Instance.Kraj();
            osluskujucisoket.Close();
            foreach (ClientHandler adminipr in prijavljeniadmini)
            {
                adminipr.Stopiraj();

            }
            prijavljeniadmini.Clear();

        }
        public void Listen()
        {

            //TRY PA WHILE UNUTRA
            try
            {
                while (true)
                {
                    Socket klijentskisoket = osluskujucisoket.Accept();
                    //da se prihvataju konekcije paralelno
                    ClientHandler handler = new ClientHandler(klijentskisoket);
                    Thread thread = new Thread(handler.HandleRequest);
                    //da se paralelno unutar te 1 konekcije prihvataju requestvoi paralelno
                    thread.Start();
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>" + ex.Message);
            }

            //kako dapamtis prijavljenje klijente



        }
    }
}
