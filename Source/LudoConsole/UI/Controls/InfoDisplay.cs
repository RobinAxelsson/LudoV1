﻿using LudoConsole.Main;
using LudoConsole.UI.Interfaces;
using LudoEngine.Enum;
using LudoEngine.GameLogic.GamePlayers;
using LudoEngine.GameLogic.Interfaces;
using LudoEngine.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LudoConsole.UI.Controls
{
    public class InfoDisplay : IInfoDisplay
    {
        public InfoDisplay(int x, int y)
        {
            X = x;
            Y = y;

            HumanPlayer.HumanThrowEvent += UpdateDiceRoll;
            HumanPlayer.OnTakeOutTwoPossibleEvent += MessageTakeOutTwoPossible;
            Stephan.StephanThrowEvent += UpdateDiceRoll;
            Pawn.OnAllTeamPawnsOutEvent += MessageOnAllTeamPawnsOut;
            Pawn.OnBounceEvent += MessageOnBounce;
            Pawn.OnEradicationEvent += MessageOnEradication;
            Pawn.OnGoalEvent += MessageOnGoal;
            Pawn.OnSafeZoneEvent += MessageOnSafeZone;
            Pawn.GameLoserEvent += LoserMessage;
            Pawn.GameOverEvent += MessageGameOver;
        }
        private List<IDrawable> drawables { get; set; } = new List<IDrawable>();
        private int X { get; set; }
        private int Y { get; set; }
        public void LoserMessage(TeamColor loser)
        {
            Update($"{loser} lost it all!");
            Thread.Sleep(1500);
        }
        public void MessageOnSafeZone(Pawn pawn)
        {
            Update($"Close one {pawn.Color}!");
            Thread.Sleep(1500);
            Update($"Pawn is safe.");
            Thread.Sleep(1500);
        }
        public void MessageGameOver()
        {
            Update($"Game Over");
        }
        public void MessageOnGoal(Pawn pawn, int pawnsInPlay)
        {
            Update($"{pawn.Color} scored!");
            Thread.Sleep(1500);
            Update($"{pawnsInPlay} to go...");
            Thread.Sleep(1500);
        }
        public void MessageOnEradication(Pawn pawn, TeamColor enemyColor, int eradicatedEnemies)
        {
            Update($"{pawn.Color} kills...");
            Thread.Sleep(1500);
            Update($"{eradicatedEnemies} {enemyColor}!");
            Thread.Sleep(1500);
        }
        public void MessageOnBounce(Pawn pawn)
        {
            Update($"Bad luck {pawn.Color}!");
            Thread.Sleep(1500);
        }
        public void MessageOnAllTeamPawnsOut(Pawn pawn)
        {
            Update($"Nice {pawn.Color}!");
            Thread.Sleep(1500);
            Update($"All Scored!");
            Thread.Sleep(1500);
        }
        public void MessageTakeOutTwoPossible(HumanPlayer player)
        {
            Update("'x' to takeout two.");
        }
        public void UpdateDiceRoll(HumanPlayer player, int result)
        {
            Update($"{player.Color}, throw dice");
            Console.ReadKey(true);
            Update($"{player.Color} throws...");
            Thread.Sleep(1000);
            Update($"{player.Color} got a {result}");
            Thread.Sleep(1500);
        }
        public void UpdateDiceRoll(Stephan stephan, int diceRoll)
        {
            Update($"{stephan.Color}, throw dice");
            Thread.Sleep(4000);
            Update($"{stephan.Color} throws...");
            Thread.Sleep(1000);
            Update($"{stephan.Color} got a {diceRoll}");
            Thread.Sleep(1500);
        }
        public void Update(string newString)
        {
            if (drawables.Count > newString.Length)
            {
                var iStart = newString.Length - 1;
                var end = drawables.Count;
                for (int i = iStart; i < end; i++)
                {
                    drawables[i].Erase = true;
                }
            }
            drawables.Clear();
            int x = 0;
            foreach (char chr in newString)
            {
                drawables.Add(new TextDrawable(this.X + x, this.Y, chr));
                x++;
            }
            ConsoleWriter.TryAppend(drawables);
        }
    }
}