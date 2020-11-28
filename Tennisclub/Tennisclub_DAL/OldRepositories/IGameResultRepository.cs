using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public interface IGameResultRepository : IBaseRepository<GameResult>
    {
        IEnumerable<GameResult> GetAllGameResultsByMemberId(int id, DateTime? date);
    }
}
