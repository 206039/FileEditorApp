using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileEditorApp.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
