using Administrador_de_Tareas.Infraestructure;
using Administrador_de_Tareas.Models;

namespace Administrador_de_Tareas.Repository
{
    public class TODORepository : IRepository
    {
        private readonly TODOListDbContext _dbContext;
        public TODORepository(TODOListDbContext context)
        {
            _dbContext = context;
        }

        public void Delete(Todo model)
        {
            _dbContext.TodoSet.Remove(model);
            _dbContext.SaveChanges();
        }

        public void Insert(Todo model)
        {
            _dbContext.TodoSet.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(Todo model)
        {
            _dbContext.TodoSet.Update(model);
            _dbContext.SaveChanges();
        }

        public async Task<List<Todo>> Get(int page)
        {
          return _dbContext.TodoSet.Skip(page*10).Take(10).ToList();
        }
    }
}
