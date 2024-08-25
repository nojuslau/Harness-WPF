using Harness_WPF.Domain.Entities;
using Harness_WPF.Services;

namespace Harness_WPF.Domain.ViewModels;
public class HarnessDrawingVM
{
    private readonly IService<HarnessDrawing> _service;

    public HarnessDrawingVM(IService<HarnessDrawing> service)
    {
        _service = service;
    }

    public void ExecuteCommand()
    {
    }
}
