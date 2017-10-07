using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitchStream.Entities;
using TwitchStream.Dal;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserLoginRepository _service;

        public UserController()
        {
            _service = new UserLoginRepository();
        }

        // GET api/values
        [HttpGet("{username,password}")]
        public TwitchStream.Entities.UserLogin Get(string username,string password)
        {
            return _service.Get(username,password);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TwitchStream.Entities.UserLogin Get(int id)
        {
            return _service.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TwitchStream.Entities.UserLogin userLogin)
        {
            _service.Insert(userLogin);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]TwitchStream.Entities.UserLogin userLogin)
        {
            _service.Update(userLogin);
        }
    }
}
