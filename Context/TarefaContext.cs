using Microsoft.EntityFrameworkCore;
using API_Tarefas.Models;

namespace API_Tarefas.Context
{
    public class TarefaContext : DbContext //herdando classe de DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options){} //herdando options de DbContext

        public DbSet<Tarefa> Tarefa { get; set; } //Declarando que esta será uma tabela
   }
}