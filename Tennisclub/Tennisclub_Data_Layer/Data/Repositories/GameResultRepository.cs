using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public class GameResultRepository : BaseRepository<GameResult>, IGameResultRepository
    {
        public GameResultRepository(TennisclubContext context) : base(context)
        {

        }

        public IEnumerable<GameResult> GetAllGameResultsByMemberId(int id, DateTime? date)
        {
            return _context.Set<GameResult>()
                .Include(x => x.Game).ThenInclude(x => x.League).Where(gameResult => gameResult.Game.MemberId == id
                && (gameResult.Game.Date == date || date == null)).ToList();
        }

        // Toekomstige methoden
    }
}
