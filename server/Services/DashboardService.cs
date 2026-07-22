using server.DTOs.Dashboard;
using server.Interfaces;

namespace server.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _repository;

    public DashboardService(IDashboardRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardResponseDto> GetDashboardAsync()
    {
        return await _repository.GetDashboardAsync();
    }
}