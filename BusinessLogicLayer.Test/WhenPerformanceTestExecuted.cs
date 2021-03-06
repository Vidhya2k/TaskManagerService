﻿using DataAccessLayer;
using NBench;

namespace BusinessLogicLayer.Test
{
    public class WhenPerformanceTestExecuted
    {
        private Counter _parseThroughput;
        private string ParseThroughputCounterName = "Test";
        private ITaskManager _taskManager;
        private ITaskDataAccess _taskDataAccess;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _parseThroughput = context.GetCounter(ParseThroughputCounterName);
            _taskDataAccess = new TaskDataAccess();
            _taskManager = new TaskManager(_taskDataAccess);
        }

        [PerfBenchmark(NumberOfIterations = 10, RunMode = RunMode.Throughput,
       TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllTasksFor10Iterations(BenchmarkContext context)
        {
            _taskManager.GetAllTasks();
            _parseThroughput.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput,
      TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllTasksFor100Iterations(BenchmarkContext context)
        {
            _taskManager.GetAllTasks();
            _parseThroughput.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput,
      TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllTasksFor500Iterations(BenchmarkContext context)
        {
            _taskManager.GetAllTasks();
            _parseThroughput.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            _taskDataAccess = null;
            _taskManager = null;
            _parseThroughput = null;
        }
    }
}
