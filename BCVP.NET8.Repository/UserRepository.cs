using BCVP.NET8.Model;
using Newtonsoft.Json;

namespace BCVP.NET8.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\":1 ,\"Name\":\"laozahng\"}]";
            return JsonConvert.DeserializeObject<List<User>>(data) ?? new List<User>(); 
        }
    }
}
