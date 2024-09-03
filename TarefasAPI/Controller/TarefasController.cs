
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tareaAPI.Data.Entities;
using TarefasAPI.Data.Entities;

namespace TarefasAPI.Controller;

 [ApiController]
  [Route("[controller]")] 
 public class TarefasController : ControllerBase
 {

    private readonly databaseContext _configuration;
     public TarefasController(databaseContext configuration)
     {
         _configuration = configuration;
     } 

    [HttpGet]
    public async Task<ActionResult> GetTarefas()  {
        var tarefas = await _configuration.Tarefas.ToListAsync();
        return Ok(tarefas);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Tarefas newTarefa)  {
        _configuration.Tarefas.Add(newTarefa);
        await _configuration.SaveChangesAsync();
        return Ok(newTarefa);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> Put(int id)
    {
        var tarefa = await _configuration.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.situacao = 1;
        tarefa.DataConclusao = DateTime.Now;
         _configuration.Tarefas.Update(tarefa);
        await _configuration.SaveChangesAsync();
        var tarefas = await _configuration.Tarefas.ToListAsync();
        return Ok(tarefas);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var tarefa = await _configuration.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.situacao = 1;
        tarefa.DataConclusao = DateTime.Now;
        _configuration.Tarefas.Remove(tarefa);
        await _configuration.SaveChangesAsync();
        var tarefas = await _configuration.Tarefas.ToListAsync();
        return Ok(tarefas);
    }
}
