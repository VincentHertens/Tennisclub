﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Repositories.GameRepositories;

namespace Tennisclub_BL.Services.GameServices
{
    public class GameService : IGameService
    {
        private const int MAX_GAMENUMBER = 10; 
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GameReadDto> GetAllGamesByDate(DateTime? date)
        {
            return _repository.GetAllGamesByDate(date);
        }

        public IEnumerable<GameReadDto> GetAllGamesByMember(int id, DateTime? date)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetAllGamesByMember(id, date);
        }

        public GameReadDto GetById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetById(id);
        }

        public GameReadDto Add(GameCreateDto gameCreateDto)
        {
            var list = _repository.GetAll(game => game.GameNumber == gameCreateDto.GameNumber);

            if (list.Count() != 0)
                throw new ArgumentException($"Game number must be unique");

            ValidateFields(gameCreateDto.GameNumber);

            return _repository.Add(gameCreateDto);
        }

        public GameReadDto Update(GameUpdateDto gameUpdateDto)
        {
            var list = _repository.GetAll(game => game.GameNumber == gameUpdateDto.GameNumber && game.Id != gameUpdateDto.Id);

            if (list.Count() != 0)
                throw new ArgumentException($"Game number must be unique");

            ValidateFields(gameUpdateDto.GameNumber);        

            return _repository.Update(gameUpdateDto);
        }

        public void Delete(int id)
        {            
            _repository.Delete(id);
        }

        private void ValidateFields(string gameNumber)
        {
            if (string.IsNullOrWhiteSpace(gameNumber) || gameNumber.Length > MAX_GAMENUMBER)
                throw new ArgumentException($"Game number cannot be empty or more than {MAX_GAMENUMBER} characters");
        }
    }
}
