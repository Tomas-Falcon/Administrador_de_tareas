using Administrador_de_Tareas.Models;

namespace Administrador_de_Tareas.Repository
{
    public interface IRepository<TItem>
    {
        public void Insert(TItem model);
        public void AutoInsert(int model);
        public void Update(TItem model);
        public void Delete(TItem model);
        public void Delete(IEnumerable<TItem> model);
        public Task<IEnumerable<TItem>> Get(int a);


    }
}
