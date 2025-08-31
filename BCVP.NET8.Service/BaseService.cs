using AutoMapper;
using BCVP.NET8.IService;
using BCVP.NET8.Model;
using BCVP.NET8.Repository;
using BCVP.NET8.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.NET8.Service
{
    public class BaseService<TEntity,TVo> : IBaseService<TEntity,TVo> where TEntity : class,new()
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IMapper mapper,IBaseRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<TVo>> Query()
        {
            var entities = await _repository.Query();
            var llot = _mapper.Map<List<TVo>>(entities);
            return llot;
        }
    }
}
