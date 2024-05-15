using Pin.LiveSports.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Services
{
    public class UserService : IUserService
    {
        public string UserType { get; set; }

        public void Login(string userType)
        {
            UserType = userType;
        }
    }
}
