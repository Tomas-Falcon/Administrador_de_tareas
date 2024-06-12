using Administrador_de_Tareas.Models;
using Administrador_de_Tareas.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using System.Threading;

namespace Administrador_de_Tareas.Models
{
    public class Todo
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsPaused { get; set; } = false;
        public States TODOStates { get; set; } = States.PLANED;

        public enum States
        {
            PLANED,
            STARTED,
            IN_PROSESS,
            COMPLETE
        }
    }
}
