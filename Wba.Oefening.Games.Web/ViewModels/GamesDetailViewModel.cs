using Wba.Oefening.Games.Core;

namespace Wba.Oefening.Games.Web.ViewModels
{
    public class GamesDetailViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public int? Rating { get; set; }
    }
}
