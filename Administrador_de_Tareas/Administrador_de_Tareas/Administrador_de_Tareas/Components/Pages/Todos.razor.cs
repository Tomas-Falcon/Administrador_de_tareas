using Administrador_de_Tareas.DTOs;
using Administrador_de_Tareas.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace Administrador_de_Tareas.Components.Pages
{
    partial class Todos
    {
        [Inject] private IRepository<TodoDTO> TodoRepository { get; set; }

        private List<TodoDTO> tasks = new List<TodoDTO>();
        private TodoDTO newTask = new TodoDTO();
        private int pageNumber = 0;
        private int pageSize = 10;
        private bool IsFirstPage => pageNumber == 0;
        private bool IsLastPage => tasks.Count < pageSize;
        private string errorMessage = "";
        private string clase = "";


        protected override async Task OnInitializedAsync()
        {
            RefreshTaskList();
        }

        private async void RefreshTaskList()
        {
            tasks = (await TodoRepository.Get(pageNumber)).ToList();

        }

        private async Task DeleteSelectedTasks()
        {
            TodoRepository.Delete(tasks.Where(w => w.IsSelected == true));
            RefreshTaskList();
            StateHasChanged();
        }

        private void Remove(TodoDTO todo)
        {
            TodoRepository.Delete(todo);

            RefreshTaskList();
            StateHasChanged();
        }

        private async Task AddTask()
        {
            if (newTask.Title.IsNullOrEmpty() || newTask.Description.IsNullOrEmpty())
            {
                errorMessage = "*Es necesario poner un titulo o una descripcion para crear la tarea";
                clase = "alert alert-danger";
                return;
            }
            errorMessage = "";
            clase = "";
            TodoRepository.Insert(newTask);
            tasks.Add(newTask);
            newTask = new TodoDTO();
            StateHasChanged();
        }

        
        private async Task NavigateToNextPage()
        {
            pageNumber++;
            RefreshTaskList();
        }

        private async Task NavigateToPreviousPage()
        {
            if (pageNumber > 0)
            {
                pageNumber--;
                RefreshTaskList();
            }
        }

        private void ChangeState(TodoDTO todo)
        {
            if (todo.TODOStates == TodoDTO.States.COMPLETE || todo.IsBlocked == true)
                return;

            todo.TODOStates++;
            SaveChange(todo);
        }

        private void ChangePause(TodoDTO todo)
        {
            todo.IsBlocked = !todo.IsBlocked;
            SaveChange(todo);
        }

        private void SaveChange(TodoDTO todo)
        {
            TodoRepository.Update(todo);
        }
        private async void AutoGenerateTasks()
        {
            TodoRepository.AutoInsert(100000);
            RefreshTaskList();
        }
    }
}