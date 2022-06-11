using System;
using System.Collections.Generic;
using System.Linq;
using DotNetTask.Core;
using DotNetTask.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //[Route("api/Task/GetAllTasks")]
        [HttpGet("GetAllTasks")]
        public IEnumerable<Task> GetAll()
        {
            return _unitOfWork.TaskRepository.GetAllTasks().OrderByDescending(a => a.TaskId);
        }
        //[Route("api/Task/AddTask")]
        [HttpPost]
        public JsonResult Post(Task task)
        {
            _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.Complete();
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public IEnumerable<Task> Put(Task task)
        {
            _unitOfWork.TaskRepository.Update(task);
            _unitOfWork.Complete();
            return _unitOfWork.TaskRepository.GetAllTasks().OrderByDescending(a => a.TaskId);
        }
    }
}