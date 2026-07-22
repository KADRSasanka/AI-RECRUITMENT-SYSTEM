namespace server.Services.Interfaces;

public interface IBaseService<TResponse, TCreate, TUpdate>
{
    Task<IEnumerable<TResponse>> GetAllAsync();

    Task<TResponse?> GetByIdAsync(int id);

    Task<TResponse> CreateAsync(TCreate request);

    Task<bool> UpdateAsync(int id, TUpdate request);

    Task<bool> DeleteAsync(int id);
}