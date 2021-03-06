﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NumberPuzzleWeb.Core.DomainModel;
using NumberPuzzleWeb.Core.DomainServices;
using DbGameModel =NumberPuzzleWeb.Infrastructure.DataAccess.Model.GameModel;

namespace NumberPuzzleWeb.Infrastructure.DataAccess.Repository
{
    public class GameModelRepository : IGameModelRepository
    {
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NumberPuzzleWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public async Task<bool> Create(GameModel gameModel)
        {
            await using var conn = new SqlConnection(ConnectionString);
            const string insert =
                "INSERT INTO GAME (Id, Numbers, PlayCount) VALUES (@Id, @Numbers, @PlayCount";
            var dbGameModel = MapToDb(gameModel);
            var rowsAffected =await conn.ExecuteAsync(insert, dbGameModel);
            return rowsAffected == 1;
        }

        public async Task<GameModel> Read(Guid id)
        {
            await using var conn = new SqlConnection(ConnectionString);
            const string select =
                "SELECT Id, Numbers, PlayCount FROM Game WHERE Id = @Id";
            var result = await conn.QueryAsync<DbGameModel>(select, new {Id = id});
            var gameModel = result.SingleOrDefault();
            return MapToDomain(gameModel);
        }

        public async Task<bool> Update(GameModel gameModel)
        {
            await using var conn = new SqlConnection(ConnectionString);
            const string insert =
                "UPDATE Game SET Numbers = @Numbers, Playcount = @PlayCount WHERE Id = @Id";
            var dbGameModel = MapToDb(gameModel);
            var rowsAffected = await conn.ExecuteAsync(insert, dbGameModel);
            return rowsAffected == 1;
        }

        private static GameModel MapToDomain(DbGameModel gameModel)
        {
            var numbers = gameModel.Numbers.ToCharArray().Select(c => c - '0').ToArray();
            return new GameModel(gameModel.Id, gameModel.PlayCount, numbers);
        }

        private static DbGameModel MapToDb(GameModel gameModel)
        {
            var numbers = new string(gameModel.Numbers).Replace(' ', '0');
            return new DbGameModel(gameModel.Id, gameModel.PlayCount, numbers);
        }
    }
}
