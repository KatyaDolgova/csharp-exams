using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IToDoService
    {
        List<ToDoItem> GetTasks();
        void AddTask(string taskName);
        void MarkCompleted(int taskId);
        void UnmarkCompleted(int taskId);
        void DeleteTask(int taskId);
        void UpdateTask(int taskId, string newTaskName);
    }
}
