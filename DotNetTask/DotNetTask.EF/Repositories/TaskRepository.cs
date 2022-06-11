using DotNetTask.Core.Interfaces;
using DotNetTask.Core.Models;
using DotNetTask.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTask.EF.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks.Include("Member");
        }
    }
}
