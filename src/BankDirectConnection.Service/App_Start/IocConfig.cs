using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BankDirectConnection.Service.App_Start
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/19 11:19:22
	===============================================================================================================================*/

    public class IocConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //注册模块的应用服务
            builder.RegisterAssemblyTypes(Assembly.Load("BankDirectConnection.PushBankment"))
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()//表示注册的类型，以接口的方式注册
                    .InstancePerLifetimeScope();//在一个生命周期中，每一个依赖或调用公用一个实例
            

            builder.RegisterWebApiFilterProvider(config);
            //autofac 注册依赖
            IContainer container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}