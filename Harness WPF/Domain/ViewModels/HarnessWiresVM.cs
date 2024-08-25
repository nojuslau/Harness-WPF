using Harness_WPF.Services;

namespace Harness_WPF.Domain.ViewModels;

public class HarnessWiresVM
{
    private readonly IService _service;

    public HarnessWiresVM(IService service)
    {
        _service = service;
    }

    public void ExecuteCommand()
    { 
    }
}
