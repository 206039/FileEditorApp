using FileEditorApp.Shared.Commands.Files;
using FileEditorApp.Shared.Events;
using FileEditorApp.Shared.Extrensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileEditorApp.Client.Pages
{
    public partial class Session
    {
        private CreateFileCommand CreateFileCommand = new CreateFileCommand
        {
            Filename = ""
        };

        private void Logout()
        {
            FileEditorAppContext.LoggedUser = null;
            NavigationManager.NavigateTo("/");
        }

        private async Task CreateFile()
        {
            if (CreateFileCommand.Filename.IsNullOrEmpty())
            {
                return;
            }
            var @event = await RestService.Execute<SuccessEvent>(HttpMethod.Post,
                "files", CreateFileCommand, FileEditorAppContext.LoggedUser.JwtToken);
            if(@event is SuccessEvent)
            {
            }
        }
    }
}
