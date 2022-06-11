using DotNetTask.Core;
using DotNetTask.Core.Interfaces;
using DotNetTask.Core.Models;
using DotNetTask.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTask.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Member> Members { get; private set; }
        public IBaseRepository<Task> Tasks { get; private set; }
        public ITaskRepository TaskRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Members = new BaseRepository<Member>(_context);
            Tasks = new BaseRepository<Task>(_context);
            TaskRepository =new TaskRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}