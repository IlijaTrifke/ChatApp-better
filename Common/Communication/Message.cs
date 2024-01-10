using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class Message
    {
        public string Poruka { get; set; }

        public Operation Operacija { get; set; }
        //public string OdKoga { get; set; }
        public string Kome { get; set; }
        //ne mora se popuni kad je svima
        public DateTime KadJePoslataPoruka { get; set; }
        public Administrator Administrator { get; set; }
        //public string Username { get; set; }
        public bool JeLUspesno { get; set; }
        public List<string> TrenutnoPrijavljeni { get; set; }
        public string Email { get; set; }
        //ne treba mi ceo clienthandler, msm moze al ne treba
        //public List<PorukaSvima> DosPoruke { get; set; }
        //public PorukaSvima porukaSvima { get; set; }
    }
}
