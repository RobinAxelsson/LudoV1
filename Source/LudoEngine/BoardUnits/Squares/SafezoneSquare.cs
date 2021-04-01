﻿using LudoEngine.BoardUnits.Intefaces;
using LudoEngine.Enum;
using LudoEngine.Models;
using System.Collections.Generic;

namespace LudoEngine.BoardUnits.Main
{
    public class SafezoneSquare : IGameSquare
    {
        public SafezoneSquare(int boardX, int boardY, TeamColor color, BoardDirection direction)
        {
            Color = color;
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
        }
        public int BoardX { get; set; }
        public int BoardY { get; set; }
        public TeamColor? Color { get; set; }
        public List<Pawn> Pawns { get; set; } = new List<Pawn>();
        public BoardDirection DefaultDirection { get; set; }
        public BoardDirection DirectionNext(TeamColor Color) => DefaultDirection;
    }
}