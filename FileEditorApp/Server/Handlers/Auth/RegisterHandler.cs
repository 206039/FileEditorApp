﻿using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Auth
{
    public class RegisterHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUserService _userService;
        public RegisterHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(RegisterCommand command)
        {
            
        }
    }
}
