using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

namespace GinsengStrip
{

    class Program
    {
        public static System.Timers.Timer t;
        public static String GlobalChat;
        static void Main(string[] args)
        {
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            GetChat();
            Game.OnGameUpdate += OnGameUpdate;
            Game.PrintChat("Secenek =" + GlobalChat);
        }

        static void GetChat()
        {
            Process proc = Process.GetProcesses().First(p => p.ProcessName.Contains("League of Legends"));
            String propFile = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(proc.Modules[0].FileName)))))));
            propFile += @"Config\";
            DirectoryInfo di = new DirectoryInfo(propFile).GetDirectories().OrderByDescending(d => d.LastWriteTimeUtc).First();
            propFile = di.FullName + @"\game.cfg";
            propFile = File.ReadAllText(propFile);
            GlobalChat = new Regex("ShowAllChannelChat=(.+) Show").Match(propFile).Groups[1].Value;
        }

        private static void OnGameUpdate(EventArgs args)
        {
                Game.PrintChat("Secenek =" + GlobalChat);
        }
    }
}
