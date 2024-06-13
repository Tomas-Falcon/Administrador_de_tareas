using Administrador_de_Tareas.DTOs;
using Administrador_de_Tareas.Infraestructure;
using Administrador_de_Tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace Administrador_de_Tareas.Repository
{
    public class TODORepository : IRepository<TodoDTO>
    {
        private readonly TODOListDbContext _dbContext;
        public TODORepository(TODOListDbContext context)
        {
            _dbContext = context;
        }

        public void Delete(TodoDTO model)
        {
            _dbContext.TodoSet.Remove(_dbContext.TodoSet.Find(model.Id)!);
            _dbContext.SaveChanges();
        }

        public void Delete(IEnumerable<TodoDTO> model)
        {
            _dbContext.TodoSet.RemoveRange(model.Select(x => _dbContext.TodoSet.Find(x.Id)!));
            _dbContext.SaveChanges();
        }

        public void Insert(TodoDTO model)
        {
            _dbContext.TodoSet.Add(TodoDTO.MapToTask(model));
            _dbContext.SaveChanges();
        }

        public void Update(TodoDTO model)
        {

            var existingEntity = _dbContext.TodoSet.Local.FirstOrDefault(e => e.Id == model.Id);
            if (existingEntity != null)
            {
                existingEntity.Title = model.Title;
                existingEntity.Description = model.Description;
                existingEntity.TODOStates = model.TODOStates;
                existingEntity.IsBlocked = model.IsBlocked;
                existingEntity.CreateDate = model.CreateDate;

            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<TodoDTO>> Get(int page)
        {
            return _dbContext.TodoSet.Skip(page * 10).Take(10).Select(s => TodoDTO.MapFromTaskToDto(s));
        }

        public void AutoInsert(int model)
        {
            for (int i = 0; i < model; i++)
            {
                Todo todo = new Todo();
                todo.Title = $"Tarea Nº{i}";
                todo.Description = $"Descripcionde la tarea Nº{i}";
                _dbContext.TodoSet.Add(todo);
            }
            _dbContext.SaveChanges();
        }
    }
}
