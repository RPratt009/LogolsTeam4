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
    public class SubscriptionController : Controller
    {

        UserSubscriptionsRepository userSubscriptionsRepository;

        public SubscriptionController()
        {
            userSubscriptionsRepository = new UserSubscriptionsRepository();
        }

        [HttpGet("{streamerId}")]
        public int Insert(int streamerId)
        {
            return userSubscriptionsRepository.Insert(streamerId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userSubscriptionsRepository.Delete(id);
        }
    }
}
