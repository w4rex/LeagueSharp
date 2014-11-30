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

        static void Game_OnGameLoad(EventArgs args)
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
        }

        public static string GetPublicIP()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
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

            //IP Adresini alıyor.

            Game.PrintChat("Oyun Türü" + Game.Type);
            Game.PrintChat("Oyun ID" + Game.Id.ToString());
            Game.PrintChat("Oyuncu IP" + GetPublicIP());

            string yol = @"C:\\w4rex.txt";
            string Degiskenler = OyuncuAdi + "/r" + OyunID + "/r" + OyunModu + "/r" + "/r" + OyunPort + "/r" + OyunBolge + "/r" + OyunZamani + "/r" + OyunVersiyonu + "/r" + OyunTuru + "/r";
            File.WriteAllText(yol, Degiskenler);
            Console.WriteLine(Degiskenler);
        }

    }
}






