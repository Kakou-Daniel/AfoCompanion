using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfoCompanion.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int eid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int break_stone { get; set; }
        public int break_wood { get; set; }
        public int break_iron { get; set; }
        public int stat_hp { get; set; }
        public int stat_ag { get; set; }
        public int stat_spd { get; set; }
        public int stat_str { get; set; }
        public int price_shop { get; set; }
        public int price_sell { get; set; }
        public int req_lvl { get; set; }
        public int? upgrade_stone { get; set; }
        public int? upgrade_wood { get; set; }
        public int? upgrade_iron { get; set; }
        public int? diamonds { get; set; }
        public bool upgradable { get; set; }
        public string imgPath { get; set; }
        public string crystalImgPath { get; set; }
        public string crystal_color { get; set; }
        public int crystal_amount { get; set; }
        public int up_itemId { get; set; }
    }
}