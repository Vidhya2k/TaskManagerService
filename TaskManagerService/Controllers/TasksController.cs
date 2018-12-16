using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using BusinessLogicLayer;

namespace TaskManagerService.Controllers
{
    [KnownType(typeof(Task))]
    public class TasksController : ApiController
    {
        private readonly TaskManager _taskManager = new TaskManager();

        // GET: api/Tasks
        public IEnumerable<ITask> GetTasks()
        {
            return _taskManager.GetAllTasks().ToList();
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            var task = _taskManager.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Task_ID)
            {
                return BadRequest();
            }

            try
            {
                _taskManager.UpdateTask(id, task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _taskManager.AddTask(task);

            return CreatedAtRoute("DefaultApi", new { id = task.Task_ID }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            var task = _taskManager.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            _taskManager.DeleteTask(task);
            return Ok(task);
        }
        
        private bool TaskExists(int id)
        {
            return _taskManager.GetTaskById(id) != null;
        }
    }
}