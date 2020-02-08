using FileEditorApp.Shared.Commands.Files;
using FileEditorApp.Shared.DTO;
using FileEditorApp.Shared.Events;
using FileEditorApp.Shared.Extrensions;
using FileEditorApp.Shared.Queries.Files;
using System.Collections.Generic;
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

        private IEnumerable<FileDto> Files { get; set; }

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

        protected override async Task OnInitializedAsync()
        {
            if((await RestService.Execute<UserFilesQueryResult>(HttpMethod.Get, "files", 
                null, FileEditorAppContext.LoggedUser.JwtToken)) is UserFilesQueryResult result)
            {
                Files = result.Files;
            }
        }
    }
}
