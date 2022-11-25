﻿using System;
using LudoConsole.UI.Controls;
using LudoConsole.UI.Interfaces;

namespace LudoConsole.UI.Models
{
    public record TextDrawable : IDrawable
    {
        public TextDrawable(int coordX, int coordY, char chr)
        {
            CoordinateX = coordX;
            CoordinateY = coordY;
            Chars = chr.ToString();
        }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Chars { get; set; }
        public ConsoleColor BackgroundColor { get; set; } = UiColor.DefaultBackgroundColor;
        public ConsoleColor ForegroundColor { get; set; } = UiColor.DefaultForegroundColor;
        public bool IsDrawn { get; set; }
        public bool DoErase { get; set; }

        public bool IsSame(IDrawable drawable)
        {
            if (CoordinateX != drawable.CoordinateX) return false;
            if (CoordinateY != drawable.CoordinateY) return false;
            if (Chars != drawable.Chars) return false;
            if (ForegroundColor != drawable.ForegroundColor) return false;
            if (BackgroundColor != drawable.BackgroundColor) return false;
            return true;
        }
    }
}