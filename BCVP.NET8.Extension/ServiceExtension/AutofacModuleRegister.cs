using Autofac;
using Autofac.Extras.DynamicProxy;
using BCVP.NET8.IService;
using BCVP.NET8.Repository.Base;
using BCVP.NET8.Service;
using System.Reflection;

namespace BCVP.NET8.Extension.ServiceExtension
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "BCVP.NET8.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "BCVP.NET8.Repository.dll");

            var aopTypes = new List<Type>() { typeof(ServiceAOP) };
            builder.RegisterType<ServiceAOP>();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(aopTypes.ToArray());

            // 获取Service.dll程序集服务,并注册
            var assemblyService = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblyService)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired()
                .EnableInterfaceInterceptors()
                .InterceptedBy(aopTypes.ToArray());

            // 获取Repository.dll程序集服务,并注册
            var assemblyRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblyRepository)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired();
        }

    }
}
