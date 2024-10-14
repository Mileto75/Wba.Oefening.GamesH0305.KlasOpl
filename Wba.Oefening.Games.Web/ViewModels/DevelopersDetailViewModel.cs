using System.Collections.Generic;
using Wba.Oefening.Games.Core;

namespace Wba.Oefening.Games.Web.ViewModels
{
    public class DevelopersDetailViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<GamesDetailViewModel> Games { get; set; }
    }
}
