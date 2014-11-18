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

        static void PrintMessage()
        {
            if (Language == "tr")
            {
                Game.PrintChat("LeagueSharp'a hoşgeldiniz!");
            }

            if (Language == "cz")
            {
                Game.PrintChat("Vítejte na LeagueSharp!");
            }

            if (Language == "de")
            {
                Game.PrintChat("Willkommen bei LeagueSharp!");
            }

            if (Language == "gr")
            {
                Game.PrintChat("Καλώς ήλθατε στο LeagueSharp!");
            }

            if (Language == "au")
            {
                Game.PrintChat("Welcome to LeagueSharp!");
            }

            if (Language == "gb")
            {
                Game.PrintChat("Welcome to LeagueSharp!");
            }

            if (Language == "us")
            {
                Game.PrintChat("Welcome to LeagueSharp!");
            }

            if (Language == "ar")
            {
                Game.PrintChat("Bem-vindo ao LeagueSharp!");
            }

            if (Language == "es")
            {
                Game.PrintChat("Bienvenido a LeagueSharp!");
            }

            if (Language == "mx")
            {
                Game.PrintChat("Bienvenido a LeagueSharp!");
            }

            if (Language == "fr")
            {
                Game.PrintChat("Bienvenue à LeagueSharp!");
            }

            if (Language == "hu")
            {
                Game.PrintChat("Üdvözöljük a LeagueSharp!");
            }

            if (Language == "it")
            {
                Game.PrintChat("Benvenuti a LeagueSharp!");
            }

            if (Language == "jp")
            {
                Game.PrintChat("Welcome to LeagueSharp!");
            }

            if (Language == "kr")
            {
                Game.PrintChat("LeagueSharp에 오신 것을 환영합니다!");
            }

            if (Language == "pl")
            {
                Game.PrintChat("Zapraszamy do LeagueSharp!");
            }

            if (Language == "br")
            {
                Game.PrintChat("Bem-vindo ao LeagueSharp!");
            }

            if (Language == "ro")
            {
                Game.PrintChat("Bine ați venit la LeagueSharp!");
            }

            if (Language == "ro")
            {
                Game.PrintChat("Добро пожаловать в LeagueSharp!");
            }

        }
    }
}
