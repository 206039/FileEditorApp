using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileEditorApp.Shared.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
