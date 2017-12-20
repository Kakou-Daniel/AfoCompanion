namespace AfoCompanion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Weapon
    {
        public int Id { get; set; }
        public int wid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int break_stone { get; set; }
        public int break_wood { get; set; }
        public int break_iron { get; set; }
        public int max_str { get; set; }
        public int min_str { get; set; }
        public int price_shop { get; set; }
        public int price_sell { get; set; }
        public int req_lvl { get; set; }
        public string bonus { get; set; }
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
