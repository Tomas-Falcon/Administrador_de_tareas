using Administrador_de_Tareas.Models;

namespace Administrador_de_Tareas.Repository
{
    public interface IRepository
    {
        public void Insert(Todo model);
        public void Update(Todo model);
        public void Delete(Todo model);
        public Task<List<Todo>> Get(int a);


    }
}
