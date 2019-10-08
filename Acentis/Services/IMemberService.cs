using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Services
{
    public interface IMemberService : IService<Member>
    {
        Member Authenticate(string email, string password);
    }
}

