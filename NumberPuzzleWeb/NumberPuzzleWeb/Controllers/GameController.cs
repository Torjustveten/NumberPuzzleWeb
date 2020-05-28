using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberPuzzleWeb.Core.ApplicationServices;
using NumberPuzzleWeb.Core.DomainModel;

namespace NumberPuzzleWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        public GameController(GameService gameService)
        {
            
        }
        [HttpGet]
        public async Task<GameModel> StartGame()
        {
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