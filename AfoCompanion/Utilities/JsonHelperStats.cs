using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AfoCompanion.Models;

namespace AfoCompanion.Utilities
{
    public class JsonHelperStats
    {
        public class MGRP
        {
            public bool FRAG { get; set; }
            public string NAME { get; set; }
            public bool CROWN { get; set; }
            public string ID { get; set; }
        }

        public class ACHV
        {
            public int ID { get; set; }
            public object TS { get; set; }
        }

        public class GRP
        {
        }

        public class RPEX
        {
            public int STR { get; set; }
            public int QUA { get; set; }
            public int ID { get; set; }
            public int SPD { get; set; }
            public int HP { get; set; }
            public int AGL { get; set; }
        }

        public class FRD
        {
            public int LV { get; set; }
            public bool FRAG { get; set; }
            public int LOSE { get; set; }
            public MGRP MGRP { get; set; }
            public string ITEM { get; set; }
            public int SPD { get; set; }
            public int TLP { get; set; }
            public int HP { get; set; }
            public string KEY { get; set; }
            public long LST { get; set; }
            public int WIN { get; set; }
            public string LOC { get; set; }
            public List<object> REP { get; set; }
            public int LVUP { get; set; }
            public string WFS { get; set; }
            public int SKIN { get; set; }
            public int AGL { get; set; }
            public long FTT { get; set; }
            public int STR { get; set; }
            public string NAME { get; set; }
            public string LFS { get; set; }
            public bool CROWN { get; set; }
            public int OS { get; set; }
            public List<object> WPN { get; set; }
            public List<Pet> PEX { get; set; }
            public string MAS { get; set; }
            public List<object> BUFF { get; set; }
            public List<int> SKL { get; set; }
            public List<ACHV> ACHV { get; set; }
            public int PT { get; set; }
            public GRP GRP { get; set; }
            public List<Pet> RPEX { get; set; }
            public string ENH { get; set; }
            public int TW { get; set; }
        }

        public class MAIN
        {
            public FRD FRD { get; set; }
        }

        public class HB
        {
            public long TS { get; set; }
        }

        public class RootObject
        {
            public MAIN MAIN { get; set; }
            public HB HB { get; set; }
        }
    }
}