using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchStream.Entities
{
    public class UserSubscriptions
    {
    public int SubscriptionId { get;set;}
    public int UserLoginId { get;set;}
    public int StreamerId { get;set;}
    public int SendEmail { get;set;}
    public int Position { get;set;}
    }
}
