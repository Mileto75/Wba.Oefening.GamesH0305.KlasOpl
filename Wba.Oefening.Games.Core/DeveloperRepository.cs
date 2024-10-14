using System.Collections.Generic;

namespace Wba.Oefening.Games.Core
{
    public class DeveloperRepository
    {
        public IEnumerable<Developer> GetDevelopers()
        {
            return new List<Developer>
            {
                new Developer{ Id = 1, Name = "Ubisoft" },
                new Developer{ Id = 2, Name = "Electronic Arts" },
                new Developer{ Id = 3, Name = "Bethesda" }
            };
        }
    }
}
