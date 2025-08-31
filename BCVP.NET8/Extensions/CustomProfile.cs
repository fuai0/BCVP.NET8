using AutoMapper;
using BCVP.NET8.Model;

namespace BCVP.NET8.Extensions
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 构造函数创建映射关系
        /// </summary>
        public CustomProfile()
        {
            CreateMap<Role, RoleVo>()
                .ForMember(a => a.RoleName, o => o.MapFrom(d => d.Name));
            CreateMap<RoleVo, Role>()
                .ForMember(a => a.Name, o => o.MapFrom(d => d.RoleName));
        }
    }
}
