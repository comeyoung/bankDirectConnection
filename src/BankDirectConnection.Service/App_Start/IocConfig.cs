using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BankDirectConnection.Service.App_Start
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/19 11:19:22
	===============================================================================================================================*/

    public class IocConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            ////注册模块的应用服务
            //builder.RegisterAssemblyTypes(Assembly.Load("IntegratedManageMent.Application"))
            //        .Where(t => t.Name.EndsWith("App"))
            //        .AsImplementedInterfaces()//表示注册的类型，以接口的方式注册
            //        .InstancePerLifetimeScope();//在一个生命周期中，每一个依赖或调用公用一个实例
            ////注册模块的仓储
            //builder.RegisterAssemblyTypes(Assembly.Load("IntegratedManagement.RepositoryDapper"))
            //         .Where(t => t.Name.EndsWith("DapperRepository"))
            //         .AsImplementedInterfaces()
            //         .InstancePerLifetimeScope();

            //builder.RegisterWebApiFilterProvider(config);
            ////autofac 注册依赖
            //IContainer container = builder.Build();

            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}