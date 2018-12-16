using System.Collections.Generic;
using System.Linq;
using Entities;

namespace BusinessLogicLayer
{
    public interface ITaskManager
    {
        IQueryable<ITask> GetAllTasks();
        ITask GetTaskById(int id);
        void UpdateTask(int id, ITask task);
        void AddTask(ITask task);
        void DeleteTask(ITask task);
    }
}