﻿using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using FileEditorApp.Shared.Queries;
using FileEditorApp.Shared.Queries.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var response = await _queryDispatcher.DispatchAsync(new SingleFileQuery { Id = id });
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateFileAsync([FromBody]UpdateFileCommand command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await CommandDispatcher.DispatchAsync(new DeleteCommand { Id = id });
            return Ok();
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadAsync(int id)
        {
            var result = await _queryDispatcher.DispatchAsync(new DownloadFileQuery { Id = id });
            if(result is DownloadFileQueryResult download)
            {
                
                return File(download.FileStream, "application/octet-stream", download.Filename);
            }
            throw new InvalidCastException();
        }

        private int UserId => int.Parse(User.Claims.ElementAt(0).Value);
    }
}
