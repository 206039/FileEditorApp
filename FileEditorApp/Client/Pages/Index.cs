using FileEditorApp.Shared.Commands.Auth;
using FileEditorApp.Shared.Events;
using FileEditorApp.Shared.Events.Auth;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileEditorApp.Client.Pages
{
    public partial class Index
    {
        public LoginCommand LoginCommand = new LoginCommand { Username = "", Password = "" };
        private string Error { get; set; }

        public async Task Login(MouseEventArgs eventArgs)
        {
            Error = "";
            var @event = await RestService.Execute<UserLoggedInEvent>(HttpMethod.Post, "auth/login", LoginCommand);
            if (@event is UserLoggedInEvent userLoggedInEvent)
            {
                FileEditorAppContext.LoggedUser = userLoggedInEvent;
                NavigationManager.NavigateTo("/session");
            }
            else if (@event is UnauthorizedEvent unauthorized)
            {
                Error = "Niepoprawne dane logowania.";
            }
        }
    }
}
