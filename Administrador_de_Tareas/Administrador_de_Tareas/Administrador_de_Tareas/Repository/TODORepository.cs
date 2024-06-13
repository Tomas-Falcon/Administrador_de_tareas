using Administrador_de_Tareas.DTOs;
using Administrador_de_Tareas.Infraestructure;
using Administrador_de_Tareas.Models;

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
            _dbContext.TodoSet.Remove(TodoDTO.MapToEntity(model));
            _dbContext.SaveChanges();
        }

        public void Delete(IEnumerable<TodoDTO> model)
        {
            _dbContext.TodoSet.RemoveRange(model.Select(x => TodoDTO.MapToEntity(x)));
            _dbContext.SaveChanges();
        }

        public void Insert(TodoDTO model)
        {
            _dbContext.TodoSet.Add(TodoDTO.MapToEntity(model));
            _dbContext.SaveChanges();
        }

        public void Update(TodoDTO model)
        {
            _dbContext.TodoSet.Update(TodoDTO.MapToEntity(model));
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<TodoDTO>> Get(int page)
        {
          return _dbContext.TodoSet.Skip(page*10).Take(10).Select(s => TodoDTO.MapFromEntity(s));
        }
    }
}
