using Api.Models;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public NewsController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            List<Character> characters = _characterService.Get();
            if (characters == null)
                return NotFound();
           // List < CharacterDTO >
            return Ok(characters);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Character> Get(int id)
        {
            Character character = _characterService.Get(id);
            if (character == null)
                return NotFound();

            return Ok(character);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Character> Post([FromBody] Character newCharacter)
        {
            return Ok(_characterService.Add(newCharacter));
        }        

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_characterService.Delete(id));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Character> Put(int id, [FromBody] Character value)
        {
            Character character = _characterService.Update(value);

            if (character == null)
                return NotFound();

            return Ok(character);
        }
    }
}
