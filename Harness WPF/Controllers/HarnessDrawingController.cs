using Harness_WPF.Domain.Entities;
using Harness_WPF.Repositories;

namespace Harness_WPF.Controllers;
class HarnessDrawingController
{
    private Repository _repository;
    public HarnessDrawingController(Repository repository)
    {
        _repository = repository;
    }

    public async Task<List<HarnessDrawing>> GetAllAsync()
    {
        List<HarnessDrawing> harnessDrawing = new List<HarnessDrawing>();
        try
        {
            //harnessDrawing = await _repository.GetAllAsync<HarnessDrawing>();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while loading data: {ex.Message}");
        }

        return harnessDrawing;
    }
}
