using FileEditorApp.Shared.Commands.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }

        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCommand loginCommand)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
