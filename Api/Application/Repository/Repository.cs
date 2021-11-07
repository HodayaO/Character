using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interface;
using Domain.Models;
using Domain.Helpers;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace Application.Repository
{
    public class Repository : IRepository
    {
        private static string jsonPath = "..\\..\\Api\\Application\\LocalFIles\\Json.txt";

        private static List<Character> _characters;
        private static List<Character> _defaultCharacters = new List<Character>()
            {
                new Character() { Id = 1, Title = "News 1", Body = "Whats new in the hood", CreatedBy = "Hodaya Ohana", CreatedDate = new DateTime(2021, 11, 6)},
                new Character() { Id = 2, Title = "News 2", Body = "Second Character", CreatedBy = "Daniel Ohana", CreatedDate = new DateTime(2021, 11, 6)}
            };

        public Repository()
        {

            _characters = ReadFromJson();

            if (_characters == null)
                _characters = _defaultCharacters;
        }

        private List<Character> ReadFromJson()
        {

            string json = File.ReadAllText(jsonPath);

            if (string.IsNullOrEmpty(json)) return null;

            try
            {
                return JsonConvert.DeserializeObject<List<Character>>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void WriteToJson(List<Character> characters)
        {
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(characters));
        }

        private void SyncCharacterList(List<Character> characters)
        {
            WriteToJson(_characters);
            _characters = ReadFromJson();
        }

        public Character Add(Character character)
        {
            character.Id = _characters.Max(c => c.Id) + 1;
            _characters.Add(character);
            SyncCharacterList(_characters);
            return character;
        }

        public bool Delete(int Id)
        {
            if (!_characters.Any(c => c.Id == Id))
                return false;

            bool isSuccess = _characters.Remove(_characters.Where(c => c.Id == Id).FirstOrDefault());

            if (isSuccess) SyncCharacterList(_characters);

            return isSuccess;
        }

        public Character Get(int Id)
        {
            return _characters.FirstOrDefault(c => c.Id == Id);
        }

        public List<Character> Get()
        {
            return _characters;
        }

        public Character Update(Character character)
        {
            Character old = _characters.FirstOrDefault(c => c.Id == character.Id);
            if (old == null) return null;

            Extention.UpdateForType<Character>(typeof(Character), character, old);

            //TODO: check if the value changed in the list
            SyncCharacterList(_characters);

            return old;
        }


    }
}
