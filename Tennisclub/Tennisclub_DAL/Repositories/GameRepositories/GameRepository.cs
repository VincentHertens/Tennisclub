using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GameRepositories
{
    public class GameRepository : GenericRepository<Game, GameReadDto, GameCreateDto, GameUpdateDto, int>, IGameRepository
    {
        public GameRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public IEnumerable<GameReadDto> GetAllGamesByDate(DateTime? date)
        {
            return GetAll(filter: game => (game.Date == date || date == null),
                orderBy: game => game.OrderBy(x => x.Date),
                x => x.Member, x => x.League);
        }

        public IEnumerable<GameReadDto> GetAllGamesByMember(int id, DateTime? date)
        {
            return GetAll(filter: game => (game.Date == date || date == null) && game.MemberId == id,
               orderBy: game => game.OrderBy(x => x.Date),
               x => x.Member, x => x.League);
        }

        public override GameReadDto Add(GameCreateDto createDto)
        {
            Validate(createDto.MemberId, createDto.LeagueId);

            return base.Add(createDto);
        }

        public override GameReadDto Update(GameUpdateDto updateDto)
        {
            Validate(updateDto.MemberId, updateDto.LeagueId);

            return base.Update(updateDto);
        }

        private void Validate(int memberId, byte leagueId)
        {
            var member = _context.Set<Member>().Find(memberId);
            var league = _context.Set<League>().Find(leagueId);

            if (member == null)
                throw new NullReferenceException("No member with this id has been found");

            if (league == null)
                throw new NullReferenceException("No league with this id has been found");

            if (!member.Active)
                throw new ArgumentException("Can't plan a game for an inactive member");
        }
    }
}
