using static Administrador_de_Tareas.DTOs.TodoDTO;

namespace Administrador_de_Tareas.Models
{
    public class Todo
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsBlocked { get; set; } = false;
        public States TODOStates { get; set; } = States.PLANED;

       
    }
}
