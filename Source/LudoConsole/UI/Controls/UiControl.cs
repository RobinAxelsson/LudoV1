using LudoConsole.UI.Models;
using LudoEngine.BoardUnits.Interfaces;
using LudoEngine.BoardUnits.Main;
using LudoEngine.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoConsole.UI.Controls
{
    public static class UiControl
    {
        public const ConsoleColor LightAccent = ConsoleColor.Gray;
        public const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        public const ConsoleColor DefaultForegroundColor = ConsoleColor.White;
        public const ConsoleColor DefaultBoardChars = ConsoleColor.Black;
        public const ConsoleColor DropShadow = ConsoleColor.Black;
        public const ConsoleColor PawnInverseColor = ConsoleColor.White;
        public const ConsoleColor DarkAccent = ConsoleColor.Black;

        public static Random random = new Random();
        public static ConsoleColor RandomColor() => (ConsoleColor)random.Next(0, 15);
        public static void SetDefault()
        {
            Console.ForegroundColor = DefaultForegroundColor;
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.CursorVisible = false;
            Console.WindowWidth = 89;
            Console.WindowHeight = 38;
        }
        public static ConsoleColor TranslateColor(TeamColor color) =>
           color == TeamColor.Blue ? ConsoleColor.DarkBlue :
           color == TeamColor.Green ? ConsoleColor.Green :
           color == TeamColor.Red ? ConsoleColor.Red :
           color == TeamColor.Yellow ? ConsoleColor.Yellow : LightAccent;

    }
}
