using System;
using System.Collections.Generic;
using System.Text;
//using System.Linq;

namespace Meeting_App
{
    class modelokaler
    {
        public int Id { get; set; }
        public String Navn { get; set; }
        public String Lokation { get; set; }
        public int Pladsantal { get; set; }

        public modelokaler (int id, String navn, String lokation, int pladsantal)
        {
            Id = id;
            Navn = navn;
            Lokation = lokation;
            Pladsantal = pladsantal;
        }

    }
}
