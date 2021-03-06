﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.DomainModel;
using NumberPuzzleWeb.Core.DomainServices;

namespace NumberPuzzleWeb.Core.ApplicationServices
{
    public class GameService
    {
        private readonly IGameModelRepository _repository;
        public GameService(IGameModelRepository repository)
        { 
            _repository = repository;
        }

        public async Task<GameModel> StartGame()
        {
            var gameModel = new GameModel();
            await _repository.Create(gameModel);
            return gameModel;
        }

        public async Task<GameModel> Read(Guid gameId)
        {
            return await _repository.Read(gameId);
        }

        public async Task<GameModel> Play(int index, Guid gameId)
        {
            var gameModel = await _repository.Read(gameId);
            var hasPlayed = gameModel.Play(index);
            await _repository.Update(gameModel);
            return gameModel;
        }
    }
}
