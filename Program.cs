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
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }


        static void Game_OnGameLoad(EventArgs args)
        {

            GetLanguageInfo();
            PrintMessage();
        }

        static void GetLanguageInfo()
        {
            Process proc = Process.GetProcesses().First(p => p.ProcessName.Contains("League of Legends"));
            String propFile = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(proc.Modules[0].FileName))))));
            propFile += @"\projects\lol_air_client\releases\";
            DirectoryInfo di = new DirectoryInfo(propFile).GetDirectories().OrderByDescending(d => d.LastWriteTimeUtc).First();
            propFile = di.FullName + @"\deploy\locale.properties";
            propFile = File.ReadAllText(propFile);
            Language = new Regex("locale=(.+)_").Match(propFile).Groups[1].Value;
        }

        static void serverip()
        {
            Game.PrintChat("Kullanilan Dil: " + Language);
        }

        static void PrintMessage()
        {
            if (Language == "tr")
            {
                Game.PrintChat("LeagueSharp'a hoşgeldiniz!");
            }

            if (Language == "cz")
            {
                Game.PrintChat("LeagueSharp'a hoşgeldiniz!");
            }


        }
    }
}
