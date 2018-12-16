using System.Collections.Generic;
using DataAccessLayer;
using Entities;
using System.Linq;

namespace BusinessLogicLayer
{
    public class TaskManager : ITaskManager
    {
        private readonly ITaskDataAccess _taskDataAccess = new TaskDataAccess();

        public TaskManager()
        {
            
        }
        public TaskManager(ITaskDataAccess taskDataAccess)
        {
            _taskDataAccess = taskDataAccess;
        }
        public IQueryable<ITask> GetAllTasks()
        {
            return _taskDataAccess.GetAllTasks();
        }

        public ITask GetTaskById(int id)
        {
            return _taskDataAccess.GetTaskById(id);
        }

        public void UpdateTask(int id, ITask task)
        {
            _taskDataAccess.UpdateTask(id, task);
        }

        public void AddTask(ITask task)
        {
            _taskDataAccess.AddTask( task);
        }

        public void DeleteTask(ITask task)
        {
            _taskDataAccess.DeleteTask(task);
        }
    }
}
