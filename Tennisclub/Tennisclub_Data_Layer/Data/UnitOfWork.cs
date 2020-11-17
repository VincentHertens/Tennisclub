using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Repositories;

namespace Tennisclub_Data_Layer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TennisclubContext _context;

        private MemberRepository _memberRepository;
        private GenderRepository _genderRepository;
        private GameRepository _gameRepository;
        private GameResultRepository _gameResultRepository;
        private LeagueRepository _leagueRepository;
        private MemberRoleRepository _memberRoleRepository;
        private RoleRepository _roleRepository;
        private MemberFineRepository _memberFineRepository;

        public UnitOfWork(TennisclubContext context)
        {
            _context = context;
        }

        public IMemberRepository Members => _memberRepository = _memberRepository ?? new MemberRepository(_context);

        public IGenderRepository Genders => _genderRepository = _genderRepository ?? new GenderRepository(_context);

        public IGameRepository Games => _gameRepository = _gameRepository ?? new GameRepository(_context);

        public IGameResultRepository GameResults => _gameResultRepository = _gameResultRepository ?? new GameResultRepository(_context);

        public ILeagueRepository Leagues => _leagueRepository = _leagueRepository ?? new LeagueRepository(_context);

        public IMemberRoleRepository MemberRoles => _memberRoleRepository = _memberRoleRepository ?? new MemberRoleRepository(_context);

        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);

        public IMemberFineRepository MemberFines => _memberFineRepository = _memberFineRepository ?? new MemberFineRepository(_context);

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
