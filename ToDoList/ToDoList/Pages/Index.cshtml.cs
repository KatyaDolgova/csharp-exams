using ToDoList.Models;
using ToDoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public IndexModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public List<ToDoItem> Tasks { get; set; } = new List<ToDoItem>();

        [BindProperty]
        public string? NewTask { get; set; }

        [BindProperty]
        public int EditTaskId { get; set; }


        [BindProperty]
        public string? EditTaskName { get; set; }


        public void OnGet()
        {
            Tasks = _toDoService.GetTasks();
        }

        public IActionResult OnPostAddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTask))
            {
                _toDoService.AddTask(NewTask);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostCompleteTask(int taskId)
        {
            _toDoService.MarkCompleted(taskId);
            return RedirectToPage();
        }

        public IActionResult OnPostUnmarkCompleteTask(int taskId)
        {
            _toDoService.UnmarkCompleted(taskId);
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteTask(int taskId)
        {
            _toDoService.DeleteTask(taskId);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateTask()
        {
            _toDoService.UpdateTask(EditTaskId, EditTaskName);

            return RedirectToPage();
        }
    }
}

