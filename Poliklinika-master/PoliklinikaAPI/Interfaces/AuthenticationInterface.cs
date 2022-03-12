using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoliklinikaAPI.ViewModels;

namespace PoliklinikaAPI.Interfaces
{
    public interface AuthenticationInterface
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
    }
}