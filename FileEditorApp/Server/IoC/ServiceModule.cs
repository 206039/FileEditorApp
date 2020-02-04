using Autofac;
using FileEditorApp.Server.Services;
using System.Reflection;

namespace FileEditorApp.Server.IoC
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where(x=>x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
