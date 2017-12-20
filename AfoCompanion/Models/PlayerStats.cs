using AfoCompanion.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfoCompanion.Models
{
    public class PlayerStats
    {
        public int LV { get; set; }
        public int LOSE { get; set; }
        public int SPD { get; set; }
        public int HP { get; set; }
        public int WIN { get; set; }
        public string LOC { get; set; }
        public string WFS { get; set; }
        public string SKIN { get; set; }
        public int AGL { get; set; }
        public int STR { get; set; }
        public string LFS { get; set; }
        public string NAME { get; set; }
        public double RATIO { get; set; }
        public string FLAGIMG { get; set; }
        public List<Pet> PEX { get; set; }
        public List<Pet> RPEX { get; set; }


        public PlayerStats(JsonHelperStats.RootObject o)
        {
            CountriesHelper.initialiseCountries();
            this.LV = o.MAIN.FRD.LV;
            this.LOSE = o.MAIN.FRD.LOSE;
            this.SPD = o.MAIN.FRD.SPD;
            this.HP = o.MAIN.FRD.HP;
            this.WIN = o.MAIN.FRD.WIN;
            this.PEX = o.MAIN.FRD.PEX;
            this.RPEX = o.MAIN.FRD.RPEX;

            if (o.MAIN.FRD.LOC != "")
            {
                this.FLAGIMG = "~/Images/Flags/" + o.MAIN.FRD.LOC + ".png";
                this.LOC = CountriesHelper.getCountry(o.MAIN.FRD.LOC);
            }
            else
            {
                this.FLAGIMG = "~/Images/Flags/UNK.png";
                this.LOC = "unknown";
            }
                

            if (o.MAIN.FRD.WFS != "")
            {
                this.WFS = o.MAIN.FRD.WFS;
            }
            else
                this.WFS = "No win saying";

            if (o.MAIN.FRD.LFS != "")
            {
                this.LFS = o.MAIN.FRD.LFS;
            }
            else
                this.LFS = "No lose saying";

            this.SKIN = "~/Images/Skins/" + o.MAIN.FRD.SKIN.ToString() + ".png";
            this.AGL = o.MAIN.FRD.AGL;
            this.STR = o.MAIN.FRD.STR;
            this.NAME = o.MAIN.FRD.NAME;
            this.RATIO = Math.Round(((double)this.WIN / ((double)this.WIN + (double)this.LOSE) * 100), 2);
        }

    }
}