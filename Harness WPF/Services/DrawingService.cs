namespace Harness_WPF.Services;

public class DrawingService : IService
{
    public List<HarnessDrawing> GetData<HarnessDrawing>()
    {
        //var _harnessDrawings = await _repository.GetAllAsync();
        return new List<HarnessDrawing>();
    }
}

