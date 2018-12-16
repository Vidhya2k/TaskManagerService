using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class TaskDataAccess : IDisposable, ITaskDataAccess
    {
        private readonly TaskManagerEntities _taskContext = new TaskManagerEntities();

        public IQueryable<ITask> GetAllTasks()
        {
            return _taskContext.Tasks;
        }

        public ITask GetTaskById(int id)
        {
            return _taskContext.Tasks.Find(id);
        }

        public void UpdateTask(int id, ITask task)
        {
            _taskContext.Entry(task).State = EntityState.Modified;
            _taskContext.SaveChanges();
        }

        public void AddTask(ITask task)
        {
            _taskContext.Tasks.Add((Task)task);
            _taskContext.SaveChanges();
        }

        public void DeleteTask(ITask task)
        {
            _taskContext.Tasks.Remove((Task)task);
            _taskContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_taskContext != null)
                {
                    _taskContext.Dispose();
                }
            }
        }
    }
}
