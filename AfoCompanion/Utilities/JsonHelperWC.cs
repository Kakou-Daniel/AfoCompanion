using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfoCompanion.Utilities
{
    public class JsonHelperWC
    {
        public class INST
        {
            public int STEP { get; set; }
            public long NTS { get; set; }
            public int ID { get; set; }
        }

        public class PEX
        {
            public int STR { get; set; }
            public int QUA { get; set; }
            public int ID { get; set; }
            public int SPD { get; set; }
            public int HP { get; set; }
            public int AGL { get; set; }
        }

        public class GRP
        {
        }

        public class MGRP
        {
            public bool FRAG { get; set; }
            public string NAME { get; set; }
            public long CRT { get; set; }
            public bool CROWN { get; set; }
            public string ID { get; set; }
            public int AP { get; set; }
            public int TTL { get; set; }
            public int RNK { get; set; }
        }

        public class TSK
        {
            public int DMND { get; set; }
            public int RQLV { get; set; }
            public int CLS { get; set; }
            public string NAME { get; set; }
            public int EXP { get; set; }
            public string DONE { get; set; }
            public string KEY { get; set; }
            public int TTL { get; set; }
            public int PRG { get; set; }
            public string DES { get; set; }
            public int DAY { get; set; }
            public int GLD { get; set; }
            public object ID { get; set; }
            public int TYPE { get; set; }
            public string PARA { get; set; }
        }

        public class ACHV
        {
            public int ID { get; set; }
            public object TS { get; set; }
        }

        public class LAND
        {
            public int CTYPE { get; set; }
            public int IDX { get; set; }
            public int STA { get; set; }
            public int CNT { get; set; }
            public object TS { get; set; }
            public int TYPE { get; set; }
        }

        public class AVA
        {
            public int LV { get; set; }
            public bool FRAG { get; set; }
            public long DNXT { get; set; }
            public int LOSE { get; set; }
            public int SPD { get; set; }
            public int TLP { get; set; }
            public int HP { get; set; }
            public long LST { get; set; }
            public string LOC { get; set; }
            public List<object> SLA { get; set; }
            public string PWD { get; set; }
            public int LVUP { get; set; }
            public string WFS { get; set; }
            public List<INST> INST { get; set; }
            public int TAX { get; set; }
            public int STR { get; set; }
            public string NAME { get; set; }
            public string LFS { get; set; }
            public int MNN { get; set; }
            public bool CROWN { get; set; }
            public int EXP { get; set; }
            public List<int> WPN { get; set; }
            public List<PEX> PEX { get; set; }
            public List<object> BUFF { get; set; }
            public int PT { get; set; }
            public GRP GRP { get; set; }
            public int DDAY { get; set; }
            public double TXR { get; set; }
            public string EM { get; set; }
            public int TW { get; set; }
            public int DMND { get; set; }
            public int VIP { get; set; }
            public int MPER { get; set; }
            public MGRP MGRP { get; set; }
            public string ITEM { get; set; }
            public string KEY { get; set; }
            public int WIN { get; set; }
            public List<object> REP { get; set; }
            public int ENGY { get; set; }
            public List<object> EVENT { get; set; }
            public int LVB { get; set; }
            public int SKIN { get; set; }
            public int AGL { get; set; }
            public int FTT { get; set; }
            public int DMON { get; set; }
            public int PCNT { get; set; }
            public List<string> BAG { get; set; }
            public List<TSK> TSK { get; set; }
            public int OS { get; set; }
            public string MAS { get; set; }
            public List<object> SKL { get; set; }
            public List<ACHV> ACHV { get; set; }
            public List<object> CD { get; set; }
            public int GLD { get; set; }
            public List<object> RPEX { get; set; }
            public List<LAND> LAND { get; set; }
            public string ENH { get; set; }
            public int EFF { get; set; }
        }

        public class ANN
        {
            public string MSG { get; set; }
            public long CRT { get; set; }
            public string NAME { get; set; }
            public string LNK { get; set; }
        }

        public class GLB
        {
            public double GC { get; set; }
            public long ST { get; set; }
            public double DC { get; set; }
            public long OT { get; set; }
            public object PRO { get; set; }
        }

        public class PAY
        {
            public GLB GLB { get; set; }
        }

        public class CFG
        {
            public int HD { get; set; }
            public PAY PAY { get; set; }
        }

        public class MAIN
        {
            public AVA AVA { get; set; }
            public ANN ANN { get; set; }
            public CFG CFG { get; set; }
            public int HBT { get; set; }
        }

        public class FROM
        {
            public int LV { get; set; }
            public string NAME { get; set; }
            public string KEY { get; set; }
            public int SKIN { get; set; }
            public string LOC { get; set; }
        }

        public class NWM
        {
            public string MSG { get; set; }
            public double DATE { get; set; }
            public FROM FROM { get; set; }
            public string KEY { get; set; }
        }

        public class ML
        {
            public string MSG { get; set; }
            public object DATE { get; set; }
            public List<string> PRM { get; set; }
            public int TYPE { get; set; }
        }

        public class HB
        {
            public List<NWM> NWM { get; set; }
            public List<ML> ML { get; set; }
            public long TS { get; set; }
        }

        public class RootObject
        {
            public MAIN MAIN { get; set; }
            public HB HB { get; set; }
        }
    }
}