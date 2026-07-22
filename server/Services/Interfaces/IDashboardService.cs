using server.DTOs.Dashboard;

namespace server.Interfaces;

public interface IDashboardService
{
    Task<DashboardResponseDto> GetDashboardAsync();
}