using DotNetTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTask.Core.Interfaces
{
    public interface ITaskRepository:IBaseRepository<Task>
    {
        IEnumerable<Task> GetAllTasks();
    }
}
