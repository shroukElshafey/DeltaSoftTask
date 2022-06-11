using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTask.Core;
using DotNetTask.Core.Interfaces;
using DotNetTask.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public IEnumerable<Member> GetAll()
        {
            return _unitOfWork.Members.GetAll();
        }
      
    }
}