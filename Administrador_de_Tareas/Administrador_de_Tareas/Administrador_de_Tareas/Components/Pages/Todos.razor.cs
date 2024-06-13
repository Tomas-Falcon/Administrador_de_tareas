using Administrador_de_Tareas.DTOs;
using Administrador_de_Tareas.Models;
using Administrador_de_Tareas.Repository;
using Microsoft.AspNetCore.Components;

namespace Administrador_de_Tareas.Components.Pages
{
    partial class Todos
    {
        [Inject] private IRepository<TodoDTO> TodoRepository { get; set; }

        private List<TodoDTO> tasks = new List<TodoDTO>();
        private List<TodoDTO> selectedTasks = new List<TodoDTO>();
        private TodoDTO newTask = new TodoDTO();
        private int pageNumber = 0;
        private int pageSize = 10;
        private bool IsFirstPage => pageNumber == 0;
        private bool IsLastPage => tasks.Count < pageSize;

        protected override async Task OnInitializedAsync()
        {
            tasks = (await TodoRepository.Get(pageNumber)).ToList();
        }

        private void ChangeSelection(TodoDTO task, ChangeEventArgs e)
        {
            if ((bool)e.Value)
            {
                selectedTasks.Add(task);
            }
            else
            {
                selectedTasks.Remove(task);
            }
        }

        private async Task DeleteSelectedTasks()
        {
            TodoDTO task = new TodoDTO();
            TodoRepository.Delete(task);
            tasks.Remove(task);

            selectedTasks.Clear();

            StateHasChanged();
        }

        private async Task AddTask()
        {
            TodoRepository.Insert(newTask);
            tasks.Add(newTask);
            newTask = new TodoDTO();
        }

        private async Task NavigateToNextPage()
        {
            pageNumber++;
            tasks = (await TodoRepository.Get(pageNumber)).ToList();
        }

        private async Task NavigateToPreviousPage()
        {
            if (pageNumber > 0)
            {
                pageNumber--;
                tasks = (await TodoRepository.Get(pageNumber)).ToList();
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
    }
}
