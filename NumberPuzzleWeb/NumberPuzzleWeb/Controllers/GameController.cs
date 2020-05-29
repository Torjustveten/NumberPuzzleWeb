using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberPuzzleWeb.API.ViewModel;
using NumberPuzzleWeb.Core.ApplicationServices;
using NumberPuzzleWeb.Core.DomainModel;

namespace NumberPuzzleWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private GameService _gameService;

        public GameController(GameService gameService)
        {
            
        }
        [HttpGet]
        public async Task<GameViewModel> StartGame()
        {
            var game = await _gameService.StartGame();
            return new GameViewModel(game.Id.ToString(), game.PlayCount, game.IsSolved, game.Numbers);
        }

        [HttpGet("{gameId}")]
        public async Task<GameModel> Read(Guid gameId)
        {
           
        }

        [HttpPost]
        public async Task<GameModel> Play(int index, Guid gameId)
        {
            
        }
    }
}