using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    [Serializable]
    public class CommunicationHelper
    {
        Socket soket;
        NetworkStream stream;
        BinaryFormatter formatter;

        public CommunicationHelper(Socket socket)
        {
            soket = socket;
            stream = new NetworkStream(soket);
            formatter = new BinaryFormatter();
        }
        public void Send(object argument)
        {
            formatter.Serialize(stream, argument);
        }
        public object Receive()
        {
            return formatter.Deserialize(stream);
        }
    }
}
