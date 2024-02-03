using System.Threading.Tasks;

namespace OpenCiv1UI.Core.Services.Contracts;

public interface IDialogService
{
    Task ShowAsync(string message, string title = "");
    
    bool IsDialogOpen { get; }
}