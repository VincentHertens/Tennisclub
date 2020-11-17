using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public interface IGameResultRepository : IBaseRepository<GameResult>
    {
        IEnumerable<GameResult> GetAllGameResultsByMemberId(int id, DateTime? date);
    }
}
