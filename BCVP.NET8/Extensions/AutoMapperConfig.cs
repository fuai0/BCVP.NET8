using AutoMapper;

namespace BCVP.NET8.Extensions
{
    /// <summary>
    /// 静态全局AutoMapper配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomProfile());
            });
        }
    }
}
