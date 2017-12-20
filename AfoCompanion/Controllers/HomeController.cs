using AfoCompanion.Models;
using AfoCompanion.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace AfoCompanion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WC()
        {
            var AfoWcMsgs = AfoHelper.GetWcMessages();
            //List<JsonHelperWC.NWM> AfoWcMsgs = null;
            List<WcMsg> listMsgs = new List<WcMsg>();

            if(AfoWcMsgs != null)
            {
                foreach(var msg in AfoWcMsgs)
                {
                    listMsgs.Add(new WcMsg(msg));
                }
                ViewBag.WcMsgs = "ok";
                listMsgs.Reverse();
                return View(listMsgs);
            }
            else
            {
                return View();
            }

        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult StatsPost(string avatar_name)
        {
            if (avatar_name == "")
            {
                ViewBag.Error = "**Please fill out name.";
                return View("Stats");
            }

            else
            {
                var stats = AfoHelper.GetStats(avatar_name);
                //var guildItems = AfoHelper.GetGuildInfos(avatar_name);
                if(stats.MAIN.FRD == null)
                {
                    ViewBag.Error = "** No results found.";
                    return View("Stats");
                }

                else
                {
                    PlayerStats player = new PlayerStats(stats);
                    ViewBag.Stats = player.WIN;
                    return View("StatsResult", player);
                }
            }
            
        }

        public ActionResult Equipment()
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=C:\Users\Daniel\Documents\AfoCompanionDB.mdf;";
            List<Equipment> listEquipments = new List<Equipment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select eid, name, description from Equipment", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Equipment equipment = new Equipment();
                        equipment.eid = (int)reader["eid"];
                        equipment.imgPath = "~/Images/Equipment/" + equipment.eid + ".png";
                        equipment.description = reader["description"].ToString();
                        equipment.name = reader["name"].ToString();
                        listEquipments.Add(equipment);
                    }
                }
                connection.Close();
            }
            return View(listEquipments);
        }

        public ActionResult CheckEquipment(int equipmentID)
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=C:\Users\Daniel\Documents\AfoCompanionDB.mdf;";
            Equipment equipment = new Equipment();
            Equipment equipmentPrec = new Equipment();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select * from Equipment where eid = @equipmentID", connection))
            {
                command.Parameters.AddWithValue("@equipmentID", equipmentID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        equipment.eid = (int)reader["eid"];
                        equipment.imgPath = "~/Images/Equipment/" + equipment.eid + ".png";
                        equipment.description = reader["description"].ToString();
                        equipment.name = reader["name"].ToString();
                        equipment.break_iron = (int)reader["break_iron"];
                        equipment.break_stone = (int)reader["break_stone"];
                        equipment.break_wood = (int)reader["break_wood"];
                        equipment.stat_ag = (int)reader["stat_ag"];
                        equipment.stat_hp = (int)reader["stat_hp"];
                        equipment.stat_str = (int)reader["stat_str"];
                        equipment.stat_spd = (int)reader["stat_spd"];
                        equipment.price_shop = (int)reader["price_shop"];
                        equipment.price_sell = (int)reader["price_sell"];
                        equipment.req_lvl = (int)reader["req_lvl"];
                        equipment.upgrade_iron = (int)reader["upgrade_iron"];
                        equipment.upgrade_stone = (int)reader["upgrade_stone"];
                        equipment.upgrade_wood = (int)reader["upgrade_wood"];
                        equipment.diamonds = (int)reader["diamonds"];
                        equipment.upgradable = (bool)reader["upgradable"];
                        equipment.crystal_amount = (int)reader["crystal_amount"];
                        equipment.crystal_color = reader["crystal_color"].ToString();
                        equipment.up_itemId = (int)reader["up_itemId"];
                    }
                }
                using (SqlCommand command2 = new SqlCommand("select eid, upgradable, upgrade_stone, upgrade_wood, upgrade_iron, diamonds, crystal_color, crystal_amount from Equipment where up_itemId = @eid ", connection))
                {
                    command2.Parameters.AddWithValue("@eid", equipmentID);
                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            equipmentPrec.eid = (int)reader2["eid"];
                            equipmentPrec.upgradable = (bool)reader2["upgradable"];
                            equipmentPrec.up_itemId = equipmentID;
                            equipmentPrec.imgPath = "~/Images/Equipment/" + equipmentPrec.eid + ".png";
                            equipmentPrec.upgrade_iron = (int)reader2["upgrade_iron"];
                            equipmentPrec.upgrade_stone = (int)reader2["upgrade_stone"];
                            equipmentPrec.upgrade_wood = (int)reader2["upgrade_wood"];
                            equipmentPrec.diamonds = (int)reader2["diamonds"];
                            equipmentPrec.crystal_amount = (int)reader2["crystal_amount"];
                            equipmentPrec.crystal_color = reader2["crystal_color"].ToString();
                            equipmentPrec.crystalImgPath = "~/Images/Crystals/" + equipmentPrec.crystal_color + ".png";
                        }
                    }
                    connection.Close();
                }
            }
            EquipmentInfoViewModel eq = new EquipmentInfoViewModel { mainEquipment = equipment, precEquipment = equipmentPrec };
            return View(eq);
        }

        public ActionResult Weapons()
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=C:\Users\Daniel\Documents\AfoCompanionDB.mdf;";
            List<Weapon> listWeapons = new List<Weapon>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select wid, name, description from Weapons", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Weapon weapon = new Weapon();
                        weapon.wid = (int)reader["wid"];
                        weapon.imgPath = "~/Images/Weapons/" + weapon.wid + ".png";
                        weapon.description = reader["description"].ToString();
                        weapon.name = reader["name"].ToString();
                        listWeapons.Add(weapon);
                    }
                }
                connection.Close();
            }
            return View(listWeapons);
        }

        public ActionResult CheckWeapon(int weaponID)
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=C:\Users\Daniel\Documents\AfoCompanionDB.mdf;";
            Weapon weapon = new Weapon();
            Weapon weaponPrec = new Weapon();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select * from Weapons where wid = @weaponID", connection))
            {
                command.Parameters.AddWithValue("@weaponID", weaponID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        weapon.wid = (int)reader["wid"];
                        weapon.imgPath = "~/Images/Weapons/" + weapon.wid + ".png";
                        weapon.description = reader["description"].ToString();
                        weapon.name = reader["name"].ToString();
                        weapon.break_iron = (int)reader["break_iron"];
                        weapon.break_stone = (int)reader["break_stone"];
                        weapon.break_wood = (int)reader["break_wood"];
                        weapon.max_str = (int)reader["max_str"];
                        weapon.min_str = (int)reader["min_str"];
                        weapon.price_shop = (int)reader["price_shop"];
                        weapon.price_sell = (int)reader["price_sell"];
                        weapon.req_lvl = (int)reader["req_lvl"];
                        weapon.bonus = reader["bonus"].ToString();
                        weapon.upgrade_iron = (int)reader["upgrade_iron"];
                        weapon.upgrade_stone = (int)reader["upgrade_stone"];
                        weapon.upgrade_wood = (int)reader["upgrade_wood"];
                        weapon.diamonds = (int)reader["diamonds"];
                        weapon.upgradable = (bool)reader["upgradable"];
                        weapon.crystal_amount = (int)reader["crystal_amount"];
                        weapon.crystal_color = reader["crystal_color"].ToString();
                        weapon.up_itemId = (int)reader["up_itemId"];
                    }
                }
                using (SqlCommand command2 = new SqlCommand("select wid, upgradable, upgrade_stone, upgrade_wood, upgrade_iron, diamonds, crystal_color, crystal_amount from Weapons where up_itemId = @wid ", connection))
                {
                    command2.Parameters.AddWithValue("@wid", weaponID);
                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            weaponPrec.wid = (int)reader2["wid"];
                            weaponPrec.upgradable = (bool)reader2["upgradable"];
                            weaponPrec.up_itemId = weaponID;
                            weaponPrec.imgPath = "~/Images/Weapons/" + weaponPrec.wid + ".png";
                            weaponPrec.upgrade_iron = (int)reader2["upgrade_iron"];
                            weaponPrec.upgrade_stone = (int)reader2["upgrade_stone"];
                            weaponPrec.upgrade_wood = (int)reader2["upgrade_wood"];
                            weaponPrec.diamonds = (int)reader2["diamonds"];
                            weaponPrec.crystal_amount = (int)reader2["crystal_amount"];
                            weaponPrec.crystal_color = reader2["crystal_color"].ToString();
                            weaponPrec.crystalImgPath = "~/Images/Crystals/" + weaponPrec.crystal_color + ".png";
                        }
                    }
                    connection.Close();
                }
            }
            WeaponInfoViewModel wp = new WeaponInfoViewModel { mainWeapon = weapon, precWeapon = weaponPrec };
            return View(wp);
        }

        public ActionResult GuildPeek()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WarGuide()
        {
            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }

        public ActionResult Photos()
        {
            return View();
        }
    }
}