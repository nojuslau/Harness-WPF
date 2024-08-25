using Harness_WPF.Domain.Entities;
using Harness_WPF.Services;

namespace Harness_WPF.Domain.ViewModels;

public class HarnessWiresVM
{
    private readonly IService<HarnessWires> _service;

    public HarnessWiresVM(IService<HarnessWires> service)
    {
        _service = service;
    }

    public void ExecuteCommand()
    { 
    }
}
