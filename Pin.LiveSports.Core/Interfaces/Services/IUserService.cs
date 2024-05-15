using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Interfaces.Services
{
    public interface IUserService
    {
        string UserType { get; set; }
        void Login(string userType);
    }
}
