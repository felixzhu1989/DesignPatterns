using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyServer
{
   public interface IUserRepository
    {
        void Add(User user);

        void Delete(int id);

        void Update(User user);

        User Get(int id);
    }
}
