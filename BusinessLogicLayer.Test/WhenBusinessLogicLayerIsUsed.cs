using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Entities;
using Moq;
using NUnit.Framework;

namespace BusinessLogicLayer.Test
{
    [TestFixture]
    public class WhenBusinessLogicLayerIsUsed
    {
        private ITaskManager _taskManager;
        private Mock<ITaskDataAccess> _mockTaskDataAccess;

        [SetUp]
        public void Setup()
        {
            _mockTaskDataAccess = new Mock<ITaskDataAccess>();
            _taskManager = new TaskManager(_mockTaskDataAccess.Object);
        }

        [Test]
        public void ThatGetAllTasksIsInvoked()
        {
            // Arrange
            var mockTask1 = new Mock<Task>();
            var mockTask2 = new Mock<Task>();
            var tasks = new[] {mockTask1.Object, mockTask2.Object};
            _mockTaskDataAccess.Setup(x => x.GetAllTasks()).Returns(tasks.AsQueryable());

            // Act
            var result = _taskManager.GetAllTasks();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(tasks.Length));
        }

        [Test]
        public void ThatGetTaskByIdIsInvokedForGivenId()
        {
            var mockTask1 = new Mock<ITask>();
            _mockTaskDataAccess.Setup(x => x.GetTaskById(1)).Returns(mockTask1.Object);

            var result = _taskManager.GetTaskById(1);

            Assert.That(result, Is.EqualTo(mockTask1.Object));
        }

        [Test]
        public void ThatAddTaskInsertsNewRecord()
        {
            var mockTask = new Mock<ITask>();
            var taskId = 100;
            mockTask.SetupGet(x => x.Task_ID).Returns(taskId);
            _mockTaskDataAccess.Setup(x => x.AddTask(mockTask.Object));

            _taskManager.AddTask(mockTask.Object);

            _mockTaskDataAccess.Verify(x => x.AddTask(mockTask.Object), Times.Once());
        }

        [Test]
        public void ThatDeleteTaskDeletesOneRecord()
        {
            var mockTask = new Mock<ITask>();
            var taskId = 100;
            mockTask.SetupGet(x => x.Task_ID).Returns(taskId);
            _mockTaskDataAccess.Setup(x => x.DeleteTask(mockTask.Object));

            _taskManager.DeleteTask(mockTask.Object);

            _mockTaskDataAccess.Verify(x => x.DeleteTask(mockTask.Object), Times.Once());
        }


        [Test]
        public void ThatUpdateTaskUpdatesOneRecord()
        {
            var mockTask = new Mock<ITask>();
            var taskId = 100;
            mockTask.SetupGet(x => x.Task_ID).Returns(taskId);
            _mockTaskDataAccess.Setup(x => x.UpdateTask(taskId, mockTask.Object));

            _taskManager.UpdateTask(taskId, mockTask.Object);

            _mockTaskDataAccess.Verify(x => x.UpdateTask(taskId, mockTask.Object), Times.Once());
        }

    }
}
