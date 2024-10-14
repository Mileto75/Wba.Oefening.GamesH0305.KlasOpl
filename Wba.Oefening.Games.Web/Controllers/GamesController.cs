using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;
using Wba.Oefening.Games.Web.ViewModels;

namespace Wba.Oefening.Games.Web.Controllers
{

    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }

       
        public IActionResult Index()
        {
            //init view model
            var gamesIndexViewModel = new GamesIndexViewModel();
            gamesIndexViewModel.Games = new List<GamesDetailViewModel>();
            //get the games from the repo
            foreach (var game in _gameRepository.GetGames())
            {
                //and add to viewmodel
                gamesIndexViewModel.Games.Add(
                    new GamesDetailViewModel
                    {
                        Id = game?.Id ?? 0,
                        Title = game?.Title ?? "NoTitle",
                        DeveloperId = game?.Developer?.Id,
                        DeveloperName = game?.Developer?.Name ?? "<NoName>",
                        Rating = game?.Rating ?? 0
                    }
                    );
            }

            //pass view model to Index.cshtml view
            return View(gamesIndexViewModel);
        }

        public IActionResult ShowGame(int id)
        {
            //get data (with a Linq Extension method)
            var game = _gameRepository.GetGames()
                .FirstOrDefault(d => d.Id == id);

            if (game == null)
                return NotFound();

            //init view model
            var gamesDetailViewModel = new GamesDetailViewModel();
            gamesDetailViewModel.Id = game?.Id ?? 0;
            gamesDetailViewModel.Title = game?.Title ?? "<NoTitle>";
            gamesDetailViewModel.DeveloperId = game?.Developer?.Id ?? 0;
            gamesDetailViewModel.DeveloperName = game?.Developer?.Name ?? "<NoName>";
            gamesDetailViewModel.Rating = game?.Rating ?? 0;

            //pass view model to ShowGame.cshtml view
            return View(gamesDetailViewModel);
        }

    }
}