using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GameRepositories
{
    public class GameRepository : GenericRepository<Game, GameReadDto, GameCreateDto, GameUpdateDto, int>, IGameRepository
    {
        public GameRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public override GameReadDto Add(GameCreateDto createDto)
        {
            var member = _context.Set<Member>().Find(createDto.MemberId);
            if (member != null && member.Active)
            {
                return base.Add(createDto);
            }

            //TODO: Error geven als niet actief
            return null;
        }
    }
}
