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
            CustomEvents.Game.OnGameUpdate += Game_OnGameUpdate; 
        }

        static void PrintMessage()
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

            Game.PrintChat(OyuncuAdi);
            Game.PrintChat(OyunID);
            Game.PrintChat(OyunModu);
            Game.PrintChat(OyunIP);
            Game.PrintChat(OyunPort);
            Game.PrintChat(OyunBolge);
            Game.PrintChat(OyunZamani);
            Game.PrintChat(OyunVersiyonu);
            Game.PrintChat(OyunTuru);

        }

        static void Game_OnGameLoad(EventArgs args)
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
    }
}
