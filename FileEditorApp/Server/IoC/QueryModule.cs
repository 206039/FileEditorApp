using Autofac;
using FileEditorApp.Shared.Queries;
using System.Reflection;

namespace FileEditorApp.Server.IoC
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(QueryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IQueryHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
