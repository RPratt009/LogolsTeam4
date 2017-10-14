using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchStream.Entities
{
    public class UserLogin
    {
    public int? ID { get;set;}
    public string UserName { get;set;}
    public string Pass { get; set; }
    public string Email { get;set;}
    public int LayoutSelected { get;set;}
    }
}
