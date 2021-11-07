using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository _repository;

        public CharacterService(IRepository repository)
        {
            _repository = repository;
        }
        public Character Add(Character character)
        {
            return _repository.Add(character);
        }

        public bool Delete(int Id)
        {
            return _repository.Delete(Id);
        }

        public Character Get(int Id)
        {
            return _repository.Get(Id);
        }

        public Character Update(Character character)
        {
            return _repository.Update(character);
        }

        public List<Character> Get()
        {
            return _repository.Get();
        }
    }
}
