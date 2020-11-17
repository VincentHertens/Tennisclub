﻿using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        IEnumerable<Game> GetAllGamesFiltered(DateTime? date);
    }
}
