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
    [Route("api/{controller}")]
    public class SubscriptionController : Controller
    {

        UserSubscriptionsRepository userSubscriptionsRepository;

        public SubscriptionController()
        {
            userSubscriptionsRepository = new UserSubscriptionsRepository();
        }

        [HttpPost]
        public int Insert([FromBody]UserSubscriptions userSubscription)
        {
            return userSubscriptionsRepository.Insert(userSubscription);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userSubscriptionsRepository.Delete(id);
        }

        [HttpPost]
        public void Update([FromBody]UserSubscriptions userSubscription)
        {
            userSubscriptionsRepository.Update(userSubscription);
        }
    }
}
