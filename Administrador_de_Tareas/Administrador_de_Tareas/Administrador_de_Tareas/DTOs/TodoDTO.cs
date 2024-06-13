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

        public bool IsSelected { get; set; } = false;

        public enum States
        {
            PLANED,
            STARTED,
            IN_PROSESS,
            COMPLETE

        }

        public static Todo MapToEntity(TodoDTO todoDT) {
            Todo todo = new Todo();
            todo.Id = todoDT.Id;
            todo.Description = todoDT.Description;
            todo.TODOStates = todoDT.TODOStates;
            todo.Title = todoDT.Title;
            todo.IsBlocked = todoDT.IsBlocked;

            return todo;
        }

        public static TodoDTO MapFromEntity(Todo todo)
        {
            TodoDTO todoDTO = new TodoDTO();
            todoDTO.Id = todo.Id;
            todoDTO.Description = todo.Description;
            todoDTO.TODOStates = todo.TODOStates;
            todoDTO.Title = todo.Title;
            todoDTO.IsBlocked = todo.IsBlocked;

            return todoDTO;
        }

    }

}

