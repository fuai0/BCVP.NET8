using BCVP.NET8.IService;
using BCVP.NET8.Model;
using BCVP.NET8.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.NET8.Service
{
    public class UserService : IUserService
    {
        public async Task<List<UserVo>> Query()
        {
            var userRepo = new UserRepository();
            var users = await userRepo.Query();
            return users.Select(d => new UserVo { UserName = d.Name}).ToList();
        }
    }
}
