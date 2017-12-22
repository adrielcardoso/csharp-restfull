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

            if (_context.pessoa.Count() == 0)
            {
                _context.pessoa.Add(new Pessoa { Nome = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.pessoa.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.pessoa.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}