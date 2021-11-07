using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IRepository
    {
        public Character Add(Character character);
        public Character Update(Character character);
        public bool Delete(int Id);
        public Character Get(int Id);
        public List<Character> Get();
    }
}
