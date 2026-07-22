using server.DTOs.Dashboard;

namespace server.Interfaces;

public interface IDashboardRepository
{
    Task<DashboardResponseDto> GetDashboardAsync();
}