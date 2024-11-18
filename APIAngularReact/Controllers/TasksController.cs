using APIAngularReact.Dtos;
using APIAngularReact.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAngularReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly MyContext _context;
      

        public TasksController(MyContext context)
        {
            _context = context;
        }

        // Obtenir toutes les tâches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtoTask>>> GetAllTasks()
        {
            var tasks = await _context.Taskes
                .Select(t => new dtoTask
                {
                    title = t.title,
                    description = t.description,
                    createdAt = t.createdAt,
                    statut=t.statut
                })
                .ToListAsync();

            return Ok(tasks);
        }

        // Obtenir une tâche spécifique par Id
        [HttpGet("{id}")]
        public async Task<ActionResult<dtoTask>> GetTaskById(int id)
        {
            var task = await _context.Taskes.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var dtoTask = new dtoTask
            {
                title = task.title,
                description = task.description,
                createdAt = task.createdAt,
                 statut = task.statut
            };

            return Ok(dtoTask);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(dtoTask newTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapper le dtoTask vers l'entité Taske
            var newTask = new Taske
            {
                title = newTaskDto.title,
                description = newTaskDto.description,
                createdAt = newTaskDto.createdAt,
                statut = newTaskDto.statut

            };

            // Ajouter la tâche dans la base de données
            _context.Taskes.Add(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }

        // Modifier la tache dans la base de donnée
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, dtoTask updatedTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Rechercher la tâche existante par ID
            var existingTask = await _context.Taskes.FindAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de la tâche
            existingTask.title = updatedTaskDto.title;
            existingTask.description = updatedTaskDto.description;
            existingTask.createdAt = updatedTaskDto.createdAt;

            // Sauvegarder les modifications
            _context.Taskes.Update(existingTask);
            await _context.SaveChangesAsync();

            return NoContent(); // Retourner une réponse 204 No Content pour indiquer la réussite
        }



        // Suprimer une tache dans la base de donnée
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            // Rechercher la tâche existante par ID
            var taskToDelete = await _context.Taskes.FindAsync(id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            // Supprimer la tâche
            _context.Taskes.Remove(taskToDelete);
            await _context.SaveChangesAsync();

            return NoContent(); // Retourner une réponse 204 No Content pour indiquer la réussite
        }


    }
}
