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
    public class StreamerController : Controller
    {
        StreamerListRepository _service;

        public StreamerController()
        {
            _service = new StreamerListRepository();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TwitchStream.Entities.StreamerList Get(int id)
        {
            return _service.Get(id);
        }

        [HttpGet("{channel}")]
        public TwitchStream.Entities.StreamerList Get(string channel)
        {
            return _service.Get(channel);
        }

        [HttpGet]
        [Route("All")]
        public IEnumerable<StreamerList> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{userId}")]
        [Route("Subs")]
        public IEnumerable<StreamerList> GetSubscriptions(int userId)
        {
            return _service.GetSubscriptions(userId);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TwitchStream.Entities.StreamerList streamer)
        {
            _service.Insert(streamer);
        }
    }
}
