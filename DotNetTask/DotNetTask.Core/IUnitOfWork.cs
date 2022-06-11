using DotNetTask.Core.Interfaces;
using DotNetTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTask.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Member> Members { get; }
        IBaseRepository<Task> Tasks { get; }
        ITaskRepository TaskRepository { get; }

        int Complete();
    }
}
