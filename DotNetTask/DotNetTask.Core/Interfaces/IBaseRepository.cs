using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTask.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
    }
}
