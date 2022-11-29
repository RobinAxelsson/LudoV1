﻿using System;
using LudoEngine.DbModel;
using System.Collections.Generic;
using System.Linq;
using LudoEngine.Board;
using LudoEngine.ClientApi;
using LudoEngine.GameLogic;
using LudoEngine.Interfaces;
using LudoEngine.Enum;
using LudoEngine.Exceptions;
using LudoEngine.GameLogic.GamePlayers;

namespace LudoEngine
{
    public static class LudoEngineFacade
    {
        public static IReadOnlyList<GameDto> GetSavedGames()
        {
            var games = DatabaseManagement.GetGames();
            return games.Select(x => new GameDto(x.Id, x.LastSaved)).ToArray();
        }

        //public static StartLocalGameSession(ILudoClient client)
        //{
            //client.OnNewGame(gameDto);
            //adding client to game loop
            //
        //}

        public static StageSavingDto GetStageSavingDto(int id)
        {
            var game = DatabaseManagement.GetGames().Single(x =>x.Id == id);

            return new StageSavingDto()
            {
                CurrentTeam = StageSaving.CurrentTeam,
                Pawns = StageSaving.Pawns,
                Game = game,
                Players = StageSaving.Players,
                TeamPosition = DatabaseManagement.GetPawnPositionsInGame(game)
            };
        }

        public static List<IGameSquare> GetNewGameBoardSquares()
        {
            var squares = GameSquareFactory.CreateGameSquares(@"Board/Map/BoardMap.txt");
            GameSetup.SetUpPawnsNewGame(squares);
            return squares;
        }

        public static void RunDemo(LudoClientBase ludoClient)
        {
            var gameSquares = GameSquareFactory.CreateGameSquares(@"Board/Map/BoardMap.txt");
            ludoClient.OnNewGame(ClientMapper.MapGame(gameSquares));
        }
    }

    public record GameDto(int Id, DateTime LastSaved);
}
