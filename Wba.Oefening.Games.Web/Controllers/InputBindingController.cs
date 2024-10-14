using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class InputBindingController : Controller
    {
        private readonly StringBuilder stringBuilder;

        public InputBindingController()
        {
            stringBuilder = new StringBuilder();
        }

        [HttpPost]
        [Route("games/getgame")]
        public IActionResult GetGame(
            [FromQuery] int gameId,
            [FromForm] string gameTitle,
            [FromForm] string gameDeveloper,
            [FromForm] int gameRating)
        {
            stringBuilder.AppendLine($"Game Id: {gameId}");
            stringBuilder.AppendLine($"Title: {gameTitle}");
            stringBuilder.AppendLine($"Developer: {gameDeveloper}");
            stringBuilder.AppendLine($"Rating: {gameRating}");
            return Content(stringBuilder.ToString(), "text/html");
        }

        [HttpPost]
        [Route("games/postgamecomplex")]
        public IActionResult GetGameComplex(Game game)
        {
            stringBuilder.AppendLine($"<ul><li>Game Id: {game?.Id}</li>");
            stringBuilder.AppendLine($"<li>Title: {game?.Title}</li>");
            stringBuilder.AppendLine($"<li>Developer: {game?.Developer?.Name}</li>");
            stringBuilder.AppendLine($"<li>Rating: {game?.Rating}</li></ul>");
            return Content(stringBuilder.ToString());
        }

        [Route("games/getgamearray")]
        [HttpGet]
        public IActionResult GetGameArray(Game[] games)
        {
            stringBuilder.AppendLine("<table>");
            foreach (var game in games)
            {
                stringBuilder.AppendLine($"<tr><td>Game Id: {game?.Id}</td></tr>");
                stringBuilder.AppendLine($"<tr><td>Title: {game?.Title}</td></tr>");
                stringBuilder.AppendLine($"<tr><td>Developer: {game?.Developer?.Name}</td></tr>");
                stringBuilder.AppendLine($"<tr><td>Rating: {game?.Rating}</td></tr>");
            }
            stringBuilder.AppendLine("</table>");
            return Content(stringBuilder.ToString(), "text/html");
        }

        [Route("developers/getdevelopers")]
        public IActionResult GetDevelopers(IEnumerable<Developer> developers)
        {
            stringBuilder.AppendLine("<table>");
            foreach (var developer in developers)
            {
                stringBuilder.AppendLine($"<tr><td>Developer Id: {developer?.Id}</td></tr>");
                stringBuilder.AppendLine($"<tr><td>Name: {developer?.Name}</td></tr>");
            }
            stringBuilder.AppendLine("</table>");
            return Content(stringBuilder.ToString(), "text/html");
        }

        [Route("games/rategame")]
        [HttpPost]
        public IActionResult RateGame([FromForm]Game game, [FromQuery]int rating)
        {
            game.Rating = rating;
            stringBuilder.AppendLine($"<tr><td>Game Id: {game?.Id}</td></tr>");
            stringBuilder.AppendLine($"<tr><td>Title: {game?.Title}</td></tr>");
            stringBuilder.AppendLine($"<tr><td>Developer: {game?.Developer?.Name}</td></tr>");
            stringBuilder.AppendLine($"<tr><td>Rating: {game?.Rating}</td></tr>");

            return Content(stringBuilder.ToString(), "text/html");
        }

    }
}