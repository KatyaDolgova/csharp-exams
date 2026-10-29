using ToDoList.Models;

namespace ToDoList.Services
{
    public class ToDoService : IToDoService
    {
        private readonly List<ToDoItem> _tasks = new();
        private readonly object _lock = new();
        private int _nextId = 1;

        public List<ToDoItem> GetTasks()
        {
            // Копия, а не живая ссылка: Singleton-сервис используется из разных запросов
            // одновременно, и enumerating оригинального списка во время его изменения
            // другим запросом мог бы бросить InvalidOperationException.
            lock (_lock)
            {
                return new List<ToDoItem>(_tasks);
            }
        }

        public void AddTask(string taskName)
        {
            lock (_lock)
            {
                _tasks.Add(new ToDoItem { Id = _nextId++, Name = taskName, IsCompleted = false });
            }
        }

        public void MarkCompleted(int taskId)
        {
            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.IsCompleted = true;
                }
            }
        }

        public void UnmarkCompleted(int taskId)
        {
            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.IsCompleted = false;
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            lock (_lock)
            {
                _tasks.RemoveAll(t => t.Id == taskId);
            }
        }

        public void UpdateTask(int taskId, string newTaskName)
        {
            if (string.IsNullOrWhiteSpace(newTaskName))
            {
                return;
            }

            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.Name = newTaskName;
                }
            }
        }
    }
}
