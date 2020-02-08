using FileEditorApp.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FileEditorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        public BaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}
