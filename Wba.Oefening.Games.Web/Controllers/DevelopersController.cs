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
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;
        private readonly GameRepository _gameRepository;

        public DevelopersController()
        {
            //initialize service classes
            _developerRepository = new DeveloperRepository();
            _gameRepository = new GameRepository();
        }

       
        public IActionResult Index()
        {
            //init view model
            var developersIndexViewModel = new DevelopersIndexViewModel();
            developersIndexViewModel.Developers = new List<DevelopersDetailViewModel>();
            //get the developers and add to view model
            foreach (var developer in _developerRepository.GetDevelopers())
            {
                developersIndexViewModel.Developers.Add(
                    new DevelopersDetailViewModel
                    {
                        Id = developer?.Id ?? 0,
                        Name = developer?.Name ?? "<NoName>",
                    }
                    );
            }

            //pass view model to Index.cshtml view
            return View(developersIndexViewModel);
        }

        public IActionResult ShowDeveloper(int id)
        {
            //get developer by id
            var developer = _developerRepository.GetDevelopers()
                .FirstOrDefault(d => d.Id == id);

            if (developer == null)
                return NotFound();

            //get games by this developer
            var gamesFromDeveloper = _gameRepository.GetGames()
                .Where(g => g.Developer.Id == id);

            //init view model
            var developersDetailViewModel = new DevelopersDetailViewModel();
            developersDetailViewModel.Id = developer?.Id;
            developersDetailViewModel.Name = developer?.Name;
            developersDetailViewModel.Games = new List<GamesDetailViewModel>();
            foreach (var game in gamesFromDeveloper)
            {
                developersDetailViewModel.Games.Add(
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

            //pass view model to ShowDeveloper.cshtml view
            return View(developersDetailViewModel);
        }
    }
}