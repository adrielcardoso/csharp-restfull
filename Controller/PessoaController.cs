using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharpRest.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharpRest.Controller
{
    [Produces("application/json")]
    [Route("api/pessoa")]
    public class PessoaController : Microsoft.AspNetCore.Mvc.Controller
    { 
        private readonly DataContext _context;

        public PessoaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.pessoas.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }

            _context.pessoas.Add(pessoa);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Pessoa item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.pessoas.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            
            todo.Nome = item.Nome;
            todo.Sobrenome = item.Sobrenome;

            _context.pessoas.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.pessoas.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.pessoas.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.pessoas.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}