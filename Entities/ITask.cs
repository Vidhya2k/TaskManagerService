using System;

namespace Entities
{
    public interface ITask
    {
        DateTime End_Date { get; set; }
        int? Parent_ID { get; set; }
        int Priority { get; set; }
        DateTime Start_Date { get; set; }
        string Task_Description { get; set; }
        int Task_ID { get; set; }
    }
}