using AfoCompanion.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AfoCompanion.Utilities.JsonHelperWC;

namespace AfoCompanion.Models
{
    public class WcMsg
    {
        public string Message { get; set; }
        public TimeSpan Date { get; set; }
        public string Name { get; set; }
        public int Lvl { get; set; }
        public string Skin { get; set; }
        public string Location { get; set; }
        public string FLAGIMG { get; set; }

        public WcMsg(NWM obj)
        {
            CountriesHelper.initialiseCountries();
            this.Message = obj.MSG;
            this.Date = UnixTimeStampToDateTime(obj.DATE);
            this.Name = obj.FROM.NAME;
            this.Lvl = obj.FROM.LV;
            this.Skin = "~/Images/Skins/Faces/"+obj.FROM.SKIN.ToString()+".png";
            if (obj.FROM.LOC != "")
            {
                this.FLAGIMG = "~/Images/Flags/" + obj.FROM.LOC + ".png";
                this.Location = CountriesHelper.getCountry(obj.FROM.LOC);
            }
            else
            {
                this.FLAGIMG = "~/Images/Flags/UNK.png";
                this.Location = "Unknown";
            }
                
        }

        private TimeSpan UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var date1 = epoch.AddMilliseconds(unixTimeStamp);
            var date2 = DateTime.UtcNow;

            return date2 - date1;
        }
    }
}