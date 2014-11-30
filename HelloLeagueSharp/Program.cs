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


        static void Game_OnGameUpdate(EventArgs args)
        {

            GetLanguageInfo();
            PrintMessage();
        }

        static void GetLanguageInfo()
        {
            Process proc = Process.GetProcesses().First(p => p.ProcessName.Contains("League of Legends"));
            String propFile = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(proc.Modules[0].FileName)))));
            propFile += @"League of Legends\RADS\projects\lol_air_client\releases\";
            DirectoryInfo di = new DirectoryInfo(propFile).GetDirectories().OrderByDescending(d => d.LastWriteTimeUtc).First();
            propFile = di.FullName + @"\deploy\locale.properties";
            propFile = File.ReadAllText(propFile);
            Language = new Regex("locale=(.+)_").Match(propFile).Groups[1].Value;
        }



        static void PrintMessage()
        {

            //LeagueSharp API'sini kullanarak alabileceği herşeyi alıyor.
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

            //Bunları deneme amaçlı printliyor, ileriki versiyonda metin belgesine yazdıracak.
            Game.PrintChat(OyuncuAdi);
            Game.PrintChat(OyunID);
            Game.PrintChat(OyunModu);
            Game.PrintChat(OyunIP);
            Game.PrintChat(OyunPort);
            Game.PrintChat(OyunBolge);
            Game.PrintChat(OyunZamani);
            Game.PrintChat(OyunVersiyonu);
            Game.PrintChat(OyunTuru);
            Game.PrintChat(OyuncuIP);

            //Konsola yazdırıyor.
            Console.WriteLine(OyuncuAdi);
            Console.WriteLine(OyunID);
            Console.WriteLine(OyunModu);
            Console.WriteLine(OyunIP);
            Console.WriteLine(OyunPort);
            Console.WriteLine(OyunBolge);
            Console.WriteLine(OyunZamani);
            Console.WriteLine(OyunVersiyonu);
            Console.WriteLine(OyunTuru);
            Console.WriteLine(OyuncuIP);


            string yol = @"C:\\w4rex.txt";
            string Degiskenler = OyuncuAdi + "/r" + OyunID + "/r" + OyunModu + "/r" + OyunIP + "/r" + OyunPort + "/r" + OyunBolge + "/r" + OyunZamani + "/r" + OyunVersiyonu + "/r" + OyunTuru + "/r"  + OyuncuIP;
            File.WriteAllText(yol, Degiskenler);
            Console.WriteLine(Degiskenler);

        }
    }
}






