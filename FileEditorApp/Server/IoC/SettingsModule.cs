using Autofac;
using FileEditorApp.Server.Extensions;
using FileEditorApp.Server.Settings;
using Microsoft.Extensions.Configuration;

namespace FileEditorApp.Server.IoC
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                    .SingleInstance();
        }
    }
}
