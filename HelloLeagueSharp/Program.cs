using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using LeagueSharp;
using LeagueSharp.Common;
using Color = System.Drawing.Color;

namespace HelloLeagueSharp
{
    class Program
    {
        public static String Language;

        static void Main(string[] args)
        {
            //Oyun yüklenirken alacak.
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        static void Game_OnGameStart(EventArgs args)
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
        }


        static void Game_OnGameUpdate(EventArgs args)
        {
            String OyuncuAdi = ObjectManager.Player.Name;
            String OyunID = Game.Id.ToString();
            String OyunModu = Game.Mode.ToString();
            String OyunIP = Game.IP;
            String OyunPort = Game.Port.ToString();
            String OyunBolge = Game.Region;
            String OyunZamani = DateTime.Now.ToLongTimeString();
            String OyunVersiyonu = Game.Version;
            String OyunTuru = Game.Type.ToString();
            String OyuncuIP = "";
            
            //IP Adresini alıyor.
            foreach (IPAddress IPAdresi in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                OyuncuIP = IPAdresi.ToString();
            }
            
            Game.PrintChat(Game.Type.ToString);
            Game.PrintChat(Game.Id.ToString());

            string yol = @"C:\\w4rex.txt";
            string Degiskenler = OyuncuAdi + "/r" + OyunID + "/r" + OyunModu + "/r" + OyunIP + "/r" + OyunPort + "/r" + OyunBolge + "/r" + OyunZamani + "/r" + OyunVersiyonu + "/r" + OyunTuru + "/r"  + OyuncuIP;
            File.WriteAllText(yol, Degiskenler);
            Console.WriteLine(Degiskenler);
        }

    }
}






