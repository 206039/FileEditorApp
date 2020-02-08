using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using FileEditorApp.Shared.Queries;
using FileEditorApp.Shared.Queries.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Controllers
{
    public class FilesController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public FilesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFileAsync([FromBody]CreateFileCommand command)
        {
            command.UserId = UserId;
            await CommandDispatcher.DispatchAsync(command);
            return StatusCode(201);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _queryDispatcher
                .DispatchAsync(new UserFilesQuery { UserId = UserId });
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileAsync(int id)
        {
            var response = await _queryDispatcher.DispatchAsync(new SingleFileQuery { Id = id, UserId = UserId });
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateFileAsync([FromBody]UpdateFileCommand command)
        {
            command.UserId = UserId;
            await CommandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await CommandDispatcher.DispatchAsync(new DeleteCommand { Id = id, UserId= UserId });
            return Ok();
        }

        [HttpGet("download/{id}/{token}")]
        public async Task<IActionResult> DownloadAsync(int id, string token)
        {
            var result = await _queryDispatcher.DispatchAsync(new DownloadFileQuery { Id = id, Token=token });
            if(result is DownloadFileQueryResult download)
            {
                
                return File(download.FileStream, "application/octet-stream", download.Filename);
            }
            throw new InvalidCastException();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> PostFileAsync()
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                var file = HttpContext.Request.Form.Files[0];
                var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                await CommandDispatcher.DispatchAsync(new UploadFileCommand { Filename = file.FileName, MemoryStream = memoryStream, UserId = UserId });
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }

        private int UserId => int.Parse(User.Claims.ElementAt(0).Value);
    }
}
