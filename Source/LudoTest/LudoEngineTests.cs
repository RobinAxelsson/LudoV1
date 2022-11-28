﻿using LudoEngine.Board;
using LudoEngine.Enum;
using LudoEngine.GameLogic;
using LudoEngine.GameLogic.GamePlayers;
using Xunit;

namespace LudoTest
{
    public class LudoEngineTests
    {
        [Fact]
        public void Run_full_game()
        {
            var aiPlayers = new[]
            {
                new Stephan(TeamColor.Red),
                new Stephan(TeamColor.Blue),
                new Stephan(TeamColor.Yellow),
                new Stephan(TeamColor.Green),
            };

            var gamePlay = new GamePlay(aiPlayers, new Dice(1,6));


            GameBoard.Init();
            GameSetup.SetUpPawnsNewGame(GameBoard.BoardSquares);
            gamePlay.Start();
        }
    }
}