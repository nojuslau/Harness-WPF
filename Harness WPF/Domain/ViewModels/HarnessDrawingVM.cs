using Harness_WPF.Services;

namespace Harness_WPF.Domain.ViewModels;
public class HarnessDrawingVM
{
    private readonly IService _service;

    public HarnessDrawingVM(IService service)
    {
        _service = service;
    }

    public void ExecuteCommand()
    {
    }
}
