using BCVP.NET8.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.NET8.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public async Task<List<TEntity>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\":1 ,\"Name\":\"basebase\"}]";
            return JsonConvert.DeserializeObject<List<TEntity>>(data) ?? new List<TEntity>();
        }
    }
}
