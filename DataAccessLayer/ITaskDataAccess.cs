using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DataAccessLayer
{
    public interface ITaskDataAccess
    {
        void AddTask(ITask task);
        void DeleteTask(ITask task);
        IQueryable<ITask> GetAllTasks();
        ITask GetTaskById(int id);
        void UpdateTask(int id, ITask task);
    }
}