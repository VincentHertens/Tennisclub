using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(TennisclubContext context) : base(context)
        {

        }

        public IEnumerable<Game> GetAllGamesFiltered(DateTime? date)
        {
            return _context.Set<Game>()
                .Include(x => x.Member)
                .Include(x => x.League)
                .Where(game => (game.Date == date || date == null)) //Of date == DateTime.MinValue()
                .OrderBy(x => x.GameNumber)
                .ToList();
        }

        // Toekomstige methoden
    }
}
