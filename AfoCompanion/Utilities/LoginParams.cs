using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfoCompanion.Utilities
{
    public class LoginParams
    {
        public string PWD { get; set; }
        public string VER { get; set; }
        public int OS { get; set; }
        public string NAME { get; set; }
        public string DEV { get; set; }
        public string LANG { get; set; }

        public LoginParams(string name, string pwd)
        {
            this.PWD = Encryptor.MD5Hash(pwd);
            this.VER = "6.7.1";
            this.OS = 2;
            this.NAME = name;
            this.DEV = "000000000000000";
            this.LANG = "en";
        }
    }
}