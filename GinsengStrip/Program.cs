using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SharpDX;
using LeagueSharp;
using LeagueSharp.Common;

namespace GinsengStrip
{

    class Program
    {
        public static System.Timers.Timer t;
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            t = new System.Timers.Timer()
            {
                Enabled = true,
                Interval = 7000
            };
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Game.OnGameUpdate += OnGameUpdate;
        }

        private static void OnGameUpdate(EventArgs args)
        {
            string zaman = Convert.ToString(Game.ClockTime);
            if (Game.ClockTime == 1.30)
            t.Elapsed += (object tSender, System.Timers.ElapsedEventArgs tE) =>
            {
                Game.PrintChat(zaman);
            };
           
        }
    }
}
