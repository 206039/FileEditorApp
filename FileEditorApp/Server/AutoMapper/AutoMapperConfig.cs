using AutoMapper;
using FileEditorApp.Shared.Domain;
using FileEditorApp.Shared.DTO;

namespace FileEditorApp.Server.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DatabaseFile, FileDto>();
        })
        .CreateMapper();
    }
}
