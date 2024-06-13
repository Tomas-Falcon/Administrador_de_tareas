using Administrador_de_Tareas.Models;

namespace Administrador_de_Tareas.DTOs
{
    public class TodoDTO
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsBlocked { get; set; } = false;
        public States TODOStates { get; set; } = States.PLANED;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool IsSelected { get; set; } = false;

        public enum States
        {
            PLANED,
            STARTED,
            IN_PROSESS,
            COMPLETE

        }

        public static Todo MapToTask(TodoDTO todoDTO) {
            Todo todo = new Todo();
            todo.Id = todoDTO.Id;
            todo.Description = todoDTO.Description;
            todo.TODOStates = todoDTO.TODOStates;
            todo.Title = todoDTO.Title;
            todo.IsBlocked = todoDTO.IsBlocked;
            todo.CreateDate = todoDTO.CreateDate;
            return todo;
        }

        public static TodoDTO MapFromTaskToDto(Todo todo)
        {
            TodoDTO todoDTO = new TodoDTO();
            todoDTO.Id = todo.Id;
            todoDTO.Description = todo.Description;
            todoDTO.TODOStates = todo.TODOStates;
            todoDTO.Title = todo.Title;
            todoDTO.IsBlocked = todo.IsBlocked;
            todoDTO.CreateDate = todo.CreateDate;

            return todoDTO;
        }

    }

}

