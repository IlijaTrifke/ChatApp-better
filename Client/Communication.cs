using Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;

namespace Client
{
    public class Communication
    {
        Socket klijentskisoket;
        CommunicationHelper helper;
        private static Communication _instance;
        List<string> username = new List<string>();

        public static Communication Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Communication();
                }
                return _instance;
            }
        }
        private Communication() { }
        public bool Connect()
        {
            //surronduj sa trycatch i postavljamo klijsoket da je null ako se desi neka greska u konekciji..odjavljuje klijente i bool
            try
            {
                //ne mora
                if (klijentskisoket == null || !klijentskisoket.Connected)
                {
                    klijentskisoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskisoket.Connect("127.0.0.1", 9999);
                    helper = new CommunicationHelper(klijentskisoket);
                }
                return true;
            }
            catch (SocketException ex)
            {

                Debug.WriteLine(">>>" + ex.Message);
                klijentskisoket = null;
                return false;
            }

        }
        public Administrator Login(Administrator admin)
        {
            //pazi koji message uzimas
            Message message = new Message()
            {
                Administrator = admin,
                Operacija = Operation.Login
            };
            //moramo message slati 

            helper.Send(message);
            message = (Message)helper.Receive();
            if (message.JeLUspesno)
            {
                return message.Administrator;
            }
            return null;
        }
        public void SaljiSvima(string poruka)
        {
            Message message = new Message()
            {
                Poruka = poruka,
                Operacija = Operation.SendAll,

            };
            helper.Send(message);
        }

        internal Message Primaj()
        {
            return (Message)helper.Receive();

        }

        internal void GetAll()
        {

            Message message = new Message()
            {
                Operacija = Operation.GetAll
            };
            helper.Send(message);
        }

        internal void SaljiSpecificno(string text, string email)
        {
            Message message = new Message()
            {
                Poruka = text,
                Operacija = Operation.SendOne,
                Kome = email

            };
            helper.Send(message);
        }
    }
}
