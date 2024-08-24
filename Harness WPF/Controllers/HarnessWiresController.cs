using Harness_WPF.Domain.Entities;
using Harness_WPF.Repositories;

namespace Harness_WPF.Controllers;

class HarnessWiresController
{
    private Repository _repository;
    public HarnessWiresController(Repository repository)
    {
        _repository = repository;
    }

    public async Task<List<HarnessWires>> GetAllAsync()
    {
        List<HarnessWires> harnessWires = new List<HarnessWires>();
        try
        {
            //harnessWires = await _repository.GetAllAsync<HarnessWires>();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while loading data: {ex.Message}");
        }

        return harnessWires;
    }
}

