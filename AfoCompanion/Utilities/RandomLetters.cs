using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfoCompanion.Utilities
{
    public class RandomLetters
    {
        static Random _random = new Random();
        
        public static string GetId()
        {
            string myId = "";
            for (int i = 0; i < 22; i++)
            {
                int num = _random.Next(0, 26); // Zero to 25
                char let = (char)('a' + num);
                myId += let;
            }


            return myId; 
        }
    }
}