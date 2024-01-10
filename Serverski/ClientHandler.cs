using Common;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;

namespace Serverski
{

    public class ClientHandler
    {
        //public Socket Ende { get; set; }
        // List<Socket> sockets;
        Socket socket;
        CommunicationHelper helper;
        public string Email { get; private set; }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!private set, znaci da moze da ga setuje samo clienthandler

        //public ClientHandler(Socket klijentskisoket, List<Socket> sockets)
        //{
        //    socket = klijentskisoket;
        //    this.sockets = sockets;
        //}

        //INICIJALIZUJ OVDEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA!

        public ClientHandler(Socket klijentskisoket)
        {

            socket = klijentskisoket;
            helper = new CommunicationHelper(socket);
        }

        public void HandleRequest()
        {
            bool x = true;
            //OVDE REQUEST I rSEPONSE
            try
            {
                while (x)
                {

                    Message msg = (Message)helper.Receive();
                    //ovo ovde glumi request to uvek klijent radi
                    switch (msg.Operacija)
                    {
                        ////poslao nam je:operac,admina (samo email i password)
                        case Operation.Login:
                            msg.Administrator = Login(msg.Administrator);
                            if (msg.Administrator != null)
                            {
                                Server.prijavljeniadmini.Add(this);
                                //MORAMPO GA OVDE DODATI A A A SNADJFJDAJFL

                                Email = msg.Administrator.Email;
                                msg.JeLUspesno = true;
                                msg.TrenutnoPrijavljeni = Server.prijavljeniadmini.Select(ch => ch.Email).ToList();
                                //celu por salji i podesi jeluspesno!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                //trenutno nemamo azuriranu listu, klijent const treba da salje zahtev za azuriranje, timer omogucava to
                                PosaljiSvima(msg);

                            }
                            else
                            {
                                msg.JeLUspesno = false;
                                helper.Send(msg);
                                //salje svima samo ako se ulogovao uspesno i ako nije samo sebi salje por
                            }
                            //helper.Send(msg);
                            //dovoljan je sendall ne moram i helper.send jer cu my ond duplo poslati

                            // msg.Administrator = Controller.Instance.Login((Administrator)msg.Administrator);
                            //helper.Send(msg);
                            //ovde je response odgovor 
                            //STA SENDUJEM TAMO MORAMU TOM FORMATU DA PRIHVATIM
                            //Controller.Instance.Dodaj(socket);
                            break;
                        case Operation.SendOne:
                            msg.Email = Email;
                            PosaljiSpecificnom(msg);
                            break;
                        case Operation.SendAll:
                            msg.Email = Email;
                            //Server.DosPoruke.Add(porukaSvima);
                            //ovde dole sad spremam response 
                            //msg.DosPoruke = Server.DosPoruke;
                            // msg.Email = Email;
                            //tu smo rekli od koga je, ne moramo u komunikaciji
                            PosaljiSvima(msg);
                            //ovako je bolje nego msg.admin.email
                            break;
                        case Operation.GetAll:
                            msg.TrenutnoPrijavljeni = Server.prijavljeniadmini.Select(ch => ch.Email).ToList();
                            msg.Operacija = Operation.Login;
                            helper.Send(msg);
                            break;
                        case Operation.Kraj:
                            x = false;
                            // Controller.Instance.Obrisi(socket);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>>" + ex.Message);
            }


        }
        private void PosaljiSpecificnom(Message poruka)
        {
            foreach (ClientHandler klijent in Server.prijavljeniadmini)
            {
                if (klijent.Email == poruka.Kome) { klijent.helper.Send(poruka); }

                //1 helper za 1 kli
            }
        }
        private void PosaljiSvima(Message poruka)
        {
            foreach (ClientHandler klijent in Server.prijavljeniadmini)
            {
                klijent.helper.Send(poruka);
                //1 helper za 1 kli
            }
        }
        private Administrator Login(Administrator admin)
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            foreach (Administrator adminn in Server.admini)
            {
                if (admin.Email == adminn.Email && admin.Password == adminn.Password)
                {
                    foreach (ClientHandler ulogovani in Server.prijavljeniadmini)
                    {
                        if (admin.Email == ulogovani.Email)
                            return null;
                    }
                    return adminn;
                }

            }

            return null;

        }
        internal void Stopiraj()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
