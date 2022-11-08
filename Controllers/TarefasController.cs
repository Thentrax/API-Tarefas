using Microsoft.AspNetCore.Mvc;
using API_Tarefas.Models;
using API_Tarefas.Context;

namespace API_Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaContext _context;    
        
        public TarefasController(TarefaContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var tarefa = _context.Tarefa.Find(id);

            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult GetAll()
        {
            var tarefas = _context.Tarefa.ToList();

            if (tarefas == null)
                return NotFound();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult GetByTitle(string titulo)
        {
            var tarefa = _context.Tarefa.Where(x => x.Titulo.ToUpper().Contains(titulo.ToUpper())).ToList();
            if (tarefa == null)
            return NotFound();

            return Ok(tarefa);
        }
        [HttpGet("ObterPorData")]
        public IActionResult GetByTitle(DateTime data)
        {
            var tarefa = _context.Tarefa.Where(x => x.Data.Date == data.Date).ToList();
            if (tarefa == null)
            return NotFound();

            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult GetByTitle(EnumStatusTarefa status)
        {
            var tarefa = _context.Tarefa.Where(x => x.Status == status).ToList();
            if (tarefa == null)
            return NotFound();

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("id")]
        public IActionResult Update(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefa.Find(id);
            if (tarefaBanco == null)
               return NotFound();

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefa.Update(tarefaBanco);
            _context.SaveChanges();
                return Ok(tarefaBanco);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var tarefaBanco = _context.Tarefa.Find(id);
            if (tarefaBanco == null)
               return NotFound();

            _context.Tarefa.Remove(tarefaBanco);
            _context.SaveChanges();
            return Ok("Tarefa excluída com sucesso!");

      }
    }
}