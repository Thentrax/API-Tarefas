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
    }
}